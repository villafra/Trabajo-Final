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
using Microsoft.VisualBasic;

namespace Trabajo_Final
{
    public partial class frmPlatosEnOrden : Form
    {
        BE_Orden oBE_Orden;
        BLL_Orden oBLL_Orden;
        BLL_PlatoReceta oBLL_PlatoReceta;
        BE_Plato oBE_Plato;
        public frmPlatosEnOrden(BE_Orden orden)
        {
            InitializeComponent();
            oBE_Orden = orden;
            oBLL_PlatoReceta = new BLL_PlatoReceta();
            oBLL_Orden = new BLL_Orden();
            Aspecto.FormatearGRPSubMenu(grpIngredientes);
            Aspecto.FormatearDGVRecetas(dgvPlatos);
            Aspecto.FormatearDGVRecetas(dgvReceta);
            ActualizarListado();
        }
        public void ActualizarListado()
        {
            Cálculos.RefreshGrilla(dgvPlatos, oBE_Orden.ID_Pedido.ListadePlatos);
            VistasDGV.dgvPlatosOrden(dgvPlatos);
            txtCantBebidas.Text = oBE_Orden.ID_Pedido.ListadePlatos.Count().ToString();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            oBE_Orden.Status = StatusOrden.En_Espera_Platos;
            if (oBLL_Orden.Modificar(oBE_Orden))
            {
                this.Close();
            }

        }

        private void dgvBebidas_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                oBE_Plato = (BE_Plato)dgvPlatos.SelectedRows[0].DataBoundItem;
                Cálculos.RefreshGrilla(dgvReceta, oBLL_PlatoReceta.PlatoEnOrden(oBE_Plato));
                VistasDGV.dgvIngEnBeb(dgvReceta);
                txtCantiIngred.Text = dgvReceta.RowCount.ToString();
            }
            catch { Cálculos.GrillaEnBlanco(dgvReceta); txtCantiIngred.Text = ""; }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            oBE_Orden.Status = StatusOrden.Platos_Listos;
            try
            {
                if (oBLL_Orden.Modificar(oBE_Orden))
                {
                    Consumir();
                    Cálculos.MsgBox("Platos Listos! Acción confirmada.");
                }
                else { throw new RestaurantException("La confirmación ha fallado, por favor, intente nuevamente"); }
            }
            catch (Exception ex) { Cálculos.MsgBox(ex.Message); }
        }
        private void Consumir()
        {
            List<BE_Plato> distinct = oBE_Orden.ID_Pedido.ListadePlatos
                .GroupBy(x => x.Codigo).Select(y => y.First()).ToList();
            foreach (BE_Plato plato in distinct)
            {
                decimal cantidad = oBE_Orden.ID_Pedido.ListadePlatos.Count(x => x.Codigo == plato.Codigo) * plato.Presentación;
                List<BE_PlatoReceta> listado = oBLL_PlatoReceta.ListarObjeto(plato, oBLL_PlatoReceta.ListarAlternativaVigente(plato));
                oBLL_PlatoReceta.Consumir(listado, cantidad);

            }
        }
    }
}
