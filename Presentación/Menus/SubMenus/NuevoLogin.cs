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
        public frmNuevoLogin()
        {
            InitializeComponent();
            oBLL_Login = new BLL_Login();
            oBLL_Gerente = new BLL_Gerente_Sucursal();
            Aspecto.FormatearSubMenu(this, grpNuevoLogin, this.Width, this.Height);
            Cálculos.DataSourceCombo(comboEmpleado, oBLL_Gerente.Listar(), "Empleados");
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (_ = oBE_Login != null ? Viejo() : Nuevo())
            {
                Cálculos.MsgBoxAlta("Los datos se han guardado correctamente");
            }
            else
            {
                Cálculos.MsgBoxNoAlta("Los datos no se han guardado correctamente. Por favor, intente nuevamente");
            }
        }

        private bool Viejo()
        {
            oBE_Login.Empleado = (BE_Empleado)comboEmpleado.SelectedItem;
            oBE_Login.Usuario = txtUsuario.Text;
            oBE_Login.Password = Encriptacion.EncriptarPass(txtPass.Text);
            return oBLL_Login.Modificar(oBE_Login);
        }

        private bool Nuevo()
        {
            oBE_Login = new BE_Login();
            oBE_Login.Empleado = (BE_Empleado)comboEmpleado.SelectedItem;
            oBE_Login.Usuario = txtUsuario.Text;
            oBE_Login.Password = Encriptacion.EncriptarPass(txtPass.Text);
            //oBE_Login.Permiso = (BE_Permiso)comboEmpleado.SelectedItem;
            return oBLL_Login.Guardar(oBE_Login);
        }
        private void ImportarLogin()
        {
            if (oBE_Login != null)
            {
                comboEmpleado.Text = oBE_Login.ToString();
                txtUsuario.Text = oBE_Login.Usuario;
                txtPass.Text = oBE_Login.Password;
            }
        }

        private void frmNuevoLogin_Load(object sender, EventArgs e)
        {
            ImportarLogin();
        }
    }
}
