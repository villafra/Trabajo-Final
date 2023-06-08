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

namespace Trabajo_Final
{
    public partial class frmMenuGerente : Form
    {
        public frmMenuGerente()
        {
            InitializeComponent();
        }

        private void frmMenuGerente_MouseDown(object sender, MouseEventArgs e)
        {
            Aspecto.ReleaseCapture();
            Aspecto.SendMessage(this.MdiParent.Handle, 0x112, 0xf012, 0);
        }
    }
}
