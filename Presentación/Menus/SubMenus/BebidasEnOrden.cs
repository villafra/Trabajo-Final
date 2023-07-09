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
        BLL_BebidaReceta oBLL_BebidaReceta;
        BLL_PlatoReceta oBLL_PlatoReceta;
        BE_Bebida_Preparada oBE_Bebida;
        BE_Plato oBE_Plato;
        public frmBebidasEnOrden(BE_Orden orden)
        {
            InitializeComponent();
            oBE_Orden = orden;
            oBLL_BebidaReceta = new BLL_BebidaReceta();
            oBLL_PlatoReceta = new BLL_PlatoReceta();
            Aspecto.FormatearGRPSubMenu(grpIngredientes);
            Aspecto.FormatearDGVRecetas(dgvBebidas);
            Aspecto.FormatearDGVRecetas(dgvReceta);
            ActualizarListado();
        }
        public void ActualizarListado()
        {
            Cálculos.RefreshGrilla(dgvBebidas, oBE_Orden.ID_Pedido.ListadeBebida);
        }
        public void ActualizarRecetario()
        {
           
        }
        private bool Nuevo()
        {
            return true;
        }
        public bool Viejo()
        {
            return true;
        }
        private void Sumar()
        {
           
        }
       
        public void ImportarBebida()
        {

        }

        private void frmNuevaReceta_Load(object sender, EventArgs e)
        {
            ImportarBebida();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
           
        }

        private void btnSacar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
           
            
        }

        public void RecuperarReceta()
        {
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
           
        }

        private void dgvBebidas_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                oBE_Bebida = (BE_Bebida_Preparada)dgvBebidas.SelectedRows[0].DataBoundItem;
                Cálculos.RefreshGrilla(dgvReceta, oBLL_BebidaReceta.BebidaEnOrden(oBE_Bebida));
            }
            catch { Cálculos.GrillaEnBlanco(dgvReceta); }
        }
    }
}
