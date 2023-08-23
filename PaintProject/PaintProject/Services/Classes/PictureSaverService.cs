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

namespace PaintProject.Services.Classes
{
    public class PictureSaverService : IPictureSaverService
    {
        //DB
        public void SaveInkCanvasToImage(InkCanvas inkCanvas, string filePath)
        {
            double inkCanvasWidth = inkCanvas.ActualWidth;
            double inkCanvasHeight = inkCanvas.ActualHeight;

            RenderTargetBitmap rtb = new RenderTargetBitmap((int)inkCanvasWidth, (int)inkCanvasHeight, 96, 96, PixelFormats.Pbgra32);
            rtb.Render(inkCanvas);

            BitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(rtb));

            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                encoder.Save(fs);
            }

            MessageBox.Show("The picture is successfully saved", "SUCCESS", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
