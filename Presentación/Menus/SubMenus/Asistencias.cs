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
    public partial class frmAsistencias : Form
    {

        public BE_Empleado oBE_Empleado;
        public BE_Novedad oBE_Novedad;
        BE_Asistencia oBE_Asistencia;
        BLL_Empleado oBLL_Empleado;
        BLL_Asistencia oBLL_Asistencia;
        BLL_Novedad oBLL_Novedad;
        public frmAsistencias()
        {
            InitializeComponent();
            oBLL_Asistencia = new BLL_Asistencia();
            oBLL_Empleado = new BLL_Gerente_Sucursal();
            oBLL_Novedad = new BLL_Novedad();
            Aspecto.FormatearSubMenu(this, grpNuevoLogin, this.Width, this.Height);
            Cálculos.DataSourceCombo(comboEmpleado, oBLL_Empleado.Listar(), "Categoría");
            Cálculos.DataSourceCombo(comboMotivo, Enum.GetValues(typeof(Inasistencia)),"Motivo");
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validaciones())
                {
                    if (Nuevo()) Cálculos.MsgBox("Los datos se han guardado correctamente");
                    else throw new RestaurantException("La carga de datos ha fallado. Intente Nuevamente.");
                }
                else { throw new RestaurantException("La fecha o hora de inicio es mayor que la fecha o hora de fin."); }
            }
            catch (Exception ex) { Cálculos.MsgBox(ex.Message); }
        }

        private bool Nuevo()
        {
            oBE_Empleado = (BE_Empleado)comboEmpleado.SelectedItem;
            oBE_Asistencia = new BE_Asistencia();
            if (oBLL_Novedad.ExisteNovedad(oBE_Empleado))
            {
                oBE_Novedad = new BE_Novedad();
                oBE_Novedad.Empleado = oBE_Empleado;
                oBLL_Novedad.Guardar(oBE_Novedad);
                oBE_Asistencia.Novedad =  oBLL_Novedad.Novedad_Empleado(oBE_Empleado);
            }
            else { oBE_Asistencia.Novedad = oBE_Novedad; }
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
            }
            if (dtpFechaInicio.Value.Date == dtpFechaFin.Value.Date)
            {
                
                oBE_Asistencia.Fecha = dtpFechaInicio.Value;
                if (oBE_Asistencia.Motivo == Inasistencia.Vacaciones)
                {
                    return oBLL_Asistencia.Guardar(oBE_Asistencia) & oBLL_Novedad.DescontarVacaciones(oBE_Novedad,1);
                }
                else return oBLL_Asistencia.Guardar(oBE_Asistencia);
            }
            else
            {
                if (oBE_Asistencia.Motivo == Inasistencia.Vacaciones)
                {
                    return oBLL_Asistencia.CompletarAsistencias(oBE_Asistencia, dtpFechaInicio.Value, dtpFechaFin.Value) &
                        oBLL_Novedad.DescontarVacaciones(oBE_Novedad,dtpFechaInicio.Value,dtpFechaFin.Value);
                }
                else return oBLL_Asistencia.CompletarAsistencias(oBE_Asistencia, dtpFechaInicio.Value, dtpFechaFin.Value);
            }
            
            
        }
        private void ImportarEmpleado()
        {
            if (oBE_Empleado != null)
            {
                txtCodigo.Text = oBE_Empleado.Codigo.ToString();
                comboEmpleado.Text = oBE_Empleado.ToString();
            }
        }
  
        private void frmNuevoLogin_Load(object sender, EventArgs e)
        {
            ImportarEmpleado();
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
        private void dtpFechaInicio_ValueChanged(object sender, EventArgs e)
        {
            dtpFechaFin.Value = dtpFechaInicio.Value;
        }
        private bool Validaciones()
        {
            bool pass;
            pass = dtpFechaInicio.Value <= dtpFechaFin.Value;
            if (!pass) return false; 
            pass = dtpHoraIngreso.Value <= dtpHoraEgreso.Value;
            return pass;
        }
    }
}
