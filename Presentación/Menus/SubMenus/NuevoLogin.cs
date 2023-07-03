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
    public partial class frmNuevoLogin : Form
    {
        public BE_Login oBE_Login;
        BLL_Login oBLL_Login;
        BLL_Gerente_Sucursal oBLL_Gerente;
        BLL_Permiso oBLL_Permiso;
        public frmNuevoLogin()
        {
            InitializeComponent();
            oBLL_Login = new BLL_Login();
            oBLL_Gerente = new BLL_Gerente_Sucursal();
            oBLL_Permiso = new BLL_Permiso();
            Aspecto.FormatearSubMenu(this, grpNuevoLogin, this.Width, this.Height);
            Cálculos.DataSourceCombo(comboEmpleado, oBLL_Gerente.Listar(), "Empleados");
            Cálculos.DataSourceCombo(comboPermiso, oBLL_Permiso.ListarPadre(), "Permisos");
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_ = oBE_Login != null ? Viejo() : Nuevo()) Cálculos.MsgBox("Los datos se han guardado correctamente");
                else throw new RestaurantException("La carga de datos ha fallado. Intente Nuevamente.");
                
            }catch(Exception ex) { Cálculos.MsgBox(ex.Message); }
        
        }

        private bool Viejo()
        {
           
                oBE_Login.Codigo = Convert.ToInt32(txtCodigo.Text);
                oBE_Login.Empleado = (BE_Empleado)comboEmpleado.SelectedItem;
                oBE_Login.Usuario = txtUsuario.Text;
                oBE_Login.Password = Encriptacion.EncriptarPass(txtPass.Text);
                oBE_Login.Permiso = (BE_Permiso)comboPermiso.SelectedItem;
            if (Cálculos.EstaSeguroM(oBE_Login.Usuario))
            {
                if (Cálculos.Camposvacios(grpNuevoLogin))
                {
                    return oBLL_Login.Modificar(oBE_Login);
                }
                else { throw new RestaurantException("Por favor, complete los campos obligatorios."); }
                
            }
            else { throw new RestaurantException("Se ha cancelado la modificación"); }
  
        }

        private bool Nuevo()
        {
            if (Cálculos.Camposvacios(grpNuevoLogin))
            {
                oBE_Login = new BE_Login();
                oBE_Login.Empleado = (BE_Empleado)comboEmpleado.SelectedItem;
                oBE_Login.Usuario = txtUsuario.Text;
                oBE_Login.Password = Encriptacion.EncriptarPass(txtPass.Text);
                oBE_Login.Permiso = (BE_Permiso)comboPermiso.SelectedItem;
                if (oBLL_Login.Existe(oBE_Login))
                {
                    return oBLL_Login.Guardar(oBE_Login);
                }
                else throw new RestaurantException("El Empleado ya tiene un usuario designado.");
            }
            else throw new RestaurantException("Por favor, complete los campos obligatorios.");
        }
        private void ImportarLogin()
        {
            if (oBE_Login != null)
            {
                txtCodigo.Text = oBE_Login.Codigo.ToString();
                comboEmpleado.Text = oBE_Login.ToString();
                txtUsuario.Text = oBE_Login.Usuario;
                txtPass.Text = oBE_Login.Password;
                comboPermiso.Text = oBE_Login.Permiso.ToString();
            }
        }

        private void frmNuevoLogin_Load(object sender, EventArgs e)
        {
            ImportarLogin();
        }

        private void comboEmpleado_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text.Length > 0)
            txtUsuario.Text = oBLL_Login.GenerarUsuario((BE_Empleado)comboEmpleado.SelectedItem);
        }
    }
}
