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
    public partial class frmBackUp : Form
    {
        public BE_Login UsuarioActivo;
        BLL_BackUp oBLL_BackUp;
        BE_BackUp oBE_BackUp;
        private List<BE_BackUp> listado;
        Reemplazos rm;
        public frmBackUp()
        {
            InitializeComponent();
            oBLL_BackUp = new BLL_BackUp();
            Aspecto.FormatearGRP(grpBackUp);
            Aspecto.FormatearGRPAccion(grpAcciones);
            Aspecto.FormatearDGV(dgvBackUps);
            CargarComboFiltro();
            ActualizarListado();
        }
        public void ActualizarListado()
        {
            Cálculos.RefreshGrilla(dgvBackUps, oBLL_BackUp.Listar());
        }
        public void Centrar()
        {
            VistasDGV.DGVLogs(dgvBackUps);
            Aspecto.CentrarDGV(this, dgvBackUps);
        }
        private void CargarComboFiltro()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>
            {
                {"Fecha", "FechaHora" },
                {"Nombre del Archivo", "NombreArchivo"},
                {"Usuario Responsable", "NombreUsuario" },
                {"Tipo de Acción", "Accion" }
            };
            rm = new Reemplazos(dict);
            Cálculos.DataSourceCombo(comboFiltro, rm.ListadoClaves(), "Filtros");
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Cálculos.EstaSeguroBackUp("BackUp"))
                {
                    if (oBLL_BackUp.CrearBackUp(UsuarioActivo))
                    {
                        ActualizarListado();
                        Centrar();
                        Cálculos.MsgBox("BackUp Creado Correctamente");
                    }
                    else { throw new Exception("La creacion del BackUp ha fallado. Intente Nuevamente."); }
                    
                }
            }
            catch(Exception ex) { Cálculos.MsgBox(ex.Message); }
           
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Cálculos.EstaSeguroBackUp("Restore"))
                {
                    if(oBLL_BackUp.RestaurarBackUp(UsuarioActivo, oBE_BackUp.NombreArchivo))
                    {
                        Cálculos.MsgBox("El restore se ha efectuado correctamente");
                        ActualizarListado();
                        Centrar();
                    }
                    else { throw new Exception("El restore ha fallado.Intente nuevamente"); }
                    
                }
            }
            catch(Exception ex) { Cálculos.MsgBox(ex.Message); }
        }

        private void dgvIngredientes_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                oBE_BackUp = (BE_BackUp)dgvBackUps.SelectedRows[0].DataBoundItem;
            }
            catch { }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Cálculos.EstaSeguroBackUp("RollBack"))
                {
                    if (oBLL_BackUp.RollBack(UsuarioActivo))
                    {
                        Cálculos.MsgBox("Se ha hecho Rollback de la base de datos.");
                        ActualizarListado();
                        Centrar();
                    }
                }
            }
            catch (Exception ex) { Cálculos.MsgBox(ex.Message); }
        }

        private void frmBackUp_Load(object sender, EventArgs e)
        {
            listado = (List<BE_BackUp>)dgvBackUps.DataSource;
        }

        private void frmBackUp_Shown(object sender, EventArgs e)
        {
            Centrar();
        }

        private void frmBackUp_Activated(object sender, EventArgs e)
        {
            Centrar();
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            if (txtFiltro.Text.Length > 0 && comboFiltro.SelectedIndex != -1)
            {
                Cálculos.RefreshGrilla(dgvBackUps, listado);
                string filtro = txtFiltro.Text;
                string Variable = rm.Reemplazar(comboFiltro.Text);
                List<BE_BackUp> filtrada = ((List<BE_BackUp>)dgvBackUps.DataSource).Where(x => Cálculos.GetPropertyValue(x, Variable).ToString().Contains(Cálculos.Capitalize(filtro))).ToList();
                Cálculos.RefreshGrilla(dgvBackUps, filtrada);
                Centrar();
                comboFiltro.Text = "";
                txtFiltro.Text = "";
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Cálculos.RefreshGrilla(dgvBackUps, listado);
            Centrar();
        }
    }
}
