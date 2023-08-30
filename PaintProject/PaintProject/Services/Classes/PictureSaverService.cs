using PaintProject.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows;
using System.Net;
using Server.FTP;
using System.Windows.Shapes;
using Path = System.IO.Path;

namespace PaintProject.Services.Classes
{
    public class PictureSaverService : IPictureSaverService
    {

        public void SaveInkCanvasToImage(InkCanvas inkCanvas, string filePath)
        {
            double inkCanvasWidth = inkCanvas.ActualWidth;
            double inkCanvasHeight = inkCanvas.ActualHeight;

            RenderTargetBitmap rtb = new RenderTargetBitmap((int)inkCanvasWidth, (int)inkCanvasHeight, 96, 96, PixelFormats.Pbgra32);
            rtb.Render(inkCanvas);

            BitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(rtb));

            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                encoder.Save(fs);
            }

            MessageBox.Show("The picture is successfully saved", "SUCCESS", MessageBoxButton.OK, MessageBoxImage.Information);
        }


        public void SaveInkCanvasToLocal(InkCanvas inkCanvas, string localFilePath)
        {
            double inkCanvasWidth = inkCanvas.ActualWidth;
            double inkCanvasHeight = inkCanvas.ActualHeight;

            RenderTargetBitmap rtb = new RenderTargetBitmap((int)inkCanvasWidth, (int)inkCanvasHeight, 96, 96, PixelFormats.Pbgra32);
            rtb.Render(inkCanvas);

            BitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(rtb));

            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);

                SaveImageToLocal(ms, localFilePath);
            }

            MessageBox.Show("The picture is successfully saved locally", "SUCCESS", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void SaveInkCanvasToFTPServer(InkCanvas inkCanvas, string ftpFilePath, string projectName)
        {
            double inkCanvasWidth = inkCanvas.ActualWidth;
            double inkCanvasHeight = inkCanvas.ActualHeight;

            RenderTargetBitmap rtb = new RenderTargetBitmap((int)inkCanvasWidth, (int)inkCanvasHeight, 96, 96, PixelFormats.Pbgra32);
            rtb.Render(inkCanvas);

            BitmapEncoder encoder = new PngBitmapEncoder();

            encoder.Frames.Add(BitmapFrame.Create(rtb));

            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);

                string localFilePath = Path.Combine(Path.GetTempPath(), projectName + ".png");
                SaveImageToLocal(ms, localFilePath);

                FTP_Server.UploadImageToFtp(localFilePath, ftpFilePath);
            }

            MessageBox.Show("The picture is successfully saved on FTP server", "SUCCESS", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void SaveImageToLocal(Stream imageStream, string localFilePath)
        {
            using (FileStream fs = new FileStream(localFilePath, FileMode.Create))
            {
                imageStream.Seek(0, SeekOrigin.Begin);
                imageStream.CopyTo(fs);
            }
        }
    }
}
