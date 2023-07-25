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
    public partial class frmDashVentas : Form
    {
        List<BE_Bebida> listado_Bebidas;
        List<BE_Plato> listado_Platos;
        List<BE_Pedido> listado_Pedidos;
        List<Dash_BebidasVentas> DashBebidas;
        List<Dash_PlatosVentas> DashPlatos;
        BLL_Dash_Ventas dashBP;
        Dash_BebidasVentas bebida;
        Dash_PlatosVentas plato;
        Dash_PedidoPromedio promedio;
        public frmDashVentas()
        {
            InitializeComponent();
            dashBP = new BLL_Dash_Ventas();
            dtpInicio.Value = DateTime.Now.AddDays(-35);
            dtpFin.Value = DateTime.Now;
            RecolectarDatos();
            Aspecto.FormatearGRP(grpDashBoard);
        }
        public void ActualizarListado()
        {
            GraficarPlato();
            GraficarBebidas();
            Aspecto.FormatearChartVentas(chartPlatos);
            Aspecto.FormatearChartVentas(chartBebidas);
            CompletarLabelAsistencia();
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
        private void GraficarPlato()
        {
            DashPlatos = dashBP.ListarPlatos(listado_Pedidos,listado_Platos, dtpInicio.Value, dtpFin.Value);
            chartPlatos.Series.Add("Platos");
            chartPlatos.Series[0].XValueMember = "Plato";
            foreach(var dato in DashPlatos)
            {
                chartPlatos.Series["Platos"].Points.AddXY(dato.Plato, dato.Cantidad);
            }

        }
        private void GraficarBebidas()
        {
            DashBebidas = dashBP.ListarBebidas(listado_Pedidos, listado_Bebidas, dtpInicio.Value, dtpFin.Value);
            chartBebidas.Series.Add("Bebidas");
            chartBebidas.Series[0].XValueMember = "Bebidd";
            foreach(var dato in DashBebidas)
            {
                if (dato.Cantidad > 0)
                chartBebidas.Series[0].Points.AddXY(dato.Bebida, dato.Cantidad);
            }
        }

        private void frmDashEmpleados_Load(object sender, EventArgs e)
        {
            ActualizarListado();
        }

        private void btn7dias_Click(object sender, EventArgs e)
        {
            Initialice();
            dtpInicio.Value = DateTime.Now.AddDays(-7);
            dtpFin.Value = DateTime.Now;
            ActualizarListado();
        }

        private void btn15_Click(object sender, EventArgs e)
        {
            Initialice();
            dtpInicio.Value = DateTime.Now.AddDays(-15);
            dtpFin.Value = DateTime.Now;
            ActualizarListado();
        }

        private void btnMes_Click(object sender, EventArgs e)
        {
            Initialice();
            dtpInicio.Value = DateTime.Now.AddDays(-30);
            dtpFin.Value = DateTime.Now;
            ActualizarListado();
        }

        private void btnAño_Click(object sender, EventArgs e)
        {
            Initialice();
            dtpInicio.Value = new DateTime(DateTime.Now.Year, 1, 1);
            dtpFin.Value = DateTime.Now;
            ActualizarListado();
        }
        private void Initialice()
        {
            chartPlatos.Series.Clear();
            chartBebidas.Series.Clear();
        }

        private void btnRango_Click(object sender, EventArgs e)
        {
            Initialice();
            ActualizarListado();
        }
        private void RecolectarDatos()
        {
            listado_Bebidas = dashBP.RecolectarBebidas();
            listado_Platos = dashBP.RecolectarPlatos();
            listado_Pedidos = dashBP.RecolectarPedidos();
        }
        private void CompletarLabelAsistencia()
        {
            plato = dashBP.MayorPlato(DashPlatos);
            lblMasPlato.Text = plato.Cantidad.ToString();
            Aspecto.CentrarLabel(panelMasPlato, lblMasPlato);
            lblNombrePlato.Text = plato.Plato;
            Aspecto.CentrarLabel(panelMasPlato, lblNombrePlato);
            bebida = dashBP.MayorBebida(DashBebidas);
            lblMasBebida.Text = bebida.Cantidad.ToString();
            Aspecto.CentrarLabel(panelMasBebida, lblMasBebida);
            lblNombreBebida.Text = bebida.Bebida;
            Aspecto.CentrarLabel(panelMasBebida, lblNombreBebida);
            promedio = dashBP.Promedio(listado_Pedidos);
            lblPromedio.Text = promedio.Promedio.ToString("$0.0");
            Aspecto.CentrarLabel(panelMotivo, lblPromedio);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RecolectarDatos();
            Initialice();
            ActualizarListado();
        }
    }
}
