using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Core.Factory
{
    public interface IFactory
    {
        object CreateViewModel(DependencyObject sender);
    }
}
