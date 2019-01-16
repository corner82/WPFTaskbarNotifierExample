using Core.Common.Views;
using SayYardimciHizmetler.Models;
using SayYardimciHizmetler.Models.ColdDrinks;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SayYardimciHizmetler.ViewModels
{
    public class ColdDrinksViewModel : BaseViewModel
    {
        #region constructor
        public ColdDrinksViewModel()
        {

        }

        #endregion

        #region properties
        private ObservableCollection<IColdDrinkType> coldDrinks;

        public ObservableCollection<IColdDrinkType> ColdDrinks
        {
            get
            {
                if (coldDrinks == null)
                    LoadColdDrinks();
                return coldDrinks;
            }
        }

        private ColdDrinkAttribute selectedDrinkType;

        public ColdDrinkAttribute SelectedDrinkType
        {
            get { return  selectedDrinkType; }
            set {
                selectedDrinkType = value;
                base.RaisePropertyChanged("SelectedDrinkType");
            }
        }

        #endregion

        public void LoadColdDrinks()
        {
            coldDrinks = new ObservableCollection<IColdDrinkType>();

            //get the data access via the service locator.
            var dataAccess = GetService<IColdDrinkTypesDataAccess>();
            foreach (var item in dataAccess.GetAllColdDrinks())
                coldDrinks.Add(item);
        }


        /*private IList<Person> people;
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
        }*/
    }
}
