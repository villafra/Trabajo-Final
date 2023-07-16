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
using Service_Layer;

namespace Trabajo_Final
{
    public partial class frmCombinarMesas : Form
    {
        BLL_Mesa oBLL_Mesa;
        BE_Mesa oBE_Mesa;
        private List<BE_Mesa> listado;
        public frmCombinarMesas()
        {
            InitializeComponent();
            oBLL_Mesa = new BLL_Mesa();
            oBE_Mesa = new BE_Mesa();
            Aspecto.FormatearGRP(grpMesas);
            Aspecto.FormatearGRPAccion(grpAcciones);
            Aspecto.FormatearDGV(dgvMesas);
            ActualizarListado();
        }
        public void ActualizarListado()
        {
            Cálculos.RefreshGrilla(dgvMesas, oBLL_Mesa.ListarLibres());
            dgvMesas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        public void Centrar()
        {
            VistasDGV.dgvMesasLibres(dgvMesas);
            Aspecto.CentrarDGV(this, dgvMesas);
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmNuevaCombMesa frm = new frmNuevaCombMesa();
            frm.oBE_Mesa = oBE_Mesa;
            frm.ShowDialog();
            ActualizarListado();
            Centrar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (oBLL_Mesa.DescombinarMesa(oBE_Mesa as BE_MesaCombinada))
                {
                    ActualizarListado();
                    Centrar();
                    Cálculos.MsgBox("Las mesas se han descombinado satisfactoriamente.");
                }
                else { throw new RestaurantException("La mesa seleccionada no es combinada."); }
            }
            catch(Exception ex) { Cálculos.MsgBox(ex.Message); }
        }

        private void dgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if ((BE_Mesa)dgvMesas.SelectedRows[0].DataBoundItem is BE_MesaCombinada)
                {
                    oBE_Mesa = (BE_MesaCombinada)dgvMesas.SelectedRows[0].DataBoundItem;
                }
                else oBE_Mesa = (BE_Mesa)dgvMesas.SelectedRows[0].DataBoundItem;
                
            }
            catch { }

        }
        private void frmCombinarMesas_Load(object sender, EventArgs e)
        {
            listado = (List<BE_Mesa>)dgvMesas.DataSource;
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            if (txtFiltro.Text.Length > 0)
            {
                Cálculos.RefreshGrilla(dgvMesas, listado);
                string filtro = txtFiltro.Text;
                string Variable = comboFiltro.Text;
                List<BE_Mesa> filtrada = ((List<BE_Mesa>)dgvMesas.DataSource).Where(x => Cálculos.GetPropertyValue(x, Variable).ToString().Contains(Cálculos.Capitalize(filtro))).ToList();
                Cálculos.RefreshGrilla(dgvMesas, filtrada);
                Centrar();
                comboFiltro.Text = "";
                txtFiltro.Text = "";
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Cálculos.RefreshGrilla(dgvMesas, listado);
            Centrar();
        }

        private void frmCombinarMesas_Activated(object sender, EventArgs e)
        {
            Centrar();
        }

        private void frmCombinarMesas_Shown(object sender, EventArgs e)
        {
            Centrar();
        }
    }
}
