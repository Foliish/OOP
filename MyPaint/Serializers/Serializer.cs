using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLib;

namespace MyPaint.Serializes
{
    public class Serializer
    {
        public Serializer() { }
        public void JSONSerialize(string fileName,ICollection<IFigure> objs)
        {
            string json = JsonConvert.SerializeObject(objs, Formatting.Indented, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
            File.WriteAllText(fileName, json);
        }
        public ICollection<IFigure> JSONDeserialize(string fileName)
        {
            string json = File.ReadAllText(fileName);
            return JsonConvert.DeserializeObject<IFigure[]>(json, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
        }
    }
}
