using LLQ;
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
using Weather.Models;
using System.Collections.ObjectModel;
using Windows.Storage;
using System.Collections;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace Weather
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class HomePage : Page
    {
        ObservableCollection<DailyWeather> dailyWeathers = new ObservableCollection<DailyWeather>();
        ObservableCollection<Items> myItems = new ObservableCollection<Items>();

        StorageFolder storageFolder = ApplicationData.Current.LocalFolder;

        ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
        



        public  HomePage()
        {
            
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Enabled;
            mainDetailListView.DataContext = dailyWeathers;
            myListView.DataContext = myItems;
            dailyWeathers.Add(new DailyWeather() { date = "明天", iconSource = new BitmapImage(new Uri(mainIcon.BaseUri, "/Assets/Icons/white/3@2x.png")), tempreture = "16°C", descrip = "多云" });
            dailyWeathers.Add(new DailyWeather() { date = "明天", iconSource = new BitmapImage(new Uri(mainIcon.BaseUri, "/Assets/Icons/white/3@2x.png")), tempreture = "16°C", descrip = "多云" });
            dailyWeathers.Add(new DailyWeather() { date = "明天", iconSource = new BitmapImage(new Uri(mainIcon.BaseUri, "/Assets/Icons/white/3@2x.png")), tempreture = "16°C", descrip = "多云" });
            dailyWeathers.Add(new DailyWeather() { date = "明天", iconSource = new BitmapImage(new Uri(mainIcon.BaseUri, "/Assets/Icons/white/3@2x.png")), tempreture = "16°C", descrip = "多云" });
            dailyWeathers.Add(new DailyWeather() { date = "明天", iconSource = new BitmapImage(new Uri(mainIcon.BaseUri, "/Assets/Icons/white/3@2x.png")), tempreture = "16°C", descrip = "多云" });
            dailyWeathers.Add(new DailyWeather() { date = "明天", iconSource = new BitmapImage(new Uri(mainIcon.BaseUri, "/Assets/Icons/white/3@2x.png")), tempreture = "16°C", descrip = "多云" });
            dailyWeathers.Add(new DailyWeather() { date = "明天", iconSource = new BitmapImage(new Uri(mainIcon.BaseUri, "/Assets/Icons/white/3@2x.png")), tempreture = "16°C", descrip = "多云" });


            myItems.Add(new Items() { icon = new BitmapImage(new Uri(mainIcon.BaseUri, "/Assets/Icons/others/co2.png")), figure = "132", text = "二氧化碳" });
            myItems.Add(new Items() { icon = new BitmapImage(new Uri(mainIcon.BaseUri, "/Assets/Icons/others/co2.png")), figure = "132", text = "二氧化碳" });
            myItems.Add(new Items() { icon = new BitmapImage(new Uri(mainIcon.BaseUri, "/Assets/Icons/others/co2.png")), figure = "132", text = "二氧化碳" });
            myItems.Add(new Items() { icon = new BitmapImage(new Uri(mainIcon.BaseUri, "/Assets/Icons/others/co2.png")), figure = "132", text = "二氧化碳" });
            myItems.Add(new Items() { icon = new BitmapImage(new Uri(mainIcon.BaseUri, "/Assets/Icons/others/co2.png")), figure = "132", text = "二氧化碳" });
           

        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
               // cityNameText.Text = $"{e.Parameter.ToString()}";
                try
                {
                    getCity();
               // Pages.Parameters.collections = await Pages.Parameters.SettingsService.LoadSettings();
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
                //if (localSettings.Values["Collections"] != null)
                //{
                   // Pages.Parameters.collections = localSettings.Values["Collections"] as string[];

                //}
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
                //var mySun = await SunRise.SunRise.getSunRise(cityName);


                curTempText.Text = myWeather.results[0].now.temperature + "°C";
                cityNameText.Text = cityName;
                //添加对应天气的图片
                // tomoText.Text = "明日天气：" + myForcast.results[0].data[0].temperature + " " + myForcast.results[0].data[0].text;
                var weatherCode = "/Assets/Icons/white/" + Convert.ToString(myWeather.results[0].now.code) + "@2x.png";
                mainIcon.Source = new BitmapImage(new Uri(mainIcon.BaseUri, weatherCode));

                string[] lastUpdate = myWeather.results[0].last_update.Split("T");
                lastUpdatedText.Text = "最后更新：" + lastUpdate[1].Substring(0, 5);
                mainDisc.Text = myWeather.results[0].now.text;


               // text.Text =Convert.ToString(Pages.Parameters.collections);

                //suggestionText.Text = mySuggestion.results[0].suggestion.car_washing.details ;
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
                Pages.Parameters.cityName = "err";
                var weatherCode = "/Assets/Icons/white/99@2x.png";
                mainIcon.Source = new BitmapImage(new Uri(mainIcon.BaseUri, weatherCode));
                cityNameText.Text = "Error";
                curTempText.Text = "--°C";
                tomoText.Text = " ";
                var dialog = new ContentDialog()    //消息框
                {
                    Title = "消息提示",
                    Content = "错误！",
                    PrimaryButtonText = "确定",
                    
                    FullSizeDesired = false,
                };

                dialog.PrimaryButtonClick += (_s, _e) => { };
                await dialog.ShowAsync();

            }




        }

        private void MainDetailListView_ItemClick(object sender, ItemClickEventArgs e)
        {
             
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            if (collectionIcon.Symbol == Symbol.SolidStar)
            {
                //ArrayList al = new ArrayList(Pages.Parameters.collections);
                //int index = al.Count;
                // al.RemoveAt(index - 1);
                Pages.Parameters.collections.Remove(Pages.Parameters.cityName);
                //Pages.Parameters.collections.Remove(Pages.Parameters.cityName);
                collectionIcon.Symbol = Symbol.OutlineStar;
               

                Frame.Navigate(typeof(Collection),"0");
                Frame.Navigate(typeof(HomePage));
            }
            else if(Pages.Parameters.cityName!= "err")
            {
                Pages.Parameters.collections.Add(Pages.Parameters.cityName);
                collectionIcon.Symbol = Symbol.SolidStar;
                
                Frame.Navigate(typeof(Collection), "1");
                Frame.Navigate(typeof(HomePage));

                // localSettings.Values["Collections"] = Pages.Parameters.collections;




            }
        }
    }
}
