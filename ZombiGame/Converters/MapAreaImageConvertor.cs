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
    public class MapAreaImageConvertor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (parameter.ToString() == "Type")
            {
                AreaType type = (AreaType)value;
                if (type == AreaType.Grass)
                {
                    return "Images/Grass.png";
                }
                else if (type == AreaType.Water)
                {
                    return "Images/Water.jpg";
                }
                else if (type == AreaType.Hill)
                {
                    return "Images/Hill.jpg";
                }
                else
                {
                    return "Images/Swamp.png";
                }
            } else if (parameter.ToString() == "Y")
            {
                int y = (int)value;                
                return SystemParameters.WorkArea.Height / 10 * y;
            } else if (parameter.ToString() == "X")
            {
                int x = (int)value;
                int mergine = (int)(SystemParameters.WorkArea.Width - SystemParameters.WorkArea.Height) / 2;
                return mergine + SystemParameters.WorkArea.Height / 10 * x;
            }
            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
