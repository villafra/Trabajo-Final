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
    public partial class frmVerOrden : Form
    {

        public BE_Orden oBE_Orden;
        public frmVerOrden()
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
            if (oBE_Orden != null)
            {
                txtCodigo.Text = oBE_Orden.Codigo.ToString();
                txtStatus.Text = oBE_Orden.Status.ToString();
                txtPedido.Text = oBE_Orden.ID_Pedido.ToString();
                txtMesa.Text = oBE_Orden.ID_Mesa.ToString();
                txtEmpleado.Text = oBE_Orden.ID_Empleado != null ? oBE_Orden.ID_Empleado.ToString() : string.Empty;
            }

        }

        private void frmVerPedido_Load(object sender, EventArgs e)
        {
            ImportarPedido();
        }
    }
}
