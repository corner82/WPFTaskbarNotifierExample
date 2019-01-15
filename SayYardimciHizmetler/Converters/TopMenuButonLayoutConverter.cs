using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SayYardimciHizmetler.Converters
{
    public class TopMenuButonLayoutConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                /*var valueTest = "string test";
                int? val = System.Convert.ToInt16(valueTest);*/
                int? val = System.Convert.ToInt16(value);
                if (val.HasValue)
                {
                    return val = val + 1;
                } else
                {
                    return 0;
                }

            } catch(FormatException ex)
            {
                
                return 0;
            }
            catch(OverflowException ex)
            {
                return 0;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
