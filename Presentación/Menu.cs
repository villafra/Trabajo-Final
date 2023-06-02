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

        private void btnEncriptar_Click(object sender, EventArgs e)
        {
            MessageBox.Show( Encriptacion.EncriptarPass(txtNombre.Text));

        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            if (this.UsuarioActivo is null)
            {
                Login frm = new Login();
                frm.ShowDialog();
            }
        }
    }
}
