using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SayYardimciHizmetler.Models
{
    class PeopleDataAccess : IPeopleDataAccess
    {
        public IEnumerable<Person> GetAllPersons()
        {
            return new List<Person>
            {
                new Person { Name = "Marlon", Surname = "Grech", Age=24},
                new Person { Name = "Marlon", Surname = "Grech", Age=24},
                new Person { Name = "Marlon", Surname = "Grech", Age=24},
                new Person { Name = "Marlon", Surname = "Grech", Age=24},
            };
        }
    }
}
