using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using static Weather.MainPage;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace Weather
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class HomePage : Page
    {
        public HomePage()
        {
            this.InitializeComponent();
            
        }

        private async void MyButton_Click(object sender, RoutedEventArgs e)
        {
            string cityName = Weather.Pages.Parameters.setCity();
            var myWeather = await MainAPI.MainAPI.GetWrather(cityName);     //实例化主要天气API
            var mySuggestion = await LifeSuggestionAPI.LifeSuggestionAPI.GetSuggestion(cityName);//实例化生活指数
            var myLocation = await CityToLocation.CityToLocation.GetLocation(cityName);     //使用高德API将城市名转换为经纬度。
            string[] Locations = myLocation.geocodes[0].location.Split(",");        //将用逗号隔开的经纬度分割分别存入。
            double Lat = Convert.ToDouble(Locations[0]);
            double Lon = Convert.ToDouble(Locations[1]);
            var myCurrentWeather = await ProCurrentWeather.ProCurrentWeather.GetProCurrentWeather(Lon, Lat);//实例化高级当前天气API
            var myForecast = await ProForecast.ProForecast.GetProForecast(Lon, Lat);//实例化高级天气预报API

            curweather.Text = myWeather.results[0].now.text;
        }
    }
}
