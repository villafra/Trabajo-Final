using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Entities;
using Data_Access_Layer;
using Abstraction_Layer;
using System.Xml.Linq;

namespace Mapper
{
    public class MPP_Permiso
    {
        Xml_Database Acceso;
        List<BE_TuplaXML> ListadoXML;

        public MPP_Permiso()
        {
            ListadoXML = new List<BE_TuplaXML>();
        }

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
                        Otorgado = item.Otorgado,
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

            permisos.Sort((p1, p2) => {
                if (p1 is BE_PermisoHijo && p2 is BE_PermisoPadre) { return -1; }
                else if (p1 is BE_PermisoPadre && p2 is BE_PermisoHijo) { return 1; }
                else { return 0; }
            });

            return permisos;
                
        }
        public bool Guardar(BE_Permiso permiso)
        {
            Acceso = new Xml_Database();
            ListadoXML.Add(CrearPermisoXML(permiso));
            return Acceso.EscribirPermiso(ListadoXML);
        }

        public bool Baja(BE_Permiso permiso)
        {
            Acceso = new Xml_Database();
            ListadoXML.Add(CrearPermisoXML(permiso));
            return Acceso.Borrar(ListadoXML);
        }

        public bool Modificar(BE_Permiso permiso)
        {
            Acceso = new Xml_Database();
            ListadoXML.Add(CrearPermisoXML(permiso));
            return Acceso.ModificarPermiso(ListadoXML);
        }
        public bool AsignarPermiso(BE_PermisoPadre perfil, BE_Permiso permiso)
        {
            Acceso = new Xml_Database();
            ListadoXML.Add(AsignarPermisoXML(perfil, permiso));
            return Acceso.EscribirPermiso(ListadoXML);

        }
        public bool DesasignarPermiso(BE_PermisoPadre perfil, BE_Permiso permiso)
        {
            Acceso = new Xml_Database();
            ListadoXML.Add(AsignarPermisoXML(perfil, permiso));
            return Acceso.BorrarPermiso(ListadoXML);
        }
        public bool CambiarStatusPermiso(BE_PermisoPadre perfil, BE_Permiso permiso)
        {
            Acceso = new Xml_Database();
            ListadoXML.Add(AsignarPermisoXML(perfil, permiso));
            return Acceso.CambiarStatusPermiso(ListadoXML);
        }
        public bool ExistePerfil(BE_PermisoPadre perfil)
        {
            Acceso = new Xml_Database();
            return Acceso.Existe(CrearPermisoXML(perfil),"Codigo");
        }
        public bool ExistePermiso(BE_PermisoPadre perfil, BE_Permiso permiso)
        {
            Acceso = new Xml_Database();
            ListadoXML.Add(AsignarPermisoXML(perfil, permiso));
            return Acceso.ExistePermiso(ListadoXML);
        }
        public bool ExisteCircular(BE_PermisoPadre permiso1, BE_PermisoPadre permiso2)
        {
            foreach (BE_Permiso permiso in permiso1.ListaPermisos())
            {
                if (permiso1.ListaPermisos().Any(p => p.Codigo.Equals(permiso2.Codigo)))
                {
                    return false;
                }
                if (permiso is BE_PermisoPadre padre)
                {
                    if (!ExisteCircular(padre, permiso2)) { return false; }
                }
            }
            ArmarArbol(permiso2);
            foreach (BE_Permiso permiso in permiso2.ListaPermisos() )
            {
                if (permiso2.ListaPermisos().Any(p => p.Codigo.Equals(permiso1.Codigo)))
                {
                    return false;
                }
                if (permiso is BE_PermisoPadre padre)
                {
                    if (!ExisteCircular(padre, permiso1)) { return false; }
                }
            }
            return true;
        }
        public BE_Permiso ListarObjeto(BE_Permiso permiso)
        {
            throw new NotImplementedException();
        }
        private BE_TuplaXML CrearPermisoXML(BE_Permiso permiso)
        {
            BE_TuplaXML nuevaTupla = new BE_TuplaXML();
            nuevaTupla.NodoRoot = "Permisos";
            nuevaTupla.NodoLeaf = "Permiso";
            XElement nuevoPermiso = new XElement("Permiso",
                new XElement("Codigo", permiso.Codigo),
                new XElement("Tipo", (permiso is BE_PermisoPadre) ? "PermisoPadre" : "PermisoHijo"),
                new XElement("Descripcion", permiso.Descripción)
                );
            nuevaTupla.Xelement = nuevoPermiso;
            return nuevaTupla;
        }
        private BE_TuplaXML AsignarPermisoXML(BE_PermisoPadre perfil, BE_Permiso permiso)
        {
            BE_TuplaXML nuevaTupla = new BE_TuplaXML();
            nuevaTupla.NodoRoot = "Padres-Hijos";
            nuevaTupla.NodoLeaf = "Padre-Hijo";
            XElement nuevoPermiso = new XElement("Padre-Hijo",
                new XElement("Padre", perfil.Codigo),
                new XElement("Hijo", permiso.Codigo),
                new XElement ("Activo", permiso.Otorgado)
                );
            nuevaTupla.Xelement = nuevoPermiso;
            return nuevaTupla;
        }
    }
}
