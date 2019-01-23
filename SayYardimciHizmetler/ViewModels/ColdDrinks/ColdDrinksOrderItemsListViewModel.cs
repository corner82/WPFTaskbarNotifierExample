using AmRoMessageDialog;
using Core.Common.Commands;
using Core.Common.ServiceLocator;
using Core.Common.Views;
using ModernMessageBoxLib;
using SayYardimciHizmetler.Constants;
using SayYardimciHizmetler.Models.Drinks;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace SayYardimciHizmetler.ViewModels.ColdDrinks
{
    partial class ColdDrinksOrderItemsListViewModel : BaseViewModel
    {
        public ColdDrinksOrderItemsListViewModel(Window wind)
        {
            //OrderItemsList = new ObservableCollection<DrinkOrderItem>();
            //LoadTestData();
            //orderItemsList = new ObservableCollection<DrinkOrderItem>();
            Mediator.Register("OrderItemAdded", OnOrderItemAdded);
            testWindow = wind;
        }

        public Window testWindow { get; set; }

        static private ObservableCollection<DrinkOrderItem>  orderItemsList;

        static public ObservableCollection<DrinkOrderItem> OrderItemsList
        {
            get {
                if (orderItemsList == null)
                    //LoadTestData();
                    orderItemsList = new ObservableCollection<DrinkOrderItem>();
                return orderItemsList;
            }
            set { orderItemsList = value; }
        }

       public void OnOrderItemAdded(object arg)
        {
            DrinkOrderItem orderItem = (DrinkOrderItem)arg;
            bool successControler = false;
            if (orderItem != null)
            {
                try
                {
                    orderItemsList.Add(orderItem);
                    successControler = true;
                    //throw new Exception("test exception");
                } catch (Exception ex)
                {
                    successControler = false;
                }
                
            } else
            {
                successControler = false;
            }

            if(successControler) {
                Mediator.NotifyColleagues(MessageConstants.NotifyMessengerBroker.Value, MessageConstants.SuccessToken);
            } else
            {
                Mediator.NotifyColleagues(MessageConstants.NotifyMessengerBroker.Value, MessageConstants.FailureToken);
            }
            
        }

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



    }
}
