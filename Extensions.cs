using System.IO;
using System.Windows.Media.Imaging;

namespace SVN.Wpf
{
    public static class Extensions
    {
        public static BitmapImage ToBitmapImage(this byte[] param)
        {
            if (param is null || param.Length == default(long))
            {
                return null;
            }

            using (var stream = new MemoryStream(param))
            {
                var image = new BitmapImage();
                image.BeginInit();

                image.CacheOption = BitmapCacheOption.OnLoad;
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.UriSource = null;
                image.StreamSource = stream;

                image.EndInit();
                image.Freeze();

                return image;
            }
        }
    }
}