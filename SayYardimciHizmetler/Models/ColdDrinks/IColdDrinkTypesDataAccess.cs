using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SayYardimciHizmetler.Models.ColdDrinks
{
    public interface IColdDrinkTypesDataAccess
    {
        ObservableCollection<ColdDrinkType> GetAllColdDrinks();
    }
}
