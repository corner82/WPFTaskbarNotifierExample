using Core.Common.AppMode;
using Core.Factory;
using SayYardimciHizmetler.Models;
using SayYardimciHizmetler.Models.Drinks;
using SayYardimciHizmetler.ViewModels;
using SayYardimciHizmetler.ViewModels.ColdDrinks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SayYardimciHizmetler.Factories.ViewModels
{
    public class ColdDrinksViewModelFactory : IFactoryViewModel
    {
        public object CreateViewModel(DependencyObject sender)
        {
            var vm = new ColdDrinksViewModel();
            /*if (Designer.IsDesignMode)
                vm.ServiceLocator.RegisterServiceObject<IPeopleDataAccess>(new ModelsDesignTime.DesignTimePeopleDataAccess());
            else
                vm.ServiceLocator.RegisterServiceObject<IPeopleDataAccess>(new PeopleDataAccess());*/
            vm.ServiceLocator.RegisterServiceObject<IDrinkTypesDataAccess>(new DrinkTypesDataAccess());
            return vm;
        }
    }
}
