using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Win32;
using MvvmLightApp.Messages;
using MvvmLightApp.Model;
using MvvmLightApp.Navigation;
using MvvmLightApp.Services;
using System.Collections.ObjectModel;

namespace MvvmLightApp.ViewModel
{
    class ToDoListViewModel : ViewModelBase
    {
        public INavigationService Navigation { get; }
        public ISaveLoadService SaveLoadService { get; }

        private string message;
        public string Message
        {
            get { return message; }
            set { Set(ref message, value); }
        }

        private ObservableCollection<ToDo> list = new ObservableCollection<ToDo>();
        public ObservableCollection<ToDo> List
        {
            get { return list; }
            set { Set(ref list, value); }
        }

        public ToDoListViewModel(INavigationService navigation, ISaveLoadService saveLoa)
        {
            Navigation = navigation;
            SaveLoadService = saveLoa;

            Messenger.Default.Register<ContactDetailsMessage>(this,
                param =>
                {
                    List.Add(new ToDo { Title = param.Message, Done = false });
                });
        }

        private RelayCommand<VM> navigationCommand;
        public RelayCommand<VM> NavigationCommand
        {
            get
            {
                return navigationCommand ?? (navigationCommand = new RelayCommand<VM>(
                    param => Navigation.NavigateTo(param)
                ));
            }
        }

        private RelayCommand saveCommand;
        public RelayCommand SaveCommand
        {
            get
            {
                return saveCommand ?? (saveCommand = new RelayCommand(
                    () => 
                    {
                        var saveFileDialog = new SaveFileDialog();
                        saveFileDialog.Filter = $"Files (*.{SaveLoadService.Extension})|*.{SaveLoadService.Extension}";
                        saveFileDialog.DefaultExt = $"{SaveLoadService.Extension}";
                        saveFileDialog.AddExtension = true;
                        saveFileDialog.ShowDialog();
                        SaveLoadService.Save(saveFileDialog.FileName, List);
                    },
                    () => List.Count != 0
                ));
            }
        }

        private RelayCommand loadCommand;
        public RelayCommand LoadCommand
        {
            get
            {
                return loadCommand ?? (loadCommand = new RelayCommand(
                    () =>
                    {
                        var openFileDialog = new OpenFileDialog();
                        openFileDialog.Filter = $"Files (*.{SaveLoadService.Extension})|*.{SaveLoadService.Extension}";
                        openFileDialog.ShowDialog();
                        List = new ObservableCollection<ToDo>(SaveLoadService.Load(openFileDialog.FileName));
                    }
                ));
            }
        }

        private RelayCommand<ToDo> editToDoCommand;
        public RelayCommand<ToDo> EditToDoCommand
        {
            get
            {
                return editToDoCommand ?? (editToDoCommand = new RelayCommand<ToDo>(
                    param => param.Done = !param.Done
                ));
            }
        }

        private RelayCommand<ToDo> deleteToDoCommand;
        public RelayCommand<ToDo> DeleteToDoCommand
        {
            get
            {
                return deleteToDoCommand ?? (deleteToDoCommand = new RelayCommand<ToDo>(
                    param => List.Remove(param)
                ));
            }
        }
    }
}
