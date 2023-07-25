using System.Globalization;
using System.IO;
using System.Drawing;

namespace StardustViewer.Utils;

public class ByteArrayToImageConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        byte[] byteArray;
        try
        {
            if (value is string)
            {
                byteArray = System.Convert.FromBase64String(value.ToString());
                return ImageSource.FromStream(() => new MemoryStream(byteArray));
            }
            else
            {
                return null;
            }
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}