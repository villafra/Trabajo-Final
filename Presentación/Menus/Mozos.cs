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
using Business_Logic_Layer;
using Automate_Layer;

namespace Trabajo_Final
{
    public partial class frmMozos : Form
    {
        BLL_Mozo oBLL_Mozo;
        BE_Mozo oBE_Mozo;
        public frmMozos()
        {
            InitializeComponent();
            oBLL_Mozo = new BLL_Mozo();
            oBE_Mozo = new BE_Mozo();
            ActualizarListado();
            Aspecto.FormatearDGV(dgvMozos);
            Aspecto.FormatearGRP(grpMozos);
        }

        private void Nuevo()
        {
            try
            {
                oBE_Mozo.Codigo = 0;
                oBE_Mozo.DNI = Int32.Parse(txtDNI.Text);
                oBE_Mozo.Nombre = txtNombre.Text;
                oBE_Mozo.Apellido = txtApellido.Text;
                oBE_Mozo.FechaNacimiento = dtpFechaNacimiento.Value;
                oBE_Mozo.Edad = oBE_Mozo.CalcularAños(oBE_Mozo.FechaNacimiento);
                oBE_Mozo.FechaIngreso = dtpFechaIngreso.Value;
                oBE_Mozo.Antiguedad = oBE_Mozo.CalcularAños(oBE_Mozo.FechaIngreso);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void Viejo()
        {
            try
            {
                oBE_Mozo.Codigo = Convert.ToInt32(txtLegajo.Text);
                oBE_Mozo.DNI = Int32.Parse(txtDNI.Text);
                oBE_Mozo.Nombre = txtNombre.Text;
                oBE_Mozo.Apellido = txtApellido.Text;
                oBE_Mozo.FechaNacimiento = dtpFechaNacimiento.Value;
                oBE_Mozo.Edad = oBE_Mozo.CalcularAños(oBE_Mozo.FechaNacimiento);
                oBE_Mozo.FechaIngreso = dtpFechaIngreso.Value;
                oBE_Mozo.Antiguedad = oBE_Mozo.CalcularAños(oBE_Mozo.FechaIngreso);
                oBLL_Mozo.Guardar(oBE_Mozo);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        private void ActualizarListado()
        {
            Cálculos.RefreshGrilla(dgvMozos, oBLL_Mozo.Listar());
            //Aspecto.DGVMozos(dgvMozos);
        }
        private void btnNuevaMozo_Click(object sender, EventArgs e)
        {
            try
            {
                Nuevo();
                if (Cálculos.LargoDNI(oBE_Mozo.DNI.ToString()) && Cálculos.ValidarNombrePersonal(oBE_Mozo.Nombre)&&Cálculos.ValidarApellido(oBE_Mozo.Apellido))
                {
                   //if (!oBLL_Mozo.Existe(oBE_Mozo))
                   // {
                        if (oBLL_Mozo.Guardar(oBE_Mozo))
                        {
                            ActualizarListado();
                            Cálculos.BorrarCampos(grpMozos);
                            Cálculos.MsgBoxAlta(oBE_Mozo.ToString());
                        }
                        else
                        {
                            Cálculos.MsgBoxNoAlta(oBE_Mozo.ToString());
                        }
                        
                    //}
                    //else
                    //{
                    //    Cálculos.MsgBoxSiExisteDNI(oBE_Mozo.ToString());
                    //}
                }
                else
                {
                    Cálculos.MsgBox("El DNI no tiene el formato correcto");
                }
 
            }
            catch (Exception ex)
            {

                Cálculos.MsgBox(ex.Message);
            }
        }

        private void btnModificarMozo_Click(object sender, EventArgs e)
        {
            try
            {
                Viejo();
                //if (!oBLL_Mozo.Existe(oBE_Mozo))
                //{
                    if (oBLL_Mozo.Guardar(oBE_Mozo))
                    {
                        ActualizarListado();
                        Cálculos.BorrarCampos(grpMozos);
                        Cálculos.MsgBoxMod(oBE_Mozo.ToString());
                    }
                    else
                    {
                        Cálculos.MsgBoxNoMod(oBE_Mozo.ToString());
                    }
                    
                //}
                //else
                //{
                //    Cálculos.MsgBoxSiExisteDNI(oBE_Mozo.ToString());
                //}
            }
            catch (Exception ex)
            {

                Cálculos.MsgBox(ex.Message);
            }
        }

        private void dgvMozos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                oBE_Mozo = (BE_Mozo)dgvMozos.SelectedRows[0].DataBoundItem;
                txtLegajo.Text = oBE_Mozo.Codigo.ToString();
                txtDNI.Text = oBE_Mozo.DNI.ToString();
                txtNombre.Text = oBE_Mozo.Nombre;
                txtApellido.Text = oBE_Mozo.Apellido;
                dtpFechaNacimiento.Value = oBE_Mozo.FechaNacimiento;
                dtpFechaIngreso.Value = oBE_Mozo.FechaIngreso;                
            }
            catch { }
        }

        private void btnEliminarMozo_Click(object sender, EventArgs e)
        {
            Viejo();
            if (Cálculos.EstaSeguro("Eliminar", oBE_Mozo.Codigo, oBE_Mozo.ToString()))
            {
                //if (!oBLL_Mozo.ExisteActivo(oBE_Mozo))
                //{
                    if (oBLL_Mozo.Baja(oBE_Mozo))
                    {
                        ActualizarListado();
                        Cálculos.BorrarCampos(grpMozos);
                        Cálculos.MsgBoxBaja(oBE_Mozo.ToString());
                    }
                    else
                    {
                        Cálculos.MsgBoxNoBaja(oBE_Mozo.ToString());
                    }
                    
                //}
                //else
                //{
                //    Cálculos.MsgBoxBajaNegativa(oBE_Mozo.ToString());
                //}
            }
        }

        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            Cálculos.ValidarEntero(e);
        }

        private void frmMozos_Activated(object sender, EventArgs e)
        {
            ActualizarListado();
        }
    }
}
