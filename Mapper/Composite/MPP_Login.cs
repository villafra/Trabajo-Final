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
        Xml_Database Acceso;
        List<BE_TuplaXML> ListadoXML;

        public MPP_Login()
        {
            ListadoXML = new List<BE_TuplaXML>();
        }

        public bool Baja(BE_Login user)
        {
            Acceso = new Xml_Database();
            ListadoXML.Add(CrearLoginXML(user));
            return Acceso.Baja(ListadoXML);
        }

        public bool Guardar(BE_Login user)
        {
            Acceso = new Xml_Database();
            ListadoXML.Add(CrearLoginXML(user));
            return Acceso.Escribir(ListadoXML);
        }
        public List<BE_Login> Listar()
        {
            Acceso = new Xml_Database();
            DataSet ds = new DataSet();
            ds = Acceso.Listar();
            MPP_Empleado oMPP_Empleado = new MPP_Empleado();

            List<BE_Login> ListaLogins = (from log in ds.Tables["Login"].AsEnumerable()
                                          select new BE_Login
                                          {
                                              Codigo = Convert.ToInt32(log[0]),
                                              Empleado = Convert.ToString(log[2]) != "admin" ? oMPP_Empleado.Listar().Find(x => x.Codigo == Convert.ToInt32(log[1])) : null,
                                              Usuario = Convert.ToString(log[2]),
                                              Password = Convert.ToString(log[3]),
                                              CantidadIntentos = Convert.ToInt32(log[4]),
                                              Permiso = (from per in ds.Tables["Permiso"].AsEnumerable()
                                                         where log[5].ToString() == per[0].ToString()
                                                         select new BE_PermisoPadre
                                                         {
                                                             Codigo = per[0].ToString(),
                                                             Descripción = per[2].ToString(),

                                                         }).FirstOrDefault(),
                                              Activo = Convert.ToString(log[2]) != "admin" ? Convert.ToBoolean(log[6]) : true,
                                              Bloqueado = Convert.ToString(log[2]) != "admin" ? Convert.ToBoolean(log[7]) : false
                                          }).ToList();
            return ListaLogins;
        }

        public BE_Login ListarObjeto(BE_Login user)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(BE_Login user)
        {
            Acceso = new Xml_Database();
            ListadoXML.Add(CrearLoginXML(user));
            return Acceso.Modificar(ListadoXML);
        }
    
        public BE_Login Login (string user)
        {
            BE_Login DevolverLogin = new BE_Login();
            DevolverLogin = Listar().Find(x => x.Usuario == user);
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
                new XElement("ID_Empleado", user.Empleado.Codigo.ToString()),
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
    }
}
