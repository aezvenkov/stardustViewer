using System.Globalization;

namespace StardustViewer.Utils;
public class ValueToColorConverter: IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is bool boolValue)
        {
            return boolValue == false ? Color.FromRgb(255, 0, 0) : Color.FromRgb(0, 255, 0);
        }

        return Color.FromRgb(255, 255, 255);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
