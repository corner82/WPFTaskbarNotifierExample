using Core.Common.Views;
using SayYardimciHizmetler.Models;
using SayYardimciHizmetler.Models.Drinks;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SayYardimciHizmetler.ViewModels.ColdDrinks
{
    public class ColdDrinksViewModel : BaseViewModel
    {
        #region constructor
        public ColdDrinksViewModel()
        {
            //LoadColdDrinkViewModels();
        }
        #endregion

        #region properties
        private ObservableCollection<ColdDrinksTypeViewModel> coldDrinkTypes;

        public ObservableCollection<ColdDrinksTypeViewModel> ColdDrinkTypes
        {
            get {
                if (coldDrinkTypes == null)
                    LoadColdDrinkViewModels();
                return coldDrinkTypes; }
            //set { myVar = value; }
        }

        private ObservableCollection<IDrinkType> coldDrinks;

        public ObservableCollection<IDrinkType> ColdDrinks
        {
            get
            {
                if (coldDrinks == null)
                    LoadColdDrinks();
                return coldDrinks;
            }
        }

        private DrinkAttr selectedDrinkType;

        public DrinkAttr SelectedDrinkType
        {
            get { return  selectedDrinkType; }
            set {
                selectedDrinkType = value;
                base.RaisePropertyChanged("SelectedDrinkType");
            }
        }

        #endregion

        #region data access
        public void LoadColdDrinkViewModels()
        {
            coldDrinkTypes = new ObservableCollection<ColdDrinksTypeViewModel>();

            //get the data access via the service locator.
            var dataAccess = GetService<IDrinkTypesDataAccess>();
            //ObservableCollection<DrinkAttr> coll;
            foreach (var item  in dataAccess.GetAllColdDrinks())
            {
                this.coldDrinkTypes.Add(new ColdDrinksTypeViewModel()
                {
                    ColdDrinksAttr = new ObservableCollection<DrinkAttr>(item.DrinksAttr),
                    //ColdDrinksAttr = item.DrinksAttr,
                    Name = item.Name,
                    DrinkTypeID = item.DrinkTypeID,
                    //Price = item.Price,
                    ColdDrinksOrders = new ObservableCollection<DrinkOrderNumber>(item.OrderNumbers),
                });
            }
        }
        public void LoadColdDrinks()
        {
            //LoadColdDrinkViewModels();
            coldDrinks = new ObservableCollection<IDrinkType>();

            //get the data access via the service locator.
            var dataAccess = GetService<IDrinkTypesDataAccess>();
            foreach (var item in dataAccess.GetAllColdDrinks())
                coldDrinks.Add(item);
        }
        #endregion

    }
}
