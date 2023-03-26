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
using eCommerceAdminPanel.View;
using eCommerceAdminPanel.ViewModel;
using GalaSoft.MvvmLight.Messaging;
using SimpleInjector;



namespace eCommerceAdminPanel
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

            Container.RegisterSingleton<MainViewModel>();
            Container.RegisterSingleton<AdminPanelViewModel>();
            Container.RegisterSingleton<AddViewModel>();
            Container.RegisterSingleton<EditViewModel>();
            Container.RegisterSingleton<CatViewModel>();
        }

        private void MainStartup()
        {
            var mainView = new MainView();
            mainView.DataContext = Container?.GetInstance<MainViewModel>();
            mainView.ShowDialog();
        }
    }
}
