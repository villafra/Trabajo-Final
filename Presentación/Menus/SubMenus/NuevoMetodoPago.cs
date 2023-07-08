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
    public partial class frmNuevoMetodoPago : Form
    {

        public BE_Pago oBE_Pago;
        BLL_Pago oBLL_Pago;
        private bool status;
        public frmNuevoMetodoPago()
        {
            InitializeComponent();
            oBLL_Pago = new BLL_Pago();
            Aspecto.FormatearSubMenu(this, grpNuevoLogin, this.Width, this.Height);
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (_ = oBE_Pago != null ? Viejo() : Nuevo())
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
            oBE_Pago.Codigo = Convert.ToInt32(txtCodigo.Text);
            oBE_Pago.Tipo = txtDescripcion.Text;
            oBE_Pago.Activo = chkActivo.Checked;
            return oBLL_Pago.Modificar(oBE_Pago);
        }

        private bool Nuevo()
        {
            oBE_Pago = new BE_Pago();
            oBE_Pago.Tipo = txtDescripcion.Text;
            return oBLL_Pago.Guardar(oBE_Pago);
        }
        private void ImportarPago()
        {
            if (oBE_Pago != null)
            {
                txtCodigo.Text = oBE_Pago.Codigo.ToString();
                txtDescripcion.Text = oBE_Pago.Tipo;
                status = oBE_Pago.Activo;
                chkActivo.Checked = status;
                chkActivo.Visible = true;
            }
        }

        private void frmNuevoLogin_Load(object sender, EventArgs e)
        {
            ImportarPago();
        }
    }
}
