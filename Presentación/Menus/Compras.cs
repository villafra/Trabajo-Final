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
    public partial class frmCompras : Form
    {
        BLL_Compra oBLL_Compra;
        BE_Compra oBE_Compra;
        public frmCompras()
        {
            InitializeComponent();
            oBLL_Compra = new BLL_Compra();
            oBE_Compra = new BE_Compra();
            Aspecto.FormatearGRP(grpCompras);
            Aspecto.FormatearGRPAccion(grpAcciones);
            Aspecto.FormatearDGV(dgvCompras);
            ActualizarListado();
        }
        public void ActualizarListado()
        {
            Cálculos.RefreshGrilla(dgvCompras, oBLL_Compra.Listar());
            dgvCompras.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmNuevaCompra frm = new frmNuevaCompra();
            frm.ShowDialog();
            ActualizarListado();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (oBE_Compra.Status == StausComp.En_Curso)
                {
                    frmNuevaCompra frm = new frmNuevaCompra();
                    frm.oBE_Compra = oBE_Compra;
                    frm.ShowDialog();
                    ActualizarListado();
                }
                else { throw new RestaurantException("No se puede modificar un pedido que ya se ha gestionado."); }
            }
            catch (Exception ex)
            {
                Cálculos.MsgBox(ex.Message);
            }
        }

        private void dgvCompras_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //oBE_Login = (BE_Login)dgvUsuarios.SelectedRows[0].DataBoundItem;
        }

        private void dgvCompras_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                oBE_Compra = (BE_Compra)dgvCompras.SelectedRows[0].DataBoundItem;
            }
            catch { }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (oBE_Compra.Status == StausComp.En_Curso)
                {
                    if (oBLL_Compra.Baja(oBE_Compra))
                    {
                        Cálculos.MsgBox("El pedido se ha borrado de la base de datos.");
                    }
                    else { throw new Exception(); }
                    ActualizarListado();
                }
                else { throw new RestaurantException("No se puede eliminar un pedido que ya se ha gestionado."); }
            }
            catch (Exception ex)
            {
                Cálculos.MsgBox(ex.Message);
            }
        }
    }
}
