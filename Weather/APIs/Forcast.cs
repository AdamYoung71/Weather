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

namespace Forcast
{
    class Forcast
    {
        public async static Task<Root> getForcast(string city)
        {
            string cORf = Weather.Pages.Parameters.isCelcius == true ? "c" : "f";

            var location_cd = city;
            var http = new HttpClient();
            //var response = await http.GetAsync("https://api.seniverse.com/v3/weather/hourly3h.json?key=SrcvbANXIm08Wx519&location=beijing&unit=f");
            var response = await http.GetAsync("https://api.seniverse.com/v3/weather/hourly3h.json?key=SrcvbANXIm08Wx519&location=" + location_cd +"&unit="+cORf);
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
        /// 北京,北京
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

    public class Data
    {
        /// <summary>
        /// 2019-04-15T08:00:00+08:00
        /// </summary>
        public string time { get; set; }
        /// <summary>
        /// 0
        /// </summary>
        public string code { get; set; }
        /// <summary>
        /// 15.3
        /// </summary>
        public string temperature { get; set; }
        /// <summary>
        /// 15.4
        /// </summary>
        public string max { get; set; }
        /// <summary>
        /// 9.8
        /// </summary>
        public string min { get; set; }
        /// <summary>
        /// 17
        /// </summary>
        public string humidity { get; set; }
        /// <summary>
        /// 0.00
        /// </summary>
        public string precip { get; set; }
        /// <summary>
        /// 3.96
        /// </summary>
        public string wind_speed { get; set; }
        /// <summary>
        /// 1
        /// </summary>
        public string wind_scale { get; set; }
        /// <summary>
        /// 180
        /// </summary>
        public string wind_direction_degree { get; set; }
        /// <summary>
        /// 南
        /// </summary>
        public string wind_direction { get; set; }
        /// <summary>
        /// 0.2
        /// </summary>
        public string clouds { get; set; }
        /// <summary>
        /// 13.33
        /// </summary>
        public string feels_like { get; set; }
        /// <summary>
        /// 晴
        /// </summary>
        public string text { get; set; }
    }

    public class Results
    {
        /// <summary>
        /// Location
        /// </summary>
        public Location location { get; set; }
        /// <summary>
        /// Data
        /// </summary>
        public List<Data> data { get; set; }
        /// <summary>
        /// 2019-04-15T11:35:27+08:00
        /// </summary>
        public string last_update { get; set; }
    }

    public class Root
    {
        /// <summary>
        /// Results
        /// </summary>
        public List<Results> results { get; set; }
    }

}
