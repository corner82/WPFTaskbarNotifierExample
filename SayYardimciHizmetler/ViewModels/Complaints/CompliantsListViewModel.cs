using Core.Common.Commands;
using Core.Common.Views;
using SayYardimciHizmetler.Constants;
using SayYardimciHizmetler.Models.Complaints;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SayYardimciHizmetler.ViewModels.Complaints
{
    public class CompliantsListViewModel : BaseViewModel
    {
        #region constructor
        public CompliantsListViewModel()
        {
            Mediator.Register("ComplaintAdded", OnComplaintAdded);
            base.PropertyChanged += ViewPropertyChanged;
        }
        #endregion

        #region properties
        private ObservableCollection<ComplaintModel> complaintsList;
        public ObservableCollection<ComplaintModel> ComplaintsList
        {
            get
            {
                if (complaintsList == null)
                    //complaintsList = ServiceLocatorSingleton.Instance.GetServiceWithKey<ObservableCollection<DrinkOrderItem>>("OrderItemsListSource");
                    complaintsList = new ObservableCollection<ComplaintModel>();
                return complaintsList;
            }
            set
            {
                if (complaintsList == value) return;
                complaintsList = value;
                base.RaisePropertyChanged("ComplaintsList");
            }
        }
        #endregion

        #region raisepropertychanged handler
        private void ViewPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "ComplaintsList")
            {
                /*ServiceLocatorSingleton.Instance.RegisterServiceObjectWithKey<ObservableCollection<DrinkOrderItem>>(
                                                                       OrderItemsList,
                                                                       "OrderItemsListSource", true);*/
            }
        }
        #endregion

        #region mediator callbacks
        public void OnComplaintAdded(object arg)
        {
            ComplaintModel comp = (ComplaintModel)arg;
            bool successControler = false;
            if (comp != null)
            {
                try
                {
                    complaintsList.Add(comp);
                    successControler = true;
                    base.RaisePropertyChanged("ComplaintsList");
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
