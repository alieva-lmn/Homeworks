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
        public ObservableCollection<Book> Books { get; set; } = new();
        private ObservableCollection<Book> _books = new();
        public ObservableCollection<string?> Cats { get; set; } = new();

        private readonly INavigationService _navigationService;
        private readonly IBookManageService _bookService;
        private readonly ICategoryManageService _catsService;

        public AdminPanelViewModel(INavigationService navigationService, IBookManageService bookService, ICategoryManageService catsService)
        {
            _navigationService = navigationService;
            _bookService = bookService;
            _catsService = catsService;

            Books = _bookService.DownloadData();
            _books = _bookService.DownloadData();

            Cats = _catsService.SetCategory();
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

        public RelayCommand<object> EditCommand
        {
            get => new(id =>
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
            });
        }
        public RelayCommand<object> DeleteCommand
        {
            get => new(id =>
            {
                if (id != null)
                {
                    foreach (var item in Books)
                    {
                        if (item.Id.ToString() == id.ToString())
                        {
                            Books.Remove(item);
                            _books = Books;
                        }
                    }
                }
                _bookService.SendData(Books);
            });
        }

        public RelayCommand AddCommand
        {
            get => new(() =>
            {
                _navigationService.NavigateTo<AddViewModel>();
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
    }
}
