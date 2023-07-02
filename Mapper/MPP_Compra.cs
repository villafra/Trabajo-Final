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
    public class MPP_Compra:IGestionable<BE_Compra>
    {
        private static List<BE_TuplaXML> ListadoXML;
        private static MPP_Compra mapper = null;
        public static MPP_Compra DevolverInstancia()
        {
            if (mapper == null) mapper = new MPP_Compra();
            else ListadoXML = null;
            return mapper;
        }
        ~MPP_Compra()
        {
            mapper = null;
            ListadoXML = null;
        }
        public bool Baja(BE_Compra compra)
        {
            ListadoXML = new List<BE_TuplaXML>();
            ListadoXML.Add(CrearCompraXML(compra));
            return Xml_Database.DevolverInstancia().Baja(ListadoXML);
        }

        public bool Guardar(BE_Compra compra)
        {
            ListadoXML = new List<BE_TuplaXML>();
            ListadoXML.Add(CrearCompraXML(compra));
            return Xml_Database.DevolverInstancia().Escribir(ListadoXML);
        }

        public List<BE_Compra> Listar()
        {
            DataSet ds = new DataSet();
            ds = Xml_Database.DevolverInstancia().Listar();

            List<BE_Compra> listadeCompras = ds.Tables.Contains("Compra") != false ?
                (from comp in ds.Tables["Compra"].AsEnumerable()
                 select new BE_Compra
                 {
                     Codigo = Convert.ToInt32(comp[0]),
                     ID_Ingrediente = MPP_Ingrediente.DevolverInstancia().ListarObjeto(new BE_Ingrediente { Codigo = Convert.ToInt32(comp[1]) },ds),
                     Cantidad = Convert.ToDecimal(comp[2]),
                     FechaCompra = Convert.ToDateTime(comp[3]),
                     FechaEntrega = Convert.ToDateTime(comp[4]),
                     FechaIngreso = comp[9].ToString() != StausComp.En_Curso.ToString() ? Convert.ToDateTime(comp[5]) : (DateTime?)null,
                     CantidadRecibida = Convert.ToDecimal(comp[6]),
                     NroFactura = comp[7].ToString(),
                     Costo = comp[9].ToString() == StausComp.En_Curso.ToString() ? MPP_Costo.DevolverInstancia().DevolverCosto(new BE_Ingrediente { Codigo = Convert.ToInt32(comp[1]) }, Convert.ToDecimal(comp[2])) : Convert.ToDecimal(comp[8]),
                     Status = (StausComp)Enum.Parse(typeof(StausComp), comp[9].ToString()),
                     Activo = Convert.ToBoolean(comp[10])
                 }).ToList() : null;
            return listadeCompras;
        }

        public BE_Compra ListarObjeto(BE_Compra compra, DataSet ds = null)
        {
            if (ds is null)
            {
                ds = new DataSet();
                ds = Xml_Database.DevolverInstancia().Listar();
            }

            BE_Compra ObjetoEncontrado = ds.Tables.Contains("Compra") != false ?
                (from comp in ds.Tables["Compra"].AsEnumerable()
                 where Convert.ToInt32(comp[0]) == compra.Codigo
                 select new BE_Compra
                 {
                     Codigo = Convert.ToInt32(comp[0]),
                     ID_Ingrediente = MPP_Ingrediente.DevolverInstancia().ListarObjeto(new BE_Ingrediente { Codigo = Convert.ToInt32(comp[1]) },ds),
                     Cantidad = Convert.ToDecimal(comp[2]),
                     FechaCompra = Convert.ToDateTime(comp[3]),
                     FechaEntrega = Convert.ToDateTime(comp[4]),
                     FechaIngreso = comp[9].ToString() != StausComp.En_Curso.ToString() ? Convert.ToDateTime(comp[5]) : (DateTime?)null,
                     CantidadRecibida = Convert.ToDecimal(comp[6]),
                     NroFactura = comp[7].ToString(),
                     Costo = comp[9].ToString() == StausComp.En_Curso.ToString() ? MPP_Costo.DevolverInstancia().DevolverCosto(new BE_Ingrediente { Codigo = Convert.ToInt32(comp[1]) }, Convert.ToDecimal(comp[2])) : Convert.ToDecimal(comp[8]),
                     Status = (StausComp)Enum.Parse(typeof(StausComp), comp[9].ToString()),
                     Activo = Convert.ToBoolean(comp[10])

                 }).FirstOrDefault() : null;
            return ObjetoEncontrado;
        }

        public bool Modificar(BE_Compra compra)
        {
            ListadoXML = new List<BE_TuplaXML>();
            ListadoXML.Add(CrearCompraXML(compra));
            if ((int)compra.ID_Ingrediente.Status == 1 || (int)compra.ID_Ingrediente.Status == 3 || (int)compra.ID_Ingrediente.Status == 5)
            {
                compra.ID_Ingrediente.Status = StatusIng.Disponible;
            }
            return Xml_Database.DevolverInstancia().Modificar(ListadoXML) & MPP_Ingrediente.DevolverInstancia().Modificar(compra.ID_Ingrediente);
        }

        private BE_TuplaXML CrearCompraXML(BE_Compra compra)
        {
            BE_TuplaXML nuevaTupla = new BE_TuplaXML();
            nuevaTupla.NodoRoot = "Compras";
            nuevaTupla.NodoLeaf = "Compra";
            XElement nuevaCompra = new XElement("Compra",
                new XElement("ID", Cálculos.IDPadleft(compra.Codigo)),
                new XElement("ID_Ingrediente", compra.ID_Ingrediente.Codigo.ToString()),
                new XElement("Cantidad", compra.Cantidad.ToString()),
                new XElement("Fecha_Compra", compra.FechaCompra.ToString("dd/MM/yyyy HH:mm:ss")),
                new XElement("Fecha_Entrega", compra.FechaEntrega.ToString("dd/MM/yyyy HH:mm:ss")),
                new XElement("Fecha_Ingreso", compra.Status != StausComp.En_Curso ? compra.FechaIngreso.Value.ToString("dd/MM/yyyy HH:mm:ss"):""),
                new XElement("Cantidad_Recibida", compra.CantidadRecibida.ToString()),
                new XElement("NroFactura", compra.NroFactura),
                new XElement("Costo", compra.Costo.ToString()),
                new XElement("Status", compra.Status.ToString()),
                new XElement("Activo",compra.Activo.ToString())
                );
            nuevaTupla.Xelement = nuevaCompra;
            return nuevaTupla;
        }
    }
}
