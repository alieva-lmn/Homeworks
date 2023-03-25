using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using LibClass.Messages;
using LibClass.Model;
using LibClass.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace eCommerceUserPanel.ViewModel
{
    public class FullInfoViewModel : ViewModelBase
    {
        private readonly IMessenger _messenger;
        private readonly INavigationService _navigationService;
        private readonly IBookManageService _bookService;
        public Book Info { get; set; } = new();

        public FullInfoViewModel(IMessenger messenger, INavigationService navigationService, IBookManageService bookService)
        {
            _messenger = messenger;
            _bookService = bookService;
            _navigationService = navigationService;

            _messenger.Register<DataMessage>(this, message =>
            {
                Info = message.Data as Book;
            });
        }
        public RelayCommand BuyCommand
        {
            get => new(
                () =>
                {
                    if (AuthViewModel.isLoggedIn == true)
                    {
                        var res = $"Thank you for your purchase, {AuthViewModel.Username}";
                        MessageBox.Show(res, "FYI", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        _navigationService.NavigateTo<AuthViewModel>();
                    }
                });
        }
    }
}
