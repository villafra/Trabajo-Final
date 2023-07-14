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
    public partial class frmHistoricoCompras : Form
    {
        BLL_Compra oBLL_Compra;
        BE_Compra oBE_Compra;
        public frmHistoricoCompras()
        {
            InitializeComponent();
            oBLL_Compra = new BLL_Compra();
            Aspecto.FormatearGRP(grpOrdenes);
            Aspecto.FormatearDGV(dgvOrdenes);
            Aspecto.FormatearGRPAccion(grpAcciones);
            ActualizarListado();
        }
        public void ActualizarListado()
        {
            Cálculos.RefreshGrilla(dgvOrdenes, oBLL_Compra.Listar());
            dgvOrdenes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dgvPedidos_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                oBE_Compra = (BE_Compra)dgvOrdenes.SelectedRows[0].DataBoundItem;
            }
            catch { }
            
        }
        private bool Nuevo()
        {
           
            return true;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Nuevo())
                {
                    ActualizarListado();
                    Cálculos.MsgBox("Se ha generado una nueva orden de cocina.");
                }
                else throw new RestaurantException("No se ha creado la orden correctamente. Intente de nuevo");
            }
            catch (Exception ex) { Cálculos.MsgBox(ex.Message); }
        }
    }
}
