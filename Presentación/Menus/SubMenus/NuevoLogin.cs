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
        BE_Login oBE_Login;
        BLL_Login oBLL_Login;
        public frmNuevoLogin()
        {
            InitializeComponent();
            oBLL_Login = new BLL_Login();
            Aspecto.FormatearSubMenu(this, grpNuevoLogin, this.Width, this.Height);
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            Nuevo();
            oBLL_Login.Guardar(oBE_Login);
        }

        private void Nuevo()
        {
            oBE_Login = new BE_Login();
            //oBE_Login.Empleado = (BE_Empleado)comboEmpleado.SelectedItem;
            oBE_Login.Usuario = txtUsuario.Text;
            oBE_Login.Password = Encriptacion.EncriptarPass(txtPass.Text);
            //oBE_Login.Permiso = (BE_Permiso)comboEmpleado.SelectedItem;
        }
    }
}
