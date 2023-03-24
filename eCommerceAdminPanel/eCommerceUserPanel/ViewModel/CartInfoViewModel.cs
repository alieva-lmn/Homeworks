using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using LibClass.Messages;
using LibClass.Model;
using LibClass.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace eCommerceUserPanel.ViewModel
{
    public class CartInfoViewModel : ViewModelBase
    {
        private readonly IMessenger _messenger;
        private readonly INavigationService _navigationService;
        private readonly IBookManageService _bookService;

        public PriceCounter OverallPrice { get; set; } = new(0);

        public static ObservableCollection<Book> MyCart { get; set; } = new();
        public CartInfoViewModel(IMessenger messenger, INavigationService navigationService, IBookManageService bookService)
        {
            _messenger = messenger;
            _bookService = bookService;
            _navigationService = navigationService;

            _messenger.Register<DataMessage>(this, message =>
            {
                OverallPrice = message.Data as PriceCounter;
            });
        }
        public RelayCommand BackCommand
        {
            get => new(
                () =>
                {
                    _navigationService.NavigateTo<UserPanelViewModel>();
                });
        }

        public RelayCommand CheckoutCommand
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
