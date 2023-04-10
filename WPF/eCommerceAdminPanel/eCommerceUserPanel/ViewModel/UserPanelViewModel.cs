using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibClass.Model;
using LibClass.Services.Interfaces;
using System.Windows;
using eCommerceUserPanel.Model;

namespace eCommerceUserPanel.ViewModel
{
    public class UserPanelViewModel : ViewModelBase
    {
        public string? Searchbar { get; set; }
        public ObservableCollection<string> Cats { get; set; } = new();
        public ObservableCollection<Book> Books { get; set; } = new();
        private ObservableCollection<Book> _books = new();
        public ObservableCollection<Cart> Cart { get; set; } = new();

        private readonly INavigationService _navigationService;
        private readonly ICategoryManageService _catsService;
        private readonly IBookManageService _bookService;
        public UserPanelViewModel(INavigationService navigationService, IBookManageService bookService, ICategoryManageService catsService)
        {
            _navigationService = navigationService;
            _bookService = bookService;
            _catsService = catsService;

            Books = _bookService.DownloadData();
            _books = _bookService.DownloadData();

            Cats = _catsService.SetCategory();
        }

        public RelayCommand<object> CategoryTitleCommand
        {
            get => new(genre =>
            {
                if (genre != null)
                {
                    Books.Clear();

                    foreach (var item in _books)
                    {
                        if (item.Genre == genre.ToString())
                        {
                            Books.Add(item);
                        }
                    }
                }
            });
        }

        public RelayCommand<object> InfoCommand
        {
            get => new(id =>
            {
                if (id != null)
                {
                    foreach (var item in Books)
                    {
                        if (item.Id.ToString() == id.ToString())
                        {
                            _navigationService.NavigateTo<FullInfoViewModel>(item);
                        }
                    }
                }
            });
        }

        public RelayCommand<object> AddToCartCommand
        {
            get => new(id =>
            {
              if (id != null)
                {
                    foreach (var book in Books)
                    {
                        if (book.Id.ToString() == id.ToString())
                        {
                            Cart cart = new Cart();
                            cart.SingleBook = book;

                            if (!CartInfoViewModel.CheckExists(id.ToString()))
                            {
                                MessageBox.Show("Item is already in your cart", "WARNING", MessageBoxButton.OK, MessageBoxImage.Warning);
                            }
                            else
                            {
                                CartInfoViewModel.MyCart.Add(cart);
                                MessageBox.Show("Item successfully added to your cart", "FYI", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                            break;
                        }
                    }
                }
            });
        }
        public RelayCommand SearchCommand
        {
            get => new(() =>
            {
                Books.Clear();

                foreach (var item in _books)
                {
                    Books.Add(item);
                }

                var tmp_list = new List<Book>();

                if (Searchbar != null)
                {
                    var tmp = char.ToUpper(Searchbar[0]) + Searchbar.Substring(1);

                    foreach (var item in Books)
                    {
                        if (item.Title.Contains(tmp))
                        {
                            tmp_list.Add(item);
                        }
                    }
                    Books.Clear();
                }
                foreach (var item in tmp_list)
                {
                    Books.Add(item);
                }
            });
        }

        public RelayCommand OpenCartCommand
        {
            get => new(() =>
            {
                _navigationService.NavigateTo<CartInfoViewModel>(CartInfoViewModel.MyCart.Sum(x => x.SingleBook.Price));
            });
        }

        public RelayCommand SignCommand
        {
            get => new(() =>
            {
                if (AuthViewModel.isLoggedIn)
                {
                    _navigationService.NavigateTo<AccountViewModel>();
                }
                else
                    _navigationService.NavigateTo<AuthViewModel>();
            });
        }
        public RelayCommand RefreshCommand
        {
            get => new(() =>
            {
                Books.Clear();

                foreach (var item in _books)
                {
                    Books.Add(item);
                }
            });
        }
    }
}
