using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SayYardimciHizmetler.Models.Drinks
{
    public class DrinkAttr : IDrinkAttr
    {
        public int Id { get; set; }
        public string PropertyName { get; set; }
    }
}
