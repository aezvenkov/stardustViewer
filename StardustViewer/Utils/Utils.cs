using SkiaSharp;

namespace StardustViewer.Utils;
public class Utils
{
    public static SKBitmap CreateImageFromByteArray(byte[] byteArray)
    {
        var stream = new SKMemoryStream(byteArray);
        return SKBitmap.Decode(stream);
    }
}
