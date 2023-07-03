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
    public class MPP_Bebida:IGestionable<BE_Bebida>
    {
        private static List<BE_TuplaXML> ListadoXML;
        private static MPP_Bebida mapper = null;
        public static MPP_Bebida DevolverInstancia()
        {
            if (mapper == null) mapper = new MPP_Bebida();
            else ListadoXML = null;
            return mapper;
        }
        ~MPP_Bebida()
        {
            mapper = null;
            ListadoXML = null;
        }
        
        public bool Baja(BE_Bebida bebida)
        {
            if (bebida.DevolverNombre() != "Bebida")
            {
                if (bebida.DevolverNombre() == "Bebida_Preparada")
                {
                    ListadoXML.Add(CrearBebidaXML((BE_Bebida_Preparada)bebida));
                    foreach (BE_TuplaXML ing in CrearListaBebidaIngrediente((BE_Bebida_Preparada)bebida))
                    {
                        ListadoXML.Add(ing);
                    }
                }
                else ListadoXML.Add(CrearBebidaXML((BE_Bebida_Alcoholica)bebida));
            }
            else ListadoXML.Add(CrearBebidaXML(bebida));
            return Xml_Database.DevolverInstancia().Borrar(ListadoXML);
        }

        public bool Guardar(BE_Bebida bebida)
        {
            if (bebida.DevolverNombre() != "Bebida")
            {
                if (bebida.DevolverNombre() == "Bebida_Preparada")
                {
                    ListadoXML.Add(CrearBebidaXML((BE_Bebida_Preparada)bebida));
                    foreach (BE_TuplaXML ing in CrearListaBebidaIngrediente((BE_Bebida_Preparada)bebida))
                    {
                        ListadoXML.Add(ing);
                    }
                }
                else ListadoXML.Add(CrearBebidaXML((BE_Bebida_Alcoholica)bebida));
            }
            else ListadoXML.Add(CrearBebidaXML(bebida));
            
            return Xml_Database.DevolverInstancia().Escribir(ListadoXML);
        }
        public List<BE_Bebida> Listar()
        {
            DataSet ds = new DataSet();
            ds = Xml_Database.DevolverInstancia().Listar();
            List<BE_Bebida> ListaCompleta = ds.Tables.Contains("Bebida") != false ?
                (from beb in ds.Tables["Bebida"].AsEnumerable()
                 select beb[2].ToString() == "Bebida" ?
                 new BE_Bebida
                 {
                     Codigo = Convert.ToInt32(beb[0]),
                     Nombre = beb[1].ToString(),
                     Tipo = (Tipo_Bebida)Enum.Parse(typeof(Tipo_Bebida), beb[3].ToString()),
                     Presentacion = Convert.ToDecimal(beb[4]),
                     CostoUnitario = MPP_Costo.DevolverInstancia().DevolverCosto(new BE_Bebida { Codigo = Convert.ToInt32(beb[0]) }, 1, ds),
                     UnidadMedida = beb[6].ToString(),
                     VidaUtil = Convert.ToInt32(beb[7])
                 } : beb[2].ToString() == "Bebida_Preparada" ?
                 (BE_Bebida)new BE_Bebida_Preparada
                 {
                     Codigo = Convert.ToInt32(beb[0]),
                     Nombre = beb[1].ToString(),
                     Tipo = (Tipo_Bebida)Enum.Parse(typeof(Tipo_Bebida), beb[3].ToString()),
                     Presentacion = Convert.ToDecimal(beb[4]),
                     CostoUnitario = MPP_Costo.DevolverInstancia().DevolverCosto(new BE_Bebida { Codigo = Convert.ToInt32(beb[0]) }, 1, ds),
                     UnidadMedida = beb[6].ToString(),
                     VidaUtil = Convert.ToInt32(beb[7]),
                     ABV = Convert.ToDecimal(beb[8]),
                     ListaIngredientes = MPP_Ingrediente.DevolverInstancia().Bebidas_Ingrediente(new BE_Bebida_Preparada { Codigo = Convert.ToInt32(beb[0]) })
                 } : new BE_Bebida_Alcoholica
                 {
                     Codigo = Convert.ToInt32(beb[0]),
                     Nombre = beb[1].ToString(),
                     Tipo = (Tipo_Bebida)Enum.Parse(typeof(Tipo_Bebida), beb[3].ToString()),
                     Presentacion = Convert.ToDecimal(beb[4]),
                     CostoUnitario = MPP_Costo.DevolverInstancia().DevolverCosto(new BE_Bebida { Codigo = Convert.ToInt32(beb[0]) }, 1, ds),
                     UnidadMedida = beb[6].ToString(),
                     VidaUtil = Convert.ToInt32(beb[7]),
                     ABV = Convert.ToDecimal(beb[8]),
                 }).ToList() : null;

            return ListaCompleta;
        }

        public BE_Bebida ListarObjeto(BE_Bebida bebida, DataSet ds = null)
        {
            if (ds is null)
            {
                ds = new DataSet();
                ds = Xml_Database.DevolverInstancia().Listar();
            }
            var ObjetoEncontrado = ds.Tables.Contains("Bebida") != false ?
                (from beb in ds.Tables["Bebida"].AsEnumerable()
                 where Convert.ToInt32(beb[0]) == bebida.Codigo
                 select beb[2].ToString() == "Bebida" ?
                 new BE_Bebida
                 {
                     Codigo = Convert.ToInt32(beb[0]),
                     Nombre = beb[1].ToString(),
                     Tipo = (Tipo_Bebida)Enum.Parse(typeof(Tipo_Bebida), beb[3].ToString()),
                     Presentacion = Convert.ToDecimal(beb[4]),
                     CostoUnitario = MPP_Costo.DevolverInstancia().DevolverCosto(new BE_Bebida { Codigo = Convert.ToInt32(beb[0]) }, 1, ds),
                     UnidadMedida = beb[6].ToString(),
                     VidaUtil = Convert.ToInt32(beb[7])
                 } : beb[2].ToString() == "Bebida_Preparada" ?
                 (BE_Bebida)new BE_Bebida_Preparada
                 {
                     Codigo = Convert.ToInt32(beb[0]),
                     Nombre = beb[1].ToString(),
                     Tipo = (Tipo_Bebida)Enum.Parse(typeof(Tipo_Bebida), beb[3].ToString()),
                     Presentacion = Convert.ToDecimal(beb[4]),
                     CostoUnitario = MPP_Costo.DevolverInstancia().DevolverCosto(new BE_Bebida { Codigo = Convert.ToInt32(beb[0]) }, 1, ds),
                     UnidadMedida = beb[6].ToString(),
                     VidaUtil = Convert.ToInt32(beb[7]),
                     ABV = Convert.ToDecimal(beb[8]),
                     ListaIngredientes = MPP_Ingrediente.DevolverInstancia().Bebidas_Ingrediente(new BE_Bebida_Preparada { Codigo = Convert.ToInt32(beb[0]) })
                 } : new BE_Bebida_Alcoholica
                 {
                     Codigo = Convert.ToInt32(beb[0]),
                     Nombre = beb[1].ToString(),
                     Tipo = (Tipo_Bebida)Enum.Parse(typeof(Tipo_Bebida), beb[3].ToString()),
                     Presentacion = Convert.ToDecimal(beb[4]),
                     CostoUnitario = MPP_Costo.DevolverInstancia().DevolverCosto(new BE_Bebida { Codigo = Convert.ToInt32(beb[0]) }, 1, ds),
                     UnidadMedida = beb[6].ToString(),
                     VidaUtil = Convert.ToInt32(beb[7]),
                     ABV = Convert.ToDecimal(beb[8]),
                 }).FirstOrDefault() : null;
            return ObjetoEncontrado;
        }

        public bool Modificar(BE_Bebida bebida)
        {
            if (bebida.DevolverNombre() != "Bebida")
            {
                if (bebida.DevolverNombre() == "Bebida_Preparada")
                {
                    ListadoXML.Add(CrearBebidaXML((BE_Bebida_Preparada)bebida));
                    foreach (BE_TuplaXML ing in CrearListaBebidaIngrediente((BE_Bebida_Preparada)bebida))
                    {
                        ListadoXML.Add(ing);
                    }
                }
                else ListadoXML.Add(CrearBebidaXML((BE_Bebida_Alcoholica)bebida));   
            }
            else ListadoXML.Add(CrearBebidaXML(bebida));

            return Xml_Database.DevolverInstancia().Modificar(ListadoXML);
        }

        public BE_TuplaXML CrearBebidaXML(BE_Bebida bebida)
        {
            BE_TuplaXML nuevaTupla = new BE_TuplaXML();
            XElement nuevaBebida;
            nuevaTupla.NodoRoot = "Bebidas";
            nuevaTupla.NodoLeaf = "Bebida";
            if (bebida.DevolverNombre() == "Bebida")
            {
                nuevaBebida = new XElement("Bebida",
                new XElement("ID", bebida.Codigo.ToString()),
                new XElement("Nombre", bebida.Nombre),
                new XElement("Tipo_Bebida",bebida.DevolverNombre()),
                new XElement("Tipo", bebida.Tipo),
                new XElement("Presentación", bebida.Presentacion.ToString()),
                new XElement("Costo_Unitario", bebida.CostoUnitario.ToString()),
                new XElement("Unidad_Medida", bebida.UnidadMedida),
                new XElement("Vida_Util", bebida.VidaUtil.ToString())
                );
            }
            else
            {
                nuevaBebida = new XElement("Bebida",
                new XElement("ID", Cálculos.IDPadleft(bebida.Codigo)),
                new XElement("Nombre", bebida.Nombre),
                new XElement("Tipo_Bebida", bebida.DevolverNombre()),
                new XElement("Tipo", bebida.Tipo),
                new XElement("Presentación", bebida.Presentacion.ToString()),
                new XElement("Costo_Unitario", bebida.CostoUnitario.ToString()),
                new XElement("Unidad_Medida", bebida.UnidadMedida),
                new XElement("Vida_Util", bebida.VidaUtil.ToString()),
                new XElement("ABV", ((BE_Bebida_Alcoholica)bebida).ABV.ToString())
                );
            }
            nuevaTupla.Xelement = nuevaBebida;
            return nuevaTupla;
        }
        public List<BE_TuplaXML> CrearListaBebidaIngrediente(BE_Bebida_Preparada bebida)
        {
            List<BE_TuplaXML> listadeIngredientes = new List<BE_TuplaXML>();
            foreach (BE_Ingrediente ingrediente in bebida.ListaIngredientes)
            {
                BE_TuplaXML nuevaTupla = new BE_TuplaXML();
                nuevaTupla.NodoRoot = "Bebidas-Ingredientes";
                nuevaTupla.NodoLeaf = "Bebida-Ingrediente";
                XElement nuevaBebidaIngrediente = new XElement("Bebida-Ingrediente",
                    new XElement("ID_Bebida", Cálculos.IDPadleft(bebida.Codigo)),
                    new XElement("ID_Ingrediente", Cálculos.IDPadleft(ingrediente.Codigo))
                    );
                nuevaTupla.Xelement = nuevaBebidaIngrediente;
                listadeIngredientes.Add(nuevaTupla);
            }
            return listadeIngredientes;
        }
    }
}
