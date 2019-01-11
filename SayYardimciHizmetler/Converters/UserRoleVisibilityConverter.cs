using Core.Common.User;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace SayYardimciHizmetler.Converters
{
    public class UserRoleVisibilityConverter : IMultiValueConverter
    {

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            UserBase user = (UserBase)values[0];
            string controlAccessLevel = (string)(values[1] as FrameworkElement).GetValue(UserAccessLoader.UserAccessLevelProperty);

            // return (userRole <= controlAccessLevel) ? Visibility.Visible : Visibility.Hidden;
            return user.Name == "Mustafa" && controlAccessLevel == "Mustafa" ? Visibility.Visible : Visibility.Hidden;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
