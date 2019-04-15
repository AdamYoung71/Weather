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

namespace ProCurrentWeather//当前天气情况高级版（使用经纬度获取。精度1km）
{
    class ProCurrentWeather
    {
        public async static Task<Root> GetProCurrentWeather(double lat, double lon)
        {
            string latitude = Convert.ToString(lat);
            string longitude = Convert.ToString(lon);
            var http = new HttpClient();
            //var response = await http.GetAsync("https://api.seniverse.com/v3/pro/weather/grid/now.json?key=9b7few3mmyrhzfp1&location=39.865927:116.359805");
            var response = await http.GetAsync("https://api.seniverse.com/v3/pro/weather/grid/now.json?key=SrcvbANXIm08Wx519&location=" + latitude + ":" + longitude);
            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(Root));

            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (Root)serializer.ReadObject(ms);

            return data;
        }

        internal static Task GetProCurrentWeather(AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            throw new NotImplementedException();
        }
    }




    public class Location
    {
        /// <summary>
        /// 116.359805
        /// </summary>
        public string longitude { get; set; }
        /// <summary>
        /// 39.865927
        /// </summary>
        public string latitude { get; set; }
    }

    public class Now_grid
    {
        /// <summary>
        /// 8.42
        /// </summary>
        public string temperature { get; set; }
        /// <summary>
        /// 21.02
        /// </summary>
        public string humidity { get; set; }
        /// <summary>
        /// 3.37
        /// </summary>
        public string wind_speed { get; set; }
        /// <summary>
        /// 1
        /// </summary>
        public string wind_scale { get; set; }
        /// <summary>
        /// 155.15
        /// </summary>
        public string wind_direction_degree { get; set; }
        /// <summary>
        /// 东南
        /// </summary>
        public string wind_direction { get; set; }
        /// <summary>
        /// 0.00
        /// </summary>
        public string precip { get; set; }
        /// <summary>
        /// 1018.13
        /// </summary>
        public string pressure { get; set; }
        /// <summary>
        /// 0.00
        /// </summary>
        public string solar_radiation { get; set; }
    }

    public class Results
    {
        /// <summary>
        /// Location
        /// </summary>
        public Location location { get; set; }
        /// <summary>
        /// Now_grid
        /// </summary>
        public Now_grid now_grid { get; set; }
        /// <summary>
        /// 2019-03-23T21:00:00+08:00
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
/*
namespace MainAPI
{
    class MainAPI
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
    }
}



namespace ProForecast//高级天气预报API（以经纬度为参数，精度1km，最多获得10天的天气预报）
{
    class ProForecast
    {
        public async static Task<Root> GetProForecast(double lat, double lon)
        {
            //类型转换（接口需要字符串）
            string latitude = Convert.ToString(lat);
            string longitude = Convert.ToString(lon);
            string language = "zh-Hans";
            var http = new HttpClient();
            //var response = await http.GetAsync("https://api.seniverse.com/v3/pro/weather/grid/hourly3h.json?key=9b7few3mmyrhzfp1&location=39.865927:116.359805");
            var response = await http.GetAsync("https://api.seniverse.com/v3/pro/weather/grid/hourly3h.json?key=SrcvbANXIm08Wx519&location=" + latitude + ":" + longitude + "&language=" + language);
            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(Root));

            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (Root)serializer.ReadObject(ms);

            return data;
        }

        internal static Task GetProForecast(AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            throw new NotImplementedException();
        }
    }

    public class Location
    {
        /// <summary>
        /// 116.359805
        /// </summary>
        public string longitude { get; set; }
        /// <summary>
        /// 39.865927
        /// </summary>
        public string latitude { get; set; }
    }

    public class Data
    {
        /// <summary>
        /// 2019-03-24T20:00:00+08:00
        /// </summary>
        public string time { get; set; }
        /// <summary>
        /// 9.60
        /// </summary>
        public string temperature { get; set; }
        /// <summary>
        /// 35.33
        /// </summary>
        public string humidity { get; set; }
        /// <summary>
        /// 0.00
        /// </summary>
        public string precip { get; set; }
        /// <summary>
        /// 0.00
        /// </summary>
        public string clouds { get; set; }
        /// <summary>
        /// 8.48
        /// </summary>
        public string wind_speed { get; set; }
        /// <summary>
        /// 2
        /// </summary>
        public string wind_scale { get; set; }
        /// <summary>
        /// 288.05
        /// </summary>
        public string wind_direction_degree { get; set; }
        /// <summary>
        /// 西北
        /// </summary>
        public string wind_direction { get; set; }
        /// <summary>
        /// 1
        /// </summary>
        public string code { get; set; }
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
        /// 2019-03-24T18:41:16+08:00
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
*/