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

namespace Weather
{
    class APIs
    {
    }
}

namespace MainAPI
{
    class MainAPI
    {
        public async static Task<Root> getWeather(string city)//主函数，序列化API
        {
            var location_cd = city;
            var http = new HttpClient();
            //var response = await http.GetAsync("https://api.seniverse.com/v3/weather/now.json?key=SrcvbANXIm08Wx519&location=" + location_cd + "&language=zh-Hans&unit=c");
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




    /*API内容*/
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
    


} //天气实况API


namespace LifeSuggestionAPI//生活指数API

{
    class LifeSuggestionAPI
    {
        public async static Task<Root> getSuggestion(string city)
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



/*namespace FiveDaysAPI
{

    class FiveDaysAPI
    {
        public async static Task<Root> getFiveDaysAPI(string city)//主函数，序列化API
        {
            var location_cd = city;
            var http = new HttpClient();
            //var response = await http.GetAsync("https://api.seniverse.com/v3/weather/daily.json?key=SrcvbANXIm08Wx519&location=beijing&language=zh-Hans&unit=c&start=-1&days=5");
            var response = await http.GetAsync("https://api.seniverse.com/v3/weather/daily.json?key=SrcvbANXIm08Wx519&location=" + location_cd + "&language=zh-Hans&unit=c&start=-1");
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

    public class Daily
    {
        /// <summary>
        /// 2019-04-14
        /// </summary>
        public DateTime date { get; set; }
        /// <summary>
        /// 晴
        /// </summary>
        public string text_day { get; set; }
        /// <summary>
        /// 0
        /// </summary>
        public string code_day { get; set; }
        /// <summary>
        /// 晴
        /// </summary>
        public string text_night { get; set; }
        /// <summary>
        /// 1
        /// </summary>
        public string code_night { get; set; }
        /// <summary>
        /// 23
        /// </summary>
        public string high { get; set; }
        /// <summary>
        /// 8
        /// </summary>
        public string low { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string precip { get; set; }
        /// <summary>
        /// 西南
        /// </summary>
        public string wind_direction { get; set; }
        /// <summary>
        /// 225
        /// </summary>
        public string wind_direction_degree { get; set; }
        /// <summary>
        /// 15
        /// </summary>
        public string wind_speed { get; set; }
        /// <summary>
        /// 3
        /// </summary>
        public string wind_scale { get; set; }
    }

    public class Results
    {
        /// <summary>
        /// Location
        /// </summary>
        public Location location { get; set; }
        /// <summary>
        /// Daily
        /// </summary>
        public List<Daily> daily { get; set; }
        /// <summary>
        /// 2019-04-14T18:00:00+08:00
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


}*/

/*namespace FiveDaysAPI
{

    class FiveDaysAPI
    {

        public async static Task<Root> getFiveDays(string city)//主函数，序列化API
        {
            var location_cd = city;
            var http = new HttpClient();
            //var response = await http.GetAsync("https://api.seniverse.com/v3/weather/now.json?key=SrcvbANXIm08Wx519&location=" + location_cd + "&language=zh-Hans&unit=c");
            var response = await http.GetAsync("https://api.seniverse.com/v3/weather/daily.json?key=SrcvbANXIm08Wx519&location=" + location_cd + "&language=zh-Hans&unit=c&start=-1&days=5");
            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(Root));

            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (Root)serializer.ReadObject(ms);

            return data;
        }

       

    }


    [DataContract]
    public class Location
    {
        [DataMember]
        public string id { get; set; }

        [DataMember]
        public string name { get; set; }

        [DataMember]
        public string country { get; set; }

        [DataMember]
        public string path { get; set; }

        [DataMember]
        public string timezone { get; set; }

        [DataMember]
        public string timezone_offset { get; set; }
    }

    [DataContract]
    public class Daily
    {
        [DataMember]
        public DateTime date { get; set; }

        [DataMember]
        public string text_day { get; set; }

        [DataMember]
        public string code_day { get; set; }

        [DataMember]
        public string text_night { get; set; }

        [DataMember]
        public string code_night { get; set; }

        [DataMember]
        public string high { get; set; }

        [DataMember]
        public string low { get; set; }

        [DataMember]
        public string precip { get; set; }

        [DataMember]
        public string wind_direction { get; set; }

        [DataMember]
        public string wind_direction_degree { get; set; }

        [DataMember]
        public string wind_speed { get; set; }

        [DataMember]
        public string wind_scale { get; set; }
    }

    [DataContract]
    public class Results
    {
        [DataMember]
        public Location location { get; set; }

        [DataMember]
        public List<Daily> daily { get; set; }

        [DataMember]
        public string last_update { get; set; }
    }

    [DataContract]
    public class Root
    {
        [DataMember]
        public List<Results> results { get; set; }
    }


}*/


