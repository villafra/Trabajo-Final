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
using Abstraction_Layer;

namespace Trabajo_Final
{
    public partial class frmNuevoCosto : Form
    {
        
        public BE_Costo oBE_Costo;
        BLL_Costo oBLL_Costo;
        private bool status;
        public frmNuevoCosto()
        {
            InitializeComponent();
            oBLL_Costo = new BLL_Costo();
            Aspecto.FormatearSubMenu(this, grpNuevoLogin, this.Width, this.Height);
            Cálculos.DataSourceCombo(ComboTipo,Enum.GetNames(typeof(TipoMaterial)),"Tipo Materiales");
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (_ = oBE_Costo != null ? Viejo() : Nuevo())
            {
                Cálculos.MsgBox("Los datos se han guardado correctamente");
            }
            else
            {
                Cálculos.MsgBox("Los datos no se han guardado correctamente. Por favor, intente nuevamente");
            }

        }

        private bool Viejo()
        {
            oBE_Costo.Codigo = Convert.ToInt32(txtCodigo.Text);
            
            return oBLL_Costo.Modificar(oBE_Costo);
        }

        private bool Nuevo()
        {
            oBE_Costo = new BE_CostoIngrediente();
            ((BE_CostoIngrediente)oBE_Costo).ID_Ingrediente = (BE_Ingrediente)ComboTipo.SelectedItem;
            oBE_Costo.DíaCosteo = dtpFechaCosteo.Value;
            oBE_Costo.TamañoLoteCosteo = numTamaño.Value;
            oBE_Costo.MateriaPrima = numMP.Value;
            oBE_Costo.HorasHombre = numHH.Value;
            oBE_Costo.OtrosGastos = numOtros.Value;
            return oBLL_Costo.Guardar(oBE_Costo);
        }
        private void ImportarCosto()
        {
            if (oBE_Costo != null)
            {
                txtCodigo.Text = oBE_Costo.Codigo.ToString();
                
            }
        }

        private void frmNuevoLogin_Load(object sender, EventArgs e)
        {
            ImportarCosto();
        }
    }
}
