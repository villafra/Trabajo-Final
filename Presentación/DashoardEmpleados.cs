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
    public partial class frmDashEmpleados : Form
    {
        List<Dash_Asistencia> dashs_Asistencia;
        List<Dash_Motivos> dashs_Motivos;
        BLL_Dash_Asistencia dashA;
        BLL_Dash_Motivos dashM;
        public frmDashEmpleados()
        {
            InitializeComponent();
            dashs_Asistencia = new List<Dash_Asistencia>();
            dashs_Motivos = new List<Dash_Motivos>();
            dashA = new BLL_Dash_Asistencia();
            dashM = new BLL_Dash_Motivos();
            dtpInicio.Value = DateTime.Now.AddDays(-35);
            dtpFin.Value = DateTime.Now;

        }
        public void ActualizarListado()
        {
            dashs_Asistencia = dashA.Listar(dtpInicio.Value, dtpFin.Value);
            dashs_Motivos = dashM.Listar(dtpInicio.Value, dtpFin.Value);
            GraficarAsis();
            GraficarMotivos();
            Aspecto.FormatearChartAsist(chartAsist);
            Aspecto.FormatearChartAsist(chartInasist);
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
        private void GraficarAsis()
        {
            chartAsist.Series.Add("Empleados");
            chartAsist.Series[0].XValueMember = "Empleado";
            foreach(var dato in dashs_Asistencia)
            {
                chartAsist.Series["Empleados"].Points.AddXY(dato.Empleado, dato.Asistencias);
            }

        }
        private void GraficarMotivos()
        {
            chartInasist.Series.Add("Inasistencias");
            chartInasist.Series[0].XValueMember = "Motivo";
            foreach(var dato in dashs_Motivos)
            {
                if (dato.Cantidad > 0)
                chartInasist.Series[0].Points.AddXY(dato.Motivo, dato.Cantidad);
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
            chartAsist.Series.Clear();
            chartInasist.Series.Clear();
        }

        private void btnRango_Click(object sender, EventArgs e)
        {
            Initialice();
            ActualizarListado();
        }
    }
}
