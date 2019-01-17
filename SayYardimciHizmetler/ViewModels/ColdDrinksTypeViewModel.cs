using Core.Common.Commands;
using Core.Common.Views;
using SayYardimciHizmetler.Models.ColdDrinks;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SayYardimciHizmetler.ViewModels
{
    public class ColdDrinksTypeViewModel : BaseViewModel
    {
        #region constructor
        public ColdDrinksTypeViewModel()
        {

        }
        #endregion

        #region properties
        public ObservableCollection<ColdDrinkAttribute> ColdDrinksAttr { get; set; }

        public ObservableCollection<ColdDrinkOrderNumber> ColdDrinksOrders { get; set; }

        private ColdDrinkAttribute selectedDrinkType;
        public ColdDrinkAttribute SelectedDrinkType
        {
            get { return selectedDrinkType; }
            set
            {
                selectedDrinkType = value;
                base.RaisePropertyChanged("SelectedDrinkType");
                Mediator.NotifyColleagues("SelectedDrinkTypeChanged", new ColdDrinkOrderNumber { Id = 1, Name = "Test Order Number" });
            }
        }

        private ColdDrinkOrderNumber selectedOrderNumber;

        public ColdDrinkOrderNumber SelectedOrderNumber
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
