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

namespace SunRise
{
    class SunRise
    {
        public async static Task<Root> getSunRise(string city)
        {
            var location_cd = city;
            var http = new HttpClient();
            //var response = await http.GetAsync("https://api.seniverse.com/v3/geo/sun.json?key=SrcvbANXIm08Wx519&location=beijing&language=zh-Hans&start=0&days=7");
            var response = await http.GetAsync("https://api.seniverse.com/v3/geo/sun.json?key=SrcvbANXIm08Wx519&location=" + location_cd + "&language=zh-Hans&start=0&days=3");
            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(Root));

            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (Root)serializer.ReadObject(ms);

            return data;
        }

    }
    public class Location
    {
        /// <summary>
        /// WX4FBXXFKE4F
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 北京
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// CN
        /// </summary>
        public string country { get; set; }
        /// <summary>
        /// 北京,北京,中国
        /// </summary>
        public string path { get; set; }
        /// <summary>
        /// Asia/Shanghai
        /// </summary>
        public string timezone { get; set; }
        /// <summary>
        /// +08:00
        /// </summary>
        public string timezone_offset { get; set; }
    }

    public class Sun
    {
        /// <summary>
        /// 2019-04-15
        /// </summary>
        public DateTime date { get; set; }
        /// <summary>
        /// 05:40
        /// </summary>
        public string sunrise { get; set; }
        /// <summary>
        /// 18:51
        /// </summary>
        public string sunset { get; set; }
    }

    public class Results
    {
        /// <summary>
        /// Location
        /// </summary>
        public Location location { get; set; }
        /// <summary>
        /// Sun
        /// </summary>
        public List<Sun> sun { get; set; }
    }

    public class Root
    {
        /// <summary>
        /// Results
        /// </summary>
        public List<Results> results { get; set; }
    }


}
