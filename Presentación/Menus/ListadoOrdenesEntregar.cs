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
    public partial class frmListadoOrdenesEntregar : Form
    {
        BLL_Orden oBLL_Orden;
        BE_Orden oBE_Orden;
        private List<BE_Orden> listado;
        public frmListadoOrdenesEntregar()
        {
            InitializeComponent();
            oBLL_Orden = new BLL_Orden();
            Aspecto.FormatearGRP(grpPedidos);
            Aspecto.FormatearDGV(dgvOrdenes);
            Aspecto.FormatearDGV(dgvItems);
            Aspecto.FormatearGRPAccion(grpAcciones);
            ActualizarListado();
        }
        public void ActualizarListado()
        {
            Cálculos.GrillaEnBlanco(dgvItems);
            Cálculos.RefreshGrilla(dgvOrdenes, oBLL_Orden.ListarEnEntrega());
        }
        public void Centrar()
        {
            VistasDGV.dgvOrdenResumen(dgvOrdenes);
        }
        public void CentrarBeb()
        {
            Cálculos.RefreshGrilla(dgvItems, oBE_Orden.ID_Pedido.ListadeBebida);
            VistasDGV.dgvOrdenItem(dgvItems);
        }
        public void CentrarPla()
        {
            Cálculos.RefreshGrilla(dgvItems, oBE_Orden.ID_Pedido.ListadePlatos);
            VistasDGV.dgvOrdenItem(dgvItems);
        }
        private void dgvPedidos_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                oBE_Orden = (BE_Orden)dgvOrdenes.SelectedRows[0].DataBoundItem;
                if (oBE_Orden.Status == StatusOrden.Bebidas_Listas)
                {
                    CentrarBeb();
                }
                else
                {
                    CentrarPla();
                }
            }
            catch { }
            
        }
      

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (oBE_Orden.Status == StatusOrden.Bebidas_Listas)
                {
                    if (oBE_Orden.ID_Pedido.ListadePlatos.Count == 0)
                        oBE_Orden.Status = StatusOrden.Orden_Entregada;
                    else
                        oBE_Orden.Status = StatusOrden.En_Espera_Platos;
                }
                else
                {
                    oBE_Orden.Status = StatusOrden.Orden_Entregada;
                }
                if (oBLL_Orden.Modificar(oBE_Orden))
                {
                    ActualizarListado();
                    Centrar();
                    Cálculos.MsgBox("La orden ha sido entregada.");
                }
                else { throw new RestaurantException("La actualización del status falló, intente nuevamente."); }
            }
            catch(Exception ex) { Cálculos.MsgBox(ex.Message); }
            
        }

        private void frmListadoOrdenesEntregar_Load(object sender, EventArgs e)
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

        private void frmListadoOrdenesEntregar_Activated(object sender, EventArgs e)
        {
            Centrar();
        }

        private void frmListadoOrdenesEntregar_Shown(object sender, EventArgs e)
        {
            Centrar();
        }
    }
}
