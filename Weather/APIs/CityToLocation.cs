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

namespace CityToLocation

{
    class CityToLocation//高德地图API，将城市名转换为对应的经纬度，以调取心知天气的高级API
    {
        public async static Task<Root> GetLocation(string cityName)
        {
            var location = cityName;
            var http = new HttpClient();
            //var response = await http.GetAsync("https://restapi.amap.com/v3/geocode/geo?address=北京市朝阳区阜通东大街6号&output=json&key=<用户的key>");
            var response = await http.GetAsync("https://restapi.amap.com/v3/geocode/geo?address=" + location + "&output=json&key=265900fd6d337e0313d7e02745492c28");
            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(Root));

            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (Root)serializer.ReadObject(ms);

            return data;
        }

        internal static Task GetLocation(AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            throw new NotImplementedException();
        }
    }
    public class Neighborhood
    {
        /// <summary>
        /// Name
        /// </summary>
        public List<string> name { get; set; }
        /// <summary>
        /// Type
        /// </summary>
        public List<string> type { get; set; }
    }

    public class Building
    {
        /// <summary>
        /// Name
        /// </summary>
        public List<string> name { get; set; }
        /// <summary>
        /// Type
        /// </summary>
        public List<string> type { get; set; }
    }

    public class Geocodes
    {
        /// <summary>
        /// 北京市朝阳区阜通东大街|6号
        /// </summary>
        public string formatted_address { get; set; }
        /// <summary>
        /// 中国
        /// </summary>
        public string country { get; set; }
        /// <summary>
        /// 北京市
        /// </summary>
        public string province { get; set; }
        /// <summary>
        /// 010
        /// </summary>
        public string citycode { get; set; }
        /// <summary>
        /// 北京市
        /// </summary>
        public string city { get; set; }
        /// <summary>
        /// 朝阳区
        /// </summary>
        public string district { get; set; }
        /// <summary>
        /// Township
        /// </summary>
        public List<string> township { get; set; }
        /// <summary>
        /// Neighborhood
        /// </summary>
        public Neighborhood neighborhood { get; set; }
        /// <summary>
        /// Building
        /// </summary>
        public Building building { get; set; }
        /// <summary>
        /// 110105
        /// </summary>
        public string adcode { get; set; }
        /// <summary>
        /// 阜通东大街
        /// </summary>
        public string street { get; set; }
        /// <summary>
        /// 6号
        /// </summary>
        public string number { get; set; }
        /// <summary>
        /// 116.483038,39.990633
        /// </summary>
        public string location { get; set; }
        /// <summary>
        /// 门牌号
        /// </summary>
        public string level { get; set; }
    }

    public class Root
    {
        /// <summary>
        /// 1
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// OK
        /// </summary>
        public string info { get; set; }
        /// <summary>
        /// 10000
        /// </summary>
        public string infocode { get; set; }
        /// <summary>
        /// 1
        /// </summary>
        public string count { get; set; }
        /// <summary>
        /// Geocodes
        /// </summary>
        public List<Geocodes> geocodes { get; set; }
    }
}




