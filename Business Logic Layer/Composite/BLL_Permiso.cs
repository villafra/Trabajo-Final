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
        public bool Baja(BE_Permiso permiso)
        {
            return MPP_Permiso.DevolverInstancia().Baja(permiso);
        }

        public bool Guardar(BE_PermisoPadre permiso)
        {
            
            return MPP_Permiso.DevolverInstancia().Guardar(permiso);
        }
        public bool AsignarPermiso(BE_PermisoPadre perfil, BE_Permiso permiso)
        {
            return MPP_Permiso.DevolverInstancia().AsignarPermiso(perfil, permiso);
        }
        public bool DesasignarPermiso(BE_PermisoPadre perfil, BE_Permiso permiso)
        {
            return MPP_Permiso.DevolverInstancia().DesasignarPermiso(perfil, permiso);
        }

        public void ArmarArbol(BE_Permiso permiso)
        {
            MPP_Permiso.DevolverInstancia().ArmarArbol(permiso);
        }

        public bool CambiarStatusPermiso(BE_PermisoPadre perfil, BE_Permiso permiso)
        {
            return MPP_Permiso.DevolverInstancia().CambiarStatusPermiso(perfil, permiso);
        }
        public List<BE_Permiso> Listar()
        {
            return MPP_Permiso.DevolverInstancia().Listar();
        }

        public BE_Permiso ListarObjeto(BE_Permiso Objeto)
        {
            throw new NotImplementedException();
        }

        public List<BE_PermisoPadre> ListarPadre()
        {
            return ArmarTreeView(MPP_Permiso.DevolverInstancia().ListarPadre());
        }

        public bool Modificar(BE_Permiso permiso)
        {
            return MPP_Permiso.DevolverInstancia().Modificar(permiso);
        }
        public bool EliminarPerfil(BE_Permiso perfil)
        {
            return MPP_Permiso.DevolverInstancia().BorrarPerfil(perfil);
        }
        public bool ExistePermiso(BE_PermisoPadre perfil, BE_Permiso permiso)
        {
            return MPP_Permiso.DevolverInstancia().ExistePermiso(perfil, permiso);
        }
        public bool ExisteCircular (BE_PermisoPadre permiso1, BE_PermisoPadre permiso2)
        {
            return MPP_Permiso.DevolverInstancia().ExisteCircular(permiso1, permiso2);
        }
        public bool ExistePerfil(BE_PermisoPadre perfil)
        {
            return MPP_Permiso.DevolverInstancia().ExistePerfil(perfil);
        }
        private List<BE_PermisoPadre> ArmarTreeView(List<BE_PermisoPadre> listado)
        {
            List<BE_PermisoPadre> listapadres = new List<BE_PermisoPadre>();

            foreach (BE_PermisoPadre permiso in listado)
            {
                MPP_Permiso.DevolverInstancia().ArmarArbol(permiso);
                listapadres.Add(permiso);
            }
            return listapadres;
        }

    }
}

