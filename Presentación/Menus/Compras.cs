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
    public partial class frmCompras : Form
    {
        BLL_Compra oBLL_Compra;
        BE_Compra oBE_Compra;
        private List<BE_Compra> listado;
        public frmCompras()
        {
            InitializeComponent();
            oBLL_Compra = new BLL_Compra();
            Aspecto.FormatearGRP(grpCompras);
            Aspecto.FormatearGRPAccion(grpAcciones);
            Aspecto.FormatearDGV(dgvCompras);
            ActualizarListado();
        }
        public void ActualizarListado()
        {
            Cálculos.RefreshGrilla(dgvCompras, oBLL_Compra.Listar());
        }
        public void Centrar()
        {
            VistasDGV.dgvCompras(dgvCompras);
            Aspecto.CentrarDGV(this, dgvCompras);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmNuevaCompra frm = new frmNuevaCompra();
            frm.ShowDialog();
            ActualizarListado();
            Centrar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (oBE_Compra.Status == StausComp.En_Curso)
                {
                    frmNuevaCompra frm = new frmNuevaCompra();
                    frm.oBE_Compra = oBE_Compra;
                    frm.ShowDialog();
                    ActualizarListado();
                    Centrar();
                }
                else { throw new RestaurantException("No se puede modificar un pedido que ya se ha gestionado."); }
            }
            catch (Exception ex)
            {
                Cálculos.MsgBox(ex.Message);
            }
        }
        private void dgvCompras_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                oBE_Compra = (BE_Compra)dgvCompras.SelectedRows[0].DataBoundItem;
            }
            catch { }

        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (oBE_Compra.Status == StausComp.En_Curso)
                {
                    if (oBLL_Compra.Baja(oBE_Compra))
                    {
                        Cálculos.MsgBox("El pedido se ha borrado de la base de datos.");
                    }
                    else { throw new Exception(); }
                    ActualizarListado();
                    Centrar();
                }
                else { throw new RestaurantException("No se puede eliminar un pedido que ya se ha gestionado."); }
            }
            catch (Exception ex)
            {
                Cálculos.MsgBox(ex.Message);
            }
        }

        private void frmCompras_Load(object sender, EventArgs e)
        {
            listado = (List<BE_Compra>)dgvCompras.DataSource;
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            if (txtFiltro.Text.Length > 0)
            {
            Cálculos.RefreshGrilla(dgvCompras, listado);
            string filtro = txtFiltro.Text;
            string Variable = comboFiltro.Text;
            List<BE_Compra> filtrada = ((List<BE_Compra>)dgvCompras.DataSource).Where(x => Cálculos.GetPropertyValue(x, Variable).ToString().Contains(Cálculos.Capitalize(filtro))).ToList();
            Cálculos.RefreshGrilla(dgvCompras, filtrada);
            Centrar();
            comboFiltro.Text = "";
            txtFiltro.Text = "";
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Cálculos.RefreshGrilla(dgvCompras, listado);
            Centrar();
        }

        private void frmCompras_Activated(object sender, EventArgs e)
        {
            Centrar();
        }

        private void frmCompras_Shown(object sender, EventArgs e)
        {
            Centrar();
        }
    }
}
