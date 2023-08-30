using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Server.FTP
{
    public class FTP_Server
    {
        private static string IpPath = "ftp://192.168.1.8";

        public static void UploadImageToFtp(string localFilePath, string ftpFilePath)
        {
            using (FileStream fs = new FileStream(localFilePath, FileMode.Open))
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create($"{IpPath}/{ftpFilePath}.png");
                request.Method = WebRequestMethods.Ftp.UploadFile;

                using (Stream ftpStream = request.GetRequestStream())
                {
                    fs.CopyTo(ftpStream);
                }
            }
        }

        public static string CreateLocalDirectory(string localFolderPath)
        {
            string filepath = @$"C:\FTP\{localFolderPath}";

            if (!Directory.Exists(filepath))
            {
                Directory.CreateDirectory(filepath);
            }
            return filepath;
        }

    }
}
