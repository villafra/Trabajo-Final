using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Automate_Layer;
using Business_Entities;
using Service_Layer;
using Business_Logic_Layer;

namespace Trabajo_Final
{
    public partial class frmVerPedido : Form
    {

        public BE_Pedido oBE_Pedido;
        public frmVerPedido()
        {
            InitializeComponent();
            Aspecto.FormatearGRPSubMenu(grpNuevoLogin);
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ImportarPedido()
        {
            if (oBE_Pedido != null)
            {
                txtCodigo.Text = oBE_Pedido.Codigo.ToString();
                dtpFecha.Value = oBE_Pedido.FechaInicio;
                txtStatus.Text = oBE_Pedido.Status.ToString();
                txtMonto.Text = oBE_Pedido.Monto_Total.ToString();
                Cálculos.DataSourceCombo(comboBebidas, oBE_Pedido.ListadeBebida, "Bebidas");
                Cálculos.DataSourceCombo(comboPlatos, oBE_Pedido.ListadePlatos, "Platos");
                txtMétodoPago.Text = oBE_Pedido.ID_Pago.ToString();
                txtEmpleado.Text = oBE_Pedido.ID_Empleado != null ? oBE_Pedido.ID_Empleado.ToString() : "";
            }

        }

        private void frmVerPedido_Load(object sender, EventArgs e)
        {
            ImportarPedido();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Cálculos.EstaSeguroC(oBE_Pedido.ToString()))
                {
                    if (oBE_Pedido.Status == StatusPedido.Liberado)
                    {
                        BLL_Pedido oBLL_Pedido = new BLL_Pedido();
                        oBE_Pedido.Status = StatusPedido.Cancelado;
                        if (oBLL_Pedido.Modificar(oBE_Pedido))
                        {
                            Cálculos.MsgBox("El pedido ha sido cancelado satisfactoriamente.");
                            frmHistoricoPedidos frm = this.Owner as frmHistoricoPedidos;
                            frm.ActualizarListado();
                            frm.Centrar();
                        }
                        else { throw new RestaurantException("La acción ha fallado, por favor, intente nuevamente"); }
                    }
                    else { throw new RestaurantException("No se puede cancelar un pedido que ya ha sido gestionado"); }
                }
                else { throw new RestaurantException("Se ha cancelado la acción"); }
            }
            catch (Exception ex) { Cálculos.MsgBox(ex.Message); }
        }
    }
}
