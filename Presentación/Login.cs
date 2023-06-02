using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business_Entities;
using Business_Logic_Layer;
using Automate_Layer;

namespace Trabajo_Final
{
    public partial class Login : Form
    {
        BE_Login oBE_Login = new BE_Login();
        BLL_Login oBLL_Login = new BLL_Login();
        public Login()
        {
            InitializeComponent();
 
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            oBE_Login = oBLL_Login.Login(txtUsuario.Text);

            if (oBE_Login != null)
            {
                if (oBLL_Login.CheckPass(oBE_Login, txtPass.Text))
                {
                    if (oBLL_Login.Intentos(oBE_Login))
                    {
                        frmMenu frm = new frmMenu();
                        frm.UsuarioActivo = oBE_Login;
                        frm.Show();
                        Cálculos.BorrarCampos(grpLogin);
                        this.Close();
                        
                    }
                }
            }
        }
    }
}
