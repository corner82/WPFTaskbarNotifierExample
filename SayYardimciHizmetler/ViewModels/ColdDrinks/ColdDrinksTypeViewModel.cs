using Core.Common.Commands;
using Core.Common.Views;
using SayYardimciHizmetler.Models.ColdDrinks;
using SayYardimciHizmetler.Models.Drinks;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SayYardimciHizmetler.ViewModels.ColdDrinks
{
    public class ColdDrinksTypeViewModel : BaseViewModel
    {
        #region constructor
        public ColdDrinksTypeViewModel()
        {

        }
        #endregion

        #region properties
        public ObservableCollection<DrinkAttr> ColdDrinksAttr { get; set; }

        public ObservableCollection<DrinkOrderNumber> ColdDrinksOrders { get; set; }

        private DrinkAttr selectedDrinkType;
        public DrinkAttr SelectedDrinkType
        {
            get { return selectedDrinkType; }
            set
            {
                selectedDrinkType = value;
                base.RaisePropertyChanged("SelectedDrinkType");
                Mediator.NotifyColleagues("SelectedDrinkTypeChanged", new DrinkOrderNumber { Id = 1, Name = "Test Order Number" });
            }
        }

        private DrinkOrderNumber selectedOrderNumber;

        public DrinkOrderNumber SelectedOrderNumber
        {
            get { return selectedOrderNumber; }
            set {
                selectedOrderNumber = value;
                base.RaisePropertyChanged("SelectedOrderNumber");
                Mediator.NotifyColleagues("ChangeView", true);
            }
        }


        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        #endregion

    }
}
