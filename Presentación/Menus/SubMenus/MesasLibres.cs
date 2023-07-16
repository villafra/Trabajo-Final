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
using Microsoft.VisualBasic;

namespace Trabajo_Final
{
    public partial class frmMesasLibres : Form
    {
        BE_Mesa oBE_Mesa;
        BLL_Mesa oBLL_Mesa;
        public frmMesasLibres()
        {
            InitializeComponent();
            oBLL_Mesa = new BLL_Mesa();
            Aspecto.FormatearGRPSubMenu(grpMesas);
            Aspecto.FormatearDGVRecetas(dgvMesas);
            ActualizarListado();
        }
        public void ActualizarListado()
        {
            Cálculos.RefreshGrilla(dgvMesas, oBLL_Mesa.ListarLibres());
        }
        private bool Nuevo()
        {
            oBE_Mesa.Status = StatusMesa.Ocupada;
            return oBLL_Mesa.Modificar(oBE_Mesa);
        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Nuevo())
                {
                    frmListadoPedidos frm = this.Owner as frmListadoPedidos;
                    frm.oBE_Orden.ID_Mesa = oBE_Mesa;
                }
                else { throw new RestaurantException("No se ha podido asignar la mesa. Por favor, intente nuevamente."); }  
            }
            catch (Exception ex) { Cálculos.MsgBox(ex.Message); }
            
        }

        private void dgvMesas_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                oBE_Mesa = (BE_Mesa)dgvMesas.SelectedRows[0].DataBoundItem;
            }
            catch { }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
