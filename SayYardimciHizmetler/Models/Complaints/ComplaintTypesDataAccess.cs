using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SayYardimciHizmetler.Models.Complaints
{
    public class ComplaintTypesDataAccess : ICompliantTypesDataAccess
    {
        public List<ComplaintTypeModel> GetAllComplaintTypes()
        {

            return new List<ComplaintTypeModel>()
            {
                new ComplaintTypeModel
                {
                    Name = "Ocak Önerileri",
                    ComplaintTypeID = 1,
                    BaseTypeID = 0
                },
                new ComplaintTypeModel
                {
                    Name = "Odacı / Servis Önerileri",
                    ComplaintTypeID = 2,
                    BaseTypeID = 0
                },
                new ComplaintTypeModel
                {
                    Name = "Genel Öneriler",
                    ComplaintTypeID = 3,
                    BaseTypeID = 0
                }
            };

        }
    }
}
