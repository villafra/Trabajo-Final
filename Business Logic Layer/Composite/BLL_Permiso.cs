using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Entities;
using Mapper;
using Abstraction_Layer;

namespace Business_Logic_Layer
{
    public class BLL_Permiso
    {
        MPP_Permiso oMPP_Permiso;

        public bool Baja(BE_Permiso permiso)
        {
            oMPP_Permiso = new MPP_Permiso();
            return oMPP_Permiso.Baja(permiso);
        }

        public bool Guardar(BE_PermisoPadre permiso)
        {
            oMPP_Permiso = new MPP_Permiso();
            return oMPP_Permiso.Guardar(permiso);
        }
        public bool AsignarPermiso(BE_PermisoPadre perfil, BE_Permiso permiso)
        {
            oMPP_Permiso = new MPP_Permiso();
            return oMPP_Permiso.AsignarPermiso(perfil, permiso);
        }
        public bool DesasignarPermiso(BE_PermisoPadre perfil, BE_Permiso permiso)
        {
            oMPP_Permiso = new MPP_Permiso();
            return oMPP_Permiso.DesasignarPermiso(perfil, permiso);
        }
        public bool CambiarStatusPermiso(BE_PermisoPadre perfil, BE_Permiso permiso)
        {
            oMPP_Permiso = new MPP_Permiso();
            return oMPP_Permiso.CambiarStatusPermiso(perfil, permiso);
        }
            public List<BE_Permiso> Listar()
        {
            oMPP_Permiso = new MPP_Permiso();
            return oMPP_Permiso.Listar();
        }

        public BE_Permiso ListarObjeto(BE_Permiso Objeto)
        {
            throw new NotImplementedException();
        }

        public List<BE_PermisoPadre> ListarPadre()
        {
            oMPP_Permiso = new MPP_Permiso();
            return ArmarTreeView(oMPP_Permiso.ListarPadre());
        }

        public bool Modificar(BE_Permiso permiso)
        {
            oMPP_Permiso = new MPP_Permiso();
            return oMPP_Permiso.Modificar(permiso);
        }
        public bool ExistePermiso(BE_PermisoPadre perfil, BE_Permiso permiso)
        {
            oMPP_Permiso = new MPP_Permiso();
            return oMPP_Permiso.ExistePermiso(perfil, permiso);
        }
        public bool ExisteCircular (BE_PermisoPadre permiso1, BE_PermisoPadre permiso2)
        {
            oMPP_Permiso = new MPP_Permiso();
            return oMPP_Permiso.ExisteCircular(permiso1, permiso2);
        }
        public bool ExistePerfil(BE_PermisoPadre perfil)
        {
            oMPP_Permiso = new MPP_Permiso();
            return oMPP_Permiso.ExistePerfil(perfil);
        }
        private List<BE_PermisoPadre> ArmarTreeView(List<BE_PermisoPadre> listado)
        {
            oMPP_Permiso = new MPP_Permiso();
            List<BE_PermisoPadre> listapadres = new List<BE_PermisoPadre>();

            foreach (BE_PermisoPadre permiso in listado)
            {
                oMPP_Permiso.ArmarArbol(permiso);
                listapadres.Add(permiso);
            }
            return listapadres;
        }

    }
}

