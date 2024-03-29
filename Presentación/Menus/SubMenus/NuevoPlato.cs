﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Automate_Layer;
using Business_Entities;
using Service_Layer;
using Business_Logic_Layer;

namespace Trabajo_Final
{
    public partial class frmNuevoPlato : Form
    {

        public BE_Plato oBE_Plato;
        BLL_Plato oBLL_Plato;
        public frmNuevoPlato()
        {
            InitializeComponent();
            oBLL_Plato = new BLL_Plato();
            Aspecto.FormatearSubMenu(this, grpNuevoLogin, this.Width, this.Height);
            Cálculos.DataSourceCombo(comboTipo, Enum.GetNames(typeof(Tipo_Plato)), "Tipo Plato");
            Cálculos.DataSourceCombo(ComboClas, Enum.GetNames(typeof(Clasificación)), "Clasificación");
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_ = oBE_Plato != null ? Viejo() : Nuevo())
                {
                    Cálculos.MsgBox("Los datos se han guardado correctamente");
                }
                else { throw new RestaurantException("Los datos no se han guardado correctamente. Por favor, intente nuevamente"); }
            }
            catch (Exception ex) { Cálculos.MsgBox(ex.Message); }
        }

        private bool Viejo()
        {
            oBE_Plato.Codigo = Convert.ToInt32(txtCodigo.Text);
            oBE_Plato.Nombre = txtNombre.Text;
            oBE_Plato.Tipo = (Tipo_Plato)Enum.Parse(typeof(Tipo_Plato), comboTipo.SelectedItem.ToString());
            oBE_Plato.Clase = (Clasificación)Enum.Parse(typeof(Clasificación), ComboClas.SelectedItem.ToString());
            oBE_Plato.Presentación = Convert.ToDecimal(txtPresentacion.Text);
            if (Cálculos.EstaSeguroM(oBE_Plato.Nombre))
            {
                if (Cálculos.Camposvacios(grpNuevoLogin))
                {
                    return oBLL_Plato.Modificar(oBE_Plato);
                }
                else { throw new RestaurantException("Por favor, complete los campos obligatorios."); }

            }
            else { throw new RestaurantException("Se ha cancelado la modificación"); }
        }

        private bool Nuevo()
        {
            if (Cálculos.Camposvacios(grpNuevoLogin))
            {
                oBE_Plato = new BE_Plato();
                oBE_Plato.Nombre = txtNombre.Text;
                oBE_Plato.Tipo = (Tipo_Plato)Enum.Parse(typeof(Tipo_Plato), comboTipo.SelectedItem.ToString());
                oBE_Plato.Clase = (Clasificación)Enum.Parse(typeof(Clasificación), ComboClas.SelectedItem.ToString());
                oBE_Plato.Presentación = Convert.ToDecimal(txtPresentacion.Text);
                if (oBLL_Plato.Existe(oBE_Plato))
                {
                    return oBLL_Plato.Guardar(oBE_Plato);
                }
                else throw new RestaurantException("El plato ya existe en la base de datos.");
            }
            else throw new RestaurantException("Por favor, complete los campos obligatorios.");
        }
        private void ImportarPlato()
        {
            if (oBE_Plato != null)
            {
                txtCodigo.Text = oBE_Plato.Codigo.ToString();
                txtNombre.Text = oBE_Plato.Nombre;
                comboTipo.Text = oBE_Plato.Tipo.ToString();
                ComboClas.Text = oBE_Plato.Clase.ToString();
                txtPresentacion.Text = oBE_Plato.Presentación.ToString();
                Cálculos.DataSourceCombo(comboIngredientes, oBE_Plato.ListaIngredientes, "Lista Ingredientes");
                comboIngredientes.Visible = true;
                lblIng.Visible = true;
            }
        }

        private void frmNuevoLogin_Load(object sender, EventArgs e)
        {
            ImportarPlato();
        }

        private void txtPresentacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            Cálculos.ValidarNumeros(e);
        }
    }
}
