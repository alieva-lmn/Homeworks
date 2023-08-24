using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PaintProject.Services.Interfaces
{
    public interface IPictureSaverService
    {
        public void SaveInkCanvasToImage(InkCanvas inkCanvas, string filePath);
        public void SaveInkCanvasToLocal(InkCanvas inkCanvas, string localFilePath);
        public void SaveInkCanvasToFTPServer(InkCanvas inkCanvas, string ftpFilePath, string projectName);
    }
}
