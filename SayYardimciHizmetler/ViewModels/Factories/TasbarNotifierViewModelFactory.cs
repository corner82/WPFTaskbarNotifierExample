using Core.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SayYardimciHizmetler.ViewModels.Factories
{
    public class TasbarNotifierViewModelFactory : IFactory
    {
        public object CreateViewModel(DependencyObject sender)
        {
            var vm = new TaskbarNotifierViewModel();
            return vm;
        }
    }
}
