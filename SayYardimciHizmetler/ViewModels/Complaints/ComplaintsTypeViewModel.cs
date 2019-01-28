using Core.Common.Commands;
using Core.Common.Views;
using Core.Utill;
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
    public class ComplaintsTypeViewModel : BaseViewModel
    {
        #region constructor
        public ComplaintsTypeViewModel()
        {
            InsertComplaintCommand = new BaseCommand(OnComplaintInsert, CanComplaintInsert);
            base.PropertyChanged += ViewPropertyChanged;
        }
        #endregion

        #region commands
        public BaseCommand InsertComplaintCommand { get; set; }
        #endregion

        #region properties
        private string complaintContent;
        public string ComplaintContent
        {
            get { return complaintContent; }
            set {
                if (complaintContent == value) return;
                complaintContent = value;
                InsertComplaintCommand.RaiseCanExecuteChanged();
                //RaisePropertyChanged("ComplaintContent");
            }
        }

        private string name;
        public string  Name
        {
            get { return name; }
            set { name = value; }
        }


        private int complaintTypeID;
        public int ComplaintTypeID
        {
            get { return complaintTypeID; }
            set { complaintTypeID = value; }
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
                base.RaisePropertyChanged("NotifyFailureMessageShow");
            }
        }

        private bool notifyMinCharacterMessageShow;
        public bool NotifyMinCharacterMessageShow
        {
            get { return notifyMinCharacterMessageShow; }
            set
            {
                if (notifyMinCharacterMessageShow == value) return;
                notifyMinCharacterMessageShow = value;
                RaisePropertyChanged("NotifyMinCharacterMessageShow");
            }
        }

        private bool notifyMaxCharacterMessageShow;
        public bool NotifyMaxCharacterMessageShow
        {
            get { return notifyMaxCharacterMessageShow; }
            set
            {
                if (notifyMaxCharacterMessageShow == value) return;
                notifyMaxCharacterMessageShow = value;
                RaisePropertyChanged("NotifyMaxCharacterMessageShow");
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

            if (e.PropertyName == "NotifyMinCharacterMessageShow")
            {
                if (NotifyMinCharacterMessageShow == true)
                {
                    ThreadHelper.Wait(5.0, () => {
                        NotifyMinCharacterMessageShow = false;
                        LoadingShow = false;
                        LoadingShowOpacity = 0;
                    });
                }
            }

            if (e.PropertyName == "NotifyMaxCharacterMessageShow")
            {
                if (NotifyMaxCharacterMessageShow == true)
                {
                    ThreadHelper.Wait(5.0, () => {
                        NotifyMaxCharacterMessageShow = false;
                        LoadingShow = false;
                        LoadingShowOpacity = 0;
                    });
                }
            }
        }
        #endregion

        #region CommandMethods
        private void OnComplaintInsert()
        {
            //SelectedDrinkType = null;
            if (complaintContent != null )
            {
                LoadingShow = true;
                LoadingShowOpacity = 1;
                try
                {
                    ComplaintModel comp = new ComplaintModel
                    {
                        Active = 1,
                        ComplaintContent = ComplaintContent,
                        ComplaintTypeID = ComplaintTypeID,

                    };
                    
                    
                    NotifySuccessMessageShow = true;
                    //System.Windows.Threading.Dispatcher.CurrentDispatcher.BeginInvoke(new Action(() => { RaisePropertyChanged("SelectedDrinkType"); }), null);
                    Mediator.NotifyColleagues("OrderItemAddedComplaints", comp);
                }
                catch (Exception ex)
                {
                    NotifyFailureMessageShow = true;
                    Mediator.NotifyColleagues(MessageConstants.NotifyMessengerBroker.Value, MessageConstants.FailureToken.Value);
                }

            }
            else
            {
                NotifyFailureMessageShow = true;
                Mediator.NotifyColleagues(MessageConstants.NotifyMessengerBroker.Value, MessageConstants.FailureToken);
            }




        }
        private bool CanComplaintInsert()
        {
            if (ComplaintContent != null )
            {
                if(ComplaintContent.Length < 20)
                {
                    NotifyMinCharacterMessageShow = true;
                    return false;
                } else if(ComplaintContent.Length > 255)
                {
                    NotifyMaxCharacterMessageShow = true;
                    return false;
                }
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
