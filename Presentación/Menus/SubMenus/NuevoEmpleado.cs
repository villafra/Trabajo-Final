using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Automate_Layer;
using Business_Entities;
using Service_Layer;
using Business_Logic_Layer;

namespace Trabajo_Final
{
    public partial class frmNuevoEmpleado : Form
    {

        public BE_Empleado oBE_Empleado;
        BLL_Empleado oBLL_Empleado;
        private bool status;
        public frmNuevoEmpleado()
        {
            InitializeComponent();
            Aspecto.FormatearSubMenu(this, grpNuevoLogin, this.Width, this.Height);
            Cálculos.DataSourceCombo(comboCategoria, Enum.GetNames(typeof(Category)), "Categoría");
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Cálculos.Camposvacios(grpNuevoLogin))
                {
                    if (Validaciones())
                    {
                        if (_ = oBE_Empleado != null ? Viejo() : Nuevo())
                        {
                            Cálculos.MsgBox("Los datos se han guardado correctamente");
                        }
                        else { throw new RestaurantException("La creación del nuevo empleado ha fallado. Por favor, intente nuevamente"); }
                    }
                }
                else { throw new RestaurantException("Por favor, complete los campos obligatorios"); }
                
            }
            catch (Exception ex) { Cálculos.MsgBox(ex.Message); }
        }

        private bool Viejo()
        {
            Category categoria = (Category)Enum.Parse(typeof(Category), comboCategoria.SelectedItem.ToString());
            if ((int)categoria == 1)
            {
                oBE_Empleado = new BE_GerenteSucursal();
                ((BE_GerenteSucursal)oBE_Empleado).Contacto = txtContacto.Text;
                oBLL_Empleado = new BLL_Gerente_Sucursal();
            }
            else if ((int)categoria > 1 && (int)categoria < 6)
            {
                oBE_Empleado = new BE_ChefPrincipal();
                oBLL_Empleado = new BLL_Chef_Principal();
            }
            else
            {
                oBE_Empleado = new BE_Mozo();
                oBLL_Empleado = new BLL_Mozo();
            }
            oBE_Empleado.Codigo = Convert.ToInt32(txtCodigo.Text);
            oBE_Empleado.DNI = Convert.ToInt64(txtDNI.Text);
            oBE_Empleado.Nombre = txtNombre.Text;
            oBE_Empleado.Apellido = txtApellido.Text;
            oBE_Empleado.FechaNacimiento = dtpFechaNac.Value;
            oBE_Empleado.FechaIngreso = dtpFechaIng.Value;
            oBE_Empleado.Categoria = (Category)Enum.Parse(typeof(Category), comboCategoria.SelectedItem.ToString());
            oBE_Empleado.Activo = status;
            return oBLL_Empleado.Modificar(oBE_Empleado);
        }

        private bool Nuevo()
        {
            Category categoria = (Category)Enum.Parse(typeof(Category), comboCategoria.SelectedItem.ToString());
            if ((int)categoria == 1)
            {
                oBE_Empleado = new BE_GerenteSucursal();
                ((BE_GerenteSucursal)oBE_Empleado).Contacto = txtContacto.Text;
                oBLL_Empleado = new BLL_Gerente_Sucursal();
            }
            else if ((int)categoria > 1 && (int)categoria < 6)
            {
                oBE_Empleado = new BE_ChefPrincipal();
                oBLL_Empleado = new BLL_Chef_Principal();
            }
            else
            {
                oBE_Empleado = new BE_Mozo();
                oBLL_Empleado = new BLL_Mozo();
            }

            oBE_Empleado.DNI = Convert.ToInt64(txtDNI.Text);
            oBE_Empleado.Nombre = txtNombre.Text;
            oBE_Empleado.Apellido = txtApellido.Text;
            oBE_Empleado.FechaNacimiento = dtpFechaNac.Value;
            oBE_Empleado.FechaIngreso = dtpFechaIng.Value;
            oBE_Empleado.Categoria = (Category)Enum.Parse(typeof(Category), comboCategoria.SelectedItem.ToString());
            
            if (oBLL_Empleado.Existe(oBE_Empleado))
            {
                return oBLL_Empleado.Guardar(oBE_Empleado);
            }
            else 
            { 
                throw new RestaurantException("El empleado que intenta agregar, ya existe en base de datos."); 
            }
        }
        private void ImportarEmpleado()
        {
            if (oBE_Empleado != null)
            {
                txtCodigo.Text = oBE_Empleado.Codigo.ToString();
                txtDNI.Text = oBE_Empleado.DNI.ToString();
                txtNombre.Text = oBE_Empleado.Nombre;
                txtApellido.Text = oBE_Empleado.Apellido;
                dtpFechaNac.Value = oBE_Empleado.FechaNacimiento;
                dtpFechaIng.Value = oBE_Empleado.FechaIngreso;
                comboCategoria.Text = oBE_Empleado.Categoria.ToString();
                if (oBE_Empleado is BE_GerenteSucursal)
                {
                    txtContacto.Text = ((BE_GerenteSucursal)oBE_Empleado).Contacto.ToString();
                }
                status = oBE_Empleado.Activo;
            }
        }

        private void frmNuevoLogin_Load(object sender, EventArgs e)
        {
            ImportarEmpleado();
        }

        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            Cálculos.ValidarEntero(e);
        }

        private void txtContacto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Cálculos.ValidarEntero(e);
        }
        private bool Validaciones()
        {
            bool pass = true;
            if(!Cálculos.LargoDNI(txtDNI.Text)) { pass = false; throw new RestaurantException("El campo DNI no tiene el formato correcto"); }
            if (!Cálculos.ValidarNombrePersonal(txtNombre.Text)) { pass = false; throw new RestaurantException("El campo de Nombre no tiene el formato correcto"); }
            if (!Cálculos.ValidarApellido(txtApellido.Text)) { pass = false; throw new RestaurantException("El campo Apellido no tiene el formato correcto"); }
            if (!Cálculos.ValidarEdad(dtpFechaNac.Value)) { pass = false; throw new RestaurantException("El empleado es menor de edad."); }
            return pass;
        }
    }
}
