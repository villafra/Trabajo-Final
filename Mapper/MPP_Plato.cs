using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Entities;
using Abstraction_Layer;
using Data_Access_Layer;
using System.Data;
using System.Xml.Linq;

namespace Mapper
{
    public class MPP_Plato : IGestionable<BE_Plato>
    {
        Xml_Database Acceso;
        public bool Baja(BE_Plato plato)
        {
            Acceso = new Xml_Database();
            return Acceso.Borrar("Platos", "Plato", CrearPlatoXML(plato));
        }

        public bool Guardar(BE_Plato plato)
        {
            Acceso = new Xml_Database();
            return Acceso.Escribir("Platos", CrearPlatoXML(plato)) & 
                Acceso.Escribir("Ingredientes-Platos", listaNodos: CrearIngredientePlatoXML(plato));
        }

        public List<BE_Plato> Listar()
        {
            Acceso = new Xml_Database();
            DataSet ds = new DataSet();
            ds = Acceso.Listar();
            List<BE_Ingrediente> listadeIngredientes;

            List<BE_Plato> listaPlatos = (from platos in ds.Tables["Plato"].AsEnumerable()
                                          select new BE_Plato
                                          {
                                              Codigo = Convert.ToInt32(platos[0]),
                                              Nombre = Convert.ToString(platos[1]),
                                              Tipo = Convert.ToString(platos[2]),
                                              Clase = Convert.ToString(platos[3]),
                                              Status = Convert.ToString(platos[4]),
                                              CostoUnitario = Convert.ToDecimal(platos[5]),
                                              Activo = Convert.ToBoolean(platos[6]),
                                              ListaIngredientes = listadeIngredientes = (from obj in ds.Tables["Ingrediente-Plato"].AsEnumerable()
                                                                                       join ing in ds.Tables["Ingrediente"].AsEnumerable()
                                                                                       on Convert.ToInt32(obj[1]) equals Convert.ToInt32(platos[0])
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

                                          }).ToList();
            return listaPlatos;
        }

        public BE_Plato ListarObjeto(BE_Plato plato)
        {
            throw new NotImplementedException();
        }

        private XElement CrearPlatoXML(BE_Plato plato)
        {
            XElement nuevoPlato = new XElement("Plato",
                new XElement("ID", plato.Codigo.ToString()),
                new XElement("Nombre", plato.Nombre.ToString()),
                new XElement("Tipo", plato.Tipo.ToString()),
                new XElement("Clase", plato.Clase.ToString()),
                new XElement("Status", plato.Status.ToString()),
                new XElement("Costo Unitario", plato.CostoUnitario.ToString()),
                new XElement("Activo",plato.Activo.ToString())
                );
            return nuevoPlato;
        }
        private List<XElement> CrearIngredientePlatoXML(BE_Plato plato)
        {
            List<XElement> ListadeIngredientes = new List<XElement>();
            foreach(BE_Ingrediente ing in plato.ListaIngredientes)
            {
                XElement nuevoIngPlato = new XElement("Ingrediente-Plato",
                new XElement("ID Plato", plato.Codigo.ToString()),
                new XElement("ID Ingrediente", ing.Codigo.ToString())
                );

                ListadeIngredientes.Add(nuevoIngPlato);
            }
            return ListadeIngredientes;
        }

        public bool Modificar(BE_Plato plato)
        {
            Acceso = new Xml_Database();
            return Acceso.Modificar("Platos", "Plato", CrearPlatoXML(plato));
        }
    }
}
