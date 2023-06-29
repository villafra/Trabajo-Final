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
    public partial class frmCombinarMesas : Form
    {
        BLL_Mesa oBLL_Mesa;
        BE_Mesa oBE_Mesa;
        public frmCombinarMesas()
        {
            InitializeComponent();
            oBLL_Mesa = new BLL_Mesa();
            oBE_Mesa = new BE_Mesa();
            Aspecto.FormatearGRP(grpMesas);
            Aspecto.FormatearGRPAccion(grpAcciones);
            Aspecto.FormatearDGV(dgvMesas);
            ActualizarListado();
        }
        public void ActualizarListado()
        {
            Cálculos.RefreshGrilla(dgvMesas, oBLL_Mesa.ListarLibres());
            dgvMesas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmNuevaCombMesa frm = new frmNuevaCombMesa();
            frm.oBE_Mesa = oBE_Mesa;
            frm.ShowDialog();
            ActualizarListado();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmNuevaCombMesa frm = new frmNuevaCombMesa();
            frm.oBE_Mesa = oBE_Mesa;
            frm.ShowDialog();
            ActualizarListado();
        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //oBE_Mesa = (BE_Mesa)dgvUsuarios.SelectedRows[0].DataBoundItem;
        }

        private void dgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if ((BE_Mesa)dgvMesas.SelectedRows[0].DataBoundItem is BE_MesaCombinada)
                {
                    oBE_Mesa = (BE_MesaCombinada)dgvMesas.SelectedRows[0].DataBoundItem;
                }
                else oBE_Mesa = (BE_Mesa)dgvMesas.SelectedRows[0].DataBoundItem;
                
            }
            catch { }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            oBLL_Mesa.DescombinarMesa(oBE_Mesa as BE_MesaCombinada);
            ActualizarListado();
        }
    }
}
