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
    public partial class frmListadoBebidas : Form
    {
        BLL_Bebida_Stock oBLL_Bebida_Stock;
        BE_Bebida_Stock oBE_Bebida_Stock;
        public frmListadoBebidas()
        {
            InitializeComponent();
            oBLL_Bebida_Stock = new BLL_Bebida_Stock();
            oBE_Bebida_Stock = new BE_Bebida_Stock();
            Aspecto.FormatearGRP(grpBebidas);
            Aspecto.FormatearDGV(dgvPlatos);
            ActualizarListado();
        }
        public void ActualizarListado()
        {
            Cálculos.RefreshGrilla(dgvPlatos, oBLL_Bebida_Stock.ListarConStock());
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
                oBE_Bebida_Stock = (BE_Bebida_Stock)dgvPlatos.SelectedRows[0].DataBoundItem;
            }
            catch { }

        }

    }
}
