using MimeKit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MailClient
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<EmailMessage> Messages { get; set; } = new();
        private BodyBuilder _builder = new BodyBuilder();
        public MainWindow()
        {
            this.DataContext = this;
            LoadMails();
            InitializeComponent();
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            var receiver = txtTo.Text;
            var subject = txtSubject.Text;
            _builder.TextBody = txtBody.Text;

            MailService.SendEmail(receiver, subject, _builder);
            MessageBox.Show("Your message was sent.", "SUCCESS", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnAttach_Click(object sender, RoutedEventArgs e)
        {
            MailService.AttachFile(_builder);
            MessageBox.Show("Your file was attached.", "SUCCESS", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void LoadMails()
        {
            Messages = MailService.GetAllMail();
        }
    }
}
