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
    public partial class frmIngredientes : Form
    {
        BLL_Ingrediente oBLL_Ingrediente;
        BE_Ingrediente oBE_Ingrediente;
        private List<BE_Ingrediente> listado;
        Reemplazos rm;
        public frmIngredientes()
        {
            InitializeComponent();
            oBLL_Ingrediente = new BLL_Ingrediente();
            oBE_Ingrediente = new BE_Ingrediente();
            Aspecto.FormatearGRP(grpIngredientes);
            Aspecto.FormatearGRPAccion(grpAcciones);
            Aspecto.FormatearDGV(dgvIngredientes);
            CargarComboFiltro();
            ActualizarListado();
        }
        public void ActualizarListado()
        {
            Cálculos.RefreshGrilla(dgvIngredientes, oBLL_Ingrediente.Listar());
            chkOcultar.Checked = false;
        }
        public void Centrar()
        {
            VistasDGV.dgvIngredientes(dgvIngredientes);
            Aspecto.CentrarDGV(this, dgvIngredientes);
        }
        private void CargarComboFiltro()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>
            {
                {"Nombre", "Nombre"},
                {"Status", "Status" },
                {"Tipo de Ingrediente", "Tipo" }
            };
            rm = new Reemplazos(dict);
            Cálculos.DataSourceCombo(comboFiltro, rm.ListadoClaves(), "Filtros");
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmNuevoIngrediente frm = new frmNuevoIngrediente();
            frm.ShowDialog();
            ActualizarListado();
            listado = (List<BE_Ingrediente>)dgvIngredientes.DataSource;
            Centrar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmNuevoIngrediente frm = new frmNuevoIngrediente();
            frm.oBE_Ingrediente = oBE_Ingrediente;
            frm.ShowDialog();
            ActualizarListado();
            listado = (List<BE_Ingrediente>)dgvIngredientes.DataSource;
            Centrar();
        }
        private void dgvIngredientes_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                oBE_Ingrediente = (BE_Ingrediente)dgvIngredientes.SelectedRows[0].DataBoundItem;
            }
            catch { }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Cálculos.EstaSeguroE(oBE_Ingrediente.ToString()))
                {
                    if (oBLL_Ingrediente.Baja(oBE_Ingrediente))
                    {
                        Cálculos.MsgBox("Se ha efectuado la baja satisfactoriamente");
                        ActualizarListado();
                        listado = (List<BE_Ingrediente>)dgvIngredientes.DataSource;
                        Centrar();
                    }
                    else { throw new RestaurantException("La baja ha fallado, por favor, intente nuevamente"); }
                }
                else { throw new RestaurantException("La baja se ha cancelado."); }
                
            }
            catch (Exception ex)
            {
                Cálculos.MsgBox(ex.Message);
            }
           
        }

        private void btnResetPass_Click(object sender, EventArgs e)
        {
            MessageBox.Show(oBE_Ingrediente.DevolverNombre());
        }

        private void frmIngredientes_Load(object sender, EventArgs e)
        {
            listado = (List<BE_Ingrediente>)dgvIngredientes.DataSource;
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            if (txtFiltro.Text.Length > 0 && comboFiltro.SelectedIndex != -1)
            {
                Cálculos.RefreshGrilla(dgvIngredientes, listado);
                string filtro = txtFiltro.Text;
                string Variable = rm.Reemplazar(comboFiltro.Text);
                List<BE_Ingrediente> filtrada = ((List<BE_Ingrediente>)dgvIngredientes.DataSource).Where(x => Cálculos.GetPropertyValue(x, Variable).ToString().Contains(Cálculos.Capitalize(filtro))).ToList();
                Cálculos.RefreshGrilla(dgvIngredientes, filtrada);
                Centrar();
                comboFiltro.Text = "";
                txtFiltro.Text = "";
                chkOcultar.Checked = false;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Cálculos.RefreshGrilla(dgvIngredientes, listado);
            Centrar();
            chkOcultar.Checked = false;
        }

        private void frmIngredientes_Shown(object sender, EventArgs e)
        {
            Centrar();
        }

        private void frmIngredientes_Activated(object sender, EventArgs e)
        {
            Centrar();
        }

        private void chkOcultar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOcultar.Checked)
            {
                Cálculos.RefreshGrilla(dgvIngredientes, listado);
                List<BE_Ingrediente> filtrada = ((List<BE_Ingrediente>)dgvIngredientes.DataSource).Where(x => x.Activo).ToList();
                Cálculos.RefreshGrilla(dgvIngredientes, filtrada);
                Centrar();
            }
            else
            {
                Cálculos.RefreshGrilla(dgvIngredientes, listado);
                Centrar();
            }
        }
    }
}
