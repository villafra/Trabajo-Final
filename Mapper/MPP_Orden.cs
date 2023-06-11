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

namespace Mapper
{
    public class MPP_Orden:IGestionable<BE_Orden>
    {
        Xml_Database Acceso;
        List<BE_TuplaXML> ListadoXML;

        public MPP_Orden()
        {
            ListadoXML = new List<BE_TuplaXML>();
        }

        public bool Baja(BE_Orden orden)
        {
            Acceso = new Xml_Database();
            ListadoXML.Add(CrearOrdenXML(orden));
            return Acceso.Borrar(ListadoXML);
        }

        public bool Guardar(BE_Orden orden)
        {
            Acceso = new Xml_Database();
            ListadoXML.Add(CrearOrdenXML(orden));
            return Acceso.Escribir(ListadoXML);
        }

        public List<BE_Orden> Listar()
        {
            Acceso = new Xml_Database();
            DataSet ds = new DataSet();
            ds = Acceso.Listar();

            List<BE_Orden> listadeOrdenes = ds.Tables.Contains("Orden") != false ? (from ord in ds.Tables["Orden"].AsEnumerable()
                                             select new BE_Orden
                                             {
                                                 Codigo = Convert.ToInt32(ord[0]),
                                                 Pasos_Orden = Convert.ToInt32(ord[1]),
                                                 Status = Convert.ToString(ord[2]),
                                                 ID_Pedido = ds.Tables.Contains("Pedido") != false ? (from ped in ds.Tables["Pedido"].AsEnumerable()
                                                              where Convert.ToInt32(ord[3]) == Convert.ToInt32(ped[0])
                                                              select new BE_Pedido
                                                              {
                                                                  Codigo = Convert.ToInt32(ped[0]),
                                                                  FechaInicio = Convert.ToDateTime(ped[1]),
                                                                  Customizado = Convert.ToBoolean(ped[2]),
                                                                  Aclaraciones = Convert.ToString(ped[3]),
                                                                  Status = Convert.ToString(ped[4]),
                                                                  Monto_Total = Convert.ToDecimal(ped[5]),
                                                                  ID_Pago = ds.Tables.Contains("Pago") != false ? (from pago in ds.Tables["Pago"].AsEnumerable()
                                                                             where Convert.ToInt32(ped[6]) == Convert.ToInt32(pago[0])
                                                                             select new BE_Pago
                                                                             {
                                                                                 Codigo = Convert.ToInt32(pago[0]),
                                                                                 Tipo = Convert.ToString(pago[1])
                                                                             }).FirstOrDefault():null,
                                                                  ListadeBebida = ds.Tables.Contains("Bebida-Pedido") & ds.Tables.Contains("Bebida") != false ? (from obj in ds.Tables["Bebida-Pedido"].AsEnumerable()
                                                                                   join beb in ds.Tables["Bebida"].AsEnumerable()
                                                                                   on Convert.ToInt32(obj[1]) equals Convert.ToInt32(ped[0])
                                                                                   select new BE_Bebida
                                                                                   {

                                                                                   }).ToList():null,
                                                                  ListadePlatos = ds.Tables.Contains("Plato-Pedido") & ds.Tables.Contains("Plato") != false ? (from obj in ds.Tables["Plato-Pedido"].AsEnumerable()
                                                                                   join platos in ds.Tables["Plato"].AsEnumerable()
                                                                                   on Convert.ToInt32(obj[1]) equals Convert.ToInt32(ped[0])
                                                                                   select new BE_Plato
                                                                                   {
                                                                                       Codigo = Convert.ToInt32(platos[0]),
                                                                                       Nombre = Convert.ToString(platos[1]),
                                                                                       Tipo = (BE_Plato.Tipo_Plato)Enum.Parse(typeof(BE_Plato.Tipo_Plato), Convert.ToString(platos[2])),
                                                                                       Clase = (BE_Plato.Clasificación)Enum.Parse(typeof(BE_Plato.Clasificación), Convert.ToString(platos[3])),
                                                                                       Status = Convert.ToString(platos[4]),
                                                                                       CostoUnitario = Convert.ToDecimal(platos[5]),
                                                                                       Activo = Convert.ToBoolean(platos[6]),
                                                                                       ListaIngredientes = ds.Tables.Contains("Ingrediente") != false ? (from obje in ds.Tables["Ingrediente-Plato"].AsEnumerable()
                                                                                                            join ing in ds.Tables["Ingrediente"].AsEnumerable()
                                                                                                            on Convert.ToInt32(obje[1]) equals Convert.ToInt32(platos[0])
                                                                                                            select new BE_Ingrediente
                                                                                                            {
                                                                                                                Codigo = Convert.ToInt32(ing[0]),
                                                                                                                Nombre = Convert.ToString(ing[1]),
                                                                                                                Tipo = Convert.ToString(ing[2]),
                                                                                                                Refrigeracion = Convert.ToBoolean(ing[3]),
                                                                                                                Stock = Convert.ToDecimal(ing[4]),
                                                                                                                UnidadMedida = Convert.ToString(ing[5]),
                                                                                                                FechaCreacion = Convert.ToDateTime(ing[6]),
                                                                                                                Lote = Convert.ToString(ing[7]),
                                                                                                                Activo = Convert.ToBoolean(ing[8]),
                                                                                                                VidaUtil = Convert.ToInt32(ing[9]),
                                                                                                                Status = Convert.ToString(ing[10]),
                                                                                                                CostoUnitario = Convert.ToDecimal(ing[11])

                                                                                                            }).ToList():null

                                                                                   }).ToList():null,



                                                              }).FirstOrDefault():null,
                                                 ID_Mesa = ds.Tables.Contains("Mesa") != false ? (from mes in ds.Tables["Mesa"].AsEnumerable()
                                                            where Convert.ToInt32(ord[4]) == Convert.ToInt32(mes[0])
                                                            select new BE_Mesa
                                                            {
                                                                Codigo = Convert.ToInt32(mes[0]),
                                                                Capacidad = Convert.ToInt32(mes[1]),
                                                                Ubicación = Convert.ToString(mes[2]),
                                                                OcupaciónActual = Convert.ToInt32(mes[3]),
                                                                Status = Convert.ToString(mes[4]),
                                                            }).FirstOrDefault():null,
                                                 ID_Empleado = ds.Tables.Contains("Mozo") != false ? (from mo in ds.Tables["Mozo"].AsEnumerable()
                                                                where Convert.ToInt32(ord[5]) == Convert.ToInt32(mo[0])
                                                                select new BE_Mozo
                                                                {
                                                                    Codigo = Convert.ToInt32(mo[0]),
                                                                    DNI = Convert.ToInt64(mo[1]),
                                                                    Nombre = Convert.ToString(mo[2]),
                                                                    Apellido = Convert.ToString(mo[3]),
                                                                    FechaNacimiento = Convert.ToDateTime(mo[4]),
                                                                    Edad = Convert.ToInt32(mo[5]),
                                                                    FechaIngreso = Convert.ToDateTime(mo[6]),
                                                                    Antiguedad = Convert.ToInt32(mo[7]),
                                                                    Categoria = (BE_Empleado.Category)Enum.Parse(typeof(BE_Empleado.Category), Convert.ToString(mo[8])),
                                                                    PedidosTomados = ds.Tables.Contains("Mozo-Pedido") & ds.Tables.Contains("Pedido") != false ? (from obj in ds.Tables["Mozo-Pedido"].AsEnumerable()
                                                                                                                                                                       join ped in ds.Tables["Pedido"].AsEnumerable()
                                                                                                                                                                       on Convert.ToInt32(obj[1]) equals Convert.ToInt32(mo[0])
                                                                                                                                                                       select new BE_Pedido
                                                                                                                                                                       {
                                                                                                                                                                           Codigo = Convert.ToInt32(ped[0]),
                                                                                                                                                                           FechaInicio = Convert.ToDateTime(ped[1]),
                                                                                                                                                                           Customizado = Convert.ToBoolean(ped[2]),
                                                                                                                                                                           Aclaraciones = Convert.ToString(ped[3]),
                                                                                                                                                                           Status = Convert.ToString(ped[4]),
                                                                                                                                                                           Monto_Total = Convert.ToDecimal(ped[5]),
                                                                                                                                                                           ID_Pago = ds.Tables.Contains("Pago") != false ? (from pago in ds.Tables["Pago"].AsEnumerable()
                                                                                                                                                                                                                            where Convert.ToInt32(ped[6]) == Convert.ToInt32(pago[0])
                                                                                                                                                                                                                            select new BE_Pago
                                                                                                                                                                                                                            {
                                                                                                                                                                                                                                Codigo = Convert.ToInt32(pago[0]),
                                                                                                                                                                                                                                Tipo = Convert.ToString(pago[1])
                                                                                                                                                                                                                            }).FirstOrDefault() : null,
                                                                                                                                                                           ListadeBebida = ds.Tables.Contains("Bebida-Pedido") & ds.Tables.Contains("Bebida") != false ? (from obj1 in ds.Tables["Bebida_Pedido"].AsEnumerable()
                                                                                                                                                                                                                                                                          join beb in ds.Tables["Bebida"].AsEnumerable()
                                                                                                                                                                                                                                                                          on Convert.ToInt32(obj1[1]) equals Convert.ToInt32(ped[0])
                                                                                                                                                                                                                                                                          select new BE_Bebida
                                                                                                                                                                                                                                                                          {

                                                                                                                                                                                                                                                                          }).ToList() : null,
                                                                                                                                                                           ListadePlatos = ds.Tables.Contains("Plato-Pedido") & ds.Tables.Contains("Plato") != false ? (from obj2 in ds.Tables["Plato-Pedido"].AsEnumerable()
                                                                                                                                                                                                                                                                        join platos in ds.Tables["Plato"].AsEnumerable()
                                                                                                                                                                                                                                                                        on Convert.ToInt32(obj2[1]) equals Convert.ToInt32(ped[0])
                                                                                                                                                                                                                                                                        select new BE_Plato
                                                                                                                                                                                                                                                                        {
                                                                                                                                                                                                                                                                            Codigo = Convert.ToInt32(platos[0]),
                                                                                                                                                                                                                                                                            Nombre = Convert.ToString(platos[1]),
                                                                                                                                                                                                                                                                            Tipo = (BE_Plato.Tipo_Plato)Enum.Parse(typeof(BE_Plato.Tipo_Plato), Convert.ToString(platos[2])),
                                                                                                                                                                                                                                                                            Clase = (BE_Plato.Clasificación)Enum.Parse(typeof(BE_Plato.Clasificación), Convert.ToString(platos[3])),
                                                                                                                                                                                                                                                                            Status = Convert.ToString(platos[4]),
                                                                                                                                                                                                                                                                            CostoUnitario = Convert.ToDecimal(platos[5]),
                                                                                                                                                                                                                                                                            Activo = Convert.ToBoolean(platos[6]),
                                                                                                                                                                                                                                                                            ListaIngredientes = ds.Tables.Contains("Ingrediente-Plato") & ds.Tables.Contains("Ingrediente") != false ? (from obje in ds.Tables["Ingrediente-Plato"].AsEnumerable()
                                                                                                                                                                                                                                                                                                                                                                                        join ing in ds.Tables["Ingrediente"].AsEnumerable()
                                                                                                                                                                                                                                                                                                                                                                                        on Convert.ToInt32(obje[1]) equals Convert.ToInt32(platos[0])
                                                                                                                                                                                                                                                                                                                                                                                        select new BE_Ingrediente
                                                                                                                                                                                                                                                                                                                                                                                        {
                                                                                                                                                                                                                                                                                                                                                                                            Codigo = Convert.ToInt32(ing[0]),
                                                                                                                                                                                                                                                                                                                                                                                            Nombre = Convert.ToString(ing[1]),
                                                                                                                                                                                                                                                                                                                                                                                            Tipo = Convert.ToString(ing[2]),
                                                                                                                                                                                                                                                                                                                                                                                            Refrigeracion = Convert.ToBoolean(ing[3]),
                                                                                                                                                                                                                                                                                                                                                                                            Stock = Convert.ToDecimal(ing[4]),
                                                                                                                                                                                                                                                                                                                                                                                            UnidadMedida = Convert.ToString(ing[5]),
                                                                                                                                                                                                                                                                                                                                                                                            Lote = Convert.ToString(ing[6]),
                                                                                                                                                                                                                                                                                                                                                                                            Activo = Convert.ToBoolean(ing[7]),
                                                                                                                                                                                                                                                                                                                                                                                            VidaUtil = Convert.ToInt32(ing[8]),
                                                                                                                                                                                                                                                                                                                                                                                            Status = Convert.ToString(ing[9]),
                                                                                                                                                                                                                                                                                                                                                                                            CostoUnitario = Convert.ToDecimal(ing[10])

                                                                                                                                                                                                                                                                                                                                                                                        }).ToList() : null
                                                                                                                                                                                                                                                                        }).ToList() : null,
                                                                                                                                                                       }).ToList() : null
                                                                }).FirstOrDefault():null,
                                             }).ToList():null;
            return listadeOrdenes;
        }

        public BE_Orden ListarObjeto(BE_Orden orden)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(BE_Orden orden)
        {
            Acceso = new Xml_Database();
            ListadoXML.Add(CrearOrdenXML(orden));
            return Acceso.Modificar(ListadoXML);
        }

        private BE_TuplaXML CrearOrdenXML (BE_Orden orden)
        {
            BE_TuplaXML nuevaTupla = new BE_TuplaXML();
            nuevaTupla.NodoRoot = "Ordenes";
            nuevaTupla.NodoLeaf = "Orden";
            XElement nuevaOrden = new XElement("Orden",
                new XElement("ID", orden.Codigo.ToString()),
                new XElement("Pasos Orden", orden.Pasos_Orden.ToString()),
                new XElement("Status", orden.Status),
                new XElement("ID Pedido", orden.ID_Pedido.ToString()),
                new XElement("ID Mesa", orden.ID_Mesa.ToString()),
                new XElement("ID Empleado", orden.ID_Empleado.ToString())
                );
            nuevaTupla.Xelement = nuevaOrden;
            return nuevaTupla;
        }
    }
}
