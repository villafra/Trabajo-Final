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
    public partial class frmListadoOrdenesEntregadas : Form
    {
        BLL_Orden oBLL_Orden;
        BE_Orden oBE_Orden;
        BLL_Mesa oBLL_Mesa;
        BE_Mesa oBE_Mesa;
        public frmListadoOrdenesEntregadas()
        {
            InitializeComponent();
            oBLL_Orden = new BLL_Orden();
            oBLL_Mesa = new BLL_Mesa();
            Aspecto.FormatearGRP(grpPedidos);
            Aspecto.FormatearDGV(dgvOrdenes);
            Aspecto.FormatearGRPAccion(grpAcciones);
            ActualizarListado();
        }
        public void ActualizarListado()
        {
            Cálculos.RefreshGrilla(dgvOrdenes, oBLL_Orden.ListarOrdenesEntregadas());
        }

        private void dgvPedidos_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                oBE_Orden = (BE_Orden)dgvOrdenes.SelectedRows[0].DataBoundItem;
                oBE_Mesa = oBE_Orden.ID_Mesa;
            }
            catch { }
            
        }
      
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                oBE_Mesa.Status = StatusMesa.Libre;
                oBE_Orden.Finalizada = true;
                if (oBLL_Mesa.Modificar(oBE_Mesa) & oBLL_Orden.Modificar(oBE_Orden))
                {
                    Cálculos.MsgBox("La orden se ha concluido y la mesa liberado.");
                    ActualizarListado();
                }
                else { throw new RestaurantException("El cierre de la orden fallo, por favor,  intente nuevamente."); }
            }
            catch(Exception ex) { Cálculos.MsgBox(ex.Message); }
            
        }
    }
}
