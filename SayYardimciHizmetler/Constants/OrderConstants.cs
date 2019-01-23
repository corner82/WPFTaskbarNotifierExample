using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SayYardimciHizmetler.Constants
{
    public class OrderConstants
    {
        private OrderConstants(string value) { Value = value; }

        public string Value { get; set; }
        public static OrderConstants NotifyOrdemItemAddBroker { get { return new OrderConstants("NotifyOrderItemAddBroker"); } }
    }
}
