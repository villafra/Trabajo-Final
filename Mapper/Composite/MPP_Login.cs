using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Entities;
using Abstraction_Layer;
using Data_Access_Layer;
using System.Xml.Linq;
using System.Data;
using Automate_Layer;

namespace Mapper
{
    public class MPP_Login : IGestionable<BE_Login>
    {
        private static List<BE_TuplaXML> ListadoXML;
        private static MPP_Login mapper = null;
        public static MPP_Login DevolverInstancia()
        {
            if (mapper == null) mapper = new MPP_Login();
            else ListadoXML = null;
            return mapper;
        }
        ~MPP_Login()
        {
            mapper = null;
            ListadoXML = null;
        }
        public bool Baja(BE_Login user)
        {
            ListadoXML = new List<BE_TuplaXML>();
            ListadoXML.Add(CrearLoginXML(user));
            return Xml_Database.DevolverInstancia().Baja(ListadoXML);
        }

        public bool Guardar(BE_Login user)
        {
            ListadoXML = new List<BE_TuplaXML>();
            ListadoXML.Add(CrearLoginXML(user));
            return Xml_Database.DevolverInstancia().Escribir(ListadoXML);
        }
        public List<BE_Login> Listar()
        {
            DataSet ds = new DataSet();
            ds = Xml_Database.DevolverInstancia().Listar();
            
            List<BE_Login> ListaLogins =
                (from log in ds.Tables["Login"].AsEnumerable()
                 select new BE_Login
                 {
                     Codigo = Convert.ToInt32(log[0]),
                     Empleado = Convert.ToString(log[2]) != "admin" ? MPP_Empleado.DevolverInstancia().ListarObjeto(new BE_Mozo { Codigo = Convert.ToInt32(log[1]) }) : null,
                     Usuario = Convert.ToString(log[2]),
                     Password = Convert.ToString(log[3]),
                     CantidadIntentos = Convert.ToInt32(log[4]),
                     Permiso = MPP_Permiso.DevolverInstancia().ListarObjeto(new BE_PermisoPadre { Codigo = log[5].ToString() },ds),
                     Activo = Convert.ToString(log[2]) != "admin" ? Convert.ToBoolean(log[6]) : true,
                     Bloqueado = Convert.ToString(log[2]) != "admin" ? Convert.ToBoolean(log[7]) : false
                 }).ToList();
            return ListaLogins;
        }

        public BE_Login ListarObjeto(BE_Login user, DataSet ds=null)
        {
            if (ds is null)
            {
                ds = new DataSet();
                ds = Xml_Database.DevolverInstancia().Listar();
            }
            BE_Login ObjetoEncontrado = (from log in ds.Tables["Login"].AsEnumerable()
                                         where Convert.ToInt32(log[0]) == user.Codigo
                                         select new BE_Login
                                         {
                                             Codigo = Convert.ToInt32(log[0]),
                                             Empleado = Convert.ToString(log[2]) != "admin" ? MPP_Empleado.DevolverInstancia().ListarObjeto(new BE_Mozo { Codigo = Convert.ToInt32(log[1]) }) : null,
                                             Usuario = Convert.ToString(log[2]),
                                             Password = Convert.ToString(log[3]),
                                             CantidadIntentos = Convert.ToInt32(log[4]),
                                             Permiso = MPP_Permiso.DevolverInstancia().ListarObjeto(new BE_PermisoPadre { Codigo = log[5].ToString() },ds),
                                             Activo = Convert.ToString(log[2]) != "admin" ? Convert.ToBoolean(log[6]) : true,
                                             Bloqueado = Convert.ToString(log[2]) != "admin" ? Convert.ToBoolean(log[7]) : false
                                         }).FirstOrDefault();
            return ObjetoEncontrado;
        }
        public BE_Login ListarLogin(string user)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = Xml_Database.DevolverInstancia().Listar();
                BE_Login ObjetoEncontrado = (from log in ds.Tables["Login"].AsEnumerable()
                                             where log[2].ToString() == user
                                             select new BE_Login
                                             {
                                                 Codigo = Convert.ToInt32(log[0]),
                                                 Empleado = Convert.ToString(log[2]) != "admin" ? MPP_Empleado.DevolverInstancia().ListarObjeto(new BE_Mozo { Codigo = Convert.ToInt32(log[1]) }) : null,
                                                 Usuario = Convert.ToString(log[2]),
                                                 Password = Convert.ToString(log[3]),
                                                 CantidadIntentos = Convert.ToInt32(log[4]),
                                                 Permiso = MPP_Permiso.DevolverInstancia().ListarObjeto(new BE_PermisoPadre { Codigo = log[5].ToString() }, ds),
                                                 Activo = Convert.ToString(log[2]) != "admin" ? Convert.ToBoolean(log[6]) : true,
                                                 Bloqueado = Convert.ToString(log[2]) != "admin" ? Convert.ToBoolean(log[7]) : false
                                             }).FirstOrDefault();
                return ObjetoEncontrado!= null ?ObjetoEncontrado : throw new Exception("El Usuario es inexistente.");
            }
            catch(Exception ex) { throw ex; }
        }

        public bool Modificar(BE_Login user)
        {
            ListadoXML = new List<BE_TuplaXML>();
            ListadoXML.Add(CrearLoginXML(user));
            return Xml_Database.DevolverInstancia().Modificar(ListadoXML);
        }
    
        public BE_Login Login (string user)
        {
            BE_Login DevolverLogin;
            DevolverLogin = ListarLogin(user);
            MPP_Permiso permiso = new MPP_Permiso();
            permiso.ArmarArbol(DevolverLogin.Permiso) ;
            return DevolverLogin;
        }

        private BE_TuplaXML CrearLoginXML(BE_Login user)
        {
            BE_TuplaXML nuevaTupla = new BE_TuplaXML();
            nuevaTupla.NodoRoot = "Logins";
            nuevaTupla.NodoLeaf = "Login";
            XElement nuevoLogin = new XElement("Login",
                new XElement("ID", Cálculos.IDPadleft(user.Codigo)),
                new XElement("ID_Empleado", user.Usuario != "admin" ? user.Empleado.Codigo.ToString(): ""),
                new XElement("Usuario", user.Usuario),
                new XElement("Password", user.Password),
                new XElement("Cantidad_Intentos", user.CantidadIntentos.ToString()),
                new XElement("Permiso", user.Permiso.Codigo.ToString()),
                new XElement("Activo", user.Activo.ToString()),
                new XElement("Bloqueado", user.Bloqueado.ToString())
                );
            nuevaTupla.Xelement = nuevoLogin;
            return nuevaTupla;
        }

        public bool Existe(BE_Login login)
        {
            return Xml_Database.DevolverInstancia().Existe(CrearLoginXML(login), "Usuario");
        }
    }
}
