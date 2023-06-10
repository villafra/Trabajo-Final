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
using Business_Logic_Layer;

namespace Trabajo_Final
{
    public partial class frmMenuGerente : Form
    {
        BE_GerenteSucursal oBE_Gerente;
        BLL_Gerente_Sucursal oBLL_Gerente;
        public frmMenuGerente()
        {
            InitializeComponent();
            oBE_Gerente = new BE_GerenteSucursal();
            oBLL_Gerente = new BLL_Gerente_Sucursal();
            CargarDGV();
        }

        private void frmMenuGerente_MouseDown(object sender, MouseEventArgs e)
        {
            Aspecto.ReleaseCapture();
            Aspecto.SendMessage(this.MdiParent.Handle, 0x112, 0xf012, 0);
        }

        private void CargarDGV()
        {
            Cálculos.RefreshGrilla(dgvEmpleados, oBLL_Gerente.Listar());
        }
    }
}
