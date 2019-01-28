using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SayYardimciHizmetler.Models.Complaints
{
    public class ComplaintTypeModel
    {
        public string Name { get; set; }
        public int? BaseTypeID { get; set; }
        public int ComplaintTypeID { get; set; }
    }
}
