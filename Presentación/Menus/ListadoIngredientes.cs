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
    public partial class frmListadoIngredientes : Form
    {
        BLL_Material_Stock oBLL_Material_Stock;
        BE_Material_Stock oBE_Material_Stock;
        private List<BE_Material_Stock> listado;
        Reemplazos rm;
        public frmListadoIngredientes()
        {
            InitializeComponent();
            oBLL_Material_Stock = new BLL_Material_Stock();
            oBE_Material_Stock = new BE_Material_Stock();
            Aspecto.FormatearGRP(grpIngredientes);
            Aspecto.FormatearDGV(dgvIngredientes);
            CargarComboFiltro();
            ActualizarListado();
        }
        public void ActualizarListado()
        {
            Cálculos.RefreshGrilla(dgvIngredientes, oBLL_Material_Stock.ListarConStock());
        }
        public void Centrar()
        {
            VistasDGV.dgvIngStock(dgvIngredientes);
            Aspecto.CentrarDGV(this, dgvIngredientes);
        }
        private void CargarComboFiltro()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>
            {
                {"Nombre del Ingrediente", "Material"},
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
                oBE_Material_Stock = (BE_Material_Stock)dgvIngredientes.SelectedRows[0].DataBoundItem;
            }
            catch { }

        }

        private void frmListadoIngredientes_Load(object sender, EventArgs e)
        {
            listado = (List<BE_Material_Stock>)dgvIngredientes.DataSource;
        }

        private void frmListadoIngredientes_Shown(object sender, EventArgs e)
        {
            Centrar();
        }

        private void frmListadoIngredientes_Activated(object sender, EventArgs e)
        {
            Centrar();
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            if (txtFiltro.Text.Length > 0 && comboFiltro.SelectedIndex != -1)
            {
                Cálculos.RefreshGrilla(dgvIngredientes, listado);
                string filtro = txtFiltro.Text;
                string Variable = rm.Reemplazar(comboFiltro.Text);
                List<BE_Material_Stock> filtrada = ((List<BE_Material_Stock>)dgvIngredientes.DataSource).Where(x => Cálculos.GetPropertyValue(x, Variable).ToString().Contains(Cálculos.Capitalize(filtro))).ToList();
                Cálculos.RefreshGrilla(dgvIngredientes, filtrada);
                Centrar();
                comboFiltro.Text = "";
                txtFiltro.Text = "";
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Cálculos.RefreshGrilla(dgvIngredientes, listado);
            Centrar();
        }
    }
}
