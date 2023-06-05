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
    public class MPP_Ingrediente:IGestionable<BE_Ingrediente>
    {
        Xml_Database Acceso;
        List<BE_TuplaXML> ListadoXML;

        public MPP_Ingrediente()
        {
            ListadoXML = new List<BE_TuplaXML>();
        }

        public bool Baja(BE_Ingrediente ingrediente)
        {
            Acceso = new Xml_Database();
            ListadoXML.Add(CrearIngredienteXML(ingrediente));
            return Acceso.Borrar(ListadoXML);
        }

        public bool Guardar(BE_Ingrediente ingrediente)
        {
            Acceso = new Xml_Database();
            ListadoXML.Add(CrearIngredienteXML(ingrediente));
            return Acceso.Escribir(ListadoXML);
        }

        public List<BE_Ingrediente> Listar()
        {
            Acceso = new Xml_Database();
            DataSet ds = new DataSet();
            ds = Acceso.Listar();

            List<BE_Ingrediente> listaIngredientes = (from ing in ds.Tables["Ingrediente"].AsEnumerable()
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

                                                      }).ToList();
            return listaIngredientes;
            
        }
        public BE_Ingrediente ListarObjeto(BE_Ingrediente ingrediente)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(BE_Ingrediente ingrediente)
        {
            Acceso = new Xml_Database();
            ListadoXML.Add(CrearIngredienteXML(ingrediente));
            return Acceso.Modificar(ListadoXML);
        }

        private BE_TuplaXML CrearIngredienteXML(BE_Ingrediente ingrediente)
        {
            BE_TuplaXML nuevaTupla = new BE_TuplaXML();
            nuevaTupla.NodoRoot = "Ingredientes";
            nuevaTupla.NodoLeaf = "Ingrediente";
            XElement nuevoIngrediente = new XElement("Ingrediente",
                new XElement("ID", ingrediente.Codigo.ToString()),
                new XElement("Nombre",ingrediente.Nombre),
                new XElement("Tipo",ingrediente.Tipo),
                new XElement("Refrigeración",ingrediente.Refrigeracion.ToString()),
                new XElement("Stock",ingrediente.Stock.ToString()),
                new XElement("Unidad de Medida", ingrediente.UnidadMedida),
                new XElement("Fecha de creación", ingrediente.FechaCreacion.ToString("dd/MM/yyyy")),
                new XElement("Lote", ingrediente.Lote),
                new XElement("Activo", ingrediente.Activo.ToString()),
                new XElement("Vida Util", ingrediente.VidaUtil.ToString()),
                new XElement("Status", ingrediente.Status),
                new XElement("Costo Unitario",ingrediente.CostoUnitario.ToString())
                );
            nuevaTupla.Xelement = nuevoIngrediente;
            return nuevaTupla;
        }
    }
}
