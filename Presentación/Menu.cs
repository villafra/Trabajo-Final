using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Service_Layer;
using Business_Entities;
using Automate_Layer;
using Business_Logic_Layer;

namespace Trabajo_Final
{
    public partial class frmMenu : Form
    {
        public Form Contenedor { get; set; }
        public BE_Login UsuarioActivo { get; set; }
        public frmMenu()
        {
            InitializeComponent();
            
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            try
            {
                if (this.UsuarioActivo is null)
                {
                    frmLogin frmlog = new frmLogin();
                    frmlog.Owner = this;
                    frmlog.ShowDialog();
                }
                txtUsuarioActivo.Text = $"Usuario Activo: " + UsuarioActivo.Usuario;
            }
            catch
            {
                Application.Exit();
            }
            Aspecto.FormatearForm(this, pnlMenu, this.Width, this.Height);
            frmBienvenida frm = new frmBienvenida();
            frm.Owner = this;
            Aspecto.AbrirNuevoForm(this, frm);

        }

        private void frmMenu_MouseDown(object sender, MouseEventArgs e)
        {
            Aspecto.ReleaseCapture();
            Aspecto.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void menuStrip_MouseDown(object sender, MouseEventArgs e)
        {
            Aspecto.ReleaseCapture();
            Aspecto.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pnlMenu_MouseDown(object sender, MouseEventArgs e)
        {
            Aspecto.ReleaseCapture();
            Aspecto.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void picboxPanel_MouseDown(object sender, MouseEventArgs e)
        {
            Aspecto.ReleaseCapture();
            Aspecto.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void menuPrincipalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmMenuGerente);
            if (frm != null)
            {

                frm.BringToFront();
                return;
            }
            else
            {
                frm = new frmMenuGerente();
                Aspecto.AbrirNuevoForm(this, frm);
               
            }
        }

        private void loguearseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmLogin);
            if (frm != null)
            {

                frm.BringToFront();
                return;
            }
            else
            {
                frm = new frmLogin();
                frm.Owner = this;
                frm.ShowDialog();
                txtUsuarioActivo.Text = $"Usuario Activo: " + UsuarioActivo.Usuario;
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cálculos.Salir();
        }

        private void crearBackUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackUp.CrearBackUp(UsuarioActivo);
        }

        private void restoreBackUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackUp.Restore(UsuarioActivo, "11-06-2023 22-35-21.zip");
            BackUp.RollBack(UsuarioActivo);
        }
    }
}
