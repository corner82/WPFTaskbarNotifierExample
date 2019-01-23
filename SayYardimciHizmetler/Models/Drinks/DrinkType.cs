using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SayYardimciHizmetler.Models.Drinks
{
    public class DrinkType : IDrinkType
    {
        public List<DrinkAttr> DrinksAttr { get; set; }
        public List<DrinkOrderNumber> OrderNumbers { get; set; }
        public string Name { get; set; }
        public int? BaseTypeID { get; set; }
        public int DrinkTypeID { get; set; }
        //public double Price { get; set; }
    }
}
