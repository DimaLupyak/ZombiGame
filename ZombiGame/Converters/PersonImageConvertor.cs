using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace ZombiGame.Converters
{
    public class PersonImageConvertor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (parameter.ToString() == "Type")
            {
                Side side = (Side)value;
                if (side == Side.Left)
                {
                    return "Images/Left.jpg";
                }
                else
                {
                    return "Images/Right.jpg";
                }
            }
            else if (parameter.ToString() == "Y")
            {
                int y = (int)value;
                return SystemParameters.WorkArea.Height / 100 * y - SystemParameters.WorkArea.Height / 40;
            }
            else if (parameter.ToString() == "X")
            {
                int x = (int)value;
                int mergine = (int)(SystemParameters.WorkArea.Width - SystemParameters.WorkArea.Height) / 2;
                return mergine + SystemParameters.WorkArea.Height / 100 * x - SystemParameters.WorkArea.Height / 40;
            }
            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
