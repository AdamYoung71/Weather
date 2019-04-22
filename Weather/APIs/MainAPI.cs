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
    class MainAPI
    {
        public async static Task<Root> getWeather(string city)//主函数，序列化API
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

        
    }





    /*API内容*/
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

    public class Now
    {
        /// <summary>
        /// 晴
        /// </summary>
        public string text { get; set; }
        /// <summary>
        /// 0
        /// </summary>
        public string code { get; set; }
        /// <summary>
        /// 15
        /// </summary>
        public string temperature { get; set; }
        /// <summary>
        /// 14
        /// </summary>
        public string feels_like { get; set; }
        /// <summary>
        /// 1009
        /// </summary>
        public string pressure { get; set; }
        /// <summary>
        /// 62
        /// </summary>
        public string humidity { get; set; }
        /// <summary>
        /// 3.3
        /// </summary>
        public string visibility { get; set; }
        /// <summary>
        /// 东北
        /// </summary>
        public string wind_direction { get; set; }
        /// <summary>
        /// 42
        /// </summary>
        public string wind_direction_degree { get; set; }
        /// <summary>
        /// 6.48
        /// </summary>
        public string wind_speed { get; set; }
        /// <summary>
        /// 2
        /// </summary>
        public string wind_scale { get; set; }
        /// <summary>
        /// 0
        /// </summary>
        public string clouds { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string dew_point { get; set; }
    }

    public class Results
    {
        /// <summary>
        /// Location
        /// </summary>
        public Location location { get; set; }
        /// <summary>
        /// Now
        /// </summary>
        public Now now { get; set; }
        /// <summary>
        /// 2019-04-22T09:05:00+08:00
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
