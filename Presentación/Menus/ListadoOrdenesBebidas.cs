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
using Service_Layer;

namespace Trabajo_Final
{
    public partial class frmListadoOrdenesBebidas : Form
    {
        BLL_Orden oBLL_Orden;
        BE_Orden oBE_Orden;
        private List<BE_Orden> listado;
        public frmListadoOrdenesBebidas()
        {
            InitializeComponent();
            oBLL_Orden = new BLL_Orden();
            Aspecto.FormatearGRP(grpPedidos);
            Aspecto.FormatearDGV(dgvOrdenes);
            Aspecto.FormatearGRPAccion(grpAcciones);
            ActualizarListado();
        }
        public void ActualizarListado()
        {
            Cálculos.RefreshGrilla(dgvOrdenes, oBLL_Orden.ListarEnEsperaBebidas());
        }
        public void Centrar()
        {
            VistasDGV.dgvOrdenBebida(dgvOrdenes);
            Aspecto.CentrarDGV(this, dgvOrdenes);
        }
        private void dgvPedidos_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                oBE_Orden = (BE_Orden)dgvOrdenes.SelectedRows[0].DataBoundItem;
            }
            catch { }
            
        }
      

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                oBE_Orden.Status = StatusOrden.Preparando_Bebidas;
                if (oBLL_Orden.Modificar(oBE_Orden))
                {
                    frmBebidasEnOrden frm = new frmBebidasEnOrden(oBE_Orden);
                    frm.Owner = this;
                    frm.ShowDialog();
                    ActualizarListado();
                    Centrar();
                }
                else { throw new RestaurantException("La actualización del status falló, intente nuevamente."); }
            }
            catch(Exception ex) { Cálculos.MsgBox(ex.Message); }
            
        }

        private void frmListadoOrdenesBebidas_Load(object sender, EventArgs e)
        {
            listado = (List<BE_Orden>)dgvOrdenes.DataSource;
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            if (txtFiltro.Text.Length > 0)
            {
                Cálculos.RefreshGrilla(dgvOrdenes, listado);
                string filtro = txtFiltro.Text;
                string Variable = comboFiltro.Text;
                List<BE_Orden> filtrada = ((List<BE_Orden>)dgvOrdenes.DataSource).Where(x => Cálculos.GetPropertyValue(x, Variable).ToString().Contains(Cálculos.Capitalize(filtro))).ToList();
                Cálculos.RefreshGrilla(dgvOrdenes, filtrada);
                Centrar();
                comboFiltro.Text = "";
                txtFiltro.Text = "";
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Cálculos.RefreshGrilla(dgvOrdenes, listado);
            Centrar();
        }

        private void frmListadoOrdenesBebidas_Activated(object sender, EventArgs e)
        {
            Centrar();
        }

        private void frmListadoOrdenesBebidas_Shown(object sender, EventArgs e)
        {
            Centrar();
        }
    }
}
