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
        public IList<BE_Permiso> Listar()
        {
            return oMPP_Permiso.Listar();
        }
  
        public List<BE_PermisoPadre> ListarPadre()
        {
            return ArmarTreeView(oMPP_Permiso.ListarPadre());
        }
        private List<BE_PermisoPadre> ArmarTreeView(List<BE_PermisoPadre> listado)
        {
            List<BE_PermisoPadre> listapadres = new List<BE_PermisoPadre>();

            foreach(BE_PermisoPadre permiso in listado)
            {
                oMPP_Permiso.ArmarArbol(permiso);
                listapadres.Add(permiso);
            }
            return listapadres;
        }

    }
}

