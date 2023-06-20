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
    public partial class frmListadoIngredientes : Form
    {
        BLL_Material_Stock oBLL_Material_Stock;
        BE_Material_Stock oBE_Material_Stock;
        public frmListadoIngredientes()
        {
            InitializeComponent();
            oBLL_Material_Stock = new BLL_Material_Stock();
            oBE_Material_Stock = new BE_Material_Stock();
            Aspecto.FormatearGRP(grpIngredientes);
            Aspecto.FormatearDGV(dgvIngredientes);
            ActualizarListado();
        }
        public void ActualizarListado()
        {
            Cálculos.RefreshGrilla(dgvIngredientes, oBLL_Material_Stock.ListarConStock());
            dgvIngredientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dgvIngredientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //oBE_Login = (BE_Login)dgvUsuarios.SelectedRows[0].DataBoundItem;
        }

        private void dgvIngredientes_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                oBE_Material_Stock = (BE_Material_Stock)dgvIngredientes.SelectedRows[0].DataBoundItem;
            }
            catch { }

        }

    }
}
