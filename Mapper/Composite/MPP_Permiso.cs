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

        public List<BE_Permiso> Listar()
        {
            Acceso = new Xml_Database();
            DataSet ds = new DataSet();
            ds = Acceso.Listar();
            List<BE_Permiso> listado = (from per in ds.Tables["Permiso"].AsEnumerable()
                                        select per[1].ToString() == "PermisoPadre" ? new BE_PermisoPadre
                                        {
                                            Codigo = per[0].ToString(),
                                            Descripción = per[2].ToString(),
                                        } : (BE_Permiso)new BE_PermisoHijo
                                        {
                                            Codigo = per[0].ToString(),
                                            Descripción = per[2].ToString(),
                                        }).ToList();
            return listado;
        }
        public List<BE_PermisoPadre> ListarPadre()
        {
            Acceso = new Xml_Database();
            DataSet ds = new DataSet();
            ds = Acceso.Listar();
            List<BE_PermisoPadre> listado = (from per in ds.Tables["Permiso"].AsEnumerable()
                                        where per[1].ToString() == "PermisoPadre" 
                                        select new BE_PermisoPadre
                                        {
                                            Codigo = per[0].ToString(),
                                            Descripción = per[2].ToString(),
                                        } ).ToList();
            return listado;
        }

        public void ArmarArbol(BE_Permiso padre)
        {
            Acceso = new Xml_Database();
            DataSet ds = Acceso.Listar();
            ((BE_PermisoPadre)padre)._permisos =  ObtenerPermisos(ds, padre);
        } 

        public List<BE_Permiso> ObtenerPermisos (DataSet ds, BE_Permiso padre)
        {
            List<BE_Permiso> permisos = new List<BE_Permiso>();

            var query = from hj in ds.Tables["Padre-Hijo"].AsEnumerable()
                        where padre.Codigo == hj[0].ToString()
                        join per in ds.Tables["Permiso"].AsEnumerable()
                        on hj[1].ToString() equals per[0].ToString()
                        select new
                        {
                            Codigo = per[0].ToString(),
                            Tipo = per[1].ToString(),
                            Descripción = per[2].ToString(),
                            Otorgado = Convert.ToBoolean(hj[2])
                        };
            foreach (var item in query)
            {
                if (item.Tipo == "PermisoPadre")
                {
                    BE_PermisoPadre permisoPadre = new BE_PermisoPadre
                    {
                        Codigo = item.Codigo,
                        Descripción = item.Descripción,
                        _permisos = ObtenerPermisos(ds, new BE_PermisoPadre { Codigo = item.Codigo })
                    };
                    permisos.Add(permisoPadre);
                }
                else
                {
                    BE_PermisoHijo permisoHijo = new BE_PermisoHijo
                    {
                        Codigo = item.Codigo,
                        Descripción = item.Descripción,
                        Otorgado = item.Otorgado
                    };
                    permisos.Add(permisoHijo);
                }
            }
            return permisos;
        }
        
    }
}
