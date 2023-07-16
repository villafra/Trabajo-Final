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
    public partial class frmListadoPlatos : Form
    {
        BLL_Plato_Stock oBLL_Plato_Stock;
        BE_Plato_Stock oBE_Plato_Stock;
        private List<BE_Plato_Stock> listado;
        Reemplazos rm;
        public frmListadoPlatos()
        {
            InitializeComponent();
            oBLL_Plato_Stock = new BLL_Plato_Stock();
            oBE_Plato_Stock = new BE_Plato_Stock();
            Aspecto.FormatearGRP(grpPlatos);
            Aspecto.FormatearDGV(dgvPlatos);
            CargarComboFiltro();
            ActualizarListado();
        }
        public void ActualizarListado()
        {
            Cálculos.RefreshGrilla(dgvPlatos, oBLL_Plato_Stock.ListarConStock());
        }
        public void Centrar()
        {
            VistasDGV.dgvPlatStock(dgvPlatos);
            Aspecto.CentrarDGV(this, dgvPlatos);
        }
        private void CargarComboFiltro()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>
            {
                {"Nombre del Plato", "Material"},
                {"Lote", "Lote" },
                {"Fecha de Creación", "FechaCreacion" }
            };
            rm = new Reemplazos(dict);
            Cálculos.DataSourceCombo(comboFiltro, rm.ListadoClaves(), "Filtros");
        }
        private void dgvIngredientes_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                oBE_Plato_Stock = (BE_Plato_Stock)dgvPlatos.SelectedRows[0].DataBoundItem;
            }
            catch { }

        }

        private void frmListadoPlatos_Load(object sender, EventArgs e)
        {
            listado = (List<BE_Plato_Stock>)dgvPlatos.DataSource;
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            if (txtFiltro.Text.Length > 0 && comboFiltro.SelectedIndex != -1)
            {
                Cálculos.RefreshGrilla(dgvPlatos, listado);
                string filtro = txtFiltro.Text;
                string Variable = rm.Reemplazar(comboFiltro.Text);
                List<BE_Plato_Stock> filtrada = ((List<BE_Plato_Stock>)dgvPlatos.DataSource).Where(x => Cálculos.GetPropertyValue(x, Variable).ToString().Contains(Cálculos.Capitalize(filtro))).ToList();
                Cálculos.RefreshGrilla(dgvPlatos, filtrada);
                Centrar();
                comboFiltro.Text = "";
                txtFiltro.Text = "";
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Cálculos.RefreshGrilla(dgvPlatos, listado);
            Centrar();
        }

        private void frmListadoPlatos_Shown(object sender, EventArgs e)
        {
            Centrar();
        }

        private void frmListadoPlatos_Activated(object sender, EventArgs e)
        {
            Centrar();
        }
    }
}
