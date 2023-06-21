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
using Service_Layer.Excepciones;
using System.Runtime.InteropServices;

namespace Trabajo_Final
{
    public partial class frmLogin : Form
    {
        BE_Login oBE_Login = new BE_Login();
        BLL_Login oBLL_Login = new BLL_Login();
        BE_PermisoPadre oBE_Permiso = new BE_PermisoPadre();

        public frmLogin()
        {
            InitializeComponent();
            Aspecto.FormatearLogin(this, this.grpLogin, this.Width, this.Height);
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtUsuario.Focus();
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
                        
                        if (this.Owner is frmMenu menu)
                        {
                            menu.UsuarioActivo = oBE_Login;

                        }
                        Cálculos.BorrarCampos(grpLogin);
                        this.Close();
                        
                    }
                }
                else throw new RestaurantException("La contraseña es incorrecta");
            }
            else throw new UsuarioInexistenteException("No se encuentra el usuario en la base de datos.");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCambiarPass_Click(object sender, EventArgs e)
        {
            oBE_Login = oBLL_Login.Login(txtUsuario.Text);
            if (oBE_Login != null)
            {
                if (oBLL_Login.CheckPass(oBE_Login, txtPass.Text))
                {
                    if (oBLL_Login.Intentos(oBE_Login))
                    {
                        frmCambioPass frm = new frmCambioPass();
                        frm.Usuario(txtUsuario.Text);
                        frm.Show();
                    }
                    else
                    {
                        Cálculos.MsgBox("El usuario está bloqueado. Comuniquese con el Administrador");
                    }

                }
                else throw new RestaurantException("La contraseña es incorrecta");
            }
            else throw new UsuarioInexistenteException("No se encuentra el usuario en la base de datos.");
        }

        private void frmLogin_MouseDown(object sender, MouseEventArgs e)
        {
            Aspecto.ReleaseCapture();
            Aspecto.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void picLogin_MouseDown(object sender, MouseEventArgs e)
        {
            Aspecto.ReleaseCapture();
            Aspecto.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
