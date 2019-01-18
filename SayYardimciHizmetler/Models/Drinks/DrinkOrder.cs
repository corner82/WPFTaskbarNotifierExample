using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SayYardimciHizmetler.Models.Drinks
{
    public class DrinkOrder : IDrinkOrder
    {
        public int? DrinkOrderItemID { get; set; }
        public List<DrinkOrderItem> DrinkOrderItems { get; set; }
        public DateTime OrderDate { get; set; }
        /*public int UserID { get; set; }
        public int OcakID { get; set; }
        public int OdaciID { get; set; }
        public int RoomID { get; set; }*/
    }
}
