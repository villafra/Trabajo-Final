using System;
using System.Collections.Generic;
using System.Windows.Forms;

public class ReemplazoManager
{
    private Dictionary<string, string> reemplazoDictionary;

    public ReemplazoManager()
    {
        // Inicializar el diccionario de reemplazo con los valores correspondientes
        reemplazoDictionary = new Dictionary<string, string>
        {
            { "Tipo de Acción", "Accion" },
            { "Tipo de Objeto", "Objeto" },
            { "Tipo de Elemento", "Elemento" }
            // Agregar más pares clave-valor según sea necesario
        };
    }

    public string ObtenerValorReemplazo(string selectedItem)
    {
        // Verificar si el valor seleccionado existe en el diccionario de reemplazo
        if (reemplazoDictionary.ContainsKey(selectedItem))
        {
            // Devolver el valor correspondiente
            return reemplazoDictionary[selectedItem];
        }

        // Si no se encuentra una correspondencia, devolver el valor seleccionado original
        return selectedItem;
    }
}
