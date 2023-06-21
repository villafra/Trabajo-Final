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
    public partial class frmPermisos : Form
    {
        BLL_Permiso oBLL_Permiso;
        public frmPermisos()
        {
            InitializeComponent();
           
            Aspecto.FormatearGRP(grpUsuarios);
            Aspecto.FormatearGRPAccion(grpAcciones);
            Aspecto.FormatearDGV(dgvUsuarios);
            ActualizarListado();
        }
        public void ActualizarListado()
        {
            Cálculos.RefreshGrilla(dgvUsuarios, oBLL_Login.Listar());
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmNuevoLogin frm = new frmNuevoLogin();
            frm.ShowDialog();
            ActualizarListado();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmNuevoLogin frm = new frmNuevoLogin();
            frm.oBE_Login = oBE_Login;
            frm.ShowDialog();
            ActualizarListado();
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            oBLL_Login.Baja(oBE_Login);
        }
    }
}
