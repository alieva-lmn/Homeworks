using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Net.Sockets;
using MVVM.Messages;

namespace MVVM.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                Set(ref _currentViewModel, value);
            }
        }

        private readonly IMessenger _messenger;
        public void ReceiveMessage(NavigationMessage message)
        {
            CurrentViewModel = App.Container.GetInstance(message.ViewModelType) as ViewModelBase;
        }
        public MainViewModel(IMessenger messenger)
        {
            CurrentViewModel = App.Container.GetInstance<Button1ViewModel>();

            _messenger = messenger;

            _messenger.Register<NavigationMessage>(this, ReceiveMessage);
        }

        public RelayCommand Button1Command
        {
            get => new(() =>
            {
                CurrentViewModel = App.Container.GetInstance<Button1ViewModel>();
            });
        }

        public RelayCommand Button2Command
        {
            get => new(() =>
            {
                CurrentViewModel = App.Container.GetInstance<Button2ViewModel>();
            });
        }

        public RelayCommand Button3Command
        {
            get => new(() =>
            {
                CurrentViewModel = App.Container.GetInstance<Button3ViewModel>();
            });
        }
    }
}
