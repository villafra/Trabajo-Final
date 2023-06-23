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
    public partial class frmPermisos : Form
    {
        BLL_Permiso oBLL_Permiso;
        public frmPermisos()
        {
            InitializeComponent();
            oBLL_Permiso = new BLL_Permiso();
            //Aspecto.FormatearGRP(grpPermisos);
            //Aspecto.FormatearGRPAccion(grpPerfiles);
            Aspecto.FormatearTreeView(tvPermisos);
            ActualizarListado();
        }
        public void ActualizarListado()
        {
            ArmarTreeView(oBLL_Permiso.ListarPadre());
           
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmNuevoLogin frm = new frmNuevoLogin();
            frm.ShowDialog();
            ActualizarListado();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
           
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
           
        }

        private void ArmarTreeView(List<BE_PermisoPadre> perfiles)
        {
            tvPermisos.Nodes.Clear();
            foreach(BE_PermisoPadre padre in perfiles)
            {
                TreeNode nodoPadre = tvPermisos.Nodes.Add(padre.Codigo, padre.ToString());
                nodoPadre.Tag = padre;
                foreach (BE_PermisoHijo hijo in padre._permisos)
                {
                    TreeNode nodoHijo = nodoPadre.Nodes.Add(hijo.Codigo, hijo.ToString());
                    nodoHijo.Tag = hijo;
                }
            }
        }
    }
}
