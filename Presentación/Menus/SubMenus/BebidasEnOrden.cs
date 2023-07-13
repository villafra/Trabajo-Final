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
        BE_Plato oBE_Plato;
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
            oBLL_Orden.Modificar(oBE_Orden);
            Consumir();
        }
        private void Consumir()
        {
            List<BE_Bebida> distinct = oBE_Orden.ID_Pedido.ListadeBebida
                .GroupBy(x => x.Codigo).Select(y => y.First()).ToList();
            foreach (BE_Bebida bebida in distinct)
            {
                decimal cantidad = oBE_Orden.ID_Pedido.ListadeBebida.Count(x => x.Codigo == bebida.Codigo);
                if (bebida is BE_Bebida_Preparada)
                {

                }
                else
                {
                List<BE_Bebida_Stock> listado =  oBLL_BebidaStock.BuscarStock(bebida);
                oBLL_BebidaStock.Consumir(listado, cantidad);
                }
            }
            
        }
    }
}
