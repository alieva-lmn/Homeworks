using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using PaintProject.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintProject.ViewModel
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
            CurrentViewModel = App.Container.GetInstance<LoginViewModel>();

            _messenger = messenger;

            _messenger.Register<NavigationMessage>(this, ReceiveMessage);
        }
    }
}
