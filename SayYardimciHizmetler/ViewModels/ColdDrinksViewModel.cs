using Core.Common.Views;
using SayYardimciHizmetler.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SayYardimciHizmetler.ViewModels
{
    public class ColdDrinksViewModel : BaseViewModel
    {
        private IList<Person> people;
        public IList<Person> People
        {
            get
            {
                if (people == null)
                    LoadPeople();
                return people;
            }
        }

        public void LoadPeople()
        {
            people = new ObservableCollection<Person>();

            //get the data access via the service locator.
            var dataAccess = GetService<IPeopleDataAccess>();
            foreach (var item in dataAccess.GetAllPersons())
                people.Add(item);
        }
    }
}
