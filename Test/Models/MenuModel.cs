using System;
using System.Collections.ObjectModel;

namespace Test.Models
{
    public class MenuModel
    {
        public string Icon { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }

        public static ObservableCollection<MenuModel> GetAllMenu()
        {
            ObservableCollection<MenuModel> lstMenu = new ObservableCollection<MenuModel>
            {
                new MenuModel { Title = "Menu 1", Detail = "Detalle numero 1", Icon = "" },
                new MenuModel { Title = "Menu 2", Detail = "Detalle numero 2", Icon = "" },
                new MenuModel { Title = "Menu 3", Detail = "Detalle numero 3", Icon = "" },
                new MenuModel { Title = "Menu 4", Detail = "Detalle numero 4", Icon = "" }
            };

            return lstMenu;
        }
    }
}
