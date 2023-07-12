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
    public partial class frmConfirmarPago : Form
    {
        public BE_Pedido oBE_Pedido;
        public bool PagoOK;
        BLL_Pago oBLL_Pago;
        BE_Pago oBE_Pago;
        public frmConfirmarPago()
        {
            InitializeComponent();
            oBLL_Pago = new BLL_Pago();
            Aspecto.FormatearGRPPedido(grpNuevoLogin);
            Aspecto.FormatearFLowPanel(flowPago);
            ActualizarListado();
        }
        public void ActualizarListado()
        {
            foreach(BE_Pago pago in oBLL_Pago.Listar())
            {
                Button botonPago = CrearBotonPago(pago);
                flowPago.Controls.Add(botonPago);
            }
            Aspecto.CentrarPanel(grpNuevoLogin, flowPago, btnIzquierda, btnDerecha);
        }
       
        private void ImportarPedido()
        {
            if (oBE_Pedido != null)
            {
                lblCosto.Text = oBE_Pedido.Monto_Total.ToString("$0.00");
                Aspecto.CentrarLabelenGRP(grpNuevoLogin, lblCosto);
                Aspecto.CentrarLabelenGRP(grpNuevoLogin, lblMonto);
            }
        }

        private void frmNuevoLogin_Load(object sender, EventArgs e)
        {
            ImportarPedido();
        }
        private Button CrearBotonPago(BE_Pago pago)
        {
            Button botonPago = new Button();
            botonPago.Text = pago.Tipo;
            botonPago.Font = new Font("Nirmala UI", 10, FontStyle.Regular);
            botonPago.TextAlign = ContentAlignment.BottomCenter;
            botonPago.TextImageRelation = TextImageRelation.ImageAboveText;
            botonPago.Width = 80;
            botonPago.Height = 80;
            botonPago.Tag = pago;
            botonPago.Anchor = AnchorStyles.None;
            botonPago.Click += BotonPago_Click;
            return botonPago;
        }
        private void BotonPago_Click(object sender, EventArgs e)
        {
            oBE_Pago = (BE_Pago)((Button)sender).Tag;
            
        }

        private void AbrirVentanaPago(BE_Pago oBE_Pago)
        {
            switch (oBE_Pago.Tipo)
            {
                case "Tarjeta de Crédito":
                    oBE_Pedido.ID_Pago = oBE_Pago;
                    frmPagoTarjeta frm = new frmPagoTarjeta();
                    frm.Owner = this;
                    frm.oBE_Pedido = oBE_Pedido;
                    frm.ShowDialog();
                    break;

                case "QR":
                    oBE_Pedido.ID_Pago = oBE_Pago;
                    frmPagoQR frmQR = new frmPagoQR();
                    frmQR.Owner = this;
                    frmQR.oBE_Pedido = oBE_Pedido;
                    frmQR.ShowDialog();
                    break;

                //case "Efectivo":
                //    frmPagoEfectivo formularioEfectivo = new frmPagoEfectivo();
                //    formularioEfectivo.ShowDialog();
                //    break;

                //case "Cheque":
                //    frmPagoCheque formularioCheque = new frmPagoCheque();
                //    formularioCheque.ShowDialog();
                //    break;

                case "Transferencia Bancaria":
                    oBE_Pedido.ID_Pago = oBE_Pago;
                    frmPagoTrans frmTrans = new frmPagoTrans();
                    frmTrans.Owner = this;
                    frmTrans.oBE_Pedido = oBE_Pedido;
                    frmTrans.ShowDialog();
                    break;

                default:
                    break;
            }
        }

        private void btnDerechaBebidas_Click(object sender, EventArgs e)
        {
            int scroll = flowPago.HorizontalScroll.Value + (flowPago.HorizontalScroll.SmallChange * 5);
            flowPago.AutoScrollPosition = new Point(scroll, 0);
        }
        private void btnIzquierdaBebidas_Click(object sender, EventArgs e)
        {
            int scroll = flowPago.HorizontalScroll.Value - (flowPago.HorizontalScroll.SmallChange * 5);
            flowPago.AutoScrollPosition = new Point(scroll, 0);
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            AbrirVentanaPago(oBE_Pago);
            frmConfirmarPedido owner = this.Owner as frmConfirmarPedido;
            owner.oBE_Pedido = oBE_Pedido;
            this.Close();
        }
    }
}
