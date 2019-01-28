using Core.Common.Commands;
using Core.Common.Views;
using Core.Utill;
using SayYardimciHizmetler.Constants;
using SayYardimciHizmetler.Models.Drinks;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SayYardimciHizmetler.ViewModels.HotDrinks
{
    public class HotDrinksTypeViewModel : BaseViewModel
    {
        #region constructor
        public HotDrinksTypeViewModel()
        {
            InsertOrderItemCommand = new BaseCommand(OnOrderItemInsert, CanOrderItemInsert);
            base.PropertyChanged += ViewPropertyChanged;
        }
        #endregion

        #region commands
        public BaseCommand InsertOrderItemCommand { get; set; }
        #endregion

        #region properties
        private string animationState;
        public string AnimationState
        {
            get
            {
                /*if (animationState == null)
                    animationState = "New";*/
                return animationState;
            }
            set
            {
                if (animationState == value) return;
                animationState = value;
                RaisePropertyChanged("AnimationState");
            }
        }


        private ObservableCollection<DrinkAttr> hotDrinksAttr;
        public ObservableCollection<DrinkAttr> HotDrinksAttr
        {
            get { return hotDrinksAttr; }
            set
            {
                hotDrinksAttr = value;
                base.RaisePropertyChanged("HotDrinksAttr");
            }
        }

        public ObservableCollection<DrinkOrderNumber> HotDrinksOrders { get; set; }

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
            }
        }

        private DrinkOrderNumber selectedOrderNumber;
        public DrinkOrderNumber SelectedOrderNumber
        {
            get { return selectedOrderNumber; }
            set
            {
                if (selectedOrderNumber == value) return;
                selectedOrderNumber = value;
                base.RaisePropertyChanged("SelectedOrderNumber");
                InsertOrderItemCommand.RaiseCanExecuteChanged();
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

        private bool notifySuccessMessageShow;
        public bool NotifySuccessMessageShow
        {
            get { return notifySuccessMessageShow; }
            set
            {
                if (notifySuccessMessageShow == value) return;
                notifySuccessMessageShow = value;
                base.RaisePropertyChanged("NotifySuccessMessageShow");
            }
        }

        private bool notifyFailureMessageShow;
        public bool NotifyFailureMessageShow
        {
            get { return notifyFailureMessageShow; }
            set
            {
                if (notifyFailureMessageShow == value) return;
                notifyFailureMessageShow = value;
                RaisePropertyChanged("NotifyFailureMessageShow");
            }
        }


        private bool loadingShow;
        public bool LoadingShow
        {
            get { return loadingShow; }
            set
            {
                if (loadingShow == value) return;
                loadingShow = value;
                base.RaisePropertyChanged("LoadingShow");
            }
        }

        private int loadingShowOpacity;
        public int LoadingShowOpacity
        {
            get { return loadingShowOpacity; }
            set
            {
                if (loadingShowOpacity == value) return;
                loadingShowOpacity = value;
                RaisePropertyChanged("LoadingShowOpacity");
            }
        }
        #endregion

        #region raisepropertychanged handler
        private void ViewPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "NotifySuccessMessageShow")
            {
                if (NotifySuccessMessageShow == true)
                {
                    ThreadHelper.Wait(2.0, () => {
                        NotifySuccessMessageShow = false;
                        LoadingShow = false;
                        LoadingShowOpacity = 0;
                    });
                }
            }

            if (e.PropertyName == "NotifyFailureMessageShow")
            {
                if (NotifyFailureMessageShow == true)
                {
                    ThreadHelper.Wait(2.0, () => {
                        NotifyFailureMessageShow = false;
                        //SelectedDrinkType = null;
                        //SelectedOrderNumber = null;
                        LoadingShow = false;
                        LoadingShowOpacity = 0;
                    });
                }
            }
        }
        #endregion

        #region CommandMethods
        private void OnOrderItemInsert()
        {
            //SelectedDrinkType = null;
            if (SelectedDrinkType != null && SelectedOrderNumber != null)
            {
                LoadingShow = true;
                LoadingShowOpacity = 1;
                AnimationState = "End";
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
                    NotifySuccessMessageShow = true;
                    //selectedDrinkType = ColdDrinksAttr[0];
                    //RaisePropertyChanged("SelectedDrinkType");
                    //AttrSelectedIndex = -1;
                    //System.Windows.Threading.Dispatcher.CurrentDispatcher.BeginInvoke(new Action(() => { RaisePropertyChanged("SelectedDrinkType"); }), null);
                    Mediator.NotifyColleagues("OrderItemAddedHotDrinks", item);
                }
                catch (Exception ex)
                {
                    SelectedDrinkType = null;
                    SelectedOrderNumber = null;
                    NotifyFailureMessageShow = true;
                    Mediator.NotifyColleagues(MessageConstants.NotifyMessengerBroker.Value, MessageConstants.FailureToken.Value);
                }
            }
            else
            {
                NotifyFailureMessageShow = true;
                SelectedDrinkType = null;
                SelectedOrderNumber = null;
                Mediator.NotifyColleagues(MessageConstants.NotifyMessengerBroker.Value, MessageConstants.FailureToken);
            }
        }
        private bool CanOrderItemInsert()
        {
            if (selectedDrinkType != null && SelectedOrderNumber != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

    }
}
