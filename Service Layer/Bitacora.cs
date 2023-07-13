using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Business_Entities;
using Data_Access_Layer;

namespace Service_Layer
{
    public static class Bitacora
    {
        private static BE_Bitacora oBE_Bitacora;
        public static void Login(BE_Login user)
        {
            oBE_Bitacora = new BE_Bitacora();
            oBE_Bitacora.CodigoUsuario = user.Codigo;
            oBE_Bitacora.Empleado = user.Empleado != null ? user.Empleado.ToString() : null;
            oBE_Bitacora.Acción = Accion.Login;
            oBE_Bitacora.FechaHora = DateTime.Now;
            Guardar(oBE_Bitacora);
        }
        public static void Logout(BE_Login user)
        {
            oBE_Bitacora.CodigoUsuario = user.Codigo;
            oBE_Bitacora.Empleado = user.Empleado != null ? user.Empleado.ToString() : null;
            oBE_Bitacora.Acción = Accion.Logout;
            oBE_Bitacora.FechaHora = DateTime.Now;
            Guardar(oBE_Bitacora);
        }

        private static void Guardar(BE_Bitacora bita)
        {
            try
            {
                if (!File.Exists(ReferenciasBD.BaseDatosLogs))
                {
                    XDocument BDLogin = new XDocument();
                    XElement Root = new XElement("Bitacoras");
                    XElement Leaf = new XElement("Bitacora",
                        new XElement("Codigo", bita.CodigoUsuario),
                        new XElement("Usuario", bita.Empleado != null ? bita.Empleado.ToString() : "admin"),
                        new XElement("Accion", bita.Acción),
                        new XElement("FechaHora", bita.FechaHora.ToString("dd/MM/yyyy HH:mm:ss"))
                        );
                    Root.Add(Leaf);
                    Root.Save(ReferenciasBD.BaseDatosLogs);
                }
                else
                {
                    XDocument logs = XDocument.Load(ReferenciasBD.BaseDatosLogs);
                    logs.Root.Add(new XElement("Bitacora",
                        new XElement("Codigo", bita.CodigoUsuario),
                        new XElement("Usuario", bita.Empleado != null ? bita.Empleado.ToString() : "admin"),
                        new XElement("Accion", bita.Acción),
                        new XElement("FechaHora", bita.FechaHora.ToString("dd/MM/yyyy HH:mm:ss"))
                        ));
                    logs.Save(ReferenciasBD.BaseDatosLogs);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static List<BE_Bitacora> ListarBitacora(BE_Login user)
        {
            DataSet ds = Listar();
            List<BE_Bitacora> listado;
            if (ds != null)
            {
                listado = (from btca in ds.Tables["Bitacora"].AsEnumerable()
                           where Convert.ToInt32(btca[0]) == user.Codigo
                           select new BE_Bitacora
                           {
                               CodigoUsuario = Convert.ToInt32(btca[0]),
                               Empleado = btca[1].ToString(),
                               Acción = (Accion)Enum.Parse(typeof(Accion), btca[2].ToString()),
                               FechaHora = Convert.ToDateTime(btca[3])
                           }
                           ).ToList();
            }
            else { listado = null; }
            return listado;
        }
        private static DataSet Listar()
        {
            DataSet ds = new DataSet();
            if (ExisteBD()) ds.ReadXml(ReferenciasBD.BaseDatosLogs, XmlReadMode.Auto);
            else ds = null;
            return ds;
        }
        private static bool ExisteBD()
        {
            return File.Exists(ReferenciasBD.BaseDatosLogs);

        }
    }
}
