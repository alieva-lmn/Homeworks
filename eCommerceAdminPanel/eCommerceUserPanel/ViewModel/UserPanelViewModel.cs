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

namespace eCommerceUserPanel.ViewModel
{
    public class UserPanelViewModel : ViewModelBase
    {
        public string? Searchbar { get; set; }
        public List<Book> books { get; set; } = new();
        public List<string> cats { get; set; } = new();

        public ObservableCollection<string> Cats { get; set; } = new();
        public ObservableCollection<Book> Books { get; set; } = new();
        public ObservableCollection<Book> Cart { get; set; } = new();

        private readonly INavigationService _navigationService;
        private readonly ICategoryManageService _catsService;
        private readonly IBookManageService _bookService;
        public UserPanelViewModel(INavigationService navigationService, IBookManageService bookService, ICategoryManageService catsService)
        {
            _navigationService = navigationService;
            _bookService = bookService;
            _catsService = catsService;

            books = _bookService.DownloadData();
            cats = _catsService.SetCategory();

            foreach (var item in books)
            {
                Books.Add(item);
            }
            foreach (var item in cats)
            {
                Cats.Add(item);
            }
        }

        public RelayCommand<object> CategoryTitleCommand
        {
            get => new(genre =>
            {
                try
                {
                    if (genre != null)
                    {
                        Books.Clear();
                        foreach (var item in books)
                        {
                            if (item.Genre == genre.ToString())
                            {
                                Books.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });
        }

        public RelayCommand<object> InfoCommand
        {
            get => new(id =>
            {
                try
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });
        }

        public RelayCommand<object> AddToCartCommand
        {
            get => new(id =>
            {
                try
                {
                    if (id != null)
                    {
                        foreach (var item in Books)
                        {
                            if (item.Id.ToString() == id.ToString())
                            {
                                if (CartInfoViewModel.MyCart.Contains(item))
                                {
                                    MessageBox.Show("Item is already in your cart", "WARNING",MessageBoxButton.OK,MessageBoxImage.Warning);
                                }
                                else
                                {
                                    CartInfoViewModel.MyCart.Add(item);
                                    MessageBox.Show("Item successfully added to your cart", "FYI", MessageBoxButton.OK, MessageBoxImage.Information);
                                }
                                break;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });
        }
        public RelayCommand SearchCommand
        {
            get => new(() =>
            {
                Books.Clear();

                foreach (var item in books)
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
                _navigationService.NavigateTo<CartInfoViewModel>();
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
        public RelayCommand RefreshCommand // REFRESH CATS
        {
            get => new(() =>
            {
                Books.Clear();

                foreach (var item in books)
                {
                    Books.Add(item);
                }
            });
        }
    }
}
