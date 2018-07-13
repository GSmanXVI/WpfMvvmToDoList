using MvvmLightApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmLightApp.Services
{
    interface ISaveLoadService
    {
        string Extension { get; set; }
        void Save(string filename, IEnumerable<ToDo> list);
        IEnumerable<ToDo> Load(string filename);
    }
}
