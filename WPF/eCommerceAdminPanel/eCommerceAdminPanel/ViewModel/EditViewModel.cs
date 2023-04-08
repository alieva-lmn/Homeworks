using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibClass.Model;
using LibClass.Messages;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using System.Windows;
using LibClass.Services.Interfaces;

namespace eCommerceAdminPanel.ViewModel
{
    class EditViewModel : ViewModelBase
    {
        private readonly IMessenger _messenger;
        private readonly INavigationService _navigationService;
        private readonly IBookManageService _bookService;
        public Book Info { get; set; } = new();

        public EditViewModel(IMessenger messenger, INavigationService navigationService, IBookManageService bookService)
        {
            _messenger = messenger;
            _bookService = bookService;
            _navigationService = navigationService;

            _messenger.Register<DataMessage>(this, message =>
            {
                Info = message.Data as Book;
            });
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
                        Info.ImagePath = openFileDialog.FileName;
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
                    if (Info != null)
                    {
                        _bookService.Replace(Info);
                        MessageBox.Show("Changes were successfully saved.", "FYI", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Something went wrong...", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                });
        }
    }
}
