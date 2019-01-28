using Core.Factory;
using SayYardimciHizmetler.Models.Complaints;
using SayYardimciHizmetler.ViewModels.Complaints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SayYardimciHizmetler.Factories.ViewModels
{
    public class ComplaintsViewModelFactory : IFactoryViewModel
    {
        public object CreateViewModel(DependencyObject sender)
        {
            var vm = new ComplaintsViewModel();
            /*if (Designer.IsDesignMode)
                vm.ServiceLocator.RegisterServiceObject<IPeopleDataAccess>(new ModelsDesignTime.DesignTimePeopleDataAccess());
            else
                vm.ServiceLocator.RegisterServiceObject<IPeopleDataAccess>(new PeopleDataAccess());*/
            vm.ServiceLocator.RegisterServiceObject<ICompliantTypesDataAccess>(new ComplaintTypesDataAccess());
            return vm;
            //return null;
        }
    }
}
