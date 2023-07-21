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
    public partial class frmHistoricoPedidos : Form
    {
        BLL_Pedido oBLL_Pedido;
        BE_Pedido oBE_Pedido;
        private List<BE_Pedido> listado;
        Reemplazos rm;
        public frmHistoricoPedidos()
        {
            InitializeComponent();
            oBLL_Pedido = new BLL_Pedido();
            oBE_Pedido = new BE_Pedido();
            Aspecto.FormatearGRP(grpPedidos);
            Aspecto.FormatearDGV(dgvPedidos);
            Aspecto.FormatearGRPAccion(grpAcciones);
            CargarComboFiltro();
            ActualizarListado();
        }
        public void ActualizarListado()
        {
            Cálculos.RefreshGrilla(dgvPedidos, oBLL_Pedido.Listar());
        }
        public void Centrar()
        {
            VistasDGV.dgvHistPedidos(dgvPedidos);
            Aspecto.CentrarDGV(this, dgvPedidos);
        }
        private void CargarComboFiltro()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>
            {
                {"Status", "Status"},
                {"Método de Pago", "ID_Pago" },
                {"Empleado a Cargo", "ID_Empleado" }
            };
            rm = new Reemplazos(dict);
            Cálculos.DataSourceCombo(comboFiltro, rm.ListadoClaves(), "Filtros");
        }
        private void dgvPedidos_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                oBE_Pedido = (BE_Pedido)dgvPedidos.SelectedRows[0].DataBoundItem;
            }
            catch { }
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
           if(oBE_Pedido != null)
            {
                frmVerPedido frm = new frmVerPedido();
                frm.Owner = this;
                frm.oBE_Pedido = oBE_Pedido;
                frm.ShowDialog();
            }
        }

        private void frmHistoricoPedidos_Load(object sender, EventArgs e)
        {
            listado = (List<BE_Pedido>)dgvPedidos.DataSource;
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            if (txtFiltro.Text.Length > 0 && comboFiltro.SelectedIndex != -1)
            {
                Cálculos.RefreshGrilla(dgvPedidos, listado);
                string filtro = txtFiltro.Text;
                string Variable = rm.Reemplazar(comboFiltro.Text);
                List<BE_Pedido> filtrada = ((List<BE_Pedido>)dgvPedidos.DataSource).Where(x => Cálculos.GetPropertyValue(x, Variable).ToString().Contains(Cálculos.Capitalize(filtro))).ToList();
                Cálculos.RefreshGrilla(dgvPedidos, filtrada);
                Centrar();
                comboFiltro.Text = "";
                txtFiltro.Text = "";
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Cálculos.RefreshGrilla(dgvPedidos, listado);
            Centrar();
        }

        private void frmHistoricoPedidos_Shown(object sender, EventArgs e)
        {
            Centrar();
        }

        private void frmHistoricoPedidos_Activated(object sender, EventArgs e)
        {
            Centrar();
        }
    }
}
