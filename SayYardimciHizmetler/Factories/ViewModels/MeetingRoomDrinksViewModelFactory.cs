using Core.Factory;
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
    public class MeetingRoomDrinksViewModelFactory : IFactoryViewModel
    {
        public object CreateViewModel(DependencyObject sender)
        {
            var vm = new MeetingRoomDrinksViewModel();
            /*if (Designer.IsDesignMode)
                vm.ServiceLocator.RegisterServiceObject<IPeopleDataAccess>(new ModelsDesignTime.DesignTimePeopleDataAccess());
            else
                vm.ServiceLocator.RegisterServiceObject<IPeopleDataAccess>(new PeopleDataAccess());*/
            vm.ServiceLocator.RegisterServiceObject<IDrinkTypesDataAccess>(new DrinkTypesDataAccess());
            return vm;
        }
    }
}
