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
    public partial class frmCostos : Form
    {
        BLL_Costo oBLL_Costo;
        BE_Costo oBE_Costo;
        public frmCostos()
        {
            InitializeComponent();
            oBLL_Costo = new BLL_Costo();
            Aspecto.FormatearGRP(grpCostos);
            Aspecto.FormatearGRPAccion(grpAcciones);
            Aspecto.FormatearDGV(dgvCostos);
            ActualizarListado();
        }
        public void ActualizarListado()
        {
            Cálculos.RefreshGrilla(dgvCostos, oBLL_Costo.Listar());
            dgvCostos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmNuevaCompra frm = new frmNuevaCompra();
            frm.ShowDialog();
            ActualizarListado();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmNuevoCosto frm = new frmNuevoCosto();
            frm.oBE_Costo = oBE_Costo;
            frm.ShowDialog();
            ActualizarListado();
        }

        private void dgvCostos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //oBE_Login = (BE_Login)dgvUsuarios.SelectedRows[0].DataBoundItem;
        }

        private void dgvCostos_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                oBE_Costo = (BE_Costo)dgvCostos.SelectedRows[0].DataBoundItem;
            }
            catch { }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            oBLL_Costo.Baja(oBE_Costo);
        }
    }
}
