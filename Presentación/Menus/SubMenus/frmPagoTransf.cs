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
using System.Threading;
using Timer = System.Windows.Forms.Timer;

namespace Trabajo_Final
{
    public partial class frmPagoTrans : Form
    {
        public BE_Pedido oBE_Pedido;
        public bool PagoOK;
        public BE_Orden oBE_Orden;
        private Timer timer;
        private int progress;
        private const int totalTime = 4000;
        public frmPagoTrans()
        {
            InitializeComponent();
            Aspecto.FormatearGRPPedido(grpNuevoLogin);
            Aspecto.CentrarLabelenGRP(grpNuevoLogin, lblMensajes);
        }
        public void SimularPago()
        {
            progress = 0;
            timer = new Timer();
            timer.Interval = 100; 
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (progress == 0) Thread.Sleep(2000);
            progress += 100; 
            pbpago.Value = progress;
            if (progress == 500) lblMensajes.Text = Mensaje1(); Aspecto.CentrarLabelenGRP(grpNuevoLogin, lblMensajes);
            if (progress == 1500) lblMensajes.Text = Mensaje2(); Aspecto.CentrarLabelenGRP(grpNuevoLogin, lblMensajes);
            if (progress == 2700) lblMensajes.Text = Mensaje3(); Aspecto.CentrarLabelenGRP(grpNuevoLogin, lblMensajes);
            if (progress == 3700) lblMensajes.Text = Mensaje4(); Aspecto.CentrarLabelenGRP(grpNuevoLogin, lblMensajes);
            if (progress >= totalTime)
            {
                timer.Stop();
                progress = 0;
                CrearOrden();
            }
        }
        private string Mensaje1()
        {
            return "Estableciendo comunicación";
        }
        private string Mensaje2()
        {
            return "Registrando";
        }
        private string Mensaje3()
        {
            return "Confirmando Pago";
        }
        private string Mensaje4()
        {
            return "Pago Confirmado";
        }

        private void frmPagoTarjeta_Load(object sender, EventArgs e)
        {
            SimularPago();
            
        }
        private void CrearOrden()
        {
            frmConfirmarPago owner = this.Owner as frmConfirmarPago;
            owner.oBE_Pedido.Status = StatusPedido.Liberado;
            this.Close();
        }
    }

}
