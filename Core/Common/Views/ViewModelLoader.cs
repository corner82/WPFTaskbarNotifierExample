using Core.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Core.Common.Views
{
    public class ViewModelLoader
    {
        #region FactoryType
        public static readonly DependencyProperty FactoryTypeProperty =
            DependencyProperty.RegisterAttached("FactoryType", typeof(Type), typeof(ViewModelLoader),
                new FrameworkPropertyMetadata((Type)null,
                new PropertyChangedCallback(OnFactoryTypeChanged)));

        public static Type GetFactoryType(DependencyObject d)
        {
            return (Type)d.GetValue(FactoryTypeProperty);
        }

        public static void SetFactoryType(DependencyObject d, Type value)
        {
            d.SetValue(FactoryTypeProperty, value);
        }

        public static void OnFactoryTypeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            System.Windows.FrameworkElement element = (FrameworkElement)d;
            IFactoryViewModel factory = Activator.CreateInstance(GetFactoryType(d)) as IFactoryViewModel;
            if (factory == null)
                throw new ArgumentException("You have to specify a type that inherits from IFactory");
            element.DataContext = factory.CreateViewModel(d);
            //var vm = factory.CreateViewModel(d);
            //element.ItemsSource = vm.ServiceLocator.GetService<IPeopleDataAccess>();
        }

        #endregion
    }
}
