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
        public frmBackUp()
        {
            InitializeComponent();
            oBLL_BackUp = new BLL_BackUp();
            Aspecto.FormatearGRP(grpBackUp);
            Aspecto.FormatearGRPAccion(grpAcciones);
            Aspecto.FormatearDGV(dgvBackUps);
            ActualizarListado();
        }
        public void ActualizarListado()
        {
            Cálculos.RefreshGrilla(dgvBackUps, oBLL_BackUp.Listar());
            dgvBackUps.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
                    }
                    else { throw new Exception("El restore ha fallado.Intente nuevamente"); }
                    
                }
            }
            catch(Exception ex) { Cálculos.MsgBox(ex.Message); }
        }

        private void dgvIngredientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //oBE_Login = (BE_Login)dgvUsuarios.SelectedRows[0].DataBoundItem;
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
                    }
                }
            }
            catch (Exception ex) { Cálculos.MsgBox(ex.Message); }
        }
    }
}
