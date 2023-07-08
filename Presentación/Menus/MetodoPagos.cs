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
    public partial class frmMetodoPagos : Form
    {
        private List<BE_Pago> listado;
        BE_Pago oBE_Pago;
        BLL_Pago oBLL_Pago;
        public frmMetodoPagos()
        {
            InitializeComponent();
            oBLL_Pago = new BLL_Pago();
            Aspecto.FormatearGRP(grpMetPagos);
            Aspecto.FormatearGRPAccion(grpAcciones);
            Aspecto.FormatearDGV(dgvMetPagos);
            ActualizarListado();
        }
        public void ActualizarListado()
        {
            Cálculos.RefreshGrilla(dgvMetPagos, oBLL_Pago.Listar());
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmNuevoMetodoPago frm = new frmNuevoMetodoPago();
            frm.ShowDialog();
            ActualizarListado();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmNuevoMetodoPago frm = new frmNuevoMetodoPago();
            frm.oBE_Pago = oBE_Pago;
            frm.ShowDialog();
            ActualizarListado();
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            
            ActualizarListado();
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            string filtro = txtFiltro.Text;
            string Variable = comboFiltro.Text;
            List<BE_Pago> filtrada = ((List<BE_Pago>)dgvMetPagos.DataSource).Where(x => Cálculos.GetPropertyValue(x, Variable).ToString().Contains(filtro)).ToList();
            Cálculos.RefreshGrilla(dgvMetPagos, filtrada);
            comboFiltro.Text = "";
            txtFiltro.Text = "";
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Cálculos.RefreshGrilla(dgvMetPagos, listado);
        }

        private void dgvMetPagos_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                oBE_Pago = (BE_Pago)dgvMetPagos.SelectedRows[0].DataBoundItem;
            }
            catch { }
            
        }
    }
}
