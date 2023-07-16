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
    public partial class frmRecetaPlatos : Form
    {
        BLL_Plato oBLL_Plato;
        BLL_PlatoReceta oBLL_Receta;
        BE_Plato oBE_Plato;
        BE_PlatoReceta oBE_Receta;
        List<BE_PlatoReceta> listado;
        public frmRecetaPlatos()
        {
            InitializeComponent();
            oBLL_Plato = new BLL_Plato();
            oBE_Plato = new BE_Plato();
            oBLL_Receta = new BLL_PlatoReceta();
            oBE_Receta = new BE_PlatoReceta();
            Aspecto.FormatearGRP(grpBebidas);
            Aspecto.FormatearDGV(dgvReceta);
            Aspecto.FormatearGRPAccion(grpAcciones);
            ActualizarListado();
        }
        public void ActualizarListado()
        {
            Cálculos.DataSourceCombo(comboPlato, oBLL_Plato.Listar(), "Platos");
        }
        public void Centrar()
        {
            Cálculos.RefreshGrilla(dgvReceta, oBLL_Receta.ListarObjeto(oBE_Plato, oBE_Receta));
            VistasDGV.dgvReceta(dgvReceta);
            Aspecto.CentrarDGV(this, dgvReceta);
        }
        private void comboPlato_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                oBE_Plato = (BE_Plato)comboPlato.SelectedItem;
                if (oBE_Plato != null)
                Cálculos.DataSourceCombo(comboAlt, oBLL_Receta.ListarAlternativasDataSource(oBE_Plato),"Alternativas Vigentes");
            }
            catch { }
        }

        private void comboAlt_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                oBE_Receta = (BE_PlatoReceta)comboAlt.SelectedItem;
                if (oBE_Receta != null && comboAlt.Text != "")
                    Centrar();
                else Cálculos.GrillaEnBlanco(dgvReceta);
            }   
            catch { }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmNuevaRecetaP frm = new frmNuevaRecetaP();
            frm.oBE_Plato = oBE_Plato;
            frm.Owner = this;
            frm.nuevo = true;
            frm.CerrarForm += ActualizarListado;
            frm.Show();
            
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (oBE_Receta != null && oBE_Plato!= null)
            {
                frmNuevaRecetaP frm = new frmNuevaRecetaP();
                frm.Owner = this;
                frm.oBE_Plato = oBE_Plato;
                frm.oBE_Receta = oBE_Receta;
                frm.nuevo = false;
                frm.CerrarForm += ActualizarListado;
                frm.RecuperarReceta();
                frm.Show();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            listado = oBLL_Receta.ListarObjeto(oBE_Plato, oBE_Receta);
            foreach (BE_PlatoReceta beb in listado)
            {
                beb.Activo = false;
            }
            oBLL_Receta.Modificar(listado);
            ActualizarListado();
        }

        private void btnDesbloquear_Click(object sender, EventArgs e)
        {
            listado = oBLL_Receta.ListarObjeto(oBE_Plato, oBE_Receta);
            foreach (BE_PlatoReceta beb in listado)
            {
                beb.Activo = true;
            }
            oBLL_Receta.Modificar(listado);
            ActualizarListado();
        }
    }
}
