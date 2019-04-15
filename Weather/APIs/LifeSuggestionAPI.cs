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
/*
namespace LifeSuggestionAPI//六项生活指数API

{
    class LifeSuggestionAPI
    {
        public async static Task<Root> GetSuggestion(string city)
        {
            var location_cd = city;
            var http = new HttpClient();
            //var response = await http.GetAsync("https://api.seniverse.com/v3/life/suggestion.json?key=9b7few3mmyrhzfp1&location=shanghai&language=zh-Hans");
            var response = await http.GetAsync("https://api.seniverse.com/v3/life/suggestion.json?key=SrcvbANXIm08Wx519&location=" + location_cd + "&language=zh-Hans");
            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(Root));

            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (Root)serializer.ReadObject(ms);

            return data;
        }

        internal static Task GetSuggestion(AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            throw new NotImplementedException();
        }
    }




    public class Location
    {
        /// <summary>
        /// WTW3SJ5ZBJUY
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 上海
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// CN
        /// </summary>
        public string country { get; set; }
        /// <summary>
        /// 上海,上海,中国
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

    public class Car_washing
    {
        /// <summary>
        /// 较适宜
        /// </summary>
        public string brief { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string details { get; set; }
    }

    public class Dressing
    {
        /// <summary>
        /// 较冷
        /// </summary>
        public string brief { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string details { get; set; }
    }

    public class Flu
    {
        /// <summary>
        /// 较易发
        /// </summary>
        public string brief { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string details { get; set; }
    }

    public class Sport
    {
        /// <summary>
        /// 较适宜
        /// </summary>
        public string brief { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string details { get; set; }
    }

    public class Travel
    {
        /// <summary>
        /// 适宜
        /// </summary>
        public string brief { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string details { get; set; }
    }

    public class Uv
    {
        /// <summary>
        /// 弱
        /// </summary>
        public string brief { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string details { get; set; }
    }

    public class Suggestion
    {
        /// <summary>
        /// Car_washing
        /// </summary>
        public Car_washing car_washing { get; set; }
        /// <summary>
        /// Dressing
        /// </summary>
        public Dressing dressing { get; set; }
        /// <summary>
        /// Flu
        /// </summary>
        public Flu flu { get; set; }
        /// <summary>
        /// Sport
        /// </summary>
        public Sport sport { get; set; }
        /// <summary>
        /// Travel
        /// </summary>
        public Travel travel { get; set; }
        /// <summary>
        /// Uv
        /// </summary>
        public Uv uv { get; set; }
    }

    public class Results
    {
        /// <summary>
        /// Location
        /// </summary>
        public Location location { get; set; }
        /// <summary>
        /// Suggestion
        /// </summary>
        public Suggestion suggestion { get; set; }
        /// <summary>
        /// 2019-03-22T22:40:54+08:00
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