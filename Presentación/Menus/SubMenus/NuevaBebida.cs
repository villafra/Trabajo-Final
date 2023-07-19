using System;
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
    public partial class frmNuevaBebida : Form
    {

        public BE_Bebida oBE_Bebida;
        BLL_Bebida oBLL_Bebida;
        List<int> BebidaAlcoholica = new List<int> { 5, 6, 7, 8 };
        List<int> BebidaAnalcoholica = new List<int> { 1, 2, 3, 4 };
        List<int> BebidaPreparada = new List<int> { 3, 7, 8};
        public frmNuevaBebida()
        {
            InitializeComponent();
            oBLL_Bebida = new BLL_Bebida();
            Aspecto.FormatearSubMenu(this, grpNuevoLogin, this.Width, this.Height);
            Cálculos.DataSourceCombo(comboTipo, Enum.GetNames(typeof(Tipo_Bebida)), "Tipo Bebida");
            Cálculos.DataSourceCombo(comboUM, Enum.GetNames(typeof(UM)), "Unidad de Medida");
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_ = oBE_Bebida != null ? Viejo() : Nuevo())
                {
                    Cálculos.MsgBox("Los datos se han guardado correctamente");
                }
                else { throw new RestaurantException("Los datos no se han guardado correctamente. Por favor, intente nuevamente"); }
            }
            catch (Exception ex) { Cálculos.MsgBox(ex.Message); }
        }

        private bool Viejo()
        {
            int tipo = (int)(Tipo_Bebida)Enum.Parse(typeof(Tipo_Bebida), comboTipo.SelectedItem.ToString());

            if (BebidaPreparada.Contains(tipo))
            {
                oBE_Bebida = new BE_Bebida_Preparada();
                if (BebidaAlcoholica.Contains(tipo)) ((BE_Bebida_Preparada)oBE_Bebida).ABV = numABV.Value;
            }
            else if (BebidaAnalcoholica.Contains(tipo))
            {
                oBE_Bebida = new BE_Bebida();
            }
            else
            {
                oBE_Bebida = new BE_Bebida_Alcoholica();
                ((BE_Bebida_Alcoholica)oBE_Bebida).ABV = numABV.Value;
            }
            oBE_Bebida.Codigo = Convert.ToInt32(txtCodigo.Text);
            oBE_Bebida.Nombre = txtNombre.Text;
            oBE_Bebida.Tipo = (Tipo_Bebida)Enum.Parse(typeof(Tipo_Bebida), comboTipo.SelectedItem.ToString());
            oBE_Bebida.Presentacion = numPresentacion.Value;
            oBE_Bebida.UnidadMedida = (UM)Enum.Parse(typeof(UM), comboUM.SelectedItem.ToString());
            oBE_Bebida.VidaUtil = Convert.ToInt32(txtVidaUtil.Text);
            oBE_Bebida.GestionLote = chkLote.Checked;
            if (Cálculos.EstaSeguroM(oBE_Bebida.Nombre))
            {
                if (Cálculos.Camposvacios(grpNuevoLogin))
                {
                    return oBLL_Bebida.Modificar(oBE_Bebida);
                }
                else { throw new RestaurantException("Por favor, complete los campos obligatorios."); }
            }
            else { throw new RestaurantException("Se ha cancelado la modificación"); }
        }

        private bool Nuevo()
        {
            
            if (Cálculos.Camposvacios(grpNuevoLogin))
            {
                int tipo = (int)(Tipo_Bebida)Enum.Parse(typeof(Tipo_Bebida), comboTipo.SelectedItem.ToString());
                if (BebidaPreparada.Contains(tipo))
                {
                    oBE_Bebida = new BE_Bebida_Preparada();
                    if (BebidaAlcoholica.Contains(tipo)) ((BE_Bebida_Preparada)oBE_Bebida).ABV = numABV.Value;
                }
                else if (BebidaAnalcoholica.Contains(tipo))
                {
                    oBE_Bebida = new BE_Bebida();
                }
                else
                {
                    oBE_Bebida = new BE_Bebida_Alcoholica();
                    ((BE_Bebida_Alcoholica)oBE_Bebida).ABV = numABV.Value;
                }
                oBE_Bebida.Nombre = txtNombre.Text;
                oBE_Bebida.Tipo = (Tipo_Bebida)Enum.Parse(typeof(Tipo_Bebida), comboTipo.SelectedItem.ToString());
                oBE_Bebida.Presentacion = numPresentacion.Value;
                oBE_Bebida.UnidadMedida = (UM)Enum.Parse(typeof(UM), comboUM.SelectedItem.ToString());
                oBE_Bebida.VidaUtil = Convert.ToInt32(txtVidaUtil.Text);
                oBE_Bebida.GestionLote = chkLote.Checked;
                if (oBLL_Bebida.Existe(oBE_Bebida))
                {
                    return oBLL_Bebida.Guardar(oBE_Bebida);
                }
                else throw new RestaurantException("El Empleado ya tiene un usuario designado.");
            }
            else throw new RestaurantException("Por favor, complete los campos obligatorios.");
        }
        private void ImportarBebida()
        {
            if (oBE_Bebida != null)
            {
                if (oBE_Bebida is BE_Bebida_Alcoholica)
                {
                    txtCodigo.Text = oBE_Bebida.Codigo.ToString();
                    txtNombre.Text = oBE_Bebida.Nombre;
                    comboTipo.Text = oBE_Bebida.Tipo.ToString();
                    numPresentacion.Value = oBE_Bebida.Presentacion;
                    comboUM.Text = oBE_Bebida.UnidadMedida.ToString();
                    txtVidaUtil.Text = oBE_Bebida.VidaUtil.ToString();
                    chkLote.Checked = oBE_Bebida.GestionLote;
                    numABV.Value = ((BE_Bebida_Alcoholica)oBE_Bebida).ABV;
                    numABV.Visible = true;
                    lblABV.Visible = true;
                }
                else if (oBE_Bebida is BE_Bebida_Preparada)
                {
                    txtCodigo.Text = oBE_Bebida.Codigo.ToString();
                    txtNombre.Text = oBE_Bebida.Nombre;
                    comboTipo.Text = oBE_Bebida.Tipo.ToString();
                    numPresentacion.Value = oBE_Bebida.Presentacion;
                    comboUM.Text = oBE_Bebida.UnidadMedida.ToString();
                    txtVidaUtil.Text = oBE_Bebida.VidaUtil.ToString();
                    chkLote.Checked = oBE_Bebida.GestionLote;
                    numABV.Value = ((BE_Bebida_Alcoholica)oBE_Bebida).ABV;
                    if (numABV.Value != 0)
                    {
                        numABV.Visible = true;
                        lblABV.Visible = true;
                    }
                    Cálculos.DataSourceCombo(comboIngredientes, ((BE_Bebida_Preparada)oBE_Bebida).ListaIngredientes, "Lista Ingredientes");
                    comboIngredientes.Visible = true;
                }
                else
                {
                    txtCodigo.Text = oBE_Bebida.Codigo.ToString();
                    txtNombre.Text = oBE_Bebida.Nombre;
                    comboTipo.Text = oBE_Bebida.Tipo.ToString();
                    numPresentacion.Value = oBE_Bebida.Presentacion;
                    comboUM.Text = oBE_Bebida.UnidadMedida.ToString();
                    txtVidaUtil.Text = oBE_Bebida.VidaUtil.ToString();
                    chkLote.Checked = oBE_Bebida.GestionLote;
                }

            }
        }

        private void frmNuevoLogin_Load(object sender, EventArgs e)
        {
            ImportarBebida();
        }

        private void comboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (comboTipo.SelectedIndex > -1)
                {
                    int tipo = (int)(Tipo_Bebida)Enum.Parse(typeof(Tipo_Bebida), comboTipo.SelectedItem.ToString());
                    if (BebidaAlcoholica.Contains(tipo))
                    {
                        numABV.Visible = true;
                        lblABV.Visible = true;
                    }
                    else
                    {
                        numABV.Visible = false;
                        lblABV.Visible = false;
                    }
                }
            }
            catch { }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
