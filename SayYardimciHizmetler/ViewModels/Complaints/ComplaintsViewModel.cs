using Core.Common.Views;
using SayYardimciHizmetler.Models.Complaints;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SayYardimciHizmetler.ViewModels.Complaints
{
    
    public class ComplaintsViewModel : BaseViewModel
    {
        #region constructor
        public ComplaintsViewModel()
        {

        }
        #endregion

        #region properties
        private ObservableCollection<ComplaintsTypeViewModel> complaintsTypes;
        public ObservableCollection<ComplaintsTypeViewModel> ComplaintsTypes
        {
            get
            {
                if (complaintsTypes == null)
                    LoadComplaintsViewModels();
                return complaintsTypes;
            }
            //set { myVar = value; }
        }

        #endregion

        #region data access
        public void LoadComplaintsViewModels()
        {
            complaintsTypes = new ObservableCollection<ComplaintsTypeViewModel>();

            //get the data access via the service locator.
            var dataAccess = GetService<ICompliantTypesDataAccess>();
            //ObservableCollection<DrinkAttr> coll;
            foreach (var item in dataAccess.GetAllComplaintTypes())
            {
                this.complaintsTypes.Add(new ComplaintsTypeViewModel()
                {
                    Name = item.Name,
                    ComplaintTypeID = item.ComplaintTypeID,
                    ComplaintContent = null,
                    
                    /*ColdDrinksAttr = new ObservableCollection<DrinkAttr>(item.DrinksAttr),
                    //ColdDrinksAttr = item.DrinksAttr,
                    Name = item.Name,
                    DrinkTypeID = item.DrinkTypeID,
                    //Price = item.Price,
                    ColdDrinksOrders = new ObservableCollection<DrinkOrderNumber>(item.OrderNumbers),*/
                });
            }
        }

        /*public void LoadColdDrinks()
        {
            //LoadColdDrinkViewModels();
            coldDrinks = new ObservableCollection<IDrinkType>();

            //get the data access via the service locator.
            var dataAccess = GetService<IDrinkTypesDataAccess>();
            foreach (var item in dataAccess.GetAllColdDrinks())
                coldDrinks.Add(item);
        }*/
        #endregion
    }



}
