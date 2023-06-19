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
            Cálculos.DataSourceCombo(comboTipo, Enum.GetNames(typeof(BE_Ingrediente.TipoIng)), "Tipo");
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (_ = oBE_Ingrediente != null ? Viejo() : Nuevo())
            {
                Cálculos.MsgBoxAlta("Los datos se han guardado correctamente");
            }
            else
            {
                Cálculos.MsgBoxNoAlta("Los datos no se han guardado correctamente. Por favor, intente nuevamente");
            }

        }

        private bool Viejo()
        {
            oBE_Ingrediente.Codigo = Convert.ToInt32(txtCodigo.Text);
            oBE_Ingrediente.Nombre = txtNombre.Text;
            oBE_Ingrediente.Tipo = (BE_Ingrediente.TipoIng)Enum.Parse(typeof(BE_Ingrediente.TipoIng),comboTipo.SelectedItem.ToString());
            oBE_Ingrediente.UnidadMedida = txtUM.Text;
            oBE_Ingrediente.VidaUtil = Convert.ToInt32(numDias.Value);
            oBE_Ingrediente.Activo = status;
            return oBLL_Ingrediente.Modificar(oBE_Ingrediente);
        }

        private bool Nuevo()
        {
            oBE_Ingrediente = new BE_Ingrediente();
            oBE_Ingrediente.Nombre = txtNombre.Text;
            oBE_Ingrediente.Tipo = (BE_Ingrediente.TipoIng)Enum.Parse(typeof(BE_Ingrediente.TipoIng), comboTipo.SelectedItem.ToString());
            oBE_Ingrediente.UnidadMedida = txtUM.Text;
            oBE_Ingrediente.VidaUtil = Convert.ToInt32(numDias.Value);
            oBE_Ingrediente.Refrigeracion = chkRefri.Checked;
            return oBLL_Ingrediente.Guardar(oBE_Ingrediente);
        }
        private void ImportarEmpleado()
        {
            if (oBE_Ingrediente != null)
            {
                txtCodigo.Text = oBE_Ingrediente.Codigo.ToString();
                txtNombre.Text = oBE_Ingrediente.Nombre;
                comboTipo.Text = oBE_Ingrediente.Tipo.ToString();
                txtUM.Text = oBE_Ingrediente.UnidadMedida.ToString();
                numDias.Value = oBE_Ingrediente.VidaUtil;
                chkRefri.Checked = oBE_Ingrediente.Refrigeracion;
                status = oBE_Ingrediente.Activo;
            }
        }

        private void frmNuevoLogin_Load(object sender, EventArgs e)
        {
            ImportarEmpleado();
        }
    }
}
