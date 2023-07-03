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
using Automate_Layer;
using Business_Logic_Layer;

namespace Trabajo_Final
{
    public partial class frmBebidas : Form
    {
        BLL_Bebida oBLL_Bebida;
        BE_Bebida oBE_Bebida;
        public frmBebidas()
        {
            InitializeComponent();
            oBLL_Bebida = new BLL_Bebida();
            oBE_Bebida = new BE_Bebida();
            Aspecto.FormatearGRP(grpBebidas);
            Aspecto.FormatearGRPAccion(grpAcciones);
            Aspecto.FormatearDGV(dgvBebidas);
            ActualizarListado();
        }
        public void ActualizarListado()
        {
            Cálculos.RefreshGrilla(dgvBebidas, oBLL_Bebida.Listar());
            dgvBebidas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmNuevoIngrediente frm = new frmNuevoIngrediente();
            frm.ShowDialog();
            ActualizarListado();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmNuevoIngrediente frm = new frmNuevoIngrediente();
            //frm.oBE_Bebida = oBE_Bebida;
            frm.ShowDialog();
            ActualizarListado();
        }

        private void dgvIngredientes_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                oBE_Bebida = (BE_Bebida)dgvBebidas.SelectedRows[0].DataBoundItem;
            }
            catch { }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            oBLL_Bebida.Baja(oBE_Bebida);
        }

        private void btnResetPass_Click(object sender, EventArgs e)
        {
            MessageBox.Show(oBE_Bebida.DevolverNombre());
        }
    }
}
