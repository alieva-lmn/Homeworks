﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.VisualBasic.ApplicationServices;
using PaintProject.Messages;
using PaintProject.Model;
using PaintProject.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User = PaintProject.Model.User;

namespace PaintProject.ViewModel
{
    public class GreetingViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IMessenger _messenger;
        public User User { get; set; }

        public GreetingViewModel(INavigationService navigationService, IMessenger messenger)
        {
            _navigationService = navigationService;
            _messenger = messenger;

            _messenger.Register<DataMessage>(this, message =>
            {
                User = message.Data as User;
            });
        }

        public RelayCommand NewProjectCommand
        {
            get => new(() =>
            {
                _navigationService.NavigateTo<DrawingViewModel>(User);
            });
        }
    }
}
