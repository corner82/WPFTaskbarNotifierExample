using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SayYardimciHizmetler.Models.ColdDrinks
{
    public class ColdDrinkType : IColdDrinkType
    {
        public ObservableCollection<ColdDrinkAttribute> ColdDrinksAttr { get; set; }
        public ObservableCollection<ColdDrinkOrderNumber> OrderNumbers { get; set; }
        public string Name { get; set; }
    }
}
