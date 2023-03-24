using eCommerceUserPanel.Services.Interfaces;
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
using System.Windows.Controls;
using System.Windows;

namespace eCommerceUserPanel.ViewModel
{
    public class AuthViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IUserManageService _userManageService;
        public static string Username { get; set; }

        public static bool isLoggedIn;

        public AuthViewModel(INavigationService navigationService, IUserManageService userManageService)
        {
            _navigationService = navigationService;
            _userManageService = userManageService;
        }
        public RelayCommand BackCommand
        {
            get => new(
                () =>
                {
                    _navigationService.NavigateTo<UserPanelViewModel>();
                });
        }

        public RelayCommand RegisterCommand
        {
            get => new(
                () =>
                {
                    _navigationService.NavigateTo<RegisterViewModel>();
                });
        }

        public RelayCommand<object> LoginCommand
        {
            get => new(
                param =>
                {
                    try
                    {
                        var password = param as PasswordBox;

                        var user = _userManageService.GetUser(Username, password.Password);
                        var res = $"{user.Email} logged in";

                        MessageBox.Show(res, "FYI", MessageBoxButton.OK, MessageBoxImage.Information);
                        isLoggedIn = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("User doesn't exist");
                    }
                });
        }
    }
}
