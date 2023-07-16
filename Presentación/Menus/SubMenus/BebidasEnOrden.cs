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
    public partial class frmBebidasEnOrden : Form
    {
        BE_Orden oBE_Orden;
        BLL_Orden oBLL_Orden;
        BLL_BebidaReceta oBLL_BebidaReceta;
        BLL_Bebida_Stock oBLL_BebidaStock;
        BE_Bebida_Preparada oBE_Bebida;
        public frmBebidasEnOrden(BE_Orden orden)
        {
            InitializeComponent();
            oBE_Orden = orden;
            oBLL_BebidaReceta = new BLL_BebidaReceta();
            oBLL_BebidaStock = new BLL_Bebida_Stock();
            oBLL_Orden = new BLL_Orden();
            Aspecto.FormatearGRPSubMenu(grpIngredientes);
            Aspecto.FormatearDGVRecetas(dgvBebidas);
            Aspecto.FormatearDGVRecetas(dgvReceta);
            ActualizarListado();
        }
        public void ActualizarListado()
        {
            Cálculos.RefreshGrilla(dgvBebidas, oBE_Orden.ID_Pedido.ListadeBebida);
            txtCantBebidas.Text = oBE_Orden.ID_Pedido.ListadeBebida.Count().ToString();
        }
        
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            oBE_Orden.Status = StatusOrden.En_Espera_Bebidas;
            oBLL_Orden.Modificar(oBE_Orden);
            this.Close();
        }

        private void dgvBebidas_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                oBE_Bebida = (BE_Bebida_Preparada)dgvBebidas.SelectedRows[0].DataBoundItem;
                Cálculos.RefreshGrilla(dgvReceta, oBLL_BebidaReceta.BebidaEnOrden(oBE_Bebida));
                txtCantiIngred.Text =  dgvReceta.RowCount.ToString();
            }
            catch { Cálculos.GrillaEnBlanco(dgvReceta); txtCantiIngred.Text = ""; }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            oBE_Orden.Status = StatusOrden.Bebidas_Listas;
            try
            {
                if (oBLL_Orden.Modificar(oBE_Orden))
                {
                    Consumir();
                    Cálculos.MsgBox("Bebidas Listas! Acción confirmada.");
                }
                else { throw new RestaurantException("La confirmación ha fallado, por favor, intente nuevamente"); }
                
            }
            catch(Exception ex) { Cálculos.MsgBox(ex.Message); }
            
        }
        private void Consumir()
        {
            List<BE_Bebida> distinct = oBE_Orden.ID_Pedido.ListadeBebida
                .GroupBy(x => x.Codigo).Select(y => y.First()).ToList();
            foreach (BE_Bebida bebida in distinct)
            {
                decimal cantidad = oBE_Orden.ID_Pedido.ListadeBebida.Count(x => x.Codigo == bebida.Codigo) * bebida.Presentacion;
                if (bebida is BE_Bebida_Preparada)
                {
                    List<BE_BebidaReceta> listado = oBLL_BebidaReceta.ListarObjeto(bebida, oBLL_BebidaReceta.ListarAlternativaVigente(bebida));
                    oBLL_BebidaReceta.Consumir(listado, cantidad);
                }
                else
                {
                    List<BE_Bebida_Stock> listado = oBLL_BebidaStock.BuscarStock(bebida);
                    oBLL_BebidaStock.Consumir(listado, cantidad);
                }
            }
            
        }
    }
}
