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
    public partial class frmModificarAsistencias : Form
    {

        public BE_Empleado oBE_Empleado;
        public BE_Novedad oBE_Novedad;
        public BE_Asistencia oBE_Asistencia;
        BLL_Empleado oBLL_Empleado;
        BLL_Asistencia oBLL_Asistencia;
        BLL_Novedad oBLL_Novedad;
        string asistencia = null;
        public frmModificarAsistencias()
        {
            InitializeComponent();
            oBLL_Asistencia = new BLL_Asistencia();
            oBLL_Empleado = new BLL_Gerente_Sucursal();
            oBLL_Novedad = new BLL_Novedad();
            Aspecto.FormatearSubMenu(this, grpNuevoLogin, this.Width, this.Height);
            Cálculos.DataSourceCombo(comboMotivo, Enum.GetValues(typeof(Inasistencia)),"Motivo");
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Nuevo()) Cálculos.MsgBox("Los datos se han guardado correctamente");
                else throw new RestaurantException("La carga de datos ha fallado. Intente Nuevamente.");
            }
            catch (Exception ex) { Cálculos.MsgBox(ex.Message); }
        }
        private bool Nuevo()
        {
            oBE_Asistencia.Asistencia = rdAsistencia.Checked;
            if (rdAsistencia.Checked)
            {
                oBE_Asistencia.HoraIngreso = dtpHoraIngreso.Value.TimeOfDay;
                oBE_Asistencia.HoraEgreso = dtpHoraEgreso.Value.TimeOfDay;
            }
            else
            {
                oBE_Asistencia.Motivo = (Inasistencia)comboMotivo.SelectedItem;
                oBE_Asistencia.HoraIngreso = TimeSpan.Zero;
                oBE_Asistencia.HoraEgreso = TimeSpan.Zero;
                if (oBE_Asistencia.Motivo == Inasistencia.Vacaciones)
                {
                    return oBLL_Asistencia.Modificar(oBE_Asistencia) & oBLL_Novedad.DescontarVacaciones(oBE_Novedad, 1);
                }
            }
                return oBLL_Asistencia.Modificar(oBE_Asistencia);
            
        }
        private void ImportarAsistencia()
        {
            if (oBE_Asistencia != null)
            {
                txtCodigo.Text = oBE_Asistencia.Codigo.ToString();
                asistencia = oBE_Asistencia.ToString();
            }
        }
        private void frmNuevoLogin_Load(object sender, EventArgs e)
        {
            ImportarAsistencia();
            Cálculos.DataSourceCombo(comboAsistencia, oBE_Novedad.listadoAsistencia, "Categoría");
            if (asistencia != null) comboAsistencia.Text = asistencia;
        }
        private void rdAsistencia_CheckedChanged(object sender, EventArgs e)
        {
            if (rdAsistencia.Checked)
            {
                lblMotivo.Visible = false;
                comboMotivo.Visible = false;
                lblHoraIngreso.Visible = true;
                dtpHoraIngreso.Visible = true;
                lblHoraFin.Visible = true;
                dtpHoraEgreso.Visible = true;
            }
        }
        private void rdInasistencia_CheckedChanged(object sender, EventArgs e)
        {
            if (rdInasistencia.Checked)
            {
                lblHoraIngreso.Visible = false;
                dtpHoraIngreso.Visible = false;
                lblHoraFin.Visible = false;
                dtpHoraEgreso.Visible = false;
                lblMotivo.Visible = true;
                comboMotivo.Visible = true;
            }
        }

        private void comboAsistencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                oBE_Asistencia = (BE_Asistencia)comboAsistencia.SelectedItem;
                if (oBE_Asistencia != null)
                {
                    txtCodigo.Text = oBE_Asistencia.Codigo.ToString();
                    dtpFechaInicio.Value = oBE_Asistencia.Fecha;
                }
                
            }
            catch { }
        }
    }
}
