using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace LocadoraDeVeiculos.Infra.ExtensionMethods
{
    public static class ImageExtensions
    {
        public static byte[] ToByteArray(this Image image, ImageFormat format = null)
        {
            format = format is null ? ImageFormat.Bmp : format;

            var stream = new MemoryStream();
            new Bitmap(image).Save(stream, format);
            stream.Position = 0;
            return stream.ToArray();
        }
    }
}
