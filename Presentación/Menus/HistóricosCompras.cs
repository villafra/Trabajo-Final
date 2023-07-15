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
        private List<BE_Compra> listado;
        public frmHistoricoCompras()
        {
            InitializeComponent();
            oBLL_Compra = new BLL_Compra();
            Aspecto.FormatearGRP(grpOrdenes);
            Aspecto.FormatearDGV(dgvCompras);
            Aspecto.FormatearGRPAccion(grpAcciones);
            ActualizarListado();
        }
        public void ActualizarListado()
        {
            Cálculos.RefreshGrilla(dgvCompras, oBLL_Compra.Listar());
        }
        public void Centrar()
        {
            VistasDGV.dgvCompras(dgvCompras);
            Aspecto.CentrarDGV(this, dgvCompras);
        }
        private void dgvPedidos_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                oBE_Compra = (BE_Compra)dgvCompras.SelectedRows[0].DataBoundItem;
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
        private void frmCompras_Load(object sender, EventArgs e)
        {
            listado = (List<BE_Compra>)dgvCompras.DataSource;
        }
        private void btBuscar_Click(object sender, EventArgs e)
        {
            if (txtFiltro.Text.Length > 0)
            {
                Cálculos.RefreshGrilla(dgvCompras, listado);
                string filtro = txtFiltro.Text;
                string Variable = comboFiltro.Text;
                List<BE_Compra> filtrada = ((List<BE_Compra>)dgvCompras.DataSource).Where(x => Cálculos.GetPropertyValue(x, Variable).ToString().Contains(Cálculos.Capitalize(filtro))).ToList();
                Cálculos.RefreshGrilla(dgvCompras, filtrada);
                Centrar();
                comboFiltro.Text = "";
                txtFiltro.Text = "";
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Cálculos.RefreshGrilla(dgvCompras, listado);
            Centrar();
        }

        private void frmCompras_Activated(object sender, EventArgs e)
        {
            Centrar();
        }

        private void frmCompras_Shown(object sender, EventArgs e)
        {
            Centrar();
        }
    }
}

