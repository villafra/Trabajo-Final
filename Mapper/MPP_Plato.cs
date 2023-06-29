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
using Automate_Layer;

namespace Mapper
{
    public class MPP_Plato : IGestionable<BE_Plato>
    {
        Xml_Database Acceso;
        List<BE_TuplaXML> ListadoXML;

        public MPP_Plato()
        {
            ListadoXML = new List<BE_TuplaXML>();
        }

        public bool Baja(BE_Plato plato)
        {
            Acceso = new Xml_Database();
            ListadoXML.Add(CrearPlatoXML(plato));
            return Acceso.Borrar(ListadoXML);
        }

        public bool Guardar(BE_Plato plato)
        {
            Acceso = new Xml_Database();
            ListadoXML.Add(CrearPlatoXML(plato));
            return Acceso.Escribir(ListadoXML);
        }

        public List<BE_Plato> Listar()
        {
            Acceso = new Xml_Database();
            DataSet ds = new DataSet();
            ds = Acceso.Listar();

            List<BE_Plato> listaPlatos = ds.Tables.Contains("Plato") != false ? (from platos in ds.Tables["Plato"].AsEnumerable()
                                          select new BE_Plato
                                          {
                                              Codigo = Convert.ToInt32(platos[0]),
                                              Nombre = Convert.ToString(platos[1]),
                                              Tipo = (BE_Plato.Tipo_Plato)Enum.Parse(typeof(BE_Plato.Tipo_Plato), Convert.ToString(platos[2])),
                                              Clase = (BE_Plato.Clasificación)Enum.Parse(typeof(BE_Plato.Clasificación), Convert.ToString(platos[3])),
                                              Status = Convert.ToString(platos[4]),
                                              CostoUnitario = Convert.ToDecimal(platos[5]),
                                              Activo = Convert.ToBoolean(platos[6]),
                                              ListaIngredientes = ds.Tables.Contains("Ingrediente-Plato") & ds.Tables.Contains("Plato") != false ? (from obj in ds.Tables["Ingrediente-Plato"].AsEnumerable()
                                                                                       join ing in ds.Tables["Ingrediente"].AsEnumerable()
                                                                                       on Convert.ToInt32(obj[1]) equals Convert.ToInt32(platos[0])
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

                                                                                       }).ToList():null

                                          }).ToList():null;
            return listaPlatos;
        }

        public BE_Plato ListarObjeto(BE_Plato plato)
        {
            throw new NotImplementedException();
        }

        private BE_TuplaXML CrearPlatoXML(BE_Plato plato)
        {
            BE_TuplaXML nuevaTupla = new BE_TuplaXML();
            nuevaTupla.NodoRoot = "Plato";
            nuevaTupla.NodoLeaf = "Platos";
            XElement nuevoPlato = new XElement("Plato",
                new XElement("ID",  Cálculos.IDPadleft(plato.Codigo)),
                new XElement("Nombre", plato.Nombre.ToString()),
                new XElement("Tipo", plato.Tipo.ToString()),
                new XElement("Clase", plato.Clase.ToString()),
                new XElement("Status", plato.Status.ToString()),
                new XElement("Costo Unitario", plato.CostoUnitario.ToString()),
                new XElement("Activo",plato.Activo.ToString())
                );
            nuevaTupla.Xelement = nuevoPlato;
            return nuevaTupla;
        }
        private List<BE_TuplaXML> CrearIngredientePlatoXML(BE_Plato plato)
        {
            List<BE_TuplaXML> ListadeIngredientes = new List<BE_TuplaXML>();
            foreach(BE_Ingrediente ing in plato.ListaIngredientes)
            {
                BE_TuplaXML nuevaTupla = new BE_TuplaXML();
                nuevaTupla.NodoRoot = "Ingredientes-Platos";
                nuevaTupla.NodoLeaf = "Ingrediente-Plato";
                XElement nuevoIngPlato = new XElement("Ingrediente-Plato",
                new XElement("ID Plato", Cálculos.IDPadleft(plato.Codigo)),
                new XElement("ID Ingrediente", Cálculos.IDPadleft(ing.Codigo))
                );
                nuevaTupla.Xelement = nuevoIngPlato;
                ListadeIngredientes.Add(nuevaTupla);
            }
            return ListadeIngredientes;
        }

        public bool Modificar(BE_Plato plato)
        {
            Acceso = new Xml_Database();
            ListadoXML.Add(CrearPlatoXML(plato));
            return Acceso.Modificar(ListadoXML);
        }
    }
}
