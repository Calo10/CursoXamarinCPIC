using System;
using System.Collections.ObjectModel;

namespace Test.Models
{
    public class MenuModel
    {
        public int Id { get; set; }
        public string Icon { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }

        public static ObservableCollection<MenuModel> GetAllMenu()
        {
            ObservableCollection<MenuModel> lstMenu = new ObservableCollection<MenuModel>
            {
                new MenuModel {Id=1, Title = "Operaciones", Detail = "Detalle numero 1", Icon = "" },
                new MenuModel {Id=2, Title = "Mapa", Detail = "Detalle numero 2", Icon = "" },
                new MenuModel {Id=3, Title = "Formulario Contacto", Detail = "Detalle numero 3", Icon = "" }
            };

            return lstMenu;
        }
    }
}
