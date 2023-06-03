using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Trabajo_Final
{
    public partial class frmCambioPass : Form
    {
        private string usuario;
        public frmCambioPass()
        {
            InitializeComponent();
        }

        public void Usuario(string user)
        {
            usuario = user;
            cambiarPass.user = usuario;
        }
    }
}
