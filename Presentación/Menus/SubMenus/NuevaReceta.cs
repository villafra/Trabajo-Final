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
using Service_Layer;
using Microsoft.VisualBasic;

namespace Trabajo_Final
{
    public partial class frmNuevaReceta : Form
    {
        BLL_Bebida_Stock oBLL_Bebida;
        BLL_BebidaReceta oBLL_Receta;
        BLL_Ingrediente oBLL_Ingrediente;
        BLL_Bebida_Stock oBLL_Stock;
        public BE_Bebida_Preparada oBE_Bebida;
        public BE_BebidaReceta oBE_Receta;
        BE_BebidaReceta nueva;
        List<IngEnBeb> listado;
        List<BE_BebidaReceta> listabr;
        IngEnBeb ingrediente;
        public event Action CerrarForm;
        public bool nuevo;
        public frmNuevaReceta()
        {
            InitializeComponent();
            oBLL_Bebida = new BLL_Bebida_Stock();
            oBLL_Receta = new BLL_BebidaReceta();
            oBLL_Ingrediente = new BLL_Ingrediente();
            listado = new List<IngEnBeb>();
            Aspecto.FormatearSubMenu(this, grpReceta, this.Width, this.Height);
            Aspecto.FormatearGRPSubMenu(grpIngredientes);
            Aspecto.FormatearDGVRecetas(dgvReceta);
            ActualizarListado();
        }
        public void ActualizarListado()
        {
            Cálculos.DataSourceCombo(comboIngrediente, oBLL_Ingrediente.Listar(), "Ingredientes");
            txtLote.Text = "100";
            txtCantReceta.Text = "0";
        }
        public void ActualizarRecetario()
        {
            Cálculos.RefreshGrilla(dgvReceta, listado);
            VistasDGV.dgvSubReceta(dgvReceta);
            Aspecto.CentrarDGVSubMenu(grpIngredientes, dgvReceta);
            Sumar();
        }
        private bool Nuevo()
        {
            if (Cálculos.Camposvacios(grpReceta))
            {
                if (BatchCompleto())
                {
                    listabr = new List<BE_BebidaReceta>();
                    foreach (IngEnBeb ing in listado)
                    {
                        nueva = new BE_BebidaReceta();
                        nueva.Bebida = oBE_Bebida;
                        nueva.Ingrediente = ing.Ingrediente;
                        nueva.Cantidad = ing.Cantidad;
                        nueva.Alternativa = ing.Alt;
                        listabr.Add(nueva);
                    }
                    oBLL_Stock = new BLL_Bebida_Stock();
                    BE_Bebida_Stock oBE_Stock = new BE_Bebida_Stock();
                    oBE_Stock.Material = oBE_Bebida;
                    oBE_Stock.Stock = 1;
                    oBE_Stock.FechaCreacion = DateTime.Now;
                    if (TieneStock(oBE_Stock))
                    {
                        oBLL_Stock.Guardar(oBE_Stock);
                    }
                    return oBLL_Receta.Guardar(listabr);
                }
                else { throw new RestaurantException("El tamaño de lote es distinto al tamaño de lote por defecto."); }
                
            }
            else { throw new RestaurantException("Por favor, complete los campos obligatorios"); }
        }
        public bool Viejo()
        {
            if (BatchCompleto())
            {
                listabr = new List<BE_BebidaReceta>();
                foreach (IngEnBeb ing in listado)
                {
                    nueva = new BE_BebidaReceta();
                    nueva.Codigo = ing.Codigo;
                    nueva.Bebida = oBE_Bebida;
                    nueva.Ingrediente = ing.Ingrediente;
                    nueva.Cantidad = ing.Cantidad;
                    nueva.Alternativa = ing.Alt;
                    listabr.Add(nueva);
                }
                return oBLL_Receta.Modificar(listabr);
            }
            else { throw new RestaurantException("El tamaño de lote es distinto al tamaño de lote por defecto."); }
        }
        private void Sumar()
        {
            txtCantReceta.Text = listado.Sum(x => x.Cantidad).ToString();
        }
        private bool BatchCompleto()
        {
            return Convert.ToDecimal(txtLote.Text).Equals(Convert.ToDecimal(txtCantReceta.Text));
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (Cálculos.Camposvacios(grpIngredientes) && Cálculos.Camposvacios(grpReceta))
            {
                ingrediente = new IngEnBeb();
                ingrediente.Ingrediente = (BE_Ingrediente)comboIngrediente.SelectedItem;
                ingrediente.Cantidad = Convert.ToDecimal(txtCantidad.Text);
                ingrediente.Alt = txtAlternativa.Text;
                listado.Add(ingrediente);
                Cálculos.BorrarCampos(grpIngredientes);
                ActualizarRecetario();
            }
            else { Cálculos.MsgBox("Por favor, complete los campos obligatorios"); }
        }

        private void btnSacar_Click(object sender, EventArgs e)
        {
            try
            {
                ingrediente = (IngEnBeb)dgvReceta.SelectedRows[0].DataBoundItem;

                listado.Remove(ingrediente);
                ActualizarRecetario();
            }
            catch { }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (nuevo)
                {
                    
                    if (Nuevo()) { Cálculos.MsgBox("La receta se ha cargado correctamente."); this.Close(); }
                    else { throw new RestaurantException("La carga de datos, ha fallado. Intente Nuevamente"); }
                }
                else
                {
                    if (Viejo()) { Cálculos.MsgBox("La receta se ha modificado correctamente."); this.Close(); }
                    else { throw new RestaurantException("La modificación, ha fallado. Intente Nuevamente"); }
                }
                
            }
            catch (Exception ex)
            {
                Cálculos.MsgBox(ex.Message);
            }
            
        }

        private void frmNuevaReceta_FormClosed(object sender, FormClosedEventArgs e)
        {
            CerrarForm?.Invoke();
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            Cálculos.ValidarNumeros(e);
        }
        public void RecuperarReceta()
        {
            if (oBE_Receta != null)
            {
                listabr = (oBLL_Receta.ListarObjeto(oBE_Bebida, oBE_Receta));
                oBE_Receta.Codigo = listabr[0].Codigo;
                foreach(BE_BebidaReceta br in listabr)
                {
                    ingrediente = new IngEnBeb();
                    ingrediente.Codigo = br.Codigo;
                    ingrediente.Ingrediente = br.Ingrediente;
                    ingrediente.Cantidad = br.Cantidad;
                    ingrediente.Alt = br.Alternativa;
                    listado.Add(ingrediente);
                }
                txtAlternativa.Text = oBE_Receta.Alternativa;
                btnSacar.Visible = false;
                btnAgregar.Visible = false;
                btnModificar.Visible = true;
                ActualizarRecetario();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ingrediente = (IngEnBeb)dgvReceta.SelectedRows[0].DataBoundItem;
            decimal valor = ingrediente.Cantidad;
            bool esDecimal = false;
            while (!esDecimal)
            {
                string respuesta = Interaction.InputBox("Ingrese la nueva cantidad:", "Modificar Receta", ingrediente.Cantidad.ToString());
                esDecimal = decimal.TryParse(respuesta, out valor);
                if (!esDecimal)MessageBox.Show("Ingrese un valor numérico. Intente nuevamente.", "Error"); 
            }
            listado.Find(x => x.Ingrediente.Codigo == ingrediente.Ingrediente.Codigo).Cantidad = valor;
            ActualizarRecetario();
        }
        public bool TieneStock(BE_Bebida_Stock bebida)
        {
            return oBLL_Bebida.Existe(bebida);
        }
    }
}
