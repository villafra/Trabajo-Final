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

namespace Trabajo_Final
{
    public partial class frmListadoBebidas : Form
    {
        BLL_Bebida_Stock oBLL_Bebida_Stock;
        BE_Bebida_Stock oBE_Bebida_Stock;
        private List<BE_Bebida_Stock> listado;
        Reemplazos rm;
        public frmListadoBebidas()
        {
            InitializeComponent();
            oBLL_Bebida_Stock = new BLL_Bebida_Stock();
            oBE_Bebida_Stock = new BE_Bebida_Stock();
            Aspecto.FormatearGRP(grpBebidas);
            Aspecto.FormatearDGV(dgvBebidas);
            CargarComboFiltro();
            ActualizarListado();
        }
        public void ActualizarListado()
        {
            Cálculos.RefreshGrilla(dgvBebidas, oBLL_Bebida_Stock.ListarConStock());
        }
        public void Centrar()
        {
            VistasDGV.dgvBebStock(dgvBebidas);
            Aspecto.CentrarDGV(this, dgvBebidas);
        }
        private void CargarComboFiltro()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>
            {
                {"Nombre de Bebida", "Material"},
                {"Lote", "Lote" },
                {"Stock", "Stock" },
                {"Fecha de Creación", "FechaCreacion" }
            };
            rm = new Reemplazos(dict);
            Cálculos.DataSourceCombo(comboFiltro, rm.ListadoClaves(), "Filtros");
        }
        private void dgvIngredientes_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                oBE_Bebida_Stock = (BE_Bebida_Stock)dgvBebidas.SelectedRows[0].DataBoundItem;
            }
            catch { }

        }

        private void frmListadoBebidas_Load(object sender, EventArgs e)
        {
            listado = (List<BE_Bebida_Stock>)dgvBebidas.DataSource;
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            if (txtFiltro.Text.Length > 0 && comboFiltro.SelectedIndex != -1)
            {
                Cálculos.RefreshGrilla(dgvBebidas, listado);
                string filtro = txtFiltro.Text;
                string Variable = rm.Reemplazar(comboFiltro.Text);
                List<BE_Bebida_Stock> filtrada = ((List<BE_Bebida_Stock>)dgvBebidas.DataSource).Where(x => Cálculos.GetPropertyValue(x, Variable).ToString().Contains(Cálculos.Capitalize(filtro))).ToList();
                Cálculos.RefreshGrilla(dgvBebidas, filtrada);
                Centrar();
                comboFiltro.Text = "";
                txtFiltro.Text = "";
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Cálculos.RefreshGrilla(dgvBebidas, listado);
            Centrar();
        }

        private void frmListadoBebidas_Activated(object sender, EventArgs e)
        {
            Centrar();
        }

        private void frmListadoBebidas_Shown(object sender, EventArgs e)
        {
            Centrar();
        }
    }
}
