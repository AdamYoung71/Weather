﻿using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Weather.Models;
using System.Collections.ObjectModel;
using Windows.Storage;
using Windows.UI.Notifications;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace Weather
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class HomePage : Page
    {
        //声明每个模板所使用的集合
        ObservableCollection<DailyWeather> dailyWeathers = new ObservableCollection<DailyWeather>(); //三天天气预报   
        ObservableCollection<Items> detailItems = new ObservableCollection<Items>(); //详细信息
        ObservableCollection<Items> suggestionItems = new ObservableCollection<Items>(); //生活指数
        ObservableCollection<Items> airItems = new ObservableCollection<Items>(); //空气质量
 
        ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings; //声明本地设置
             

        public  HomePage()
        {
            
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Enabled; //开启页面缓存模式，在导航后不会丢失当前页面的数据

            // 将每个Listview的items绑定到对应的集合中。
            mainDetailListView.DataContext = dailyWeathers;
            myListView.DataContext = detailItems;
            myListView2.DataContext = suggestionItems;
            myListView3.DataContext = airItems;
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            try
            {
                if (Convert.ToString(e.Parameter) == "fromCollection"|| Convert.ToString(e.Parameter) == "search"|| Convert.ToString(e.Parameter) == "refresh"||Convert.ToString(e.Parameter) =="init")
                    getCity();
            }
            catch { }
            base.OnNavigatedTo(e);
          
        }

        public async void getCity()
        {
            try
            {
               /*************实例化API******************/
                string cityName = Pages.Parameters.cityName;
                var myWeather = await MainAPI.MainAPI.getWeather(cityName);     //实例化主要天气API
                var mySuggestion = await LifeSuggestionAPI.LifeSuggestionAPI.getSuggestion(cityName);//实例化生活指数
                var myLocation = await CityToLocation.CityToLocation.GetLocation(cityName);     //使用高德API将城市名转换为经纬度。
                string[] Locations = myLocation.geocodes[0].location.Split(",");        //将用逗号隔开的经纬度分割分别存入。
                double Lat = Convert.ToDouble(Locations[0]);
                double Lon = Convert.ToDouble(Locations[1]);
                if (Lon < 0) //API的返回数据有负数，转换为正数
                {
                    Lon = 360 + Lon;
                }
                var myCurrentWeather = await ProCurrentWeather.ProCurrentWeather.GetProCurrentWeather(Lon, Lat);//实例化高级当前天气API
                var myForcast = await ProForecast.ProForecast.GetProForecast(Lon, Lat);
                var myAir = await AirQulity.AirQuality.getAir(cityName);
                

                //给页面上方的主要部分赋值
                
                curTempText.Text = Pages.Parameters.isCelcius == true? myWeather.results[0].now.temperature + "°C" : myWeather.results[0].now.temperature + "°F";
                cityNameText.Text = cityName;

                //添加对应天气的图片
                var weatherCode = "/Assets/Icons/white/" + Convert.ToString(myWeather.results[0].now.code) + "@2x.png";
                mainIcon.Source = new BitmapImage(new Uri(mainIcon.BaseUri, weatherCode));
                string[] lastUpdate = myWeather.results[0].last_update.Split("T");
                lastUpdatedText.Text = "最后更新：" + lastUpdate[1].Substring(0, 5);
                mainDisc.Text = myWeather.results[0].now.text;

                //只在启动或搜索不同城市时更新页面下方的各种信息
                if(Pages.Parameters.previous == Pages.Parameters.cityName)
                {
                    /******************获取主页下方的信息项*******************/
                    detailItems.Clear(); //先清空
                    string cORf = Pages.Parameters.isCelcius == true ? "°C" : "°F";
                    detailItems.Add(new Items() { icon = new BitmapImage(new Uri(mainIcon.BaseUri, "/Assets/Icons/others/thermometer.png")), figure = myWeather.results[0].now.feels_like + cORf, text = "体感温度" });
                    detailItems.Add(new Items() { icon = new BitmapImage(new Uri(mainIcon.BaseUri, "/Assets/Icons/others/pressure.png")), figure = myWeather.results[0].now.pressure + "百帕", text = "气压" });
                    detailItems.Add(new Items() { icon = new BitmapImage(new Uri(mainIcon.BaseUri, "/Assets/Icons/others/humidity.png")), figure = myWeather.results[0].now.humidity + "%", text = "相对湿度" });
                    detailItems.Add(new Items() { icon = new BitmapImage(new Uri(mainIcon.BaseUri, "/Assets/Icons/others/windsock.png")), figure = myWeather.results[0].now.wind_direction, text = "风向" });
                    detailItems.Add(new Items() { icon = new BitmapImage(new Uri(mainIcon.BaseUri, "/Assets/Icons/others/visible.png")), figure = myWeather.results[0].now.visibility + "km", text = "能见度" });

                    suggestionItems.Clear();
                    suggestionItems.Add(new Items() { icon = new BitmapImage(new Uri(mainIcon.BaseUri, "/Assets/Icons/others/uv.png")), figure = mySuggestion.results[0].suggestion.uv.brief, text = "紫外线" });
                    suggestionItems.Add(new Items() { icon = new BitmapImage(new Uri(mainIcon.BaseUri, "/Assets/Icons/others/sports.png")), figure = mySuggestion.results[0].suggestion.sport.brief, text = "运动" });
                    suggestionItems.Add(new Items() { icon = new BitmapImage(new Uri(mainIcon.BaseUri, "/Assets/Icons/others/clothes.png")), figure = mySuggestion.results[0].suggestion.dressing.brief, text = "穿衣" });
                    suggestionItems.Add(new Items() { icon = new BitmapImage(new Uri(mainIcon.BaseUri, "/Assets/Icons/others/car.png")), figure = mySuggestion.results[0].suggestion.car_washing.brief, text = "洗车" });
                    suggestionItems.Add(new Items() { icon = new BitmapImage(new Uri(mainIcon.BaseUri, "/Assets/Icons/others/hang.png")), figure = mySuggestion.results[0].suggestion.airing.brief, text = "晾晒" });
                    suggestionItems.Add(new Items() { icon = new BitmapImage(new Uri(mainIcon.BaseUri, "/Assets/Icons/others/fever.png")), figure = mySuggestion.results[0].suggestion.flu.brief, text = "感冒" });

                    airItems.Clear();
                    airItems.Add(new Items() { icon = new BitmapImage(new Uri(mainIcon.BaseUri, "/Assets/Icons/others/quality.png")), figure = myAir.results[0].air.city.quality, text = "空气质量" });
                    airItems.Add(new Items() { icon = new BitmapImage(new Uri(mainIcon.BaseUri, "/Assets/Icons/others/aqi.png")), figure = myAir.results[0].air.city.aqi, text = "AQI" });
                    airItems.Add(new Items() { icon = new BitmapImage(new Uri(mainIcon.BaseUri, "/Assets/Icons/others/particles.png")), figure = myAir.results[0].air.city.pm25, text = "PM2.5" });
                    airItems.Add(new Items() { icon = new BitmapImage(new Uri(mainIcon.BaseUri, "/Assets/Icons/others/o3.png")), figure = myAir.results[0].air.city.o3, text = "臭氧" });
                    

                    if(myAir.results[0].air.city.primary_pollutant == null)
                    {
                        airItems.Add(new Items() { icon = new BitmapImage(new Uri(mainIcon.BaseUri, "/Assets/Icons/others/dust.png")), figure = "无", text = "首要污染物" });
                    }
                    else
                    {
                        airItems.Add(new Items() { icon = new BitmapImage(new Uri(mainIcon.BaseUri, "/Assets/Icons/others/dust.png")), figure = myAir.results[0].air.city.primary_pollutant, text = "首要污染物" });
                    }
                    /******************************************************/


                    /******************获取未来三天天气预报*******************/
                    var code_1 = "/Assets/Icons/white/" + Convert.ToString(myForcast.results[0].data[1].code) + "@2x.png";
                    var code_2 = "/Assets/Icons/white/" + Convert.ToString(myForcast.results[0].data[2].code) + "@2x.png";
                    var code_3 = "/Assets/Icons/white/" + Convert.ToString(myForcast.results[0].data[3].code) + "@2x.png";

                    dailyWeathers.Clear();
                    if(Pages.Parameters.isCelcius == true)
                    {
                        dailyWeathers.Add(new DailyWeather() { date = "明天", iconSource = new BitmapImage(new Uri(mainIcon.BaseUri, code_1)), tempreture = myForcast.results[0].data[1].temperature.Substring(0, 2) + "°C", descrip = myForcast.results[0].data[1].text });
                        dailyWeathers.Add(new DailyWeather() { date = "后天", iconSource = new BitmapImage(new Uri(mainIcon.BaseUri, code_2)), tempreture = myForcast.results[0].data[2].temperature.Substring(0, 2) + "°C", descrip = myForcast.results[0].data[2].text });
                        dailyWeathers.Add(new DailyWeather() { date = "三天后", iconSource = new BitmapImage(new Uri(mainIcon.BaseUri, code_3)), tempreture = myForcast.results[0].data[3].temperature.Substring(0, 2) + "°C", descrip = myForcast.results[0].data[3].text });
                    }
                    else
                    {
                        dailyWeathers.Add(new DailyWeather() { date = "明天", iconSource = new BitmapImage(new Uri(mainIcon.BaseUri, code_1)), tempreture = myForcast.results[0].data[1].temperature.Substring(0, 2) + "°F", descrip = myForcast.results[0].data[1].text });
                        dailyWeathers.Add(new DailyWeather() { date = "后天", iconSource = new BitmapImage(new Uri(mainIcon.BaseUri, code_2)), tempreture = myForcast.results[0].data[2].temperature.Substring(0, 2) + "°F", descrip = myForcast.results[0].data[2].text });
                        dailyWeathers.Add(new DailyWeather() { date = "三天后", iconSource = new BitmapImage(new Uri(mainIcon.BaseUri, code_3)), tempreture = myForcast.results[0].data[3].temperature.Substring(0, 2) + "°F", descrip = myForcast.results[0].data[3].text });
                    }
                   
                }

                //更新磁贴
                var tileXML = TileUpdateManager.GetTemplateContent(TileTemplateType.TileSquare150x150Block); //选择模板
                var tileAttributes = tileXML.GetElementsByTagName("text");
                tileAttributes[0].AppendChild(tileXML.CreateTextNode(myWeather.results[0].now.temperature+"°")); //绑定内容
                tileAttributes[1].AppendChild(tileXML.CreateTextNode(mainDisc.Text));
                var tileNotification = new TileNotification(tileXML);
                TileUpdateManager.CreateTileUpdaterForApplication().Update(tileNotification); //更新





                //判断是否是被收藏的城市，若是用实心五角星，不是则用空心五角星
                if (Pages.Parameters.collections.Contains(cityName))
                {
                    collectionIcon.Symbol = Symbol.SolidStar;
                }
                else
                {
                    collectionIcon.Symbol = Symbol.OutlineStar;
                }

            }
            catch
            {
                //错误处理
                Pages.Parameters.cityName = "err";
                var weatherCode = "/Assets/Icons/white/99@2x.png"; //使用N/A图片
                mainIcon.Source = new BitmapImage(new Uri(mainIcon.BaseUri, weatherCode));
                cityNameText.Text = "Error";
                curTempText.Text = "--°C";
                tomoText.Text = " ";
                mainDisc.Text = " ";
                    var dialog = new ContentDialog()    //消息框
                    {
                        Title = "消息提示",
                        Content = "未找到！",
                        PrimaryButtonText = "确定",
                        FullSizeDesired = false,
                    };

                    dialog.PrimaryButtonClick += (_s, _e) => { };
                    await dialog.ShowAsync();
            }
        }

       

        private void Button_Click(object sender, RoutedEventArgs e) //收藏功能
        {
            
            if (collectionIcon.Symbol == Symbol.SolidStar)
            {
                Pages.Parameters.collections.Remove(Pages.Parameters.cityName);  
                collectionIcon.Symbol = Symbol.OutlineStar;            
                Frame.Navigate(typeof(Collection),"0");
                Frame.Navigate(typeof(HomePage),"Collection");
            }
            else if(Pages.Parameters.cityName != "err")
            {
                Pages.Parameters.collections.Add(Pages.Parameters.cityName);
                collectionIcon.Symbol = Symbol.SolidStar;
                
                Frame.Navigate(typeof(Collection), "1");
                Frame.Navigate(typeof(HomePage), "Collection");               
            }
            string settingString = string.Join(",", Pages.Parameters.collections.ToArray());
            localSettings.Values["collectionSettings"] = settingString; //写入本地设置
        }
    }
}
