using System;
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
    public partial class frmNuevaReceta : Form
    {
        BLL_Bebida oBLL_Bebida;
        BLL_BebidaReceta oBLL_Receta;
        BLL_Ingrediente oBLL_Ingrediente;
        public BE_Bebida_Preparada oBE_Bebida;
        public frmNuevaReceta()
        {
            InitializeComponent();
            oBLL_Bebida = new BLL_Bebida();
            oBLL_Receta = new BLL_BebidaReceta();
            oBLL_Ingrediente = new BLL_Ingrediente();
            Aspecto.FormatearSubMenu(this, grpReceta, this.Width, this.Height);
            Aspecto.FormatearGRPSubMenu(grpIngredientes);
            ActualizarListado();
        }
        public void ActualizarListado()
        {
            Cálculos.DataSourceCombo(comboIngrediente, oBLL_Ingrediente.Listar(), "Ingredientes");
        }
        public void ImportarBebida()
        {
            if(oBE_Bebida != null)
            {
                txtBebida.Text = oBE_Bebida.ToString();
            }
        }

        private void frmNuevaReceta_Load(object sender, EventArgs e)
        {
            ImportarBebida();
        }
    }
}
