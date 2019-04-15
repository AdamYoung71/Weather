﻿using LLQ;
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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using static Weather.Pages.Events;

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
            this.NavigationCacheMode = NavigationCacheMode.Enabled;
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
               // cityNameText.Text = $"{e.Parameter.ToString()}";
                try
                {
                    getCity();
                }
                catch
                {
                    //var weatherCode = "/Assets/Icons/white/99@2x.png";
                    //mainIcon.Source = new BitmapImage(new Uri(mainIcon.BaseUri, weatherCode));
                    //cityNameText.Text = "Error";
                }
            

            base.OnNavigatedTo(e);
          
        }

        public async void getCity()
        {
            try
            {
                string cityName = Pages.Parameters.cityName;
                var myWeather = await MainAPI.MainAPI.getWeather(cityName);     //实例化主要天气API
                var mySuggestion = await LifeSuggestionAPI.LifeSuggestionAPI.getSuggestion(cityName);//实例化生活指数
                var myLocation = await CityToLocation.CityToLocation.GetLocation(cityName);     //使用高德API将城市名转换为经纬度。
                string[] Locations = myLocation.geocodes[0].location.Split(",");        //将用逗号隔开的经纬度分割分别存入。
                double Lat = Convert.ToDouble(Locations[0]);
                double Lon = Convert.ToDouble(Locations[1]);
                var myCurrentWeather = await ProCurrentWeather.ProCurrentWeather.GetProCurrentWeather(Lon, Lat);//实例化高级当前天气API
                var myForcast = await ProForecast.ProForecast.GetProForecast(Lon, Lat);
                var myAir = await AirQulity.AirQuality.getAir(cityName);



                curTempText.Text = myWeather.results[0].now.temperature + "℃";
                cityNameText.Text = cityName;
                //添加对应天气的图片
                tomoText.Text = "明日天气：" + myForcast.results[0].data[0].temperature + " " + myForcast.results[0].data[0].text;
                var weatherCode = "/Assets/Icons/white/" + Convert.ToString(myWeather.results[0].now.code) + "@2x.png";
                mainIcon.Source = new BitmapImage(new Uri(mainIcon.BaseUri, weatherCode));



            }
            catch
            {
                var weatherCode = "/Assets/Icons/white/99@2x.png";
                mainIcon.Source = new BitmapImage(new Uri(mainIcon.BaseUri, weatherCode));
                cityNameText.Text = "Error";
                curTempText.Text = "--℃";
                tomoText.Text = " ";
              
            }




        }

       

       
    }
}
