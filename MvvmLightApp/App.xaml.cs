using MvvmLightApp.Navigation;
using MvvmLightApp.Tools;
using MvvmLightApp.View;
using MvvmLightApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MvvmLightApp
{
    public partial class App : Application
    {

        private ViewModelLocator viewModelLocator = new ViewModelLocator();

        public App()
        {
            try
            {
                var appView = new AppView();
                appView.DataContext = viewModelLocator.MainViewModel;
                appView.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
