using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using PaintProject.Services.Classes;
using PaintProject.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Windows.Controls;
using System.Windows;
using Microsoft.VisualBasic.ApplicationServices;
using PaintProject.Model;
using User = PaintProject.Model.User;
using PaintProject.ViewModel;

namespace PaintProject.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IUserManageService _userManageService;
        public static string Username { get; set; }
        public static bool isLoggedIn { get; set; } //checkbox 

        public LoginViewModel(INavigationService navigationService, IUserManageService userManageService)
        {
            _navigationService = navigationService;
            _userManageService = userManageService;
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
                if (param != null)
                {
                    try
                    {
                        var password = (PasswordBox)param;

                        if (Username == null)
                        {
                            MessageBox.Show("No information is provided", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                        }

                        var user = _userManageService.GetUserAsync(Username, password.Password);

                        if (user.Result != null)
                        {
                            if (isLoggedIn)
                            {
                                //user.Result.isLoggedIn = true;
                            }
                            _navigationService.NavigateTo<GreetingViewModel>(user.Result);
                        }
                        else
                            MessageBox.Show($"'{Username}' doesn't exist", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("User doesn't exist", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            });
        }

    }
}

