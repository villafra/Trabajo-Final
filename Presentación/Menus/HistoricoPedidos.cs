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
    public partial class frmHistoricoPedidos : Form
    {
        BLL_Pedido oBLL_Pedido;
        BE_Pedido oBE_Pedido;
        BLL_Orden oBLL_Orden;
        public BE_Orden oBE_Orden;
        private BE_Login usuario;
        public frmHistoricoPedidos()
        {
            InitializeComponent();
            oBLL_Pedido = new BLL_Pedido();
            oBE_Pedido = new BE_Pedido();
            oBLL_Orden = new BLL_Orden();
            Aspecto.FormatearGRP(grpPedidos);
            Aspecto.FormatearDGV(dgvPedidos);
            Aspecto.FormatearGRPAccion(grpAcciones);
            ActualizarListado();
        }
        public void ActualizarListado()
        {
            Cálculos.RefreshGrilla(dgvPedidos, oBLL_Pedido.Listar());
            dgvPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dgvPedidos_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                oBE_Pedido = (BE_Pedido)dgvPedidos.SelectedRows[0].DataBoundItem;
            }
            catch { }
            
        }
        private bool Nuevo()
        {
            oBE_Orden = new BE_Orden();
            oBE_Orden.ID_Pedido = oBE_Pedido;
            oBE_Orden.ID_Empleado = usuario.Empleado;
            oBE_Orden.Status = oBE_Orden.DefinirStatusInicial();
            oBE_Pedido.Status = StatusPedido.Asignado;
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
