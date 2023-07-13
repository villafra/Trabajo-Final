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

namespace Trabajo_Final
{
    public partial class frmBitacora : Form
    {
        public BE_Login UsuarioActivo;
        public frmBitacora(BE_Login user)
        {
            InitializeComponent();
            UsuarioActivo = user;
            Aspecto.FormatearGRP(grpBitacora);
            Aspecto.FormatearDGV(dgvBitacora);
            ActualizarListado();
        }
        public void ActualizarListado()
        {
            Cálculos.RefreshGrilla(dgvBitacora, Bitacora.ListarBitacora(UsuarioActivo));
            VistasDGV.DGVBitacora(dgvBitacora);
        }
    }
}
