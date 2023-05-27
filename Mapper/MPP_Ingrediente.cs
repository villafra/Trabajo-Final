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

        public bool Baja(BE_Ingrediente ingrediente)
        {
            Acceso = new Xml_Database();
            return Acceso.Borrar("Ingredientes", "Ingrediente", CrearIngredienteXML(ingrediente));
        }

        public bool Guardar(BE_Ingrediente ingrediente)
        {
            Acceso = new Xml_Database();
            return Acceso.Escribir("Ingredientes", CrearIngredienteXML(ingrediente));
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
                                                          Lote = Convert.ToString(ing[6]),
                                                          Activo = Convert.ToBoolean(ing[7]),
                                                          VidaUtil = Convert.ToInt32(ing[8]),
                                                          Status = Convert.ToString(ing[9]),
                                                          CostoUnitario = Convert.ToDecimal(ing[10])

                                                      }).ToList();
            return listaIngredientes;
            
        }

        public BE_Ingrediente ListarObjeto(BE_Ingrediente ingrediente)
        {
            throw new NotImplementedException();
        }

        private XElement CrearIngredienteXML(BE_Ingrediente ingrediente)
        {
            XElement nuevoIngrediente = new XElement("Ingrediente",
                new XElement("ID", ingrediente.Codigo.ToString()),
                new XElement("Nombre",ingrediente.Nombre),
                new XElement("Tipo",ingrediente.Tipo),
                new XElement("Refrigeración",ingrediente.Refrigeracion.ToString()),
                new XElement("Stock",ingrediente.Stock.ToString()),
                new XElement("Unidad de Medida", ingrediente.UnidadMedida),
                new XElement("Lote", ingrediente.Lote),
                new XElement("Activo", ingrediente.Activo.ToString()),
                new XElement("Vida Util", ingrediente.VidaUtil.ToString()),
                new XElement("Status", ingrediente.Status),
                new XElement("Costo Unitario",ingrediente.CostoUnitario.ToString())
                );
            return nuevoIngrediente;
        }
    }
}
