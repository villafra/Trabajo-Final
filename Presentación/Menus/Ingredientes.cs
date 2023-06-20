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
    public partial class frmIngredientes : Form
    {
        BLL_Ingrediente oBLL_Ingrediente;
        BE_Ingrediente oBE_Ingrediente;
        public frmIngredientes()
        {
            InitializeComponent();
            oBLL_Ingrediente = new BLL_Ingrediente();
            oBE_Ingrediente = new BE_Ingrediente();
            Aspecto.FormatearGRP(grpIngredientes);
            Aspecto.FormatearGRPAccion(grpAcciones);
            Aspecto.FormatearDGV(dgvIngredientes);
            ActualizarListado();
        }
        public void ActualizarListado()
        {
            Cálculos.RefreshGrilla(dgvIngredientes, oBLL_Ingrediente.Listar());
            dgvIngredientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmNuevoIngrediente frm = new frmNuevoIngrediente();
            frm.ShowDialog();
            ActualizarListado();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmNuevoIngrediente frm = new frmNuevoIngrediente();
            frm.oBE_Ingrediente = oBE_Ingrediente;
            frm.ShowDialog();
            ActualizarListado();
        }

        private void dgvIngredientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //oBE_Login = (BE_Login)dgvUsuarios.SelectedRows[0].DataBoundItem;
        }

        private void dgvIngredientes_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                oBE_Ingrediente = (BE_Ingrediente)dgvIngredientes.SelectedRows[0].DataBoundItem;
            }
            catch { }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            oBLL_Ingrediente.Baja(oBE_Ingrediente);
        }
    }
}
