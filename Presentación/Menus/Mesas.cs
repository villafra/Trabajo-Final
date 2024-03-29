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
    public partial class frmMesas : Form
    {
        BLL_Mesa oBLL_Mesa;
        BE_Mesa oBE_Mesa;
        private List<BE_Mesa> listado;
        Reemplazos rm;
        public frmMesas()
        {
            InitializeComponent();
            oBLL_Mesa = new BLL_Mesa();
            oBE_Mesa = new BE_Mesa();
            Aspecto.FormatearGRP(grpMesas);
            Aspecto.FormatearGRPAccion(grpAcciones);
            Aspecto.FormatearDGV(dgvMesas);
            CargarComboFiltro();
            ActualizarListado();
        }
        public void ActualizarListado()
        {
            Cálculos.RefreshGrilla(dgvMesas, oBLL_Mesa.Listar());
        }
        public void Centrar()
        {
            VistasDGV.dgvMesas(dgvMesas);
            Aspecto.CentrarDGV(this, dgvMesas);
        }
        private void CargarComboFiltro()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>
            {
                {"Capacidad", "Capacidad"},
                {"Ubicación", "Ubicacion" },
                {"Status", "Status" },
                {"Empleado a Cargo", "ID_Empleado" }
            };
            rm = new Reemplazos(dict);
            Cálculos.DataSourceCombo(comboFiltro, rm.ListadoClaves(), "Filtros");
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmNuevaMesa frm = new frmNuevaMesa();
            frm.ShowDialog();
            ActualizarListado();
            Centrar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmNuevaMesa frm = new frmNuevaMesa();
            frm.oBE_Mesa = oBE_Mesa;
            frm.ShowDialog();
            ActualizarListado();
            Centrar();
        }
        private void dgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                oBE_Mesa = (BE_Mesa)dgvMesas.SelectedRows[0].DataBoundItem;
            }
            catch { }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Cálculos.EstaSeguroE(oBE_Mesa.ToString()))
                {
                    if (oBLL_Mesa.Baja(oBE_Mesa))
                    {
                        Cálculos.MsgBox("La baja se ha efectuado satisfactoriamente.");
                        ActualizarListado();
                        Centrar();
                    }
                    else { throw new RestaurantException("La baja ha fallado, por favor, intente nuevamente"); }
                }
                else { throw new RestaurantException("La baja ha sido cancelada."); }
            }
            catch (Exception ex) { Cálculos.MsgBox(ex.Message); }
        }

        private void frmMesas_Load(object sender, EventArgs e)
        {
            listado = (List<BE_Mesa>)dgvMesas.DataSource;
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            if (txtFiltro.Text.Length > 0 && comboFiltro.SelectedIndex != -1)
            {
                Cálculos.RefreshGrilla(dgvMesas, listado);
                string filtro = txtFiltro.Text;
                string Variable = rm.Reemplazar(comboFiltro.Text);
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

        private void frmMesas_Shown(object sender, EventArgs e)
        {
            Centrar();
        }

        private void frmMesas_Activated(object sender, EventArgs e)
        {
            Centrar();
        }
    }
}
