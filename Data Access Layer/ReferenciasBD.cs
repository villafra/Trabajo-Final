using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Data_Access_Layer
{
    public static class ReferenciasBD
    {
        private static string CarpetaBD = "Base de Datos";
        private static string CarpetaBackUp = "BackUp";
        private static string BasedeDatos = "Restaurant.xml";
        private static string BaseDatosLog = "Logs.xml";
        private static string BaseDatosBackup = "Backups.xml";
        private static string Agenda = "Agenda.xml";
        private static string CarpetaRollBack = $"C:\\Users\\Public\\Documents";
        private static string RollBack = "Rollback.xml";
        private static string NodoRoot = "Restaurant";
        private static string NodoRootBKP = "BackUps";
        private static string QRdir = "PagoQR.png";
        
        private static List<string> Leafs = new List<string>
        {
            "Bebidas",
            "Clientes",
            "Compras",
            "Empleados",
            "Ingredientes",
            "Mesas",
            "Ordenes",
            "Pagos",
            "Pedidos",
            "Platos",
            "Reservas",
            "Bebidas-Ingredientes",
            "Bebidas-Clientes",
            "Platos-Clientes",
            "Reservas-Clientes",
            "Mozo-Pedidos",
            "Ordenes-Pendientes",
            "Platos-Pedidos",
            "Bebidas-Pedidos",
            "Ingredientes-Platos",
            "Materiales-Stocks",
            "Calendarios"
        };

        private static List<XElement> Permisos = new List<XElement>
        {
            new XElement("Permiso",
                new XElement("Codigo", "Comp1"),
                new XElement("Tipo", "PermisoHijo"),
                new XElement("Descripción", "Listado Empleados")),
            new XElement("Permiso",
                new XElement("Codigo", "Comp2"),
                new XElement("Tipo", "PermisoHijo"),
                new XElement("Descripcion", "Rotacion Personal")),
            new XElement("Permiso",
                new XElement("Codigo", "Comp3"),
                new XElement("Tipo", "PermisoHijo"),
                new XElement("Descripcion", "Cargar Novedades")),
            new XElement("Permiso",
                new XElement("Codigo", "Comp4"),
                new XElement("Tipo", "PermisoHijo"),
                new XElement("Descripcion", "Clientes")),
            new XElement("Permiso",
                new XElement("Codigo", "Comp5"),
                new XElement("Tipo", "PermisoHijo"),
                new XElement("Descripcion", "Generar Compras")),
            new XElement("Permiso",
                new XElement("Codigo", "Comp6"),
                new XElement("Tipo", "PermisoHijo"),
                new XElement("Descripcion", "Recetas Platos")),
            new XElement("Permiso",
                new XElement("Codigo", "Comp7"),
                new XElement("Tipo", "PermisoHijo"),
                new XElement("Descripcion", "Costos")),
            new XElement("Permiso",
                new XElement("Codigo", "Comp8"),
                new XElement("Tipo", "PermisoHijo"),
                new XElement("Descripcion", "Listados Ciegos")),
            new XElement("Permiso",
                new XElement("Codigo", "Comp9"),
                new XElement("Tipo", "PermisoHijo"),
                new XElement("Descripcion", "Comparar Stock")),
            new XElement("Permiso",
                new XElement("Codigo", "Comp10"),
                new XElement("Tipo", "PermisoHijo"),
                new XElement("Descripcion", "Ajustes")),
            new XElement("Permiso",
                new XElement("Codigo", "Comp11"),
                new XElement("Tipo", "PermisoHijo"),
                new XElement("Descripcion", "Combinar Mesa")),
            new XElement("Permiso",
                new XElement("Codigo", "Comp12"),
                new XElement("Tipo", "PermisoHijo"),
                new XElement("Descripcion", "Proveedores")),
            new XElement("Permiso",
                new XElement("Codigo", "Comp13"),
                new XElement("Tipo", "PermisoHijo"),
                new XElement("Descripcion", "Métodos de Pago")),
            new XElement("Permiso",
                new XElement("Codigo", "Comp14"),
                new XElement("Tipo", "PermisoHijo"),
                new XElement("Descripcion", "Logs")),
            new XElement("Permiso",
                new XElement("Codigo", "Comp15"),
                new XElement("Tipo", "PermisoHijo"),
                new XElement("Descripcion", "Crear BackUp")),
            new XElement("Permiso",
                new XElement("Codigo", "Comp16"),
                new XElement("Tipo", "PermisoHijo"),
                new XElement("Descripcion", "Restore Back Up")),
            new XElement("Permiso",
                new XElement("Codigo", "Comp18"),
                new XElement("Tipo", "PermisoHijo"),
                new XElement("Descripcion", "Permisos")),
            new XElement("Permiso",
                new XElement("Codigo", "Comp19"),
                new XElement("Tipo", "PermisoHijo"),
                new XElement("Descripcion", "Usuarios")),
            new XElement("Permiso",
                new XElement("Codigo", "Comp20"),
                new XElement("Tipo", "PermisoHijo"),
                new XElement("Descripcion", "Listado Ingredientes")),
            new XElement("Permiso",
                new XElement("Codigo", "Comp21"),
                new XElement("Tipo", "PermisoHijo"),
                new XElement("Descripcion", "Gestionar Ingredientes")),
            new XElement("Permiso",
                new XElement("Codigo", "Comp22"),
                new XElement("Tipo", "PermisoHijo"),
                new XElement("Descripcion", "Listado Bebidas")),
            new XElement("Permiso",
                new XElement("Codigo", "Comp23"),
                new XElement("Tipo", "PermisoHijo"),
                new XElement("Descripcion", "Gestionar Bebidas")),
            new XElement("Permiso",
                new XElement("Codigo", "Comp24"),
                new XElement("Tipo", "PermisoHijo"),
                new XElement("Descripcion", "Listado Platos")),
            new XElement("Permiso",
                new XElement("Codigo", "Comp25"),
                new XElement("Tipo", "PermisoHijo"),
                new XElement("Descripcion", "Gestionar Platos")),
            new XElement("Permiso",
                new XElement("Codigo", "Comp26"),
                new XElement("Tipo", "PermisoHijo"),
                new XElement("Descripcion", "Ingresar Pedido")),
            new XElement("Permiso",
                new XElement("Codigo", "Comp27"),
                new XElement("Tipo", "PermisoHijo"),
                new XElement("Descripcion", "Devolver Pedido")),
            new XElement("Permiso",
                new XElement("Codigo", "Comp28"),
                new XElement("Tipo", "PermisoHijo"),
                new XElement("Descripcion", "Listado Mesas")),
            new XElement("Permiso",
                new XElement("Codigo", "Comp29"),
                new XElement("Tipo", "PermisoHijo"),
                new XElement("Descripcion", "Gestionar Mesas")),
            new XElement("Permiso",
                new XElement("Codigo", "Comp30"),
                new XElement("Tipo", "PermisoHijo"),
                new XElement("Descripcion", "Listado Reservas")),
            new XElement("Permiso",
                new XElement("Codigo", "Comp31"),
                new XElement("Tipo", "PermisoHijo"),
                new XElement("Descripcion", "Gestionar Reservas")),
            new XElement("Permiso",
                new XElement("Codigo", "Comp32"),
                new XElement("Tipo", "PermisoHijo"),
                new XElement("Descripcion", "Listado Ordenes")),
            new XElement("Permiso",
                new XElement("Codigo", "Comp33"),
                new XElement("Tipo", "PermisoHijo"),
                new XElement("Descripcion", "Gestionar Ordenes")),
            new XElement("Permiso",
                new XElement("Codigo", "Comp34"),
                new XElement("Tipo", "PermisoHijo"),
                new XElement("Descripcion", "Listado Pedidos")),
            new XElement("Permiso",
                new XElement("Codigo", "Comp35"),
                new XElement("Tipo", "PermisoHijo"),
                new XElement("Descripcion", "Gestionar Pedidos")),
            new XElement("Permiso",
                new XElement("Codigo", "Comp36"),
                new XElement("Tipo", "PermisoHijo"),
                new XElement("Descripcion", "Recetas Bebidas")),
            new XElement("Permiso",
                new XElement("Codigo", "ADMIN"),
                new XElement("Tipo", "PermisoPadre"),
                new XElement("Descripcion", "Administrador"))
        };

        private static List<XElement> PadreHijo = new List<XElement>()
        {
            new XElement("Padre-Hijo",
                new XElement("Padre", "ADMIN"),
                new XElement("Hijo", "Comp14"),
                new XElement("Activo", true)),
            new XElement("Padre-Hijo",
                new XElement("Padre", "ADMIN"),
                new XElement("Hijo", "Comp15"),
                new XElement("Activo", true)),
            new XElement("Padre-Hijo",
                new XElement("Padre", "ADMIN"),
                new XElement("Hijo", "Comp16"),
                new XElement("Activo", true)),
            new XElement("Padre-Hijo",
                new XElement("Padre", "ADMIN"),
                new XElement("Hijo", "Comp18"),
                new XElement("Activo", true))
        };

        public static string BaseDatosRestaurant
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(CarpetaBD))
                {
                    if (!Directory.Exists(CarpetaBD)) Directory.CreateDirectory(CarpetaBD);
                    return Path.Combine(CarpetaBD, BasedeDatos);
                }
                else return BasedeDatos;
            }
        }
        public static string QR
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(CarpetaBD))
                {
                    if (!Directory.Exists(CarpetaBD)) Directory.CreateDirectory(CarpetaBD);
                    return Path.Combine(CarpetaBD, QRdir);
                }
                else return QRdir;
            }
        }
        public static string BaseDatosBackups
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(CarpetaBackUps))
                {
                    if (!Directory.Exists(CarpetaBackUps)) Directory.CreateDirectory(CarpetaBackUps);
                    return Path.Combine(CarpetaBackUps, BaseDatosBackup);
                }
                else return BasedeDatos;
            }
        }

        public static string CarpetaBackUps
        {
            get
            {
                if (!Directory.Exists(CarpetaBackUp)) Directory.CreateDirectory(CarpetaBackUp);
                return CarpetaBackUp;
            }
        }
        public static string DirectorioBD
        {
            get
            {
                if (!Directory.Exists(CarpetaBD)) Directory.CreateDirectory(CarpetaBD);
                return CarpetaBD;
            }
        }

        public static string BaseDatosLogs
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(CarpetaBD))
                {
                    if (!Directory.Exists(CarpetaBD)) Directory.CreateDirectory(CarpetaBD);
                    return Path.Combine(CarpetaBD, BaseDatosLog);
                }
                else return BaseDatosLog;
            }
        }

        public static string Calendario
        {
            get
            {
                if (!string.IsNullOrEmpty(Agenda))
                {
                    if (!Directory.Exists(CarpetaBD)) Directory.CreateDirectory(CarpetaBD);
                    return Path.Combine(CarpetaBD, Agenda);
                }
                else return Agenda;
            }
        }

        public static List<string> ArmaBD { get { return Leafs; } }
        public static string ArchivoRollBack { get { return Path.Combine(CarpetaRollBack, RollBack); } }
        public static string DirectorioRollBack { get { return CarpetaRollBack; } }
        public static string Root { get { return NodoRoot; } }
        public static string RootBKP { get { return NodoRootBKP; } }
        public static List<XElement> ArmarPermisos { get { return Permisos; } }
        public static List<XElement> ArmaPadreHijo { get { return PadreHijo; } }
        public static string NombreBD { get { return BasedeDatos; } }
    }
}
