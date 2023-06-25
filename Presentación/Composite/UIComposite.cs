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
        private static List<string> SubVisibles = new List<string>();
        private static List<string> MenusVisibles = new List<string>();
        public static void CambiarVisibilidadMenu(ToolStripItemCollection dropDownItems, IList<BE_Permiso> permiso)
        {
            CambiarVisibilidad(dropDownItems, permiso);
            MostrarItems(dropDownItems);
            SubVisibles.Clear();
            MostrarMenuPrincial(dropDownItems);
        }

        private static void CambiarVisibilidad(ToolStripItemCollection Items, IList<BE_Permiso> permisos, bool visibles = false)
        {
            foreach (ToolStripMenuItem item in Items)
            {
                string tag = item.Tag as string;
                bool permisopadre;
                bool permisohijo;

                if (item.OwnerItem == null) { CambiarVisibilidad(item.DropDownItems, permisos); continue ; }
                if (tag != null && tag.Equals("Gral")) { item.Visible = true;continue; }
                if (item.HasDropDown) { CambiarVisibilidad(item.DropDownItems, permisos, visibles); }
                
                permisopadre = permisos.Any(p => p.Codigo.Equals(tag));
                permisohijo = permisos.Any(p => p is BE_PermisoPadre ? ((BE_PermisoPadre)p)._permisos.Any(x => x.Codigo.Equals(tag)) : false);
                
                if (!string.IsNullOrEmpty(tag) && (permisopadre || permisohijo))
                {
                    item.Visible = true;
                    if (item.OwnerItem != null && item.OwnerItem.Tag != null && item.OwnerItem.Tag.Equals("Sub"))
                    {
                        SubVisibles.Add(item.OwnerItem.Text);
                        MenusVisibles.Add(item.OwnerItem.OwnerItem.Text);
                    }
                    else if(item.OwnerItem != null && item.OwnerItem.Tag != null && item.OwnerItem.Tag.Equals("SubSub"))
                    {
                        SubVisibles.Add(item.OwnerItem.Text);
                        SubVisibles.Add(item.OwnerItem.OwnerItem.Text);
                        MenusVisibles.Add(item.OwnerItem.OwnerItem.OwnerItem.Text);
                    }
                    else
                    {
                        MenusVisibles.Add(item.OwnerItem.Text);
                    }
                    continue;
                }
                else item.Visible = false;
            }
        }
        private static void MostrarItems(ToolStripItemCollection collection)
        {
            foreach (ToolStripItem item in collection)
            {
                if (SubVisibles.Find(x=> x == item.Text) != null ) item.Visible = true;
                if (item is ToolStripMenuItem dropDownItem) MostrarItems(dropDownItem.DropDownItems);
            }
        }
        private static void MostrarMenuPrincial(ToolStripItemCollection dropDownItems)
        {
            foreach(ToolStripMenuItem item in dropDownItems)
            {
                if(item.Text == "Menu Usuario") { item.Visible = true; continue; }
                if (MenusVisibles.Find(x => x == item.Text) != null) item.Visible = true;
                else item.Visible = false;
            }
            MenusVisibles.Clear();
        }
    }
}
