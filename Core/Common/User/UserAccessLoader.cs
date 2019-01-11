using Core.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Core.Common.User
{
    public class UserAccessLoader
    {
        public static readonly DependencyProperty UserAccessLevelProperty = DependencyProperty.RegisterAttached("UserAccessLevel",
                                                                        typeof(Type),
                                                                        typeof(UserAccessLoader),
                                                                        new PropertyMetadata(null,
                                                                            new PropertyChangedCallback(OnUserAccessLevelChanged)));

        public static void SetUserAccessLevel(DependencyObject element, Type value)
        {
            element.SetValue(UserAccessLevelProperty, value);
        }

        public static Type GetUserAcccessLevel(DependencyObject element)
        {
            return (Type)element.GetValue(UserAccessLevelProperty);
        }

        public static void OnUserAccessLevelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement element = (FrameworkElement)d;
            //ItemsControl element = (ItemsControl)d;
            IFactoryUserAccess factory = Activator.CreateInstance(GetUserAcccessLevel(d)) as IFactoryUserAccess;
            if (factory == null)
                throw new ArgumentException("You have to specify a type that inherits from IFactory");
            factory.CheckUserAccess(d);
        }
    }
}
