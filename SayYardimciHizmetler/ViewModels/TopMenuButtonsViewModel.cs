using Core.Common.Commands;
using Core.Common.Views;
using SayYardimciHizmetler.Models;
using SayYardimciHizmetler.Models.Drinks;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SayYardimciHizmetler.ViewModels
{
    public class TopMenuButtonsViewModel : BaseViewModel
    {
        #region constructor
        public TopMenuButtonsViewModel()
        {
            #region mediator test
            Mediator.Register("SelectedDrinkTypeChanged", OnSelectedDrinkTypeChanged);
            #endregion
        }
        #endregion

        #region TopMenuButtons
        private static IList<TopMenuButton> topMenuButtons;
        public  IList<TopMenuButton> TopMenuButtons
        {
            get
            {
                if (topMenuButtons == null)
                    LoadTopMenuButtons();
                return topMenuButtons;
            }

        }

         public void LoadTopMenuButtons()
        {
            topMenuButtons = new ObservableCollection<TopMenuButton>();

            //get the data access via the service locator.
            var dataAccess = GetService<ITopMenuButtonsDataAccess>();
            foreach (var item in dataAccess.GetTopMenuButtons())
                topMenuButtons.Add(item);
        }
        #endregion

        #region mediator callbacks
        static public void OnSelectedDrinkTypeChanged(object selectedTypeChanged)
        {
            DrinkOrderNumber test = (DrinkOrderNumber)selectedTypeChanged;
        }

        #endregion




    }
}
