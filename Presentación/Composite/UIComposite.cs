using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business_Entities;

namespace Trabajo_Final
{
    public static class UIComposite
    {
        public static void CambiarVisibilidadMenu(ToolStripItemCollection dropDownItems, IList<BE_Permiso> permiso)
        {
            bool tieneVisibles = false;
            CambiarVisibilidadMenu(dropDownItems, ref tieneVisibles, permiso);
        }
        public static void CambiarVisibilidadMenu(ToolStripItemCollection dropDownItems, ref bool tieneVisibles, IList<BE_Permiso> permiso)
        {
            foreach (object obj in dropDownItems)
            {
                ToolStripMenuItem subMenu = obj as ToolStripMenuItem;
                if (subMenu != null)
                {
                    if (subMenu.HasDropDown)
                    {
                        tieneVisibles = subMenu.Name != "Empleados" || subMenu.Name != "Inventarios" ? false : true;
                        CambiarVisibilidadMenu(subMenu.DropDownItems, ref tieneVisibles, permiso);
                    }
                    bool visible = false;
                    string tag = subMenu.Tag as string;
                    if (!string.IsNullOrEmpty(tag) && (tag.Equals("Gral") || permiso.Any(p => p.Codigo.Equals(tag))))
                    {
                        visible = true;
                        tieneVisibles = true;
                    }

                    if (string.IsNullOrWhiteSpace(tag) && tieneVisibles)
                        subMenu.Visible = true;
                    else
                        subMenu.Visible = visible;


                }
            }
        }
    }
}
