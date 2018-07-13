using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmLightApp.Model
{
    [Serializable]
    public class ToDo : ObservableObject
    {
        private string title;
        public string Title
        {
            get { return title; }
            set { Set(ref title, value); }
        }

        private bool done;
        public bool Done
        {
            get { return done; }
            set { Set(ref done, value); }
        }

    }
}
