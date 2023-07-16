using System;
using System.Collections.Generic;
using System.Windows.Forms;

public class Reemplazos
{
    private Dictionary<string, string> reemplazoDictionary;

    public Reemplazos(Dictionary<string, string> Diccionario)
    {
        reemplazoDictionary = Diccionario;
    }

    public string Reemplazar(string selectedItem)
    {
        if (reemplazoDictionary.ContainsKey(selectedItem))
        {
            return reemplazoDictionary[selectedItem];
        }
        return selectedItem;
    }
    public List<string> ListadoClaves()
    {
        return new List<string>(reemplazoDictionary.Keys);
    }
}
