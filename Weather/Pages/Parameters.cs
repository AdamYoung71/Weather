using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Windows.Storage;

namespace Weather.Pages
{
    public class Parameters
    {
        public static string cityName = "成都";
        public static List<Boolean> signal = new List<bool>();
        public static void getCity(string s)
        {
            cityName = s;
        }

        public static string setCity()
        {
            return cityName;
        }

       
        public static List<string>  collections = new List<string>();

        public static string Serialize(object obj)
        {
            using (var sw = new StringWriter())
            {
                var serializer = new XmlSerializer(obj.GetType());
                serializer.Serialize(sw, obj);
                return sw.ToString();
            }
        }

        public static T Deserialize<T>(string xml)
        {
            using (var sw = new StringReader(xml))
            {
                var serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(sw);
            }
        }

       
    }
    
    
    
}
