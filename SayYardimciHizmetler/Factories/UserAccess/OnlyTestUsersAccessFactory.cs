using Core.Common.ServiceLocator;
using Core.Common.User;
using Core.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SayYardimciHizmetler.Factories.UserAccess
{
    public class OnlyTestUsersAccessFactory : IFactoryUserAccess
    {
        public void CheckUserAccess(DependencyObject sender)
        {
            var element = sender as FrameworkElement;
            var cont = element.DataContext;
            UserBase currentUser = ServiceLocatorSingleton.Instance.GetService<IUser>() as UserBase;
            var elementType = element.GetType();
            PropertyInfo propInfo = elementType.GetProperty("Visibility");
            if (propInfo != null)
            {
                if(currentUser.Name == "Mustafa")
                propInfo.SetValue(element, Visibility.Hidden);
            }
                
        }
    }
}
