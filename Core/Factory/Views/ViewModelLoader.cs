using Core.Common.Views;
using System;
using System.Collections;
using System.Windows;
using System.Windows.Controls;

namespace Core.Factory.Views
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
            FrameworkElement element = (FrameworkElement)d ;
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
