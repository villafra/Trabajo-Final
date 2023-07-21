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
    }
}
