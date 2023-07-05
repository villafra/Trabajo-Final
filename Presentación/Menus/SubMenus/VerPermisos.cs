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
    public partial class frmVerPermisos : Form
    {
        BE_Permiso Permiso;
        BLL_Permiso oBLL_Permiso;
        public frmVerPermisos(BE_Permiso permiso)
        {
            InitializeComponent();
            Permiso = permiso;
            oBLL_Permiso = new BLL_Permiso();
            ActualizarListado();
        }

        public void ActualizarListado()
        {
            oBLL_Permiso.ArmarArbol(Permiso);

            ArmarTreeView((BE_PermisoPadre)Permiso);
            Cálculos.RefreshTreeView(tvPermisos);
        }

        private void ArmarTreeView(BE_PermisoPadre perfil)
        {
            tvPermisos.Nodes.Clear();
            TreeNode nodoPadre;
            nodoPadre = tvPermisos.Nodes.Add(perfil.Codigo, perfil.Descripción);
            nodoPadre.Tag = perfil;
            EnramarTreeView(perfil.ListaPermisos(), nodoPadre);
        }
        private void EnramarTreeView(List<BE_Permiso> listado, TreeNode nodoroot)
        {
            foreach (BE_Permiso hijo in listado)
            {
                if (hijo is BE_PermisoPadre)
                {
                    TreeNode nodoPHijo = nodoroot.Nodes.Add(hijo.Codigo, hijo.Descripción);
                    nodoPHijo.Tag = hijo;
                    nodoPHijo.Checked = hijo.Otorgado;
                    EnramarTreeView(hijo.ListaPermisos(), nodoPHijo);
                }
                else
                {
                    TreeNode nodoHijo = nodoroot.Nodes.Add(hijo.Codigo, hijo.Descripción);
                    nodoHijo.Tag = hijo;
                    nodoHijo.Checked = hijo.Otorgado;
                }
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
