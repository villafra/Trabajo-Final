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
    public partial class frmVerCompra : Form
    {

        public BE_Compra oBE_Compra;
        public frmVerCompra()
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
            if (oBE_Compra != null)
            {
                txtCodigo.Text = oBE_Compra.Codigo.ToString();
                if (oBE_Compra is BE_CompraBebida)
                {
                    txtMaterial.Text = ((BE_CompraBebida)oBE_Compra).ID_Material.ToString();
                }
                else
                {
                    txtMaterial.Text = ((BE_CompraIngrediente)oBE_Compra).ID_Material.ToString();
                }
                txtCantidad.Text = oBE_Compra.Cantidad.ToString();
                dtpFechaCompra.Value = oBE_Compra.FechaCompra;
                dtpFechaEntrega.Value = oBE_Compra.FechaEntrega;
                dtpFechaIngreso.Value = oBE_Compra.FechaIngreso != null ? oBE_Compra.FechaIngreso.Value : oBE_Compra.FechaCompra;
                txtCantRecibida.Text = oBE_Compra.CantidadRecibida.ToString();
                txtNroFactura.Text = oBE_Compra.NroFactura;
                txtCosto.Text = oBE_Compra.Costo.ToString();
                txtStatus.Text = oBE_Compra.Status.ToString();
            }

        }

        private void frmVerPedido_Load(object sender, EventArgs e)
        {
            ImportarPedido();
        }
    }
}
