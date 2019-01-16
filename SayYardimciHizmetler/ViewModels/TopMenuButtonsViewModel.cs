﻿using Core.Common.Views;
using SayYardimciHizmetler.Models;
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

        }
        #endregion

        #region TopMenuButtons
        private IList<TopMenuButton> topMenuButtons;
        public IList<TopMenuButton> TopMenuButtons
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
    }
}