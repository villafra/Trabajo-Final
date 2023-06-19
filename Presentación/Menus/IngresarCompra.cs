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

namespace Trabajo_Final
{
    public partial class frmIngresarCompra : Form
    {
        BLL_Compra oBLL_Compra;
        BE_Compra oBE_Compra;
        public frmIngresarCompra()
        {
            InitializeComponent();
            oBLL_Compra = new BLL_Compra();
            oBE_Compra = new BE_Compra();
            Aspecto.FormatearGRP(grpCompras);
            Aspecto.FormatearGRPAccion(grpAcciones);
            Aspecto.FormatearDGV(dgvCompras);
            ActualizarListado();
        }
        private void ActualizarListado()
        {
            Cálculos.RefreshGrilla(dgvCompras, oBLL_Compra.Listar());
            dgvCompras.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmNuevaCompra frm = new frmNuevaCompra();
            frm.ShowDialog();
            ActualizarListado();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmNuevaCompra frm = new frmNuevaCompra();
            frm.oBE_Compra = oBE_Compra;
            frm.ShowDialog();
            ActualizarListado();
        }

        private void dgvCompras_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //oBE_Login = (BE_Login)dgvUsuarios.SelectedRows[0].DataBoundItem;
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
            oBLL_Compra.Baja(oBE_Compra);
        }
    }
}
