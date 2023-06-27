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
            Cálculos.DataSourceCombo(comboCategoria, Enum.GetNames(typeof(BE_Empleado.Category)), "Categoría");
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (_ = oBE_Empleado != null ? Viejo() : Nuevo())
            {
                Cálculos.MsgBox("Los datos se han guardado correctamente");
            }
            else
            {
                Cálculos.MsgBox("Los datos no se han guardado correctamente. Por favor, intente nuevamente");
            }

        }

        private bool Viejo()
        {
            BE_Empleado.Category categoria = (BE_Empleado.Category)Enum.Parse(typeof(BE_Empleado.Category), comboCategoria.SelectedItem.ToString());
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
            oBE_Empleado.Categoria = (BE_Empleado.Category)Enum.Parse(typeof(BE_Empleado.Category), comboCategoria.SelectedItem.ToString());
            oBE_Empleado.Activo = status;
            return oBLL_Empleado.Modificar(oBE_Empleado);
        }

        private bool Nuevo()
        {
            BE_Empleado.Category categoria = (BE_Empleado.Category)Enum.Parse(typeof(BE_Empleado.Category), comboCategoria.SelectedItem.ToString());
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
            oBE_Empleado.Categoria = (BE_Empleado.Category)Enum.Parse(typeof(BE_Empleado.Category), comboCategoria.SelectedItem.ToString());
            return oBLL_Empleado.Guardar(oBE_Empleado);

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
    }
}
