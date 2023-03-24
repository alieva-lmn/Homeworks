using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using System.Windows.Controls;
using LibClass.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LibClass.Services.Interfaces;
using eCommerceAdminPanel.View;
using LibClass.Services.Classes;
using System.DirectoryServices;
using System.Windows.Input;
using static System.Reflection.Metadata.BlobBuilder;
using System.Reflection;
using LibClass.Messages;
using GalaSoft.MvvmLight.Messaging;

namespace eCommerceAdminPanel.ViewModel
{
    public class AdminPanelViewModel : ViewModelBase
    {
        public string? Searchbar { get; set; }

        public List<Book> books { get; set; } = new();
        public List<string> cats { get; set; } = new();

        public ObservableCollection<Book> Books { get; set; } = new();
        public ObservableCollection<string> Cats { get; set; } = new();

        private readonly INavigationService _navigationService;
        private readonly IBookManageService _bookService;
        private readonly ICategoryManageService _catsService;

        public AdminPanelViewModel(INavigationService navigationService, IBookManageService bookService, ICategoryManageService catsService)
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

                try
                {
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }  
            });
        }

        public RelayCommand<object> EditCommand
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
                                _navigationService.NavigateTo<EditViewModel>(item);
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
        public RelayCommand<object> DeleteCommand
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
                                Books.Remove(item);
                                books.Remove(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                _bookService.SendData(books);
            });
        }

        public RelayCommand AddCommand
        {
            get => new(() =>
            {
                _navigationService.NavigateTo<AddViewModel>();
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
    }
}
