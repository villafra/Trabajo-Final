using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business_Entities;
using Automate_Layer;
using Business_Logic_Layer;

namespace Trabajo_Final
{
    public partial class frmNovedades : Form
    {
        BE_Empleado oBE_Empleado;
        BLL_Novedad oBLL_Novedad;
        BE_Novedad oBE_Novedad;
        BE_Asistencia oBE_Asistencia;
        private List<BE_Novedad> listado;
        public frmNovedades()
        {
            InitializeComponent();
            Aspecto.FormatearGRP(grpNovedades);
            Aspecto.FormatearGRPAccion(grpAcciones);
            Aspecto.FormatearDGV(dgvNovedades);
            Aspecto.FormatearDGV(dgvAsistencias);
            ActualizarListado();
        }
        public void ActualizarListado()
        {
            oBLL_Novedad = new BLL_Novedad();
            Cálculos.RefreshGrilla(dgvNovedades, oBLL_Novedad.Listar());     
        }
        public void Centrar()
        {
            VistasDGV.dgvNovedades(dgvNovedades);
            VistasDGV.dgvAsistencias(dgvAsistencias);
        }
        public void Novedades()
        {
            Cálculos.RefreshGrilla(dgvAsistencias, oBE_Novedad.listadoAsistencia);
            VistasDGV.dgvAsistencias(dgvAsistencias);
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAsistencias frm = new frmAsistencias();
            frm.oBE_Empleado = oBE_Empleado;
            frm.oBE_Novedad = oBE_Novedad;
            frm.ShowDialog();
            ActualizarListado();
            Centrar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmModificarAsistencias frm = new frmModificarAsistencias();
            frm.oBE_Empleado = oBE_Empleado;
            frm.oBE_Novedad = oBE_Novedad;
            frm.oBE_Asistencia = oBE_Asistencia;
            frm.ShowDialog();
            ActualizarListado();
            Centrar();
        }


        private void dgvNovedades_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                oBE_Novedad =  (BE_Novedad)dgvNovedades.SelectedRows[0].DataBoundItem;
                Category categoria = oBE_Novedad.Empleado.Categoria;
                if ((int)categoria == 1)
                {
                    oBE_Empleado = (BE_GerenteSucursal)oBE_Novedad.Empleado;
                }
                else if ((int)categoria > 1 && (int)categoria < 6)
                {
                    oBE_Empleado = (BE_ChefPrincipal)oBE_Novedad.Empleado;
                }
                else
                {
                    oBE_Empleado = (BE_Mozo)oBE_Novedad.Empleado;
                }
                Novedades();
            }
            catch { }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            oBLL_Novedad.AsignarVacacionesXLey(oBE_Novedad);
            ActualizarListado();
            Centrar();
        }

        private void dgvAsistencias_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                oBE_Asistencia = (BE_Asistencia)dgvAsistencias.SelectedRows[0].DataBoundItem;
            }
            catch { }
        }

        private void frmNovedades_Load(object sender, EventArgs e)
        {
            listado = (List<BE_Novedad>)dgvNovedades.DataSource;
        }

        private void frmNovedades_Activated(object sender, EventArgs e)
        {
            Centrar();
        }

        private void frmNovedades_Shown(object sender, EventArgs e)
        {
            Centrar();
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            Cálculos.RefreshGrilla(dgvNovedades, listado);
            string filtro = txtFiltro.Text;
            string Variable = comboFiltro.Text;
            List<BE_Novedad> filtrada = ((List<BE_Novedad>)dgvNovedades.DataSource).Where(x => Cálculos.GetPropertyValue(x, Variable).ToString().Contains(Cálculos.Capitalize(filtro))).ToList();
            Cálculos.RefreshGrilla(dgvNovedades, filtrada);
            Centrar();
            comboFiltro.Text = "";
            txtFiltro.Text = "";
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Cálculos.RefreshGrilla(dgvNovedades, listado);
            Centrar();
        }
    }
}
