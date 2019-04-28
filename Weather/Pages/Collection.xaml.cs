using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Weather.Models;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace Weather
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class Collection : Page
    {
        public ObservableCollection<DailyWeather> collectionDailyWeathers = new ObservableCollection<DailyWeather>();
        
        public Collection()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Enabled;
            collectionDetailListView.DataContext = collectionDailyWeathers;
            collectionInit();           
        }




        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            if (Pages.Parameters.collections != null && Convert.ToString(e.Parameter) == "1")
            {
                var myWeather = await MainAPI.MainAPI.getWeather(Pages.Parameters.cityName);     //实例化主要天气API
                var weatherCode = "/Assets/Icons/white/" + Convert.ToString(myWeather.results[0].now.code) + "@2x.png";
                collectionDailyWeathers.Add(new DailyWeather() { date = Pages.Parameters.cityName, iconSource = new BitmapImage(new Uri(myImg.BaseUri, weatherCode)), tempreture = myWeather.results[0].now.temperature, descrip = myWeather.results[0].now.text });

                var dialog = new ContentDialog()    //消息框
                {
                    Title = "消息提示",
                    Content = "已收藏",
                    PrimaryButtonText = "确定",
                    FullSizeDesired = false,
                };
                dialog.PrimaryButtonClick += (_s, _e) => { };
                await dialog.ShowAsync();
            }
            if (Convert.ToString(e.Parameter) == "0")
            {
                int index = collectionDailyWeathers.Count();
                if (index == 0)
                {

                }
                else
                {
                   DailyWeather daily = collectionDailyWeathers.First(r => r.date == Pages.Parameters.cityName);
                    collectionDailyWeathers.Remove(daily);
                }
                var dialog = new ContentDialog()    //消息框
                {
                    Title = "消息提示",
                    Content = "已取消收藏！",
                    PrimaryButtonText = "确定",
                    FullSizeDesired = false,
                };
                dialog.PrimaryButtonClick += (_s, _e) => { };
                await dialog.ShowAsync();
            }

            base.OnNavigatedTo(e);
        }

        private void CollectionDetailListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                DailyWeather a = e.ClickedItem as DailyWeather;
                Pages.Parameters.cityName = a.date;
                Pages.Parameters.previous = a.date;
                Frame.Navigate(typeof(HomePage),"fromCollection");
            }
            catch
            {

            }
        }

        public async void collectionInit()
        {
            foreach (string t in Pages.Parameters.collections)
            {
                var myWeather = await MainAPI.MainAPI.getWeather(t);     //实例化主要天气API
                var weatherCode = "/Assets/Icons/white/" + Convert.ToString(myWeather.results[0].now.code) + "@2x.png";
                
                collectionDailyWeathers.Add(new DailyWeather() { date = t, iconSource = new BitmapImage(new Uri(myImg.BaseUri, weatherCode)), tempreture =myWeather.results[0].now.temperature, descrip =myWeather.results[0].now.text });

            }
        }
    }
}
