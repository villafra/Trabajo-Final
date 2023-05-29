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
    public class MPP_Mesa:IGestionable<BE_Mesa>
    {
        Xml_Database Acceso;
        List<BE_TuplaXML> ListadoXML;

        public MPP_Mesa()
        {
            ListadoXML = new List<BE_TuplaXML>();
        }

        public bool Baja(BE_Mesa mesa)
        {
            Acceso = new Xml_Database();
            ListadoXML.Add(CrearMesaXML(mesa));
            return Acceso.Borrar(ListadoXML);
        }

        public bool Guardar(BE_Mesa mesa)
        {
            Acceso = new Xml_Database();
            ListadoXML.Add(CrearMesaXML(mesa));
            return Acceso.Escribir(ListadoXML);
        }

        public List<BE_Mesa> Listar()
        {
            Acceso = new Xml_Database();
            DataSet ds = new DataSet();
            ds = Acceso.Listar();

            List<BE_Mesa> listadeMesas = (from mes in ds.Tables["Mesa"].AsEnumerable()
                                          select new BE_Mesa
                                          {
                                              Codigo = Convert.ToInt32(mes[0]),
                                              Capacidad = Convert.ToInt32(mes[1]),
                                              Ubicación = Convert.ToString(mes[2]),
                                              OcupaciónActual = Convert.ToInt32(mes[3]),
                                              Status = Convert.ToString(mes[4]),
                                              ID_Empleado = (from emp in ds.Tables["Empleado"].AsEnumerable()
                                                             where Convert.ToInt32(emp[0]) == Convert.ToInt32(mes[5])
                                                             select new BE_Mozo
                                                             {
                                                                 Codigo = Convert.ToInt32(emp[0]),
                                                                 DNI = Convert.ToInt64(emp[1]),
                                                                 Nombre = Convert.ToString(emp[2]),
                                                                 Apellido = Convert.ToString(emp[3]),
                                                                 FechaNacimiento = Convert.ToDateTime(emp[4]),
                                                                 Edad = Convert.ToInt32(emp[5]),
                                                                 FechaIngreso = Convert.ToDateTime(emp[6]),
                                                                 Antiguedad = Convert.ToInt32(emp[7]),
                                                                 Categoria = Convert.ToString(emp[8]),
                                                                 PedidosTomados = (from pedemp in ds.Tables["Pedido-Mozo"].AsEnumerable()
                                                                                   join ped in ds.Tables["Pedido"].AsEnumerable()
                                                                                   on Convert.ToInt32(pedemp[1]) equals Convert.ToInt32(ped[0])
                                                                                   select new BE_Pedido
                                                                                   {
                                                                                       Codigo = Convert.ToInt32(ped[0]),
                                                                                       FechaInicio = Convert.ToDateTime(ped[1]),
                                                                                       Customizado = Convert.ToBoolean(ped[2]),
                                                                                       Aclaraciones = Convert.ToString(ped[3]),
                                                                                       Status = Convert.ToString(ped[4]),
                                                                                       Monto_Total = Convert.ToDecimal(ped[5]),
                                                                                       ID_Pago = (from pago in ds.Tables["Pago"].AsEnumerable()
                                                                                                  where Convert.ToInt32(ped[6]) == Convert.ToInt32(pago[0])
                                                                                                  select new BE_Pago
                                                                                                  {
                                                                                                      Codigo = Convert.ToInt32(pago[0]),
                                                                                                      Tipo = Convert.ToString(pago[1])
                                                                                                  }).FirstOrDefault(),
                                                                                       ListadeBebida = (from obj in ds.Tables["Bebida-Pedido"].AsEnumerable()
                                                                                                        join beb in ds.Tables["Bebida"].AsEnumerable()
                                                                                                        on Convert.ToInt32(obj[1]) equals Convert.ToInt32(ped[0])
                                                                                                        select new BE_Bebida
                                                                                                        {

                                                                                                        }).ToList(),
                                                                                       ListadePlatos = (from obj in ds.Tables["Plato-Pedido"].AsEnumerable()
                                                                                                        join platos in ds.Tables["Plato"].AsEnumerable()
                                                                                                        on Convert.ToInt32(obj[1]) equals Convert.ToInt32(ped[0])
                                                                                                        select new BE_Plato
                                                                                                        {
                                                                                                            Codigo = Convert.ToInt32(platos[0]),
                                                                                                            Nombre = Convert.ToString(platos[1]),
                                                                                                            Tipo = Convert.ToString(platos[2]),
                                                                                                            Clase = Convert.ToString(platos[3]),
                                                                                                            Status = Convert.ToString(platos[4]),
                                                                                                            CostoUnitario = Convert.ToDecimal(platos[5]),
                                                                                                            Activo = Convert.ToBoolean(platos[6]),
                                                                                                            ListaIngredientes = (from obje in ds.Tables["Ingrediente-Plato"].AsEnumerable()
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

                                                                                                                                 }).ToList()

                                                                                                        }).ToList(),
                                                                                   }).ToList()


                                                             }).FirstOrDefault()




                                          }).ToList();
            return listadeMesas;
        }

        public BE_Mesa ListarObjeto(BE_Mesa mesa)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(BE_Mesa mesa)
        {
            Acceso = new Xml_Database();
            ListadoXML.Add(CrearMesaXML(mesa));
            return Acceso.Modificar(ListadoXML);
        }

        private BE_TuplaXML CrearMesaXML(BE_Mesa mesa)
        {
            BE_TuplaXML nuevaTupla = new BE_TuplaXML();
            nuevaTupla.NodoRoot = "Mesas";
            nuevaTupla.NodoLeaf = "Mesa";
            XElement nuevaMesa = new XElement("Mesa",
                new XElement("ID", mesa.Codigo.ToString()),
                new XElement("Capacidad", mesa.Capacidad.ToString()),
                new XElement("Ubicación", mesa.Ubicación),
                new XElement("Ocupación Actual", mesa.OcupaciónActual.ToString()),
                new XElement("Status", mesa.Status.ToString()),
                new XElement("ID_Mozo", mesa.ID_Empleado.Codigo.ToString())
                );
            nuevaTupla.Xelement = nuevaMesa;
            return nuevaTupla;
        }
    }
}
