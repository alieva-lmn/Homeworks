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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Win32;
using System.Windows.Media.Imaging;
using System;

namespace eCommerceAdminPanel.ViewModel
{
    public class AddViewModel : ViewModelBase
    {
        public Book? MyBook { get; set; } = new();

        private readonly INavigationService _navigationService;
        private readonly IBookManageService _bookService;
        public AddViewModel(INavigationService navigationService, IBookManageService bookService)
        {
            _navigationService = navigationService;
            _bookService = bookService;
        }
        public RelayCommand BrowseCommand
        {
            get => new(
                () =>
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.Filter = "Image Files|(*.bmp;*.jpeg;*.jpg;*.png)";
                    openFileDialog.FilterIndex = 1;

                    if (openFileDialog.ShowDialog() == true)
                    {
                        MyBook.ImagePath = openFileDialog.FileName;
                    }
                });
        }
        public RelayCommand BackCommand
        {
            get => new(
                () =>
                {
                    _navigationService.NavigateTo<AdminPanelViewModel>();
                });
        }
        public RelayCommand OkCommand
        {
            get => new(
                () =>
                {
                    if (MyBook != null)
                    {
                        _bookService.Add(MyBook);
                        MyBook = null;
                        MessageBox.Show("Item successfully added to list", "FYI", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Something went wrong...", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                });
        }
    }
}
