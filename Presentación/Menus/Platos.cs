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
    public partial class frmPlatos : Form
    {
        BLL_Plato oBLL_Plato;
        BE_Plato oBE_Plato;
        private List<BE_Plato> listado;
        Reemplazos rm;
        public frmPlatos()
        {
            InitializeComponent();
            oBLL_Plato = new BLL_Plato();
            oBE_Plato = new BE_Plato();
            Aspecto.FormatearGRP(grpPlatos);
            Aspecto.FormatearGRPAccion(grpAcciones);
            Aspecto.FormatearDGV(dgvPlatos);
            CargarComboFiltro();
            ActualizarListado();
        }
        public void ActualizarListado()
        {
            Cálculos.RefreshGrilla(dgvPlatos, oBLL_Plato.Listar());
            chkOcultar.Checked = false;
        }
        public void Centrar()
        {
            VistasDGV.dgvPlatos(dgvPlatos);
            Aspecto.CentrarDGV(this, dgvPlatos);
        }
        private void CargarComboFiltro()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>
            {
                {"Nombre del Plato", "Nombre"},
                {"Tipo de Plato", "Tipo" },
                {"Clase de Plato", "Clase" }
            };
            rm = new Reemplazos(dict);
            Cálculos.DataSourceCombo(comboFiltro, rm.ListadoClaves(), "Filtros");
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmNuevoPlato frm = new frmNuevoPlato();
            frm.ShowDialog();
            ActualizarListado();
            Centrar();
            listado = (List<BE_Plato>)dgvPlatos.DataSource;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmNuevoPlato frm = new frmNuevoPlato();
            frm.oBE_Plato = oBE_Plato;
            frm.ShowDialog();
            ActualizarListado();
            Centrar();
            listado = (List<BE_Plato>)dgvPlatos.DataSource;
        }

        private void dgvIngredientes_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                oBE_Plato = (BE_Plato)dgvPlatos.SelectedRows[0].DataBoundItem;
            }
            catch { }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Cálculos.EstaSeguroE(oBE_Plato.ToString()))
                {
                    if (oBLL_Plato.Baja(oBE_Plato))
                    {
                        Cálculos.MsgBox("La baja se ha efectuado satisfactoriamente.");
                        ActualizarListado();
                        Centrar();
                        listado = (List<BE_Plato>)dgvPlatos.DataSource;
                    }
                    else { throw new RestaurantException("La baja ha fallado, por favor, intente nuevamente"); }
                }
                else { throw new RestaurantException("La baja se ha cancelado."); }
            }
            catch (Exception ex) { Cálculos.MsgBox(ex.Message); }

        }

        private void frmPlatos_Load(object sender, EventArgs e)
        {
            listado = (List<BE_Plato>)dgvPlatos.DataSource;
        }

        private void frmPlatos_Shown(object sender, EventArgs e)
        {
            Centrar();
        }

        private void frmPlatos_Activated(object sender, EventArgs e)
        {
            Centrar();
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            if (txtFiltro.Text.Length > 0 && comboFiltro.SelectedIndex != -1)
            {
                Cálculos.RefreshGrilla(dgvPlatos, listado);
                string filtro = txtFiltro.Text;
                string Variable = rm.Reemplazar(comboFiltro.Text);
                List<BE_Plato> filtrada = ((List<BE_Plato>)dgvPlatos.DataSource).Where(x => Cálculos.GetPropertyValue(x, Variable).ToString().Contains(Cálculos.Capitalize(filtro))).ToList();
                Cálculos.RefreshGrilla(dgvPlatos, filtrada);
                Centrar();
                comboFiltro.Text = "";
                txtFiltro.Text = "";
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Cálculos.RefreshGrilla(dgvPlatos, listado);
            Centrar();
            chkOcultar.Checked = false;
        }

        private void btnCargarImagen_Click(object sender, EventArgs e)
        {
            try
            {
                if (Cálculos.CargarFoto(oBE_Plato.Nombre))
                {
                    if (oBLL_Plato.CargarImágen(oBE_Plato))
                    {
                        Cálculos.MsgBox("Se ha añadido la imágen satisfactoriamente.");
                    }
                    else { throw new RestaurantException("La carga de la imáge ha fallado, por favor, intente nuevamente."); }
                }
                else { throw new RestaurantException("Se ha cancelado la carga de la imágen."); }
            }
            catch (Exception ex) { Cálculos.MsgBox(ex.Message); }
        }

        private void chkOcultar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOcultar.Checked)
            {
                Cálculos.RefreshGrilla(dgvPlatos, listado);
                List<BE_Plato> filtrada = ((List<BE_Plato>)dgvPlatos.DataSource).Where(x => x.Activo).ToList();
                Cálculos.RefreshGrilla(dgvPlatos, filtrada);
                Centrar();
            }
            else
            {
                Cálculos.RefreshGrilla(dgvPlatos, listado);
                Centrar();
            }
        }

        private void btnReactivar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Cálculos.QuiereReactivar("Bebida"))
                {
                    if (oBE_Plato != null && !oBE_Plato.Activo)
                    {
                        oBE_Plato.Activo = true;
                        if (oBLL_Plato.Modificar(oBE_Plato))
                        {
                            ActualizarListado();
                            Centrar();
                            listado = (List<BE_Plato>)dgvPlatos.DataSource;
                            Cálculos.MsgBox("La Plato se ha reactivado satisfactoriamente");
                        }
                        else { throw new RestaurantException("La reactivación ha fallado, por favor, intente nuevamente"); }
                    }
                }
                else { throw new RestaurantException("Se ha cancelado la reactivación"); }
            }
            catch (Exception ex) { Cálculos.MsgBox(ex.Message); }
        }
    }
}
