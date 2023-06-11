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
    public class MPP_Empleado:IGestionable<BE_Empleado>
    {
        Xml_Database Acceso;
        List<BE_TuplaXML> ListadoXML;

        public MPP_Empleado()
        {
            ListadoXML = new List<BE_TuplaXML>();
        }

        public bool Baja(BE_Empleado empleado)
        {
            Acceso = new Xml_Database();
            ListadoXML.Add(CrearEmpleadoXML(empleado));
            return Acceso.Borrar(ListadoXML);
        }

        public bool Guardar(BE_Empleado empleado)
        {
            Acceso = new Xml_Database();
            ListadoXML.Add(CrearEmpleadoXML(empleado));
            return Acceso.Escribir(ListadoXML);
        }

        public List<BE_Empleado> Listar()
        {
            Acceso = new Xml_Database();
            DataSet ds = new DataSet();
            ds = Acceso.Listar();
            List<BE_Empleado> ListaTotal = new List<BE_Empleado>();
            try
            {
                List<BE_Mozo> listadeMozos = ds.Tables.Contains("Mozo") != false ? (from mo in ds.Tables["Mozo"].AsEnumerable()
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
                                                                                                                         }).FirstOrDefault():null,
                                                                                                              ListadeBebida = ds.Tables.Contains("Bebida-Pedido") & ds.Tables.Contains("Bebida") != false ?(from obj1 in ds.Tables["Bebida_Pedido"].AsEnumerable()
                                                                                                                               join beb in ds.Tables["Bebida"].AsEnumerable()
                                                                                                                               on Convert.ToInt32(obj1[1]) equals Convert.ToInt32(ped[0])
                                                                                                                               select new BE_Bebida
                                                                                                                               {

                                                                                                                               }).ToList():null,
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

                                                                                                                                                        }).ToList():null
                                                                                                                               }).ToList():null,
                                                                                                          }).ToList():null
                                                                                    }).ToList() : null;

                List<BE_ChefPrincipal> listadeChef = ds.Tables.Contains("Chef_Principal") != false ? (from che in ds.Tables["Chef_Principal"].AsEnumerable()
                                                      select new BE_ChefPrincipal
                                                      {
                                                          Codigo = Convert.ToInt32(che[0]),
                                                          DNI = Convert.ToInt64(che[1]),
                                                          Nombre = Convert.ToString(che[2]),
                                                          Apellido = Convert.ToString(che[3]),
                                                          FechaNacimiento = Convert.ToDateTime(che[4]),
                                                          Edad = Convert.ToInt32(che[5]),
                                                          FechaIngreso = Convert.ToDateTime(che[6]),
                                                          Antiguedad = Convert.ToInt32(che[7]),
                                                          Categoria = (BE_Empleado.Category)Enum.Parse(typeof(BE_Empleado.Category), Convert.ToString(che[8])),
                                                          OrdenesPendientes = ds.Tables.Contains("Orden_Pendiente") & ds.Tables.Contains("Orden") != false ? (from obj in ds.Tables["Orden_Pendiente"].AsEnumerable()
                                                                               join ord in ds.Tables["Orden"].AsEnumerable()
                                                                               on Convert.ToInt32(obj[1]) equals Convert.ToInt32(che[0])
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
                                                                                                    ID_Pago = ds.Tables.Contains("Pago") != false ?(from pago in ds.Tables["Pago"].AsEnumerable()
                                                                                                               where Convert.ToInt32(ped[6]) == Convert.ToInt32(pago[0])
                                                                                                               select new BE_Pago
                                                                                                               {
                                                                                                                   Codigo = Convert.ToInt32(pago[0]),
                                                                                                                   Tipo = Convert.ToString(pago[1])
                                                                                                               }).FirstOrDefault():null,
                                                                                                    ListadeBebida = ds.Tables.Contains("Bebida-Pedido") & ds.Tables.Contains("Bebida") != false ? (from obj1 in ds.Tables["Bebida_Pedido"].AsEnumerable()
                                                                                                                     join beb in ds.Tables["Bebida"].AsEnumerable()
                                                                                                                     on Convert.ToInt32(obj1[1]) equals Convert.ToInt32(ped[0])
                                                                                                                     select new BE_Bebida
                                                                                                                     {

                                                                                                                     }).ToList():null,
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
                                                                                  
                                                                               }).ToList():null,
                                                      }).ToList():null;

                List<BE_GerenteSucursal> listadeGerentes = ds.Tables.Contains("Gerente_Sucursal") != false ? (from ger in ds.Tables["Gerente_Sucursal"].AsEnumerable()
                                                            select new BE_GerenteSucursal
                                                            {
                                                                Codigo = Convert.ToInt32(ger[0]),
                                                                DNI = Convert.ToInt64(ger[1]),
                                                                Nombre = Convert.ToString(ger[2]),
                                                                Apellido = Convert.ToString(ger[3]),
                                                                FechaNacimiento = Convert.ToDateTime(ger[4]),
                                                                Edad = Convert.ToInt32(ger[5]),
                                                                FechaIngreso = Convert.ToDateTime(ger[6]),
                                                                Antiguedad = Convert.ToInt32(ger[7]),
                                                                Categoria = (BE_Empleado.Category)Enum.Parse(typeof(BE_Empleado.Category), Convert.ToString(ger[8])),
                                                                Contacto = Convert.ToString(ger[9])

                                                            }).ToList():null;
                
                ListaTotal = listadeMozos.Cast<BE_Empleado>().Concat(listadeChef.Cast<BE_Empleado>()).ToList().Concat(listadeGerentes.Cast<BE_Empleado>()).ToList();

                //ListaTotal.AddRange(listadeMozos.Cast<BE_Empleado>());
                //ListaTotal.AddRange(listadeChef.Cast<BE_Empleado>());
                //ListaTotal.AddRange(listadeGerentes.Cast<BE_Empleado>());
                return ListaTotal;
            }
            catch(Exception ex)
            {
                ListaTotal = null;
                return ListaTotal;
                throw ex;
            }
            
        }

        public List<BE_Mozo> ListarMozos()
        {
            Acceso = new Xml_Database();
            DataSet ds = new DataSet();
            ds = Acceso.Listar();

            List<BE_Mozo> listadeMozos = ds.Tables.Contains("Mozo") != false ? (from mo in ds.Tables["Mozo"].AsEnumerable()
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
                                                                                    PedidosTomados = ds.Tables.Contains("Mozo-Pedido") & ds.Tables.Contains("Ingrediente") != false ? (from obj in ds.Tables["Mozo-Pedido"].AsEnumerable()
                                                                                                                                                                                       join ped in ds.Tables["Ingrediente"].AsEnumerable()
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
                                                                                }).ToList() : null;

            return listadeMozos;
        }
        public List<BE_GerenteSucursal> ListarGerentes()
        {
            Acceso = new Xml_Database();
            DataSet ds = new DataSet();
            ds = Acceso.Listar();

            List<BE_GerenteSucursal> listadeGerentes = ds.Tables.Contains("Gerente_Sucursal") != false ? (from ger in ds.Tables["Gerente_Sucursal"].AsEnumerable()
                                                                                                          select new BE_GerenteSucursal
                                                                                                          {
                                                                                                              Codigo = Convert.ToInt32(ger[0]),
                                                                                                              DNI = Convert.ToInt64(ger[1]),
                                                                                                              Nombre = Convert.ToString(ger[2]),
                                                                                                              Apellido = Convert.ToString(ger[3]),
                                                                                                              FechaNacimiento = Convert.ToDateTime(ger[4]),
                                                                                                              Edad = Convert.ToInt32(ger[5]),
                                                                                                              FechaIngreso = Convert.ToDateTime(ger[6]),
                                                                                                              Antiguedad = Convert.ToInt32(ger[7]),
                                                                                                              Categoria = (BE_Empleado.Category)Enum.Parse(typeof(BE_Empleado.Category), Convert.ToString(ger[8])),
                                                                                                              Contacto = Convert.ToString(ger[9])

                                                                                                          }).ToList() : null;

            return listadeGerentes;
        }

        public List<BE_ChefPrincipal> ListarChefs()
        {
            Acceso = new Xml_Database();
            DataSet ds = new DataSet();
            ds = Acceso.Listar();

            List<BE_ChefPrincipal> listadeChef = ds.Tables.Contains("Chef_Principal") != false ? (from che in ds.Tables["Chef_Principal"].AsEnumerable()
                                                                                                  select new BE_ChefPrincipal
                                                                                                  {
                                                                                                      Codigo = Convert.ToInt32(che[0]),
                                                                                                      DNI = Convert.ToInt64(che[1]),
                                                                                                      Nombre = Convert.ToString(che[2]),
                                                                                                      Apellido = Convert.ToString(che[3]),
                                                                                                      FechaNacimiento = Convert.ToDateTime(che[4]),
                                                                                                      Edad = Convert.ToInt32(che[5]),
                                                                                                      FechaIngreso = Convert.ToDateTime(che[6]),
                                                                                                      Antiguedad = Convert.ToInt32(che[7]),
                                                                                                      Categoria = (BE_Empleado.Category)Enum.Parse(typeof(BE_Empleado.Category), Convert.ToString(che[8])),
                                                                                                      OrdenesPendientes = ds.Tables.Contains("Orden_Pendiente") & ds.Tables.Contains("Orden") != false ? (from obj in ds.Tables["Orden_Pendiente"].AsEnumerable()
                                                                                                                                                                                                          join ord in ds.Tables["Orden"].AsEnumerable()
                                                                                                                                                                                                          on Convert.ToInt32(obj[1]) equals Convert.ToInt32(che[0])
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



                                                                                                                                                                                                                                                                   }).FirstOrDefault() : null,
                                                                                                                                                                                                              ID_Mesa = ds.Tables.Contains("Mesa") != false ? (from mes in ds.Tables["Mesa"].AsEnumerable()
                                                                                                                                                                                                                                                               where Convert.ToInt32(ord[4]) == Convert.ToInt32(mes[0])
                                                                                                                                                                                                                                                               select new BE_Mesa
                                                                                                                                                                                                                                                               {
                                                                                                                                                                                                                                                                   Codigo = Convert.ToInt32(mes[0]),
                                                                                                                                                                                                                                                                   Capacidad = Convert.ToInt32(mes[1]),
                                                                                                                                                                                                                                                                   Ubicación = Convert.ToString(mes[2]),
                                                                                                                                                                                                                                                                   OcupaciónActual = Convert.ToInt32(mes[3]),
                                                                                                                                                                                                                                                                   Status = Convert.ToString(mes[4]),

                                                                                                                                                                                                                                                               }).FirstOrDefault() : null,

                                                                                                                                                                                                          }).ToList() : null,
                                                                                                  }).ToList() : null;
            return listadeChef;
        }
        public BE_Empleado ListarObjeto(BE_Empleado empleado)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(BE_Empleado empleado)
        {
            Acceso = new Xml_Database();
            ListadoXML.Add(CrearEmpleadoXML(empleado));
            return Acceso.Modificar(ListadoXML);
        }

        private BE_TuplaXML CrearEmpleadoXML(BE_Empleado empleado)
        {
            BE_TuplaXML nuevaTupla = new BE_TuplaXML();
            XElement nuevoEmpleado;

            nuevaTupla.NodoRoot = "Empleados";
            if (empleado.DevolverNombre() == "Mozo")
            {
                nuevaTupla.NodoLeaf = "Mozo";
                nuevoEmpleado = new XElement("Mozo",
                    new XElement("ID", empleado.Codigo.ToString()),
                    new XElement("DNI", empleado.DNI.ToString()),
                    new XElement("Nombre", empleado.Nombre),
                    new XElement("Apellido", empleado.Apellido),
                    new XElement("Fecha de Nacimiento", empleado.FechaNacimiento.ToString("dd/MM/yyyy")),
                    new XElement("Edad", empleado.Edad.ToString()),
                    new XElement("Fecha de Ingreso", empleado.FechaIngreso.ToString("dd/MM/yyyy")),
                    new XElement("Antiguedad", empleado.Antiguedad.ToString()),
                    new XElement("Categoria", empleado.Categoria)
                    );
                nuevaTupla.Xelement = nuevoEmpleado;
            }
            else if (empleado.DevolverNombre() == "ChefPrincipal")
            {
                nuevaTupla.NodoLeaf = "Chef Principal";
                nuevoEmpleado = new XElement("Chef Principal",
                   new XElement("ID", empleado.Codigo.ToString()),
                   new XElement("DNI", empleado.DNI.ToString()),
                   new XElement("Nombre", empleado.Nombre),
                   new XElement("Apellido", empleado.Apellido),
                   new XElement("Fecha de Nacimiento", empleado.FechaNacimiento.ToString("dd/MM/yyyy")),
                   new XElement("Edad", empleado.Edad.ToString()),
                   new XElement("Fecha de Ingreso", empleado.FechaIngreso.ToString("dd/MM/yyyy")),
                   new XElement("Antiguedad", empleado.Antiguedad.ToString()),
                   new XElement("Categoria", empleado.Categoria)
                   );
                nuevaTupla.Xelement = nuevoEmpleado;
            }
            else
            {
                nuevaTupla.NodoLeaf = "Gerente Sucursal";
                nuevoEmpleado = new XElement("Gerente Sucursal",
                   new XElement("ID", empleado.Codigo.ToString()),
                   new XElement("DNI", empleado.DNI.ToString()),
                   new XElement("Nombre", empleado.Nombre),
                   new XElement("Apellido", empleado.Apellido),
                   new XElement("Fecha de Nacimiento", empleado.FechaNacimiento.ToString("dd/MM/yyyy")),
                   new XElement("Edad", empleado.Edad.ToString()),
                   new XElement("Fecha de Ingreso", empleado.FechaIngreso.ToString("dd/MM/yyyy")),
                   new XElement("Antiguedad", empleado.Antiguedad.ToString()),
                   new XElement("Categoria", empleado.Categoria),
                   new XElement("Contacto", ((BE_GerenteSucursal)empleado).Contacto)
                   );
                nuevaTupla.Xelement = nuevoEmpleado;
            }
            return nuevaTupla;    
        }

        private List<BE_TuplaXML> CrearMozoPedidosXML(BE_Mozo mozo)
        {
            List<BE_TuplaXML> listadePedidos = new List<BE_TuplaXML>();
            foreach(BE_Pedido pedido in mozo.PedidosTomados)
            {
                BE_TuplaXML nuevaTupla = new BE_TuplaXML();
                nuevaTupla.NodoRoot = "Mozos-Pedidos";
                nuevaTupla.NodoLeaf = "Mozo-Pedido";
                XElement nuevoMozoPedido = new XElement("Mozo-Pedido",
                    new XElement("ID Pedido", pedido.Codigo.ToString()),
                    new XElement("ID Mozo", mozo.Codigo.ToString())
                    );
                nuevaTupla.Xelement = nuevoMozoPedido;
                listadePedidos.Add(nuevaTupla);
            }
            return listadePedidos;
        }

        private List<BE_TuplaXML> CrearOrdenesPendientesXML(BE_ChefPrincipal chef)
        {
            List<BE_TuplaXML> listadeOrdenes = new List<BE_TuplaXML>();
            foreach(BE_Orden orden in chef.OrdenesPendientes)
            {
                BE_TuplaXML nuevaTupla = new BE_TuplaXML();
                nuevaTupla.NodoRoot = "Ordenes_Pendientes";
                nuevaTupla.NodoLeaf = "Orden_Pendiente";
                XElement nuevaOrdenPendiente = new XElement("Orden_Pendiente",
                    new XElement("ID Orden",orden.Codigo.ToString()),
                    new XElement("ID Chef", chef.Codigo.ToString())
                    );
                nuevaTupla.Xelement = nuevaOrdenPendiente;
                listadeOrdenes.Add(nuevaTupla);
            }
            return listadeOrdenes;
        }
    }
}
    