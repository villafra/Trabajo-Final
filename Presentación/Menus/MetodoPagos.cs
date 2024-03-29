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
    public partial class frmMetodoPagos : Form
    {
        private List<BE_Pago> listado;
        BE_Pago oBE_Pago;
        BLL_Pago oBLL_Pago;
        Reemplazos rm;
        public frmMetodoPagos()
        {
            InitializeComponent();
            oBLL_Pago = new BLL_Pago();
            Aspecto.FormatearGRP(grpMetPagos);
            Aspecto.FormatearGRPAccion(grpAcciones);
            Aspecto.FormatearDGV(dgvMetPagos);
            CargarComboFiltro();
            ActualizarListado();
        }
        public void ActualizarListado()
        {
            Cálculos.RefreshGrilla(dgvMetPagos, oBLL_Pago.Listar());
            chkOcultar.Checked = false;
        }
        public void Centrar()
        {
            VistasDGV.dgvMetPagos(dgvMetPagos);
            Aspecto.CentrarDGV(this, dgvMetPagos);
        }
        private void CargarComboFiltro()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>
            {
                {"Código", "Codigo" },
                {"Método de Pago", "Tipo"}
            };
            rm = new Reemplazos(dict);
            Cálculos.DataSourceCombo(comboFiltro, rm.ListadoClaves(), "Filtros");
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmNuevoMetodoPago frm = new frmNuevoMetodoPago();
            frm.ShowDialog();
            ActualizarListado();
            Centrar();
            listado = (List<BE_Pago>)dgvMetPagos.DataSource;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmNuevoMetodoPago frm = new frmNuevoMetodoPago();
            frm.oBE_Pago = oBE_Pago;
            frm.ShowDialog();
            ActualizarListado();
            Centrar();
            listado = (List<BE_Pago>)dgvMetPagos.DataSource;
        }
        private void btBuscar_Click(object sender, EventArgs e)
        {
            if (txtFiltro.Text.Length > 0 && comboFiltro.SelectedIndex != -1)
            {
                Cálculos.RefreshGrilla(dgvMetPagos, listado);
                string filtro = txtFiltro.Text;
                string Variable = rm.Reemplazar(comboFiltro.Text);
                List<BE_Pago> filtrada = ((List<BE_Pago>)dgvMetPagos.DataSource).Where(x => Cálculos.GetPropertyValue(x, Variable).ToString().Contains(Cálculos.Capitalize(filtro))).ToList();
                Cálculos.RefreshGrilla(dgvMetPagos, filtrada);
                Centrar();
                comboFiltro.Text = "";
                txtFiltro.Text = "";
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Cálculos.RefreshGrilla(dgvMetPagos, listado);
            Centrar();
            chkOcultar.Checked = false;
        }

        private void dgvMetPagos_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                oBE_Pago = (BE_Pago)dgvMetPagos.SelectedRows[0].DataBoundItem;
            }
            catch { }
            
        }

        private void frmMetodoPagos_Load(object sender, EventArgs e)
        {
            listado = (List<BE_Pago>)dgvMetPagos.DataSource;
        }

        private void frmMetodoPagos_Shown(object sender, EventArgs e)
        {
            Centrar();
        }

        private void frmMetodoPagos_Activated(object sender, EventArgs e)
        {
            Centrar();
        }

        private void btnCargarImagen_Click(object sender, EventArgs e)
        {
            try
            {
                if (Cálculos.CargarFoto(oBE_Pago.ToString()))
                {
                    if (oBLL_Pago.CargarImágen(oBE_Pago))
                    {
                        Cálculos.MsgBox("Se ha añadido la imágen satisfactoriamente.");
                    }
                    else { throw new RestaurantException("La carga de la imágen ha fallado, por favor, intente nuevamente."); }
                }
                else { throw new RestaurantException("Se ha cancelado la carga de la imágen."); }
            }
            catch (Exception ex) { Cálculos.MsgBox(ex.Message); }
        }

        private void chkOcultar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOcultar.Checked)
            {
                Cálculos.RefreshGrilla(dgvMetPagos, listado);
                List<BE_Pago> filtrada = ((List<BE_Pago>)dgvMetPagos.DataSource).Where(x => x.Activo).ToList();
                Cálculos.RefreshGrilla(dgvMetPagos, filtrada);
                Centrar();
            }
            else
            {
                Cálculos.RefreshGrilla(dgvMetPagos, listado);
                Centrar();
            }
        }
    }
}
