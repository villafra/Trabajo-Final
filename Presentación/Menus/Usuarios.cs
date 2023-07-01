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
using Service_Layer;

namespace Trabajo_Final
{
    public partial class frmUsuarios : Form
    {
        BLL_Login oBLL_Login;
        BE_Login oBE_Login;
        public frmUsuarios()
        {
            InitializeComponent();
            oBLL_Login = new BLL_Login();
            oBE_Login = new BE_Login();
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

        private void dgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                oBE_Login = (BE_Login)dgvUsuarios.SelectedRows[0].DataBoundItem;
            }
            catch { }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            oBLL_Login.Baja(oBE_Login);
        }

        private void btnResetPass_Click(object sender, EventArgs e)
        {
            try
            {
                oBE_Login.Password = oBLL_Login.AutoGenerarPass();
                if (Cálculos.CambiarPass(Encriptacion.DesencriptarPass(oBE_Login.Password)))
                {
                    if (oBLL_Login.Modificar(oBE_Login)) Cálculos.MsgBox("La contraseña se ha restaurado.");
                    else throw new RestaurantException("El reset de la contraseña ha fallado. Intente nuevamente.");
                }
            }catch(Exception ex) { Cálculos.MsgBox(ex.Message); }
        }

        private void btnDesbloquear_Click(object sender, EventArgs e)
        {
            try
            {
                if (oBLL_Login.DesbloquearUsuario(oBE_Login)) Cálculos.MsgBox("Se ha desbloqueado el usuario."); ActualizarListado();
            }
            catch(Exception ex)
            {
                Cálculos.MsgBox(ex.Message);
            }
        }
    }
}
