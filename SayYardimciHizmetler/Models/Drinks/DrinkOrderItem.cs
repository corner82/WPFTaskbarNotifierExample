using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SayYardimciHizmetler.Models.Drinks
{
    public class DrinkOrderItem : IDrinkOrderItem
    {
        public int? DrinkOrderItemID { get; set; }

        public int DrinkAttrID { get; set; }
        public string DrinkAttrName { get; set; }

        public int DrinkTypeID { get; set; }
        public string DrinkTypeName { get; set; }
        public double DrinkTypePrice { get; set; }

        public int DrinkOrderNumberID { get; set; }
        public string DrinkOrderNumberName { get; set; }
    }
}
