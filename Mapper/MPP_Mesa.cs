﻿using System;
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
    public class MPP_Mesa:IGestionable<BE_Mesa>
    {
        Xml_Database Acceso;
        List<BE_TuplaXML> ListadoXML;
        public bool Baja(BE_Mesa mesa)
        {
            ListadoXML = new List<BE_TuplaXML>();
            Acceso = new Xml_Database();
            ListadoXML.Add(CrearMesaXML(mesa));
            return Acceso.Borrar(ListadoXML);
        }
        public bool Baja (List<BE_Mesa> mesas)
        {
            ListadoXML = new List<BE_TuplaXML>();
            Acceso = new Xml_Database();
            foreach(BE_Mesa mesa in mesas)
            {
                ListadoXML.Add(CrearMesaXML(mesa));
            }
            return Acceso.Borrar(ListadoXML);
        }

        public bool Guardar(BE_Mesa mesa)
        {
            ListadoXML = new List<BE_TuplaXML>();
            Acceso = new Xml_Database();
            ListadoXML.Add(CrearMesaXML(mesa));
            return Acceso.Escribir(ListadoXML);
        }

        public bool Guardar(List<BE_Mesa> mesas)
        {
            ListadoXML = new List<BE_TuplaXML>();
            Acceso = new Xml_Database();
            foreach (BE_Mesa mesa in mesas)
            {
                ListadoXML.Add(CrearMesaXML(mesa));
            }
            return Acceso.Escribir(ListadoXML);
        }

        public List<BE_Mesa> Listar()
        {
            Acceso = new Xml_Database();
            DataSet ds = new DataSet();
            ds = Acceso.Listar();

            List<BE_Mesa> listadeMesas = ds.Tables.Contains("Mesa") != false ? (from mes in ds.Tables["Mesa"].AsEnumerable()
                                          select mes[7].ToString() != "Combinada" ? new BE_Mesa
                                          {
                                              Codigo = Convert.ToInt32(mes[0]),
                                              Capacidad = Convert.ToInt32(mes[1]),
                                              Ubicación = (Ubicacion)Enum.Parse(typeof(Ubicacion), Convert.ToString(mes[2])),
                                              OcupaciónActual = Convert.ToInt32(mes[3]),
                                              Status = (StatusMesa)Enum.Parse(typeof(StatusMesa), Convert.ToString(mes[4])),
                                              ID_Empleado = ds.Tables.Contains("Mozo") != false ? Convert.ToString(mes[4]) == StatusMesa.Ocupada.ToString() ? (from mo in ds.Tables["Mozo"].AsEnumerable()
                                                             where Convert.ToInt32(mo[0]) == Convert.ToInt32(mes[5])
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
                                                                                                                                                                                                                                                                                                                                                                                         Tipo = (TipoIng)Enum.Parse(typeof(TipoIng), Convert.ToString(ing[2])),
                                                                                                                                                                                                                                                                                                                                                                                         Refrigeracion = Convert.ToBoolean(ing[3]),
                                                                                                                                                                                                                                                                                                                                                                                         UnidadMedida = (UM)Enum.Parse(typeof(UM), Convert.ToString(ing[4])),
                                                                                                                                                                                                                                                                                                                                                                                         Activo = Convert.ToBoolean(ing[5]),
                                                                                                                                                                                                                                                                                                                                                                                         VidaUtil = Convert.ToInt32(ing[6]),
                                                                                                                                                                                                                                                                                                                                                                                         Status = (StatusIng)Enum.Parse(typeof(StatusIng), Convert.ToString(ing[7])),
                                                                                                                                                                                                                                                                                                                                                                                         GestionLote = Convert.ToBoolean(ing[8])

                                                                                                                                                                                                                                                                                                                                                                                     }).ToList() : null
                                                                                                                                                                                                                                                                     }).ToList() : null,
                                                                                                                                                                    }).ToList() : null
                                                             }).FirstOrDefault():null:null,
                                              Activo = Convert.ToBoolean(mes[6]),

                                          }: new BE_MesaCombinada
                                          {
                                              Codigo = Convert.ToInt32(mes[0]),
                                              Capacidad = Convert.ToInt32(mes[1]),
                                              Ubicación = (Ubicacion)Enum.Parse(typeof(Ubicacion), Convert.ToString(mes[2])),
                                              OcupaciónActual = Convert.ToInt32(mes[3]),
                                              Status = (StatusMesa)Enum.Parse(typeof(StatusMesa), Convert.ToString(mes[4])),
                                              ID_Empleado = ds.Tables.Contains("Mozo") != false ? Convert.ToString(mes[4]) == StatusMesa.Ocupada.ToString() ? (from mo in ds.Tables["Mozo"].AsEnumerable()
                                                                                                                                                               where Convert.ToInt32(mo[0]) == Convert.ToInt32(mes[5])
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
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      Tipo = (TipoIng)Enum.Parse(typeof(TipoIng), Convert.ToString(ing[2])),
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      Refrigeracion = Convert.ToBoolean(ing[3]),
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      UnidadMedida = (UM)Enum.Parse(typeof(UM), Convert.ToString(ing[4])),
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      Activo = Convert.ToBoolean(ing[5]),
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      VidaUtil = Convert.ToInt32(ing[6]),
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      Status = (StatusIng)Enum.Parse(typeof(StatusIng), Convert.ToString(ing[7])),
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      GestionLote = Convert.ToBoolean(ing[8])

                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  }).ToList() : null
                                                                                                                                                                                                                                                                                                                                                                  }).ToList() : null,
                                                                                                                                                                                                                                                                 }).ToList() : null
                                                                                                                                                               }).FirstOrDefault() : null : null,
                                              Activo = Convert.ToBoolean(mes[6]),
                                              Mesa1 = new BE_Mesa { Codigo = Convert.ToInt32(mes[8]) },
                                              Mesa2 = new BE_Mesa { Codigo = Convert.ToInt32(mes[9]) },
                                          }).ToList():null;
            return listadeMesas;
        }

        public List<BE_Mesa> ListarLibres()
        {
            Acceso = new Xml_Database();
            DataSet ds = new DataSet();
            ds = Acceso.Listar();

            List<BE_Mesa> listadeMesas = ds.Tables.Contains("Mesa") != false ? (from mes in ds.Tables["Mesa"].AsEnumerable()
                                                                                where mes[4].ToString() == StatusMesa.Libre.ToString()
                                                                                & Convert.ToBoolean(mes[6]) == true
                                                                                select mes[7].ToString() != "Combinada" ? new BE_Mesa
                                                                                {
                                                                                    Codigo = Convert.ToInt32(mes[0]),
                                                                                    Capacidad = Convert.ToInt32(mes[1]),
                                                                                    Ubicación = (Ubicacion)Enum.Parse(typeof(Ubicacion), Convert.ToString(mes[2])),
                                                                                    OcupaciónActual = Convert.ToInt32(mes[3]),
                                                                                    Status = (StatusMesa)Enum.Parse(typeof(StatusMesa), Convert.ToString(mes[4])),
                                                                                    Activo = Convert.ToBoolean(mes[6]),

                                                                                }: new BE_MesaCombinada
                                                                                {
                                                                                    Codigo = Convert.ToInt32(mes[0]),
                                                                                    Capacidad = Convert.ToInt32(mes[1]),
                                                                                    Ubicación = (Ubicacion)Enum.Parse(typeof(Ubicacion), Convert.ToString(mes[2])),
                                                                                    OcupaciónActual = Convert.ToInt32(mes[3]),
                                                                                    Status = (StatusMesa)Enum.Parse(typeof(StatusMesa), Convert.ToString(mes[4])),
                                                                                    Activo = Convert.ToBoolean(mes[6]),
                                                                                    Mesa1 = new BE_Mesa { Codigo = Convert.ToInt32(mes[8]) },
                                                                                    Mesa2 = new BE_Mesa { Codigo = Convert.ToInt32(mes[9]) },

                                                                                }).ToList() : null;
            return listadeMesas;
        }

        public BE_Mesa ListarObjeto(BE_Mesa mesa)
        {
            BE_Mesa Devolvermesa = Listar().Find(x => x.Codigo == mesa.Codigo);
            return Devolvermesa;
        }

        public bool Modificar(BE_Mesa mesa)
        {
            ListadoXML = new List<BE_TuplaXML>();
            Acceso = new Xml_Database();
            ListadoXML.Add(CrearMesaXML(mesa));
            return Acceso.Modificar(ListadoXML);
        }

        public bool CombinarMesa(List<BE_Mesa> mesas)
        {
            ListadoXML = new List<BE_TuplaXML>();
            Acceso = new Xml_Database();
            foreach (BE_Mesa mesa in mesas)
            {
               ListadoXML.Add(CrearMesaXML(mesa));
            }
            return Acceso.Modificar(ListadoXML);
        }

        private BE_TuplaXML CrearMesaXML(BE_Mesa mesa)
        {
            BE_TuplaXML nuevaTupla = new BE_TuplaXML();
            nuevaTupla.NodoRoot = "Mesas";
            nuevaTupla.NodoLeaf = "Mesa";
            XElement nuevaMesa = new XElement("Mesa",
                new XElement("ID", Cálculos.IDPadleft(mesa.Codigo)),
                new XElement("Capacidad", mesa.Capacidad.ToString()),
                new XElement("Ubicación", mesa.Ubicación),
                new XElement("Ocupación_Actual", mesa.OcupaciónActual.ToString()),
                new XElement("Status", mesa.Status.ToString()),
                new XElement("ID_Mozo", mesa.ID_Empleado != null ? mesa.ID_Empleado.Codigo.ToString() : ""),
                new XElement("Activo", mesa.Activo.ToString()),
                new XElement("Tipo_Mesa", mesa is BE_MesaCombinada ? "Combinada" :""),
                new XElement("Mesa_1", mesa is BE_MesaCombinada ? ((BE_MesaCombinada)mesa).Mesa1.Codigo.ToString() : ""),
                new XElement("Mesa_2", mesa is BE_MesaCombinada ? ((BE_MesaCombinada)mesa).Mesa2.Codigo.ToString() : "")
                );
            nuevaTupla.Xelement = nuevaMesa;
            return nuevaTupla;
        }
    }
}
