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

    public class Ac
    {
        /// <summary>
        /// 较少开启
        /// </summary>
        public string brief { get; set; }
        /// <summary>
        /// 您将感到很舒适，一般不需要开启空调。
        /// </summary>
        public string details { get; set; }
    }

    public class Air_pollution
    {
        /// <summary>
        /// 良
        /// </summary>
        public string brief { get; set; }
        /// <summary>
        /// 气象条件有利于空气污染物稀释、扩散和清除，可在室外正常活动。
        /// </summary>
        public string details { get; set; }
    }

    public class Airing
    {
        /// <summary>
        /// 极适宜
        /// </summary>
        public string brief { get; set; }
        /// <summary>
        /// 天气不错，极适宜晾晒。抓紧时机把久未见阳光的衣物搬出来晒晒太阳吧！
        /// </summary>
        public string details { get; set; }
    }

    public class Allergy
    {
        /// <summary>
        /// 极易发
        /// </summary>
        public string brief { get; set; }
        /// <summary>
        /// 天气条件极易诱发过敏，易过敏人群尽量减少外出，外出宜穿长衣长裤并佩戴好眼镜和口罩，外出归来时及时清洁手和口鼻。
        /// </summary>
        public string details { get; set; }
    }

    public class Beer
    {
        /// <summary>
        /// 适宜
        /// </summary>
        public string brief { get; set; }
        /// <summary>
        /// 炎热的天气可能增加啤酒对您的诱惑，适量饮用啤酒会给您带来清凉的感觉，但千万注意不要过量呦！
        /// </summary>
        public string details { get; set; }
    }

    public class Boating
    {
        /// <summary>
        /// 较适宜
        /// </summary>
        public string brief { get; set; }
        /// <summary>
        /// 白天较适宜划船，但较大的风力会对划船产生一定的影响。
        /// </summary>
        public string details { get; set; }
    }

    public class Car_washing
    {
        /// <summary>
        /// 较适宜
        /// </summary>
        public string brief { get; set; }
        /// <summary>
        /// 较适宜洗车，未来一天无雨，风力较小，擦洗一新的汽车至少能保持一天。
        /// </summary>
        public string details { get; set; }
    }

    public class Chill
    {
        /// <summary>
        /// 无
        /// </summary>
        public string brief { get; set; }
        /// <summary>
        /// 温度未达到风寒所需的低温，稍作防寒准备即可。
        /// </summary>
        public string details { get; set; }
    }

    public class Comfort
    {
        /// <summary>
        /// 较舒适
        /// </summary>
        public string brief { get; set; }
        /// <summary>
        /// 白天天气晴好，您在这种天气条件下，会感觉早晚凉爽、舒适，午后偏热。
        /// </summary>
        public string details { get; set; }
    }

    public class Dating
    {
        /// <summary>
        /// 较适宜
        /// </summary>
        public string brief { get; set; }
        /// <summary>
        /// 虽然有点风，但情侣们可以放心外出，不用担心天气来调皮捣乱而影响了兴致。
        /// </summary>
        public string details { get; set; }
    }

    public class Dressing
    {
        /// <summary>
        /// 热
        /// </summary>
        public string brief { get; set; }
        /// <summary>
        /// 天气热，建议着短裙、短裤、短薄外套、T恤等夏季服装。
        /// </summary>
        public string details { get; set; }
    }

    public class Fishing
    {
        /// <summary>
        /// 较适宜
        /// </summary>
        public string brief { get; set; }
        /// <summary>
        /// 较适合垂钓，但风力稍大，会对垂钓产生一定的影响。
        /// </summary>
        public string details { get; set; }
    }

    public class Flu
    {
        /// <summary>
        /// 少发
        /// </summary>
        public string brief { get; set; }
        /// <summary>
        /// 各项气象条件适宜，无明显降温过程，发生感冒机率较低。
        /// </summary>
        public string details { get; set; }
    }

    public class Hair_dressing
    {
        /// <summary>
        /// 一般
        /// </summary>
        public string brief { get; set; }
        /// <summary>
        /// 风较大，注意防晒，因风尘大，头发易脏，注意保持秀发清洁，建议使用滋润防晒型洗发护发品。
        /// </summary>
        public string details { get; set; }
    }

    public class Kiteflying
    {
        /// <summary>
        /// 较适宜
        /// </summary>
        public string brief { get; set; }
        /// <summary>
        /// 天气不错，但气温略高，带上太阳帽，选择合适的地点，还是较适宜放风筝的
        /// </summary>
        public string details { get; set; }
    }

    public class Makeup
    {
        /// <summary>
        /// 去油防晒
        /// </summary>
        public string brief { get; set; }
        /// <summary>
        /// 建议用蜜质SPF20面霜打底，水质无油粉底霜。
        /// </summary>
        public string details { get; set; }
    }

    public class Mood
    {
        /// <summary>
        /// 好
        /// </summary>
        public string brief { get; set; }
        /// <summary>
        /// 天气较好，空气温润，和风飘飘，美好的天气会带来一天接踵而来的好心情。
        /// </summary>
        public string details { get; set; }
    }

    public class Morning_sport
    {
        /// <summary>
        /// 较适宜
        /// </summary>
        public string brief { get; set; }
        /// <summary>
        /// 早晨气象条件较适宜晨练，但风力稍大，晨练时会感觉有点凉，晨练时着装不要过于单薄，选择避风的地点。
        /// </summary>
        public string details { get; set; }
    }

    public class Night_life
    {
        /// <summary>
        /// 较适宜
        /// </summary>
        public string brief { get; set; }
        /// <summary>
        /// 天气较好，虽然有点风，但仍比较适宜夜生活，您可以放心外出。
        /// </summary>
        public string details { get; set; }
    }

    public class Road_condition
    {
        /// <summary>
        /// 干燥
        /// </summary>
        public string brief { get; set; }
        /// <summary>
        /// 天气较好，路面比较干燥，路况较好。
        /// </summary>
        public string details { get; set; }
    }

    public class Shopping
    {
        /// <summary>
        /// 较适宜
        /// </summary>
        public string brief { get; set; }
        /// <summary>
        /// 天气较好，虽然风有点大，还是较适宜逛街的，不过出门前要给秀发定定型，别让风吹乱您的秀发。
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
        /// 天气较好，但风力较大，推荐您进行室内运动，若在户外运动请注意防风。
        /// </summary>
        public string details { get; set; }
    }

    public class Sunscreen
    {
        /// <summary>
        /// 强
        /// </summary>
        public string brief { get; set; }
        /// <summary>
        /// 属强紫外辐射天气，外出时应加强防护，建议涂擦SPF在15-20之间，PA++的防晒护肤品。
        /// </summary>
        public string details { get; set; }
    }

    public class Traffic
    {
        /// <summary>
        /// 良好
        /// </summary>
        public string brief { get; set; }
        /// <summary>
        /// 天气较好，路面干燥，交通气象条件良好，车辆可以正常行驶。
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
        /// 天气较好，风稍大，但温度适宜，是个好天气哦。适宜旅游，您可以尽情地享受大自然的无限风光。
        /// </summary>
        public string details { get; set; }
    }

    public class Umbrella
    {
        /// <summary>
        /// 不带伞
        /// </summary>
        public string brief { get; set; }
        /// <summary>
        /// 天气较好，您在出门的时候无须带雨伞。
        /// </summary>
        public string details { get; set; }
    }

    public class Uv
    {
        /// <summary>
        /// 强
        /// </summary>
        public string brief { get; set; }
        /// <summary>
        /// 紫外线辐射强，建议涂擦SPF20左右、PA++的防晒护肤品。避免在10点至14点暴露于日光下。
        /// </summary>
        public string details { get; set; }
    }

    public class Suggestion
    {
        /// <summary>
        /// Ac
        /// </summary>
        public Ac ac { get; set; }
        /// <summary>
        /// Air_pollution
        /// </summary>
        public Air_pollution air_pollution { get; set; }
        /// <summary>
        /// Airing
        /// </summary>
        public Airing airing { get; set; }
        /// <summary>
        /// Allergy
        /// </summary>
        public Allergy allergy { get; set; }
        /// <summary>
        /// Beer
        /// </summary>
        public Beer beer { get; set; }
        /// <summary>
        /// Boating
        /// </summary>
        public Boating boating { get; set; }
        /// <summary>
        /// Car_washing
        /// </summary>
        public Car_washing car_washing { get; set; }
        /// <summary>
        /// Chill
        /// </summary>
        public Chill chill { get; set; }
        /// <summary>
        /// Comfort
        /// </summary>
        public Comfort comfort { get; set; }
        /// <summary>
        /// Dating
        /// </summary>
        public Dating dating { get; set; }
        /// <summary>
        /// Dressing
        /// </summary>
        public Dressing dressing { get; set; }
        /// <summary>
        /// Fishing
        /// </summary>
        public Fishing fishing { get; set; }
        /// <summary>
        /// Flu
        /// </summary>
        public Flu flu { get; set; }
        /// <summary>
        /// Hair_dressing
        /// </summary>
        public Hair_dressing hair_dressing { get; set; }
        /// <summary>
        /// Kiteflying
        /// </summary>
        public Kiteflying kiteflying { get; set; }
        /// <summary>
        /// Makeup
        /// </summary>
        public Makeup makeup { get; set; }
        /// <summary>
        /// Mood
        /// </summary>
        public Mood mood { get; set; }
        /// <summary>
        /// Morning_sport
        /// </summary>
        public Morning_sport morning_sport { get; set; }
        /// <summary>
        /// Night_life
        /// </summary>
        public Night_life night_life { get; set; }
        /// <summary>
        /// Road_condition
        /// </summary>
        public Road_condition road_condition { get; set; }
        /// <summary>
        /// Shopping
        /// </summary>
        public Shopping shopping { get; set; }
        /// <summary>
        /// Sport
        /// </summary>
        public Sport sport { get; set; }
        /// <summary>
        /// Sunscreen
        /// </summary>
        public Sunscreen sunscreen { get; set; }
        /// <summary>
        /// Traffic
        /// </summary>
        public Traffic traffic { get; set; }
        /// <summary>
        /// Travel
        /// </summary>
        public Travel travel { get; set; }
        /// <summary>
        /// Umbrella
        /// </summary>
        public Umbrella umbrella { get; set; }
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
        /// 2019-04-16T23:10:42+08:00
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


