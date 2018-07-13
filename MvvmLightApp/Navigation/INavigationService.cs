using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmLightApp.Navigation
{
    interface INavigationService
    {
        ViewModelBase Current { get; set; }
        void NavigateTo(VM name);
        void NavigateTo<T>(VM name, T data);
        void AddPage(ViewModelBase page, VM name);
        void RemovePage(VM name);
    }
}
