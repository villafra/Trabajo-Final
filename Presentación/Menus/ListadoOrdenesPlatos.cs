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
    public partial class frmListadoOrdenesPlatos : Form
    {
        BLL_Orden oBLL_Orden;
        BE_Orden oBE_Orden;
        public frmListadoOrdenesPlatos()
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
            Cálculos.RefreshGrilla(dgvOrdenes, oBLL_Orden.ListarEnEsperaPlatos());
            dgvOrdenes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
                oBE_Orden.Status = StatusOrden.Preparando_Platos;
                if (oBLL_Orden.Modificar(oBE_Orden))
                {
                    frmPlatosEnOrden frm = new frmPlatosEnOrden(oBE_Orden);
                    frm.Owner = this;
                    frm.ShowDialog();
                    ActualizarListado();
                }
                else { throw new RestaurantException("La actualización del status falló, intente nuevamente."); }
            }
            catch(Exception ex) { Cálculos.MsgBox(ex.Message); }
            
        }
    }
}
