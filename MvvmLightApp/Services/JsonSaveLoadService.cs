using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmLightApp.Model;
using Newtonsoft.Json;

namespace MvvmLightApp.Services
{
    class JsonSaveLoadService : ISaveLoadService
    {
        public string Extension { get; set; } = "json";

        public IEnumerable<ToDo> Load(string filename)
        {
            var json = File.ReadAllText(filename);
            var data = JsonConvert.DeserializeObject<IEnumerable<ToDo>>(json);
            return data;
        }

        public void Save(string filename, IEnumerable<ToDo> list)
        {
            var json = JsonConvert.SerializeObject(list);
            File.WriteAllText(filename, json);
        }
    }
}
