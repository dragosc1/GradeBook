using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace GradeBook.Converters
{
    /// <summary>
    /// Date to string converter (converts by culture en-GB / ro-RO)
    /// </summary>
    public class DateToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string cultureLanguage = Properties.Settings.Default.language;
            culture = new CultureInfo(cultureLanguage);
            DateTime dateTime = (DateTime)value;
            if (cultureLanguage == "ro-RO")
                return dateTime.ToString("dd/MM/yyyy", culture);
            else return dateTime.ToString("MM/dd/yyyy", culture);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
