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
    public partial class frmHistoricoOrdenes : Form
    {
        BLL_Orden oBLL_Orden;
        BE_Orden oBE_Orden;
        public frmHistoricoOrdenes()
        {
            InitializeComponent();
            oBLL_Orden = new BLL_Orden();
            oBE_Orden = new BE_Orden();
            Aspecto.FormatearGRP(grpOrdenes);
            Aspecto.FormatearDGV(dgvOrdenes);
            Aspecto.FormatearGRPAccion(grpAcciones);
            ActualizarListado();
        }
        public void ActualizarListado()
        {
            Cálculos.RefreshGrilla(dgvOrdenes, oBLL_Orden.Listar());
            dgvOrdenes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dgvPedidos_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                oBE_Orden = (BE_Orden)dgvOrdenes.SelectedRows[0].DataBoundItem;
            }
            catch { }
            
        }
        private bool Nuevo()
        {
           
            return true;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Nuevo())
                {
                    ActualizarListado();
                    Cálculos.MsgBox("Se ha generado una nueva orden de cocina.");
                }
                else throw new RestaurantException("No se ha creado la orden correctamente. Intente de nuevo");
            }
            catch (Exception ex) { Cálculos.MsgBox(ex.Message); }
        }
    }
}
