using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Core.Common.User
{
    public class UserAccessLoader
    {
        public static readonly DependencyProperty UserAccessLevelProperty = DependencyProperty.RegisterAttached("UserAccessLevel",
                                                                        typeof(int),
                                                                        typeof(FrameworkElement),
                                                                        new PropertyMetadata(5));

        public static void SetUserAccessLevel(UIElement element, int value)
        {
            element.SetValue(UserAccessLevelProperty, value);
        }

        public static int GetUserAcccessLevel(UIElement element)
        {
            return (int)element.GetValue(UserAccessLevelProperty);
        }
    }
}
