using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace PHD_Kamelott.Converters
{
    class StringForImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var assembly = typeof(App).Assembly;
            var imagesource = value as string;
            var realName = "PHD_Kamelott.Resources.Images." + imagesource;
            if (HasRessource(realName))
            {
                return ImageSource.FromResource("PHD_Kamelott.Resources.Images." + imagesource, assembly);
            }else
            {
                return ImageSource.FromResource("PHD_Kamelott.Resources.Images.profile_generic.png", assembly);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        private bool HasRessource(string value)
        {
            return this.GetType().GetTypeInfo().Assembly.GetManifestResourceNames().Where(x => x == value).Count() > 0;
        }

    }
}
