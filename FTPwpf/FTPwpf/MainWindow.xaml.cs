using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;
using static System.Net.WebRequestMethods;

namespace FTPwpf    
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<string> FilesList { get; set; } = new();
        //private string IpPath = "ftp://192.168.1.8";
        private string IpPath = "ftp://10.1.10.180";

        public MainWindow()
        {
            InitializeComponent();
            FileListView.ItemsSource = FilesList;
        }

        private void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            ListDirectoryFromFtpServer();
        }

        private void ListDirectoryFromFtpServer()
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(IpPath);
            request.Method = WebRequestMethods.Ftp.ListDirectory;

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());

            string listing = reader.ReadToEnd();

            response.Close();

            FilesList.Clear();

            string[] files = listing.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            
            foreach (string file in files)
            {
                FilesList.Add(file);
            }
        }

        private void DownloadButton_Click(object sender, RoutedEventArgs e)
        {
            if (FileListView.SelectedItem != null)
            {
                string selectedFile = FileListView.SelectedItem.ToString();
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    FileName = selectedFile
                };

                if (saveFileDialog.ShowDialog() == true)
                {
                    DownloadFile(selectedFile, saveFileDialog.FileName);
                }
            }
            else
            {
                MessageBox.Show("Please select a file to download.");
            }
        }

        private void DownloadFile(string remoteFilePath, string localFilePath)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create($"{IpPath}/{remoteFilePath}");
            request.Method = WebRequestMethods.Ftp.DownloadFile;

            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            {
                using (Stream responseStream = response.GetResponseStream())
                {
                    using (FileStream fileStream = new FileStream(localFilePath, FileMode.Create))
                    {
                        responseStream.CopyTo(fileStream);
                    }
                }
            }

            MessageBox.Show("File downloaded successfully!");
        }
    }
}
