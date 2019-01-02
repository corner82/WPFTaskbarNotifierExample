using Core.Factory;
using SayYardimciHizmetler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SayYardimciHizmetler.ViewModels.Factories
{
    public class ColdDrinksViewModelFactory : IFactory
    {
        public object CreateViewModel(DependencyObject sender)
        {
            var vm = new ColdDrinksViewModel();
            /*if (Designer.IsDesignMode)
                vm.ServiceLocator.RegisterService<IPeopleDataAccess>(new DesignTimeData.DesignTimePeopleDataAccess());
            else
                vm.ServiceLocator.RegisterService<IPeopleDataAccess>(new PeopleDataAccess());*/
            vm.ServiceLocator.RegisterServiceObject<IPeopleDataAccess>(new PeopleDataAccess());
           
            return vm;
        }
    }
}
