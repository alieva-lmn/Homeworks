using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using MVVM.Interfaces;
using MVVM.Classes;
using MVVM.View;
using MVVM.ViewModel;
using GalaSoft.MvvmLight.Messaging;
using SimpleInjector;


namespace MVVM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
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

            Container.RegisterSingleton<MainViewModel>();
            Container.RegisterSingleton<Button1ViewModel>();
            Container.RegisterSingleton<Button2ViewModel>();
            Container.RegisterSingleton<Button3ViewModel>();
        }

        private void MainStartup()
        {
            var mainView = new MainView();
            mainView.DataContext = Container?.GetInstance<MainViewModel>();
            mainView.ShowDialog();
        }
    }
}
