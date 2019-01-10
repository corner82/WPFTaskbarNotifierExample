using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SayYardimciHizmetler.Models
{
    public interface ISideMenuDataAccess
    {
        IEnumerable<SideMenu> GetSideMenuItems();
    }
}
