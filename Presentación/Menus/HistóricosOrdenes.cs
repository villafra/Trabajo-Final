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
    public partial class frmHistoricoOrdenes : Form
    {
        BLL_Orden oBLL_Orden;
        BE_Orden oBE_Orden;
        private List<BE_Orden> listado;
        Reemplazos rm;
        public frmHistoricoOrdenes()
        {
            InitializeComponent();
            oBLL_Orden = new BLL_Orden();
            oBE_Orden = new BE_Orden();
            Aspecto.FormatearGRP(grpOrdenes);
            Aspecto.FormatearDGV(dgvOrdenes);
            Aspecto.FormatearGRPAccion(grpAcciones);
            CargarComboFiltro();
            ActualizarListado();
        }
        public void ActualizarListado()
        {
            Cálculos.RefreshGrilla(dgvOrdenes, oBLL_Orden.Listar());
            chkOcultar.Checked = false;
        }
        public void Centrar()
        {
            VistasDGV.dgvHistOrdenes(dgvOrdenes);
            Aspecto.CentrarDGV(this, dgvOrdenes);
        }
        private void CargarComboFiltro()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>
            {
                {"Código", "Codigo"},
                {"Status", "Status" },
                {"Nro de Pedido", "ID_Pedido" },
                {"Nro de Mesa", "ID_Mesa" },
                {"Empleado a Cargo", "ID_Empleado" }
            };
            rm = new Reemplazos(dict);
            Cálculos.DataSourceCombo(comboFiltro, rm.ListadoClaves(), "Filtros");
        }
        private void dgvPedidos_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                oBE_Orden = (BE_Orden)dgvOrdenes.SelectedRows[0].DataBoundItem;
            }
            catch { }
            
        }
        private bool Nuevo()
        {
           
            return true;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (oBE_Orden != null)
            {
                frmVerOrden frm = new frmVerOrden();
                frm.Owner = this;
                frm.oBE_Orden = oBE_Orden;
                frm.ShowDialog();
                listado = (List<BE_Orden>)dgvOrdenes.DataSource;
            }
        }

        private void frmHistoricoOrdenes_Load(object sender, EventArgs e)
        {
            listado = (List<BE_Orden>)dgvOrdenes.DataSource;
        }

        private void frmHistoricoOrdenes_Shown(object sender, EventArgs e)
        {
            Centrar();
        }

        private void frmHistoricoOrdenes_Activated(object sender, EventArgs e)
        {
            Centrar();
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            if (txtFiltro.Text.Length > 0 && comboFiltro.SelectedIndex != -1)
            { 
                Cálculos.RefreshGrilla(dgvOrdenes, listado);
                string filtro = txtFiltro.Text;
                string Variable = rm.Reemplazar(comboFiltro.Text);
                List<BE_Orden> filtrada = ((List<BE_Orden>)dgvOrdenes.DataSource).Where(x => Cálculos.GetPropertyValue(x, Variable).ToString().Contains(Cálculos.Capitalize(filtro))).ToList();
                Cálculos.RefreshGrilla(dgvOrdenes, filtrada);
                Centrar();
                comboFiltro.Text = "";
                txtFiltro.Text = "";
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Cálculos.RefreshGrilla(dgvOrdenes, listado);
            Centrar();
            chkOcultar.Checked = false;
        }

        private void chkOcultar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOcultar.Checked)
            {
                Cálculos.RefreshGrilla(dgvOrdenes, listado);
                List<BE_Orden> filtrada = ((List<BE_Orden>)dgvOrdenes.DataSource).Where(x => x.Activo).ToList();
                Cálculos.RefreshGrilla(dgvOrdenes, filtrada);
                Centrar();
            }
            else
            {
                Cálculos.RefreshGrilla(dgvOrdenes, listado);
                Centrar();
            }
        }
    }
}
