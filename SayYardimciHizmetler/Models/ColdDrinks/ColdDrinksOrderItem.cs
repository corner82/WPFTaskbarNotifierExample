using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SayYardimciHizmetler.Models.ColdDrinks
{
    public class ColdDrinksOrderItem :IColdDrinksOrderItem
    {
        public int? ColdDrinkOrderItemID { get; set; }
        public int ColdDrinkAttrID { get; set; }
        public string ColdDrinkAttrName { get; set; }
        
        public int ColdDrinksOrderNumberID { get; set; }
        public string ColdDrinksOrderNumberName { get; set; }
    }
}
