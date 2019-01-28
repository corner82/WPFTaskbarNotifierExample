using Core.Common.Views;
using SayYardimciHizmetler.Models.Drinks;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SayYardimciHizmetler.ViewModels.MeetingRoomDrinks
{
    public class MeetingRoomDrinksViewModel : BaseViewModel
    {
        #region constructor
        public MeetingRoomDrinksViewModel()
        {

        }
        #endregion

        #region properties
        private ObservableCollection<MeetingRoomDrinksTypeViewModel> meetingRoomDrinkTypes;

        public ObservableCollection<MeetingRoomDrinksTypeViewModel> MeetingRoomDrinkTypes
        {
            get
            {
                if (meetingRoomDrinkTypes == null)
                    LoadMeetingRoomDrinkViewModels();
                return meetingRoomDrinkTypes;
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
        public void LoadMeetingRoomDrinkViewModels()
        {
            meetingRoomDrinkTypes = new ObservableCollection<MeetingRoomDrinksTypeViewModel>();

            //get the data access via the service locator.
            var dataAccess = GetService<IDrinkTypesDataAccess>();
            foreach (var item in dataAccess.GetAllMeetingRoomDrinks())
            {
                this.meetingRoomDrinkTypes.Add(new MeetingRoomDrinksTypeViewModel()
                {
                    MeetingRoomDrinksAttr = new ObservableCollection<DrinkAttr>(item.DrinksAttr),
                    //ColdDrinksAttr = item.DrinksAttr,
                    Name = item.Name,
                    DrinkTypeID = item.DrinkTypeID,
                    //Price = item.Price,
                    MeetingRoomDrinksOrders = new ObservableCollection<DrinkOrderNumber>(item.OrderNumbers),
                });
            }
        }
        #endregion
    }
}
