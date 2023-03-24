using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using LibClass.Services.Interfaces;
using LibClass.Services.Classes;
using eCommerceUserPanel.View;
using eCommerceUserPanel.ViewModel;
using GalaSoft.MvvmLight.Messaging;
using SimpleInjector;
using eCommerceUserPanel.Services.Interfaces;
using eCommerceUserPanel.Services.Classes;

namespace eCommerceUserPanel
{
    public partial class App : Application
    {
        public static Container Container { get; set; } = new();
        protected override void OnStartup(StartupEventArgs e)
        {
            Register();
            MainStartup();

            base.OnStartup(e);
        }
        private void Register()
        {
            Container.RegisterSingleton<IMessenger, Messenger>();
            Container.RegisterSingleton<INavigationService, NavigationService>();
            Container.RegisterSingleton<IBookManageService, BookManageService>();
            Container.RegisterSingleton<ICategoryManageService, CategoryManageService>();
            Container.RegisterSingleton<IUserManageService, UserManageService>();

            Container.RegisterSingleton<MainViewModel>();
            Container.RegisterSingleton<UserPanelViewModel>();
            Container.RegisterSingleton<FullInfoViewModel>();
            Container.RegisterSingleton<CartInfoViewModel>();
            Container.RegisterSingleton<AuthViewModel>();
            Container.RegisterSingleton<RegisterViewModel>();
            Container.RegisterSingleton<AccountViewModel>();
        }

        private void MainStartup()
        {
            var mainView = new MainView();
            mainView.DataContext = Container?.GetInstance<MainViewModel>();
            mainView.ShowDialog();
        }
    }
}
