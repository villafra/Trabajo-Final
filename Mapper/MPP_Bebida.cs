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
    public class MPP_Bebida:IGestionable<BE_Bebida>
    {
        Xml_Database Acceso;
        List<BE_TuplaXML> ListadoXML;

        public MPP_Bebida()
        {
            ListadoXML = new List<BE_TuplaXML>();
        }

        public bool Baja(BE_Bebida bebida)
        {
            Acceso = new Xml_Database();
            if (bebida.DevolverNombre() != "Bebida")
            {
                if (bebida.DevolverNombre() == "Bebida_Preparada")
                {
                    ListadoXML.Add(CrearBebidaHerenciaXML((BE_Bebida_Preparada)bebida));
                    foreach (BE_TuplaXML ing in CrearListaBebidaIngrediente((BE_Bebida_Preparada)bebida))
                    {
                        ListadoXML.Add(ing);
                    }
                }
                else
                {
                    ListadoXML.Add(CrearBebidaXML((BE_Bebida_Alcoholica)bebida));
                }
            }
            else
            {
                ListadoXML.Add(CrearBebidaXML(bebida));
            }
            return Acceso.Borrar(ListadoXML);
        }

        public bool Guardar(BE_Bebida bebida)
        {
            Acceso = new Xml_Database();
            if (bebida.DevolverNombre() != "Bebida")
            {
                if (bebida.DevolverNombre() == "Bebida_Preparada")
                {
                    ListadoXML.Add(CrearBebidaHerenciaXML((BE_Bebida_Preparada)bebida));
                    foreach (BE_TuplaXML ing in CrearListaBebidaIngrediente((BE_Bebida_Preparada)bebida))
                    {
                        ListadoXML.Add(ing);
                    }
                }
                else
                {
                    ListadoXML.Add(CrearBebidaXML((BE_Bebida_Alcoholica)bebida));
                }
            }
            else
            {
                ListadoXML.Add(CrearBebidaXML(bebida));
            }
            return Acceso.Escribir(ListadoXML);
        }

        public List<BE_Bebida> Listar()
        {
            Acceso = new Xml_Database();
            DataSet ds = new DataSet();
            ds = Acceso.Listar();

            List<BE_Bebida> listaBebidas = ds.Tables.Contains("Bebida") != false ? (from beb in ds.Tables["Bebida"].AsEnumerable()
                                            select new BE_Bebida
                                            {
                                                Codigo = Convert.ToInt32(beb[0]),
                                                Nombre = Convert.ToString(beb[1]),
                                                Tipo = (BE_Bebida.Tipo_Bebida)Enum.Parse(typeof(BE_Bebida.Tipo_Bebida),Convert.ToString(beb[2])),
                                                Presentacion = Convert.ToDecimal(beb[3]),
                                                Stock = Convert.ToInt32(beb[4]),
                                                CostoUnitario = Convert.ToDecimal(beb[5]),
                                                UnidadMedida = Convert.ToString(beb[6]),
                                                VidaUtil = Convert.ToInt32(beb[7])
                                            }).ToList():null;

            List<BE_Bebida_Alcoholica> listaBebidasAlcoholica = ds.Tables.Contains("Bebida_Acoholica") != false ? (from beb in ds.Tables["Bebida Alcoholica"].AsEnumerable()
                                                                 select new BE_Bebida_Alcoholica
                                                                 {
                                                                     Codigo = Convert.ToInt32(beb[0]),
                                                                     Nombre = Convert.ToString(beb[1]),
                                                                     Tipo = (BE_Bebida.Tipo_Bebida)Enum.Parse(typeof(BE_Bebida.Tipo_Bebida), Convert.ToString(beb[2])),
                                                                     Presentacion = Convert.ToDecimal(beb[3]),
                                                                     Stock = Convert.ToInt32(beb[4]),
                                                                     CostoUnitario = Convert.ToDecimal(beb[5]),
                                                                     UnidadMedida = Convert.ToString(beb[6]),
                                                                     VidaUtil = Convert.ToInt32(beb[7]),
                                                                     ABV = Convert.ToDecimal(beb[8])
                                                                 }).ToList():null;

            List<BE_Bebida_Preparada> listaBebidasPreparadas = ds.Tables.Contains("Bebida_Preparada") != false ?(from beb in ds.Tables["Bebida Preparada"].AsEnumerable()
                                                                select new BE_Bebida_Preparada
                                                                {
                                                                    Codigo = Convert.ToInt32(beb[0]),
                                                                    Nombre = Convert.ToString(beb[1]),
                                                                    Tipo = (BE_Bebida.Tipo_Bebida)Enum.Parse(typeof(BE_Bebida.Tipo_Bebida), Convert.ToString(beb[2])),
                                                                    Presentacion = Convert.ToDecimal(beb[3]),
                                                                    Stock = Convert.ToInt32(beb[4]),
                                                                    CostoUnitario = Convert.ToDecimal(beb[5]),
                                                                    UnidadMedida = Convert.ToString(beb[6]),
                                                                    VidaUtil = Convert.ToInt32(beb[7]),
                                                                    ABV = Convert.ToDecimal(beb[8]),
                                                                    ListaIngredientes = ds.Tables.Contains("Bebida-Ingrediente") & ds.Tables.Contains("Ingrediente") != false ? (from obj in ds.Tables["Bebida-Ingrediente"].AsEnumerable()
                                                                                         join ing in ds.Tables["Ingrediente"].AsEnumerable()
                                                                                         on Convert.ToInt32(obj[1]) equals Convert.ToInt32(beb[0])
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

                                                                                         }).ToList():null,
                                                                }).ToList():null;

            List<BE_Bebida> ListaCompleta = new List<BE_Bebida>();
            ListaCompleta = listaBebidas.Concat(listaBebidasAlcoholica).ToList().Concat(listaBebidasPreparadas).ToList();
            return ListaCompleta;
        }

        public BE_Bebida ListarObjeto(BE_Bebida bebida)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(BE_Bebida bebida)
        {
            Acceso = new Xml_Database();
            if (bebida.DevolverNombre() != "Bebida")
            {
                if (bebida.DevolverNombre() == "Bebida_Preparada")
                {
                    ListadoXML.Add(CrearBebidaHerenciaXML((BE_Bebida_Preparada)bebida));
                    foreach (BE_TuplaXML ing in CrearListaBebidaIngrediente((BE_Bebida_Preparada)bebida))
                    {
                        ListadoXML.Add(ing);
                    }
                }
                else
                {
                    ListadoXML.Add(CrearBebidaXML((BE_Bebida_Alcoholica)bebida));
                }
            }
            else
            {
                ListadoXML.Add(CrearBebidaXML(bebida));
            }
            return Acceso.Modificar(ListadoXML);
        }

        public BE_TuplaXML CrearBebidaXML(BE_Bebida bebida)
        {
            BE_TuplaXML nuevaTupla = new BE_TuplaXML();
            nuevaTupla.NodoRoot = ReferenciasBD.Root;
            nuevaTupla.NodoLeaf = "Bebidas";
            XElement nuevaBebida = new XElement("Bebida",
                new XElement("ID", bebida.Codigo.ToString()),
                new XElement("Nombre", bebida.Nombre),
                new XElement("Tipo", bebida.Tipo),
                new XElement("Presentación", bebida.Presentacion.ToString()),
                new XElement("Stock", bebida.Stock.ToString()),
                new XElement("Costo Unitario", bebida.CostoUnitario.ToString()),
                new XElement("Unidad de Medida", bebida.UnidadMedida),
                new XElement("Vida Util", bebida.VidaUtil.ToString())
                );
            nuevaTupla.Xelement = nuevaBebida;
            return nuevaTupla;
        }
        public BE_TuplaXML CrearBebidaHerenciaXML(BE_Bebida_Alcoholica bebida)
        {
            BE_TuplaXML nuevaTupla = new BE_TuplaXML();
            nuevaTupla.NodoRoot = ReferenciasBD.Root;
            nuevaTupla.NodoLeaf = "Bebidas Alcoholicas";
            XElement nuevaBebida = new XElement("Bebida Alcoholica",
                new XElement("ID", bebida.Codigo.ToString()),
                new XElement("Nombre", bebida.Nombre),
                new XElement("Tipo", bebida.Tipo),
                new XElement("Presentación", bebida.Presentacion.ToString()),
                new XElement("Stock", bebida.Stock.ToString()),
                new XElement("Costo Unitario", bebida.CostoUnitario.ToString()),
                new XElement("Unidad de Medida", bebida.UnidadMedida),
                new XElement("Vida Util", bebida.VidaUtil.ToString()),
                new XElement("ABV", bebida.ABV.ToString())
                );
            nuevaTupla.Xelement = nuevaBebida;
            return nuevaTupla;
        }
        public BE_TuplaXML CrearBebidaHerenciaXML(BE_Bebida_Preparada bebida)
        {
            BE_TuplaXML nuevaTupla = new BE_TuplaXML();
            nuevaTupla.NodoRoot = ReferenciasBD.Root;
            nuevaTupla.NodoLeaf = "Bebidas Preparadas";
            XElement nuevaBebida = new XElement("Bebida Preparada",
                new XElement("ID", bebida.Codigo.ToString()),
                new XElement("Nombre", bebida.Nombre),
                new XElement("Tipo", bebida.Tipo),
                new XElement("Presentación", bebida.Presentacion.ToString()),
                new XElement("Stock", bebida.Stock.ToString()),
                new XElement("Costo Unitario", bebida.CostoUnitario.ToString()),
                new XElement("Unidad de Medida", bebida.UnidadMedida),
                new XElement("Vida Util", bebida.VidaUtil.ToString()),
                new XElement("ABV", bebida.ABV.ToString())
                );
            nuevaTupla.Xelement = nuevaBebida;
            return nuevaTupla;
        }

        public List<BE_TuplaXML> CrearListaBebidaIngrediente(BE_Bebida_Preparada bebida)
        {
            List<BE_TuplaXML> listadeIngredientes = new List<BE_TuplaXML>();
            foreach (BE_Ingrediente ingrediente in bebida.ListaIngredientes)
            {
                BE_TuplaXML nuevaTupla = new BE_TuplaXML();
                nuevaTupla.NodoRoot = ReferenciasBD.Root;
                nuevaTupla.NodoLeaf = "Bebidas-Ingredientes";
                XElement nuevaBebidaIngrediente = new XElement("Bebida-Ingrediente",
                    new XElement("ID Bebida",bebida.Codigo.ToString()),
                    new XElement("ID Ingrediente", ingrediente.Codigo.ToString())
                    );
                nuevaTupla.Xelement = nuevaBebidaIngrediente;
                listadeIngredientes.Add(nuevaTupla);
            }
            return listadeIngredientes;
        }
    }
}
