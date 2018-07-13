using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using MvvmLightApp.Model;

namespace MvvmLightApp.Services
{
    class XmlSaveLoadService : ISaveLoadService
    {
        public string Extension { get; set; } = "xml";

        public IEnumerable<ToDo> Load(string filename)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ToDo[]));
            using (var fileStream = new FileStream(filename, FileMode.Open))
            {
                return xmlSerializer.Deserialize(fileStream) as ToDo[];
            }
        }

        public void Save(string filename, IEnumerable<ToDo> list)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ToDo[]));
            using (var fileStream = new FileStream(filename, FileMode.Create))
            {
                xmlSerializer.Serialize(fileStream, list.ToArray());
            }
        }
    }
}
