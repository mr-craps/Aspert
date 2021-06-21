using System;
using System.Globalization;
using System.Linq;
using Xamarin.Forms;

namespace Aspert
{
    public class PriorityMultiValueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
            => values.FirstOrDefault(o => o != null);

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }
}