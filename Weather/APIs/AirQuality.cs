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

namespace AirQulity
{
    class AirQuality
    {
        public async static Task<Root> getAir(string city)
        {
            var location_cd = city;
            var http = new HttpClient();
            //var response = await http.GetAsync("https://api.seniverse.com/v3/air/now.json?key=SrcvbANXIm08Wx519&location=beijing&language=zh-Hans&scope=city");
            var response = await http.GetAsync("https://api.seniverse.com/v3/air/now.json?key=SrcvbANXIm08Wx519&location=" + location_cd + "&language=zh-Hans&scope=city");
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

    public class City
    {
        /// <summary>
        /// 80
        /// </summary>
        public string aqi { get; set; }
        /// <summary>
        /// 59
        /// </summary>
        public string pm25 { get; set; }
        /// <summary>
        /// 105
        /// </summary>
        public string pm10 { get; set; }
        /// <summary>
        /// 6
        /// </summary>
        public string so2 { get; set; }
        /// <summary>
        /// 62
        /// </summary>
        public string no2 { get; set; }
        /// <summary>
        /// 0.600
        /// </summary>
        public string co { get; set; }
        /// <summary>
        /// 34
        /// </summary>
        public string o3 { get; set; }
        /// <summary>
        /// PM2.5
        /// </summary>
        public string primary_pollutant { get; set; }
        /// <summary>
        /// 2019-04-15T10:00:00+08:00
        /// </summary>
        public string last_update { get; set; }
        /// <summary>
        /// 良
        /// </summary>
        public string quality { get; set; }
    }

    public class Air
    {
        /// <summary>
        /// City
        /// </summary>
        public City city { get; set; }
        /// <summary>
        /// Stations
        /// </summary>
        public string stations { get; set; }
    }

    public class Results
    {
        /// <summary>
        /// Location
        /// </summary>
        public Location location { get; set; }
        /// <summary>
        /// Air
        /// </summary>
        public Air air { get; set; }
        /// <summary>
        /// 2019-04-15T10:00:00+08:00
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
