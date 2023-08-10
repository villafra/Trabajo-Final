using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business_Logic_Layer;
using Business_Entities;
using Automate_Layer;

namespace Presentación
{
    public partial class CambiarPass : UserControl
    {
        BLL_Login oBLL_Login;
        BE_Login login;
        public string user;
        public CambiarPass()
        {
            InitializeComponent();
            Aspecto.FormatearGRP(grpPass);
            oBLL_Login = new BLL_Login();
            login = new BE_Login();

        }
        private bool pass1, pass2;

        private void txtpass1_Enter(object sender, EventArgs e)
        {
            txtpass1.SelectAll();
            pass1 = true;
        }

        private void txtpass2_Enter(object sender, EventArgs e)
        {
            txtpass2.SelectAll();
            pass2 = true;
        }

        private void txtpass2_Click(object sender, EventArgs e)
        {
            if (pass2)
            {
                txtpass2.SelectAll();
            }

            pass2 = false;
        }

        private void btnSeePass1_MouseDown(object sender, MouseEventArgs e)
        {
            txtpass1.PasswordChar = '\0';

        }

        private void btnSeePass1_MouseUp(object sender, MouseEventArgs e)
        {
            txtpass1.PasswordChar = '●';
        }

        private void btnSeePass2_MouseDown(object sender, MouseEventArgs e)
        {
            txtpass2.PasswordChar = '\0';
        }

        private void btnSeePass2_MouseUp(object sender, MouseEventArgs e)
        {
            txtpass2.PasswordChar = '●';
        }

        private void txtpass1_Click(object sender, EventArgs e)
        {
            if (pass1)
            {
                txtpass1.SelectAll();
            }

            pass1 = false;
        }

        private bool ValidarPass()
        {
            return txtpass1.Text == txtpass2.Text;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (Cálculos.Camposvacios(grpPass))
             CambiarNuevaPass();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Parent.Hide();
        }

        public void CambiarNuevaPass()
        {
            if (ValidarPass())
            {
                login = oBLL_Login.Login(user);
                login.Password = oBLL_Login.EncriptarPass(txtpass1.Text);
                if (oBLL_Login.Modificar(login))
                {
                    Cálculos.MsgBox("La contraseña ha sido restaurada con exito");
                    Parent.Hide();
                }

            }
            else
            {
                Cálculos.MsgBox("La Contraseña no coincide");
            }
        }
    }
}
