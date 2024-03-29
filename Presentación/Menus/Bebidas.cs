﻿using System;
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
    public partial class frmBebidas : Form
    {
        BLL_Bebida oBLL_Bebida;
        BE_Bebida oBE_Bebida;
        private List<BE_Bebida> listado;
        Reemplazos rm;
        public frmBebidas()
        {
            InitializeComponent();
            oBLL_Bebida = new BLL_Bebida();
            oBE_Bebida = new BE_Bebida();
            Aspecto.FormatearGRP(grpBebidas);
            Aspecto.FormatearGRPAccion(grpAcciones);
            Aspecto.FormatearDGV(dgvBebidas);
            CargarComboFiltro();
            ActualizarListado();
        }
        public void ActualizarListado()
        {
            Cálculos.RefreshGrilla(dgvBebidas, oBLL_Bebida.Listar());
            chkOcultar.Checked = false;
        }
        public void Centrar()
        {
            VistasDGV.dgvBebidas(dgvBebidas);
            Aspecto.CentrarDGV(this, dgvBebidas);
        }
        private void CargarComboFiltro()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>
            {
                {"Nombre", "Nombre"},
                {"Tipo de Bebida", "Tipo" },
                {"Presentación", "Presentacion" }
            };
            rm = new Reemplazos(dict);
            Cálculos.DataSourceCombo(comboFiltro, rm.ListadoClaves(), "Filtros");
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmNuevaBebida frm = new frmNuevaBebida();
            frm.ShowDialog();
            ActualizarListado();
            Centrar();
            listado = (List<BE_Bebida>)dgvBebidas.DataSource;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmNuevaBebida frm = new frmNuevaBebida();
            frm.oBE_Bebida = oBE_Bebida;
            frm.ShowDialog();
            ActualizarListado();
            Centrar();
            listado = (List<BE_Bebida>)dgvBebidas.DataSource;
        }

        private void dgvIngredientes_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                oBE_Bebida = (BE_Bebida)dgvBebidas.SelectedRows[0].DataBoundItem;
            }
            catch { }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Cálculos.EstaSeguroE(oBE_Bebida.ToString()))
                {
                    if (oBLL_Bebida.Baja(oBE_Bebida))
                    {
                        ActualizarListado();
                        Centrar();
                        listado = (List<BE_Bebida>)dgvBebidas.DataSource;
                        Cálculos.MsgBox("La baja se ha efectuado satisfactoriamente");
                    }
                    else { throw new RestaurantException("La baja ha fallado, por favor, intente nuevamente"); }
                }
                else { throw new RestaurantException("La baja se ha cancelado."); }
            }
            catch (Exception ex) { Cálculos.MsgBox(ex.Message); }

        }
        private void frmBebidas_Load(object sender, EventArgs e)
        {
            listado = (List<BE_Bebida>)dgvBebidas.DataSource;
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            if (txtFiltro.Text.Length > 0 && comboFiltro.SelectedIndex != -1)
            {
                Cálculos.RefreshGrilla(dgvBebidas, listado);
                string filtro = txtFiltro.Text;
                string Variable = rm.Reemplazar(comboFiltro.Text);
                List<BE_Bebida> filtrada = ((List<BE_Bebida>)dgvBebidas.DataSource).Where(x => Cálculos.GetPropertyValue(x, Variable).ToString().Contains(Cálculos.Capitalize(filtro))).ToList();
                Cálculos.RefreshGrilla(dgvBebidas, filtrada);
                Centrar();
                comboFiltro.Text = "";
                txtFiltro.Text = "";
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Cálculos.RefreshGrilla(dgvBebidas, listado);
            Centrar();
            chkOcultar.Checked = false;
        }

        private void frmBebidas_Activated(object sender, EventArgs e)
        {
            Centrar();
        }

        private void frmBebidas_Shown(object sender, EventArgs e)
        {
            Centrar();
        }

        private void btnCargarImagen_Click(object sender, EventArgs e)
        {
            try
            {
                if (Cálculos.CargarFoto(oBE_Bebida.Nombre))
                {
                    if (oBLL_Bebida.CargarImágen(oBE_Bebida))
                    {
                        Cálculos.MsgBox("Se ha añadido la imágen satisfactoriamente.");
                    }
                    else { throw new RestaurantException("La carga de la imáge ha fallado, por favor, intente nuevamente."); }
                }
                else { throw new RestaurantException("Se ha cancelado la carga de la imágen."); }
            }
            catch(Exception ex) { Cálculos.MsgBox(ex.Message); }
        }

        private void chkOcultar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOcultar.Checked)
            {
                Cálculos.RefreshGrilla(dgvBebidas, listado);
                List<BE_Bebida> filtrada = ((List<BE_Bebida>)dgvBebidas.DataSource).Where(x => x.Activo).ToList();
                Cálculos.RefreshGrilla(dgvBebidas, filtrada);
                Centrar();
            }
            else
            {
                Cálculos.RefreshGrilla(dgvBebidas, listado);
                Centrar();
            }
        }

        private void btnReactivar_Click(object sender, EventArgs e)
        {
            try
            {
                if(Cálculos.QuiereReactivar("Bebida"))
                {
                    if (oBE_Bebida != null && !oBE_Bebida.Activo)
                    {
                        oBE_Bebida.Activo = true;
                        if (oBLL_Bebida.Modificar(oBE_Bebida))
                        {
                            ActualizarListado();
                            Centrar();
                            listado = (List<BE_Bebida>)dgvBebidas.DataSource;
                            Cálculos.MsgBox("La Bebida se ha reactivado satisfactoriamente");
                        }
                        else { throw new RestaurantException("La reactivación ha fallado, por favor, intente nuevamente"); }
                    }
                }
                else { throw new RestaurantException("Se ha cancelado la reactivación"); }
            }
            catch(Exception ex) { Cálculos.MsgBox(ex.Message); }
        }
    }
}
