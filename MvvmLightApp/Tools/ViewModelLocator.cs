using Autofac;
using GalaSoft.MvvmLight;
using MvvmLightApp.Navigation;
using MvvmLightApp.Services;
using MvvmLightApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmLightApp.Tools
{
    class ViewModelLocator
    {
        private AppViewModel appViewModel;
        private ToDoListViewModel toDoListViewModel;
        private AddTaskViewModel addTaskViewModel;

        private INavigationService navigationService;

        public ViewModelBase MainViewModel { get; set; }

        public ViewModelLocator()
        {
            navigationService = new NavigationService();

            var builder = new ContainerBuilder();
            builder.RegisterType<AppViewModel>();
            builder.RegisterType<ToDoListViewModel>();
            builder.RegisterType<AddTaskViewModel>();
            builder.RegisterType<JsonSaveLoadService>().As<ISaveLoadService>().InstancePerLifetimeScope();
            builder.RegisterInstance(navigationService).As<INavigationService>();
            var container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                appViewModel = scope.Resolve<AppViewModel>();
                toDoListViewModel = scope.Resolve<ToDoListViewModel>();
                addTaskViewModel = scope.Resolve<AddTaskViewModel>() ;
            };

            MainViewModel = appViewModel;

            navigationService.AddPage(toDoListViewModel, VM.ToDoList);
            navigationService.AddPage(addTaskViewModel, VM.AddTask);

            navigationService.NavigateTo(VM.ToDoList);
        }
    }
}
