using eCommerceUserPanel.Model;
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
using System.Windows.Controls;
using static System.Reflection.Metadata.BlobBuilder;

namespace eCommerceUserPanel.ViewModel
{
    public class CartInfoViewModel : ViewModelBase
    {
        private readonly IMessenger _messenger;
        private readonly INavigationService _navigationService;
        public PriceCounter OverallPrice { get; set; } = new();
        public static ObservableCollection<Cart> MyCart { get; set; } = new();

        public CartInfoViewModel(IMessenger messenger, INavigationService navigationService)
        {
            _messenger = messenger;
            _navigationService = navigationService;

            _messenger.Register<DataMessage>(this, message =>
            {
                if (message.Data.GetType().Name == OverallPrice.OverallPrice.GetType().Name)
                {
                    OverallPrice.OverallPrice = (double)message.Data;
                }
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
                        MyCart.Clear();
                        OverallPrice.OverallPrice = 0;
                    }
                    else
                    {
                        _navigationService.NavigateTo<AuthViewModel>();
                    }
                });
        }
        public RelayCommand<object> MinusCommand
        {
            get => new(id =>
                {
                    if (id != null)
                    {
                        foreach (var item in MyCart)
                        {
                            if (item.SingleBook.Id.ToString() == id.ToString())
                            {
                                if (item.ItemCount > 1)
                                {
                                    OverallPrice.OverallPrice -= item.SingleBook.Price;
                                    OverallPrice.OverallPrice = Math.Round(OverallPrice.OverallPrice, 2);
                                    item.ItemCount--;
                                }
                            }
                        }
                    }
                });
        }

        public RelayCommand<object> PlusCommand
        {
            get => new(id =>
            {
                if (id != null)
                {
                    foreach (var item in MyCart)
                    {
                        if (item.SingleBook.Id.ToString() == id.ToString())
                        {
                            OverallPrice.OverallPrice += item.SingleBook.Price;
                            OverallPrice.OverallPrice = Math.Round(OverallPrice.OverallPrice, 2);
                            item.ItemCount++;
                        }
                    }
                }
            });
        }

        public RelayCommand<object> DeleteCommand //padaet
        {
            get => new(id =>
            {
                if (id != null)
                {
                    foreach (var item in MyCart)
                    {
                        if (item.SingleBook.Id.ToString() == id.ToString())
                        {
                            MyCart.Remove(item);
                            OverallPrice.OverallPrice -= item.SingleBook.Price * item.ItemCount;
                            OverallPrice.OverallPrice = Math.Round(OverallPrice.OverallPrice,2);
                            break;
                        }
                    }
                }
            });
        }
    }
}
