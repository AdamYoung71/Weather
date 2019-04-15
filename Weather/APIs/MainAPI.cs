using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.IO;
using Windows.UI.Xaml.Controls;

/***********主要API，获取基本天气信息*************/


namespace MainAPI
{
    /*class MainAPI
    {
        public async static Task<Root> GetWrather(string city)//主函数，序列化API
        {
            var location_cd = city;
            var http = new HttpClient();
            //var response = await http.GetAsync("https://api.seniverse.com/v3/weather/now.json?key=9b7few3mmyrhzfp1&location=chengdu&language=zh-Hans&unit=c");
            var response = await http.GetAsync("https://api.seniverse.com/v3/weather/now.json?key=SrcvbANXIm08Wx519&location=" + location_cd + "&language=zh-Hans&unit=c");
            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(Root));

            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (Root)serializer.ReadObject(ms);

            return data;
        }

        internal static Task GetWrather(AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            throw new NotImplementedException();
        }
    }





    /*API内容
    [DataContract]
    public class Location
    {

        [DataMember]
        public string id { get; set; }

        [DataMember]
        public string name { get; set; }

        public string country { get; set; }
        [DataMember]

        public string path { get; set; }
        [DataMember]

        public string timezone { get; set; }
        [DataMember]

        public string timezone_offset { get; set; }

    }
    [DataContract]
    public class Now
    {
        [DataMember]

        public string text { get; set; }
        [DataMember]

        public string code { get; set; }
        [DataMember]

        public string temperature { get; set; }

    }
    [DataContract]
    public class Results
    {
        [DataMember]

        public Location location { get; set; }
        [DataMember]

        public Now now { get; set; }
        [DataMember]

        public string last_update { get; set; }
    }
    [DataContract]
    public class Root
    {
        [DataMember]

        public List<Results> results { get; set; }
    }*/
}
