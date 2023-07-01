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
    public partial class frmBackUp : Form
    {
        public BE_Login UsuarioActivo;
        BLL_BackUp oBLL_BackUp;
        BE_BackUp oBE_BackUp;
        public frmBackUp()
        {
            InitializeComponent();
            oBLL_BackUp = new BLL_BackUp();
            Aspecto.FormatearGRP(grpBackUp);
            Aspecto.FormatearGRPAccion(grpAcciones);
            Aspecto.FormatearDGV(dgvBackUps);
            ActualizarListado();
        }
        public void ActualizarListado()
        {
            Cálculos.RefreshGrilla(dgvBackUps, oBLL_BackUp.Listar());
            dgvBackUps.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (Cálculos.EstaSeguroBackUp("BackUp"))
            {
                oBLL_BackUp.CrearBackUp(UsuarioActivo);
                ActualizarListado();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (Cálculos.EstaSeguroBackUp("Restore"))
            {
                oBLL_BackUp.RestaurarBackUp(UsuarioActivo, oBE_BackUp.NombreArchivo);
                ActualizarListado();
            }
        }

        private void dgvIngredientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //oBE_Login = (BE_Login)dgvUsuarios.SelectedRows[0].DataBoundItem;
        }

        private void dgvIngredientes_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                oBE_BackUp = (BE_BackUp)dgvBackUps.SelectedRows[0].DataBoundItem;
            }
            catch { }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Cálculos.EstaSeguroBackUp("RollBack"))
            {
                oBLL_BackUp.RollBack(UsuarioActivo);
                ActualizarListado();
            }
        }
    }
}
