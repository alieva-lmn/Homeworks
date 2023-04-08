using MVVM.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MVVM.ViewModel
{
    public class Button2ViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        public Button2ViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
