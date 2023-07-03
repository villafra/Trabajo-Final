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
        public frmListadoPlatos()
        {
            InitializeComponent();
            oBLL_Plato_Stock = new BLL_Plato_Stock();
            oBE_Plato_Stock = new BE_Plato_Stock();
            Aspecto.FormatearGRP(grpPlatos);
            Aspecto.FormatearDGV(dgvPlatos);
            ActualizarListado();
        }
        public void ActualizarListado()
        {
            Cálculos.RefreshGrilla(dgvPlatos, oBLL_Plato_Stock.ListarConStock());
            dgvPlatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dgvIngredientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //oBE_Login = (BE_Login)dgvUsuarios.SelectedRows[0].DataBoundItem;
        }

        private void dgvIngredientes_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                oBE_Plato_Stock = (BE_Plato_Stock)dgvPlatos.SelectedRows[0].DataBoundItem;
            }
            catch { }

        }

    }
}
