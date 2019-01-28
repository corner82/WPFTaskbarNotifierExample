using Core.Common.Views;
using SayYardimciHizmetler.Models.Drinks;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SayYardimciHizmetler.ViewModels.HotDrinks
{
    public class HotDrinksViewModel : BaseViewModel
    {
        #region constructor
        public HotDrinksViewModel()
        {

        }
        #endregion

        #region properties
        private ObservableCollection<HotDrinksTypeViewModel> hotDrinkTypes;
        public ObservableCollection<HotDrinksTypeViewModel> HotDrinkTypes
        {
            get
            {
                if (hotDrinkTypes == null)
                    LoadHotDrinkViewModels();
                return hotDrinkTypes;
            }
            //set { myVar = value; }
        }

        private DrinkAttr selectedDrinkType;
        public DrinkAttr SelectedDrinkType
        {
            get { return selectedDrinkType; }
            set
            {
                selectedDrinkType = value;
                base.RaisePropertyChanged("SelectedDrinkType");
            }
        }

        #endregion

        #region data access
        public void LoadHotDrinkViewModels()
        {
            hotDrinkTypes = new ObservableCollection<HotDrinksTypeViewModel>();

            //get the data access via the service locator.
            var dataAccess = GetService<IDrinkTypesDataAccess>();
            //ObservableCollection<DrinkAttr> coll;
            foreach (var item in dataAccess.GetAllHotDrinks())
            {
                this.hotDrinkTypes.Add(new HotDrinksTypeViewModel()
                {
                    HotDrinksAttr = new ObservableCollection<DrinkAttr>(item.DrinksAttr),
                    //ColdDrinksAttr = item.DrinksAttr,
                    Name = item.Name,
                    DrinkTypeID = item.DrinkTypeID,
                    //Price = item.Price,
                    HotDrinksOrders = new ObservableCollection<DrinkOrderNumber>(item.OrderNumbers),
                });
            }
        }
        #endregion
    }
}
