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
    public partial class frmIngresarCompra : Form
    {
        BLL_Compra oBLL_Compra;
        BE_Compra oBE_Compra;
        private List<BE_Compra> listado;
        Reemplazos rm;
        public frmIngresarCompra()
        {
            InitializeComponent();
            oBLL_Compra = new BLL_Compra();
            Aspecto.FormatearGRP(grpCompras);
            Aspecto.FormatearGRPAccion(grpAcciones);
            Aspecto.FormatearDGV(dgvCompras);
            CargarComboFiltro();
            ActualizarListado();
        }
        public void ActualizarListado()
        {
            Cálculos.RefreshGrilla(dgvCompras, oBLL_Compra.ListarFiltro(StausComp.En_Curso));
        }
        public void Centrar()
        {
            VistasDGV.dgvInCompras(dgvCompras);
            Aspecto.CentrarDGV(this, dgvCompras);
        }
        private void CargarComboFiltro()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>
            {
                {"Nro de Compra", "Codigo"},
                {"Tipo de Material", "Material" },
                {"Fecha de Entrega", "FechaEntrega" },
                {"Status", "Status" }
            };
            rm = new Reemplazos(dict);
            Cálculos.DataSourceCombo(comboFiltro, rm.ListadoClaves(), "Filtros");
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmNuevoIngresoCompra frm = new frmNuevoIngresoCompra();
            if (oBE_Compra.Codigo != 0) frm.oBE_Compra = oBE_Compra;
            frm.ShowDialog();
            ActualizarListado();
            Centrar();
        }

        private void dgvCompras_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                oBE_Compra = (BE_Compra)dgvCompras.SelectedRows[0].DataBoundItem;
            }
            catch { }

        }
        private void frmIngresarCompra_Load(object sender, EventArgs e)
        {
            listado = (List<BE_Compra>)dgvCompras.DataSource;
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            if (txtFiltro.Text.Length > 0 && comboFiltro.SelectedIndex != -1)
            {
                Cálculos.RefreshGrilla(dgvCompras, listado);
                string filtro = txtFiltro.Text;
                string Variable = rm.Reemplazar(comboFiltro.Text);
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

        private void frmIngresarCompra_Shown(object sender, EventArgs e)
        {
            Centrar();
        }

        private void frmIngresarCompra_Activated(object sender, EventArgs e)
        {
            Centrar();
        }
    }
}
