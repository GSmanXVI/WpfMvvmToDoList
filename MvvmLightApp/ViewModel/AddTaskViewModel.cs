using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MvvmLightApp.Messages;
using MvvmLightApp.Navigation;
using System;

namespace MvvmLightApp.ViewModel
{
    class AddTaskViewModel : ViewModelBase
    {
        public INavigationService Navigation { get; }

        public AddTaskViewModel(INavigationService navigation)
        {
            Navigation = navigation;
        }

        private string input;
        public string Input
        {
            get { return input; }
            set { Set(ref input, value); }
        }

        private RelayCommand<VM> navigationCommand;
        public RelayCommand<VM> NavigationCommand
        {
            get
            {
                return navigationCommand ?? (navigationCommand = new RelayCommand<VM>(
                    param =>
                    {
                        Navigation.NavigateTo(param, new ContactDetailsMessage { Message = Input });
                        Input = "";
                    },
                    param => !String.IsNullOrWhiteSpace(Input)
                ));
            }
        }
    }
}
