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
    public partial class frmCostos : Form
    {
        BLL_Costo oBLL_Costo;
        BE_Costo oBE_Costo;
        private List<BE_Costo> listado;
        public frmCostos()
        {
            InitializeComponent();
            oBLL_Costo = new BLL_Costo();
            Aspecto.FormatearGRP(grpCostos);
            Aspecto.FormatearGRPAccion(grpAcciones);
            Aspecto.FormatearDGV(dgvCostos);
            ActualizarListado();
        }
        public void ActualizarListado()
        {
            Cálculos.RefreshGrilla(dgvCostos, oBLL_Costo.Listar());
        }

        public void Centrar()
        {
            VistasDGV.dgvCostos(dgvCostos);
            Aspecto.CentrarDGV(this, dgvCostos);
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmNuevoCosto frm = new frmNuevoCosto();
            frm.ShowDialog();
            ActualizarListado();
            Centrar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmNuevoCosto frm = new frmNuevoCosto();
            frm.oBE_Costo = oBE_Costo;
            frm.ShowDialog();
            ActualizarListado();
            Centrar();
        }

        private void dgvCostos_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                oBE_Costo = (BE_Costo)dgvCostos.SelectedRows[0].DataBoundItem;
            }
            catch { }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            oBLL_Costo.Baja(oBE_Costo);
            ActualizarListado();
            Centrar();
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            if (txtFiltro.Text.Length > 0)
            {
                Cálculos.RefreshGrilla(dgvCostos, listado);
                string filtro = txtFiltro.Text;
                string Variable = comboFiltro.Text;
                List<BE_Costo> filtrada = ((List<BE_Costo>)dgvCostos.DataSource).Where(x => Cálculos.GetPropertyValue(x, Variable).ToString().Contains(Cálculos.Capitalize(filtro))).ToList();
                Cálculos.RefreshGrilla(dgvCostos, filtrada);
                Centrar();
                comboFiltro.Text = "";
                txtFiltro.Text = "";
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Cálculos.RefreshGrilla(dgvCostos, listado);
            Centrar();
        }

        private void frmCostos_Load(object sender, EventArgs e)
        {
            listado = (List<BE_Costo>)dgvCostos.DataSource;
        }

        private void frmCostos_Shown(object sender, EventArgs e)
        {
            Centrar();
        }

        private void frmCostos_Activated(object sender, EventArgs e)
        {
            Centrar();
        }
    }
}
