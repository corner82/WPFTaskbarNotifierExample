﻿using Core.Factory;
using SayYardimciHizmetler.Models.Drinks;
using SayYardimciHizmetler.ViewModels.MeetingRoomDrinks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SayYardimciHizmetler.Factories.ViewModels
{
    public class MeetingRoomDrinksOrderItemsListViewModelFactory : IFactoryViewModel
    {
        public object CreateViewModel(DependencyObject sender)
        {
            var vm = new MeetingRoomDrinksOrderItemsListViewModel();
            /*if (Designer.IsDesignMode)
                vm.ServiceLocator.RegisterServiceObject<IPeopleDataAccess>(new ModelsDesignTime.DesignTimePeopleDataAccess());
            else
                vm.ServiceLocator.RegisterServiceObject<IPeopleDataAccess>(new PeopleDataAccess());*/
            vm.ServiceLocator.RegisterServiceObject<IDrinkOrderDataAccess>(new DrinkOrderDataAccess());
            return vm;
        }
    }
}
