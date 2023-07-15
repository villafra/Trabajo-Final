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
    public partial class frmBebidas : Form
    {
        BLL_Bebida oBLL_Bebida;
        BE_Bebida oBE_Bebida;
        private List<BE_Bebida> listado;
        public frmBebidas()
        {
            InitializeComponent();
            oBLL_Bebida = new BLL_Bebida();
            oBE_Bebida = new BE_Bebida();
            Aspecto.FormatearGRP(grpBebidas);
            Aspecto.FormatearGRPAccion(grpAcciones);
            Aspecto.FormatearDGV(dgvBebidas);
            ActualizarListado();
        }
        public void ActualizarListado()
        {
            Cálculos.RefreshGrilla(dgvBebidas, oBLL_Bebida.Listar());
        }
        public void Centrar()
        {
            VistasDGV.dgvBebidas(dgvBebidas);
            Aspecto.CentrarDGV(this, dgvBebidas);
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmNuevaBebida frm = new frmNuevaBebida();
            frm.ShowDialog();
            ActualizarListado();
            Centrar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmNuevaBebida frm = new frmNuevaBebida();
            frm.oBE_Bebida = oBE_Bebida;
            frm.ShowDialog();
            ActualizarListado();
            Centrar();
        }

        private void dgvIngredientes_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                oBE_Bebida = (BE_Bebida)dgvBebidas.SelectedRows[0].DataBoundItem;
            }
            catch { }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            oBLL_Bebida.Baja(oBE_Bebida);
        }

        private void btnResetPass_Click(object sender, EventArgs e)
        {
            MessageBox.Show(oBE_Bebida.DevolverNombre());
        }

        private void frmBebidas_Load(object sender, EventArgs e)
        {
            listado = (List<BE_Bebida>)dgvBebidas.DataSource;
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            if (txtFiltro.Text.Length > 0)
            {
                Cálculos.RefreshGrilla(dgvBebidas, listado);
                string filtro = txtFiltro.Text;
                string Variable = comboFiltro.Text;
                List<BE_Bebida> filtrada = ((List<BE_Bebida>)dgvBebidas.DataSource).Where(x => Cálculos.GetPropertyValue(x, Variable).ToString().Contains(Cálculos.Capitalize(filtro))).ToList();
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

        private void frmBebidas_Activated(object sender, EventArgs e)
        {
            Centrar();
        }

        private void frmBebidas_Shown(object sender, EventArgs e)
        {
            Centrar();
        }
    }
}
