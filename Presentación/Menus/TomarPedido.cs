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
using Business_Logic_Layer;

namespace Trabajo_Final
{
    public partial class frmTomarPedido : Form
    {
        List<BE_Plato_Stock> platos;
        List<BE_Bebida_Stock> bebidas;
        BLL_Plato_Stock oBLL_Plato;
        BLL_Bebida_Stock oBLL_Bebida;
        BE_Pedido oBE_Pedido;
        BLL_Pedido oBLL_Pedido;
        private BE_Login usuario;
        public frmTomarPedido(BE_Login usuarioActivo)
        {
            InitializeComponent();
            usuario = usuarioActivo;
            oBLL_Bebida = new BLL_Bebida_Stock();
            oBLL_Plato = new BLL_Plato_Stock();
            oBLL_Pedido = new BLL_Pedido();
            platos = new List<BE_Plato_Stock>();
            bebidas = new List<BE_Bebida_Stock>();
            Aspecto.FormatearFLowPanel(flowBebidas);
            Aspecto.FormatearFLowPanel(flowPlatos);
            Aspecto.FormatearFLowPanel(flowPedido);
           
        }
        public void ActualizarListado()
        {
            foreach (BE_Plato_Stock plato in oBLL_Plato.ListarConStock())
            {
                Button botonPlato = CrearBotonPlato(plato);
                flowPlatos.Controls.Add(botonPlato);
            }
            foreach(BE_Bebida_Stock bebida in oBLL_Bebida.ListarConStock())
            {
                Button botonBebida = CrearBotonBebida(bebida);
                flowBebidas.Controls.Add(botonBebida);
            }
        }
        private void frmBienvenida_MouseDown(object sender, MouseEventArgs e)
        {
            Aspecto.ReleaseCapture();
            Aspecto.SendMessage(this.MdiParent.Handle, 0x112, 0xf012, 0);
        }

        private void picboxPrincipal_MouseDown(object sender, MouseEventArgs e)
        {
            Aspecto.ReleaseCapture();
            Aspecto.SendMessage(this.MdiParent.Handle, 0x112, 0xf012, 0);
        }
        private Button CrearBotonPlato(BE_Plato_Stock plato)
        {
            Button botonPlato = new Button();
            botonPlato.Text = plato.Material.Nombre;
            botonPlato.Font = new Font("Nirmala UI", 10, FontStyle.Regular);
            botonPlato.TextAlign = ContentAlignment.BottomCenter;
            botonPlato.TextImageRelation = TextImageRelation.ImageAboveText;
            botonPlato.Width = 240;
            botonPlato.Height = 250;
            botonPlato.Click += BotonPlato_Click;
            botonPlato.Tag = plato;
            return botonPlato;
        }
        private Button CrearBotonPedido(BE_Plato_Stock plato)
        {
            Button botonPlato = new Button();
            botonPlato.Text = plato.Material.Nombre;
            botonPlato.Font = new Font("Nirmala UI", 12, FontStyle.Bold);
            botonPlato.ForeColor = Color.Red;
            botonPlato.TextAlign = ContentAlignment.BottomRight;
            botonPlato.TextImageRelation = TextImageRelation.ImageAboveText;
            botonPlato.Width = 240;
            botonPlato.Height = 250;
            botonPlato.MouseDown += BotonPedido_MouseDown;
            botonPlato.Tag = plato;
            return botonPlato;
        }
        private Button CrearBotonPedido(BE_Bebida_Stock bebida)
        {
            Button botonBebida = new Button();
            botonBebida.Text = bebida.Material.Nombre;
            botonBebida.Font = new Font("Nirmala UI", 12, FontStyle.Bold);
            botonBebida.ForeColor = Color.Red;
            botonBebida.TextAlign = ContentAlignment.BottomRight;
            botonBebida.TextImageRelation = TextImageRelation.ImageAboveText;
            botonBebida.Width = 240;
            botonBebida.Height = 250;
            botonBebida.MouseDown += BotonPedido_MouseDown;
            botonBebida.Tag = bebida;
            return botonBebida;
        }
        private void BotonPlato_Click(object sender, EventArgs e)
        {

            Button botonPlato = (Button)sender;
            BE_Plato_Stock plato = (BE_Plato_Stock)botonPlato.Tag;
            if (!platos.Contains(plato))
            {
                flowPedido.Controls.Add(CrearBotonPedido(plato));
                platos.Add(plato);
            }
            else{ Cálculos.MsgBox("Ya existe en pedido.");}
            
        }
        private Button CrearBotonBebida(BE_Bebida_Stock bebida)
        {
            Button botonBebida = new Button();
            botonBebida.Text = bebida.Material.Nombre;
            botonBebida.Font = new Font("Nirmala UI", 10, FontStyle.Regular);
            botonBebida.TextAlign = ContentAlignment.BottomCenter;
            botonBebida.TextImageRelation = TextImageRelation.ImageAboveText;
            botonBebida.Width = 240;
            botonBebida.Height = 250;
            botonBebida.Click += BotonBebida_Click;
            botonBebida.Tag = bebida;
            return botonBebida;
        }
        private void BotonBebida_Click(object sender, EventArgs e)
        {

            Button botonBebida = (Button)sender;
            BE_Bebida_Stock bebida = (BE_Bebida_Stock)botonBebida.Tag;
            if (!bebidas.Contains(bebida))
            {
                flowPedido.Controls.Add(CrearBotonPedido(bebida));
                bebidas.Add(bebida);
            }
            else { Cálculos.MsgBox("Ya existe en Pedido"); }
            
           
        }
        private void BotonPedido_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Button botonPedido = (Button)sender;
                if (botonPedido.Tag is BE_Bebida_Stock)
                {
                    int cantidad = bebidas.Count(x => x.Material.Codigo == ((BE_Bebida_Stock)botonPedido.Tag).Material.Codigo);
                    cantidad += 1;
                    bebidas.Add(((BE_Bebida_Stock)botonPedido.Tag));
                    botonPedido.Text = cantidad.ToString();
                }
                else
                {
                    int cantidad = platos.Count(x => x.Material.Codigo == ((BE_Plato_Stock)botonPedido.Tag).Material.Codigo);
                    cantidad += 1;
                    platos.Add(((BE_Plato_Stock)botonPedido.Tag));
                    botonPedido.Text = cantidad.ToString();
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                Button botonPedido = (Button)sender;

                if (botonPedido.Tag is BE_Bebida_Stock)
                {
                    int cantidad = bebidas.Count(x => x.Material.Codigo == ((BE_Bebida_Stock)botonPedido.Tag).Material.Codigo);
                    if (cantidad == 1)
                    {
                        flowPedido.Controls.Remove(botonPedido);
                    }
                    cantidad -= 1;
                    bebidas.Remove((BE_Bebida_Stock)botonPedido.Tag);
                    botonPedido.Text = cantidad.ToString();
                }
                else
                {
                    int cantidad = platos.Count(x => x.Material.Codigo == ((BE_Plato_Stock)botonPedido.Tag).Material.Codigo);
                    if (cantidad == 1)
                    {
                        flowPedido.Controls.Remove(botonPedido);
                    }
                    cantidad -= 1;
                    platos.Remove((BE_Plato_Stock)botonPedido.Tag);
                    botonPedido.Text = cantidad.ToString();
                }
            }
        }

        private void frmTomarPedido_Load(object sender, EventArgs e)
        {
            ActualizarListado();
        }
        private void ArmarPedido()
        {
            oBE_Pedido = new BE_Pedido();
            oBE_Pedido.ListadePlatos = oBLL_Pedido.AgregarPlatos(platos);
            oBE_Pedido.ListadeBebida = oBLL_Pedido.AgregarBebidas(bebidas);
            oBE_Pedido.Monto_Total = oBLL_Pedido.CalcularTotal(oBE_Pedido);
            oBE_Pedido.Status = StatusPedido.Liberado;
            oBE_Pedido.FechaInicio = DateTime.Now;
            oBE_Pedido.ID_Empleado = usuario.Empleado;
            oBLL_Pedido.Guardar(oBE_Pedido);

        }

        private void btnCrearOrden_Click(object sender, EventArgs e)
        {
            ArmarPedido();
        }
    }
}
