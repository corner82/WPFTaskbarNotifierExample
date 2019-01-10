using SayYardimciHizmetler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SayYardimciHizmetler.ModelsDesignTime
{
    public class DesignTimePeopleDataAccess : IPeopleDataAccess
    {
        public IEnumerable<Person> GetAllPersons()
        {
            return new List<Person>
            {
                new Person { Name = "Design Name", Surname = "Design Surname", Age=24}
            };
        }
    }
}
