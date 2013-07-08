using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using AlmacenSL.Web;

namespace AlmacenSL.Infrastructure
{
    public class BoolToLoginImagePathConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var currentUser = value as UserAuth;
            if (currentUser != null && currentUser.IsAuthenticated)
            {
                return "/AlmacenSL.Infrastructure;component/Assets/Images/UserOn.jpg";
            }
            else
            {
                return "/AlmacenSL.Infrastructure;component/Assets/Images/UserOff.jpg";
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
