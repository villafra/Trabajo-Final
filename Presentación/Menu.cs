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
                    frmLogin frm = new frmLogin();
                    frm.Owner = this;
                    frm.ShowDialog();
                    Aspecto.FormatearForm(this, pnlMenu, this.Width, this.Left);
                }
                this.Text = UsuarioActivo.Usuario;
            }
            catch
            {
                Application.Exit();
            }
        }

        private void frmMenu_MouseDown(object sender, MouseEventArgs e)
        {
            Aspecto.CopiarDibujo();
            Aspecto.ReplicarDibujo(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
