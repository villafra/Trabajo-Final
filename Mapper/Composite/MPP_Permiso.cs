using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Entities;
using Data_Access_Layer;


namespace Mapper
{
    public class MPP_Permiso
    {
        Xml_Database Acceso;
        List<BE_TuplaXML> ListadoXML;

        public IList<BE_Permiso> ListarTodos()
        {
            Acceso = new Xml_Database();
            DataSet ds = new DataSet();
            ds = Acceso.Listar();
            List<BE_Permiso> listaCompleta = new List<BE_Permiso>();
            try
            {
                List<BE_PermisoPadre> ListaPadres = (from per in ds.Tables["PermisoPadre"].AsEnumerable()
                                                       select new BE_PermisoPadre
                                                       {
                                                           Codigo = Convert.ToString(per[0]),
                                                           Descripción = Convert.ToString(per[1])
                                                       }).ToList();
                List<BE_PermisoHijo> ListaHijos = (from per in ds.Tables["PermisoHijo"].AsEnumerable()
                                                   select new BE_PermisoHijo
                                                   {
                                                       Codigo = Convert.ToString(per[0]),
                                                       Descripción = Convert.ToString(per[1])
                                                   }).ToList();

                listaCompleta = ListaPadres.Cast<BE_Permiso>().ToList().Concat(ListaHijos.Cast<BE_Permiso>()).ToList();

                return listaCompleta;
            }
            catch (Exception ex)
            {
                listaCompleta = null;
                return listaCompleta;
                throw ex;

            }
            

        }
    }
}
