using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SayYardimciHizmetler.Models
{
    public class SideMenuDataAccess : ISideMenuDataAccess
    {
        private readonly IEnumerable<SideMenu> menuItems;

        public IEnumerable<SideMenu> MenuItems
        {
            get
            {
                if (menuItems == null)
                    GetSideMenuItems();
                return menuItems;
            }
            //set { menuItems = value; }
        }



        public IEnumerable<SideMenu> GetSideMenuItems()
        {
            return new List<SideMenu>()
            {
                new SideMenu { MenuIcon="Home", MenuText = "Ana Sayfa"},
                new SideMenu { MenuIcon = "AccountCardDetails", MenuText = "Detaylar" },
                new SideMenu { MenuIcon = "Tea", MenuText = "Sıcak İçecek"},
                new SideMenu { MenuIcon = "Beer", MenuText = "Soğuk İçecek"}
            };
        }
    }
}
