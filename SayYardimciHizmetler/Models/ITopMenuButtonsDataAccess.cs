using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SayYardimciHizmetler.Models
{
    interface ITopMenuButtonsDataAccess
    {
        IEnumerable<TopMenuButton> GetTopMenuButtons();
    }
}
