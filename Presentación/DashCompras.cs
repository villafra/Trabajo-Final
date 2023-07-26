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
    public partial class frmDashCompras : Form
    {
        List<BE_Bebida> listado_Bebidas;
        List<BE_Ingrediente> listado_Ingredientes;
        List<BE_Compra> listado_Compras;
        List<Dash_Compras> DashBebidas;
        List<Dash_Compras> DashIngredientes;
        BLL_Dash_Compras dashBP;
        Dash_Compras bebida;
        Dash_Compras ingrediente;
        Dash_PedidoPromedio promedio;
        public frmDashCompras()
        {
            InitializeComponent();
            dashBP = new BLL_Dash_Compras();
            dtpInicio.Value = DateTime.Now.AddDays(-35);
            dtpFin.Value = DateTime.Now;
            RecolectarDatos();
            Aspecto.FormatearGRP(grpDashBoard);
        }
        public void ActualizarListado()
        {
            GraficarPlato();
            GraficarBebidas();
            Aspecto.FormatearChartCompras(chartIng);
            Aspecto.FormatearChartCompras(chartBebidas);
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
            DashIngredientes = dashBP.ListarIngrediente(listado_Compras,listado_Ingredientes, dtpInicio.Value, dtpFin.Value);
            chartIng.Series.Add("Ingredientes");
            chartIng.Series[0].XValueMember = "Ingrediente";
            foreach(var dato in DashIngredientes)
            {
                chartIng.Series["Ingredientes"].Points.AddXY(dato.Material, dato.Cantidad);
            }

        }
        private void GraficarBebidas()
        {
            DashBebidas = dashBP.ListarBebida(listado_Compras, listado_Bebidas, dtpInicio.Value, dtpFin.Value);
            chartBebidas.Series.Add("Bebidas");
            chartBebidas.Series[0].XValueMember = "Bebida";
            foreach(var dato in DashBebidas)
            {
                if (dato.Cantidad > 0)
                chartBebidas.Series[0].Points.AddXY(dato.Material, dato.Cantidad);
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
            chartIng.Series.Clear();
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
            listado_Ingredientes = dashBP.RecolectarIngredientes();
            listado_Compras = dashBP.RecolectarCompras();
        }
        private void CompletarLabelAsistencia()
        {
            ingrediente = dashBP.MayorIngrediente(DashIngredientes);
            lblMasPlato.Text = ingrediente.Cantidad.ToString();
            Aspecto.CentrarLabel(panelMasPlato, lblMasPlato);
            lblNombrePlato.Text = ingrediente.Material;
            Aspecto.CentrarLabel(panelMasPlato, lblNombrePlato);
            bebida = dashBP.MayorBebida(DashBebidas);
            lblMasBebida.Text = bebida.Cantidad.ToString();
            Aspecto.CentrarLabel(panelMasBebida, lblMasBebida);
            lblNombreBebida.Text = bebida.Material;
            Aspecto.CentrarLabel(panelMasBebida, lblNombreBebida);
            promedio = dashBP.PromedioCompra(listado_Compras);
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
