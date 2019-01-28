using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SayYardimciHizmetler.Models.Complaints
{
    public class ComplaintModel
    {
        public int? ComplaintID { get; set; }
        public string ComplaintContent { get; set; }
        public int ComplaintTypeID { get; set; }
        public byte Active { get; set; } = 1;
    }
}
