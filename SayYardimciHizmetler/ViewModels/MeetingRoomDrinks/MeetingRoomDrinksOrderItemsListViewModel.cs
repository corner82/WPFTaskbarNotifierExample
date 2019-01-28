using Core.Common.Commands;
using Core.Common.ServiceLocator;
using Core.Common.Views;
using SayYardimciHizmetler.Constants;
using SayYardimciHizmetler.Models.Drinks;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SayYardimciHizmetler.ViewModels.MeetingRoomDrinks
{
    public class MeetingRoomDrinksOrderItemsListViewModel : BaseViewModel
    {
        #region constructor
        public MeetingRoomDrinksOrderItemsListViewModel()
        {
            Mediator.Register("OrderItemAddedMeetingRoomDrinks", OnOrderItemAddedMeetingRoom);
            base.PropertyChanged += ViewPropertyChanged;
        }
        #endregion

        #region properties
        private ObservableCollection<DrinkOrderItem> orderItemsList;
        public ObservableCollection<DrinkOrderItem> OrderItemsList
        {
            get
            {
                if (orderItemsList == null)
                    //orderItemsList = ServiceLocatorSingleton.Instance.GetServiceWithKey<ObservableCollection<DrinkOrderItem>>("OrderItemsListSource");
                orderItemsList = new ObservableCollection<DrinkOrderItem>();
                return orderItemsList;
            }
            set
            {
                if (orderItemsList == value) return;
                orderItemsList = value;
                base.RaisePropertyChanged("OrderItemsList");
            }
        }
        #endregion

        #region raisepropertychanged handler
        private void ViewPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            /*if (e.PropertyName == "OrderItemsList")
            {
                ServiceLocatorSingleton.Instance.RegisterServiceObjectWithKey<ObservableCollection<DrinkOrderItem>>(
                                                                       OrderItemsList,
                                                                       "OrderItemsListSource", true);
            }*/
        }
        #endregion

        #region mediator callbacks
        public void OnOrderItemAddedMeetingRoom(object arg)
        {
            DrinkOrderItem orderItem = (DrinkOrderItem)arg;
            bool successControler = false;
            if (orderItem != null)
            {
                try
                {
                    OrderItemsList.Add(orderItem);
                    successControler = true;
                    base.RaisePropertyChanged("OrderItemsList");
                    //throw new Exception("test exception");
                }
                catch (Exception ex)
                {
                    successControler = false;
                }

            }
            else
            {
                successControler = false;
            }

            if (successControler)
            {
                Mediator.NotifyColleagues(MessageConstants.NotifyMessengerBroker.Value, MessageConstants.SuccessToken);
            }
            else
            {
                Mediator.NotifyColleagues(MessageConstants.NotifyMessengerBroker.Value, MessageConstants.FailureToken);
            }

        }
        #endregion

        #region dataaccess
        public void LoadTestData()
        {
            /*orderItemsList = new ObservableCollection<DrinkOrderItem>();
            orderItemsList.Add(new DrinkOrderItem {
                    DrinkAttrName = "500 ml",
                    DrinkOrderNumberName = "3"
                });
            OrderItemsList.Add(new DrinkOrderItem
            {
                DrinkAttrName = "1000 ml",
                DrinkOrderNumberName = "5"
            });*/

        }
        #endregion


    }
}
