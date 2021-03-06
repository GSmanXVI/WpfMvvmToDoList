﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MvvmLightApp.ViewModel
{
    class AppViewModel : ViewModelBase
    {
        private ViewModelBase currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get { return currentViewModel; }
            set { Set(ref currentViewModel, value); }
        }

        public AppViewModel()
        {
            Messenger.Default.Register<ViewModelBase>(this,
                param =>
                {
                    CurrentViewModel = param;
                });
        }
    }
}
