using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Entities;
using Mapper;

namespace Business_Logic_Layer
{
    public class BLL_Permiso
    {
        MPP_Permiso oMPP_Permiso;
        public BLL_Permiso()
        {
            oMPP_Permiso = new MPP_Permiso();
        }
        public IList<BE_Permiso> ListarTodos()
        {
            return oMPP_Permiso.ListarTodos();
        }
        public IList<BE_Permiso> ArmarArbol(BE_PermisoPadre padre)
        {
            return oMPP_Permiso.ArmarArbol(padre);
        }

        //private void LlenarPermisosRecursivo(List<BE_Permiso> permisos, string codigoPermiso, ArrayList arbolCodigos, bool denegar)
        //{
        //    if (!arbolCodigos.Contains(codigoPermiso)) //Evia el abrazo de oso; si el codigo de permiso a recorrer ya se encuentra en el arbol es porque hay una referencia circular, ergo, se ignora.
        //    {
        //        arbolCodigos.Add(codigoPermiso);
        //        foreach (BE_Permiso p in _abmc.Buscar(nameof(BE_Permiso.Codigo).ObtenerFullNameMasPropiedad<Permiso>(), codigoPermiso)[0].ObtenerPermisos())
        //        {
        //            if (denegar) //Si el compuesto llamador está denegado (es decir no otorgado) se denegan todos los permisos asociados.
        //                p.Otorgado = false;
        //            if (p is BE_PermisoPadre)
        //            {
        //                denegar = !p.Otorgado;
        //                LlenarPermisosRecursivo(permisos, p.Codigo, arbolCodigos, denegar);
        //            }
        //            else
        //                permisos.Add(p);
        //        }
        //        arbolCodigos.Remove(codigoPermiso);
        //    }
        //}
    
    }
}

