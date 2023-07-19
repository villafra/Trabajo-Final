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
    public partial class frmNuevoIngrediente : Form
    {

        public BE_Ingrediente oBE_Ingrediente;
        BLL_Ingrediente oBLL_Ingrediente;
        private bool status;
        public frmNuevoIngrediente()
        {
            InitializeComponent();
            oBLL_Ingrediente = new BLL_Ingrediente();
            Aspecto.FormatearSubMenu(this, grpNuevoLogin, this.Width, this.Height);
            Cálculos.DataSourceCombo(comboTipo, Enum.GetNames(typeof(TipoIng)), "Tipo");
            Cálculos.DataSourceCombo(comboUM, Enum.GetNames(typeof(UM)), "UM");
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_ = oBE_Ingrediente != null ? Viejo() : Nuevo())
                {
                    Cálculos.MsgBox("Los datos se han guardado correctamente");
                }
                else { throw new RestaurantException("Los datos no se han guardado correctamente. Por favor, intente nuevamente"); }
            }
            catch (Exception ex) { Cálculos.MsgBox(ex.Message); }
           

        }

        private bool Viejo()
        {
            oBE_Ingrediente.Codigo = Convert.ToInt32(txtCodigo.Text);
            oBE_Ingrediente.Nombre = txtNombre.Text;
            oBE_Ingrediente.Tipo = (TipoIng)Enum.Parse(typeof(TipoIng),comboTipo.SelectedItem.ToString());
            oBE_Ingrediente.UnidadMedida = (UM)Enum.Parse(typeof(UM), comboUM.SelectedItem.ToString());
            oBE_Ingrediente.VidaUtil = Convert.ToInt32(numDias.Value);
            oBE_Ingrediente.Activo = status;
            if (Cálculos.EstaSeguroM(oBE_Ingrediente.Nombre))
            {
                if (Cálculos.Camposvacios(grpNuevoLogin))
                {
                    return oBLL_Ingrediente.Modificar(oBE_Ingrediente);
                }
                else { throw new RestaurantException("Por favor, complete los campos obligatorios."); }

            }
            else { throw new RestaurantException("Se ha cancelado la modificación"); }
        }

        private bool Nuevo()
        {
            if (Cálculos.Camposvacios(grpNuevoLogin))
            {
                oBE_Ingrediente = new BE_Ingrediente();
                oBE_Ingrediente.Nombre = txtNombre.Text;
                oBE_Ingrediente.Tipo = (TipoIng)Enum.Parse(typeof(TipoIng), comboTipo.SelectedItem.ToString());
                oBE_Ingrediente.UnidadMedida = (UM)Enum.Parse(typeof(UM), comboUM.SelectedItem.ToString());
                oBE_Ingrediente.VidaUtil = Convert.ToInt32(numDias.Value);
                oBE_Ingrediente.Refrigeracion = chkRefri.Checked;
                oBE_Ingrediente.GestionLote = chkLote.Checked;
                if (oBLL_Ingrediente.Existe(oBE_Ingrediente))
                {   
                    return oBLL_Ingrediente.Guardar(oBE_Ingrediente);
                }
                else throw new RestaurantException("Ya existe el ingrediente en base de datos.");

            }
            else { throw new RestaurantException("Por favor, complete los campos obligatorios"); }

        }
        private void ImportarEmpleado()
        {
            if (oBE_Ingrediente != null)
            {
                txtCodigo.Text = oBE_Ingrediente.Codigo.ToString();
                txtNombre.Text = oBE_Ingrediente.Nombre;
                comboTipo.Text = oBE_Ingrediente.Tipo.ToString();
                comboUM.Text = oBE_Ingrediente.UnidadMedida.ToString();
                numDias.Value = oBE_Ingrediente.VidaUtil;
                chkRefri.Checked = oBE_Ingrediente.Refrigeracion;
                chkLote.Checked = oBE_Ingrediente.GestionLote;
                status = oBE_Ingrediente.Activo;
            }
        }
        private void frmNuevoLogin_Load(object sender, EventArgs e)
        {
            ImportarEmpleado();
        }
    }
}
