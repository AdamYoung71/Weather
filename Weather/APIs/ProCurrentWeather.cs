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
