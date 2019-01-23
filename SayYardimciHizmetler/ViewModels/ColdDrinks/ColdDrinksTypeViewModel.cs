using Core.Common.Commands;
using Core.Common.Views;
using MaterialDesignThemes.Wpf;
using SayYardimciHizmetler.Constants;
using SayYardimciHizmetler.Models;
using SayYardimciHizmetler.Models.Drinks;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SayYardimciHizmetler.ViewModels.ColdDrinks
{
    public class ColdDrinksTypeViewModel : BaseViewModel
    {
        #region constructor
        public ColdDrinksTypeViewModel()
        {
            InsertOrderItemCommand = new BaseCommand(OnOrderItemInsert, CanOrderItemInsert);
            base.PropertyChanged += TestPropertyChanged;
        }
        #endregion

        #region commands
        public BaseCommand InsertOrderItemCommand { get; set; }
        #endregion

        #region properties
        //public bool ClickFirstSet { get; set; } = true;

        private ObservableCollection<DrinkAttr> coldDrinksAttr;
        public ObservableCollection<DrinkAttr> ColdDrinksAttr
        {
            get { return coldDrinksAttr; }
            set {
                coldDrinksAttr = value;
                base.RaisePropertyChanged("ColdDrinksAttr");
            }
        }

        public ObservableCollection<DrinkOrderNumber> ColdDrinksOrders { get; set; }

        private DrinkAttr selectedDrinkType;
        public DrinkAttr SelectedDrinkType
        {
            get { return selectedDrinkType; }
            set
            {
                if (selectedDrinkType == value) return;
                selectedDrinkType = value;
                base.RaisePropertyChanged("SelectedDrinkType");
                InsertOrderItemCommand.RaiseCanExecuteChanged();
                //Mediator.NotifyColleagues("SelectedDrinkTypeChanged", new DrinkOrderNumber { Id = 1, Name = "Test Order Number" });
            }
        }

        private DrinkOrderNumber selectedOrderNumber;
        public DrinkOrderNumber SelectedOrderNumber
        {
            get { return selectedOrderNumber; }
            set {
                if (selectedOrderNumber == value) return;
                selectedOrderNumber = value;
                base.RaisePropertyChanged("SelectedOrderNumber");
                InsertOrderItemCommand.RaiseCanExecuteChanged();
                //Mediator.NotifyColleagues("ChangeView", true);
            }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int drinkTypeID;
        public int DrinkTypeID
        {
            get { return drinkTypeID; }
            set { drinkTypeID = value; }
        }

        /*private int selectedOrderNumberID;
        public int SelectedOrderNumberID
        {
            get { return selectedOrderNumberID; }
            set { selectedOrderNumberID = value; }
        }*/

        /*private double price;
        public double Price
        {
            get { return price; }
            set { price = value; }
        }*/

        /*private bool loader;
        public bool Loader
        {
            get {
                loader = false;
                return loader;
            }
            set {
                loader = value;
                base.RaisePropertyChanged("Loader");
            }
        }*/

        /*private bool isDialogOpen;
        public bool IsDialogOpen
        {
            get {
                return isDialogOpen;
            }
            set {
                isDialogOpen = value;
                base.RaisePropertyChanged("IsDialogOpen");
            }
        }*/
        #endregion

        #region raisepropertychanged handler
        private void TestPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "AttrSelectedIndex")
            {
                //AttrSelectedIndex = -1;
            }

            if (e.PropertyName == "SelectedDrinkType")
            {
                //selectedDrinkType = ColdDrinksAttr[0];
            }
        }
        #endregion

        #region CommandMethods
        private  void OnOrderItemInsert()
        {
            SelectedDrinkType = null;
            if (SelectedDrinkType != null && SelectedOrderNumber != null)
            {
                try
                {
                    DrinkOrderItem item = new DrinkOrderItem
                    {
                        DrinkAttrName = selectedDrinkType.PropertyName,
                        DrinkAttrID = selectedDrinkType.Id,
                        DrinkTypePrice = selectedDrinkType.Price,
                        DrinkOrderNumberName = selectedOrderNumber.Name,
                        DrinkOrderNumberID = selectedOrderNumber.Id,
                        DrinkTypeName = name,
                        DrinkTypeID = drinkTypeID,
                    };
                    SelectedDrinkType = null;
                    SelectedOrderNumber = null;
                    //selectedDrinkType = ColdDrinksAttr[0];
                    //RaisePropertyChanged("SelectedDrinkType");
                    //AttrSelectedIndex = -1;
                    //System.Windows.Threading.Dispatcher.CurrentDispatcher.BeginInvoke(new Action(() => { RaisePropertyChanged("SelectedDrinkType"); }), null);
                    Mediator.NotifyColleagues("OrderItemAdded", item);
                } catch (Exception ex)
                {
                    Mediator.NotifyColleagues(MessageConstants.NotifyMessengerBroker.Value, MessageConstants.FailureToken.Value);
                }

            } else
            {
                SelectedDrinkType = null;
                SelectedOrderNumber = null;
                Mediator.NotifyColleagues(MessageConstants.NotifyMessengerBroker.Value, MessageConstants.FailureToken);
            }



            
        }
        private bool CanOrderItemInsert()
        {
            if(selectedDrinkType != null && SelectedOrderNumber != null) {
                return true;
            } else
            {
                return false;
            }


            /*if(SelectedDrinkType == null && ClickFirstSet)
            {
                ClickFirstSet = false;
                return true;
            } else if (SelectedDrinkType != null)
            {
                ClickFirstSet = false;
                return true;
            } else if(SelectedDrinkType == null && ClickFirstSet==false)
            {
                Mediator.NotifyColleagues(MessageConstants.NotifyMessengerBroker.Value, MessageConstants.SuccessToken);
                return false;
            }
            return false;*/  
        }
        #endregion

    }
}
