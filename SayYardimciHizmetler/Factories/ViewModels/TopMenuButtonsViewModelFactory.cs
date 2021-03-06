﻿using Core.Factory;
using SayYardimciHizmetler.Models;
using SayYardimciHizmetler.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SayYardimciHizmetler.Factories.ViewModels
{
    public class TopMenuButtonsViewModelFactory : IFactoryViewModel
    {
        public object CreateViewModel(DependencyObject sender)
        {
            var vm = new TopMenuButtonsViewModel();
            /*if (Designer.IsDesignMode)
                vm.ServiceLocator.RegisterServiceObject<ISideMenuDataAccess>(new ModelsDesignTime.DesignTimePeopleDataAccess());
            else
                vm.ServiceLocator.RegisterServiceObject<ISideMenuDataAccess>(new SideMenuDataAccess());*/
            vm.ServiceLocator.RegisterServiceObject<ITopMenuButtonsDataAccess>(new TopMenuButtonsDataAccess());
            return vm;
        }
    }
}
