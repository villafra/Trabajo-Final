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
    public partial class frmPlatos : Form
    {
        BLL_Plato oBLL_Plato;
        BE_Plato oBE_Plato;
        public frmPlatos()
        {
            InitializeComponent();
            oBLL_Plato = new BLL_Plato();
            oBE_Plato = new BE_Plato();
            Aspecto.FormatearGRP(grpPlatos);
            Aspecto.FormatearGRPAccion(grpAcciones);
            Aspecto.FormatearDGV(dgvPlatos);
            ActualizarListado();
        }
        public void ActualizarListado()
        {
            Cálculos.RefreshGrilla(dgvPlatos, oBLL_Plato.Listar());
            dgvPlatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmNuevoPlato frm = new frmNuevoPlato();
            frm.ShowDialog();
            ActualizarListado();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmNuevoPlato frm = new frmNuevoPlato();
            frm.oBE_Plato = oBE_Plato;
            frm.ShowDialog();
            ActualizarListado();
        }

        private void dgvIngredientes_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                oBE_Plato = (BE_Plato)dgvPlatos.SelectedRows[0].DataBoundItem;
            }
            catch { }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            oBLL_Plato.Baja(oBE_Plato);
        }

        private void btnResetPass_Click(object sender, EventArgs e)
        {
            MessageBox.Show(oBE_Plato.DevolverNombre());
        }
    }
}
