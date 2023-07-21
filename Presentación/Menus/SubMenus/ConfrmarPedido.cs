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
    public partial class frmConfirmarPedido : Form
    {
        public BE_Pedido oBE_Pedido;
        BLL_Pedido oBLL_Pedido;
        public bool PagoOK;
        public frmConfirmarPedido()
        {
            InitializeComponent();
            oBLL_Pedido = new BLL_Pedido();
            Aspecto.FormatearGRPPedido(grpNuevoLogin);
            Aspecto.FormatearFLowPanel(flowBebidas);
            Aspecto.FormatearFLowPanel(flowPlatos);
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            frmConfirmarPago frm = new frmConfirmarPago();
            frm.Owner = this;
            frm.oBE_Pedido = oBE_Pedido;
            frm.ShowDialog();
            if (PagoOK)
            {
                try
                {
                    if (Nuevo())
                    {
                        Cálculos.MsgBox("El Pedido se encuentra liberado.");
                        frmTomarPedido owner = this.Owner as frmTomarPedido;
                        owner.LimpiarPedido();
                    }
                    else throw new RestaurantException("No se ha creado el pedido correctamente. Intente de nuevo");
                }
                catch (Exception ex) { Cálculos.MsgBox(ex.Message); }
                this.Close();
            }
           
        }
        private bool Nuevo()
        {
            return oBLL_Pedido.Guardar(oBE_Pedido);
        }

       
        private void ImportarPedido()
        {
            if (oBE_Pedido != null)
            {
                foreach(BE_Bebida beb in oBE_Pedido.ListadeBebida)
                {
                    Button botonBebida = CrearBotonBebida(beb);
                    flowBebidas.Controls.Add(botonBebida);
                }
                Aspecto.CentrarPanel(grpNuevoLogin, flowBebidas,btnIzquierdaBebidas,btnDerechaBebidas);
                foreach (BE_Plato pla in oBE_Pedido.ListadePlatos)
                {
                    Button botonPlato = CrearBotonPlato(pla);
                    flowPlatos.Controls.Add(botonPlato);
                }
                Aspecto.CentrarPanel(grpNuevoLogin, flowPlatos,btnIzquierdaPlatos, btnDerechaPlatos);
                lblCosto.Text = oBE_Pedido.Monto_Total.ToString("$0.00");
                Aspecto.CentrarLabelenGRP(grpNuevoLogin,lblCosto);
                Aspecto.CentrarLabelenGRP(grpNuevoLogin, lblMonto);
            }
        }

        private void frmNuevoLogin_Load(object sender, EventArgs e)
        {
            ImportarPedido();
        }
        private Button CrearBotonBebida(BE_Bebida bebida)
        {
            Button botonBebida = new Button();
            botonBebida.Text = bebida.Nombre;
            botonBebida.Font = new Font("Nirmala UI", 10, FontStyle.Regular);
            botonBebida.TextAlign = ContentAlignment.BottomCenter;
            botonBebida.TextImageRelation = TextImageRelation.ImageAboveText;
            botonBebida.Width = 80;
            botonBebida.Height = 80;
            botonBebida.Tag = bebida;
            botonBebida.Anchor = AnchorStyles.None;
            GuardaFotos.CargarImagen(bebida.ToString(), botonBebida);
            botonBebida.BackgroundImageLayout = ImageLayout.Stretch;
            return botonBebida;
        }
        private Button CrearBotonPlato(BE_Plato plato)
        {
            Button botonPlato = new Button();
            botonPlato.Text = plato.Nombre;
            botonPlato.Font = new Font("Nirmala UI", 10, FontStyle.Regular);
            botonPlato.TextAlign = ContentAlignment.BottomCenter;
            botonPlato.TextImageRelation = TextImageRelation.ImageAboveText;
            botonPlato.Width = 80;
            botonPlato.Height = 80;
            botonPlato.Tag = plato;
            botonPlato.Anchor = AnchorStyles.None;
            GuardaFotos.CargarImagen(plato.ToString(), botonPlato);
            botonPlato.BackgroundImageLayout = ImageLayout.Stretch;
            return botonPlato;
        }

        private void btnDerechaPlatos_Click(object sender, EventArgs e)
        {
            int scroll = flowPlatos.HorizontalScroll.Value + (flowPlatos.HorizontalScroll.SmallChange*5);
            flowPlatos.AutoScrollPosition = new Point(scroll, 0);      
        }

        private void btnDerechaBebidas_Click(object sender, EventArgs e)
        {
            int scroll = flowBebidas.HorizontalScroll.Value + (flowBebidas.HorizontalScroll.SmallChange * 5);
            flowBebidas.AutoScrollPosition = new Point(scroll, 0);
        }
        private void btnIzquierdaPlatos_Click(object sender, EventArgs e)
        {
            int scroll = flowPlatos.HorizontalScroll.Value - (flowPlatos.HorizontalScroll.SmallChange * 5);
            flowPlatos.AutoScrollPosition = new Point(scroll, 0);
        }

        private void btnIzquierdaBebidas_Click(object sender, EventArgs e)
        {
            int scroll = flowBebidas.HorizontalScroll.Value - (flowBebidas.HorizontalScroll.SmallChange * 5);
            flowBebidas.AutoScrollPosition = new Point(scroll, 0);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            frmTomarPedido owner = this.Owner as frmTomarPedido;
            owner.LimpiarPedido();
            this.Close();
        }
    }
}
