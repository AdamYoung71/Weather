using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;


namespace Weather.Models
{
    public class DailyWeather
    {
        public string date { get; set; }
        public BitmapImage iconSource { get; set; }
        public string tempreture { get; set; }
        public string descrip { get; set; }

        public DailyWeather() //构造函数
        {
            iconSource = new BitmapImage();
            date = string.Empty;
            tempreture = string.Empty;
            descrip = string.Empty;
        }

        public static DailyWeather getDaily(string Date, string Code, string temp, string desc) //赋值函数
        {
            string code = Convert.ToString(Code);
            return new DailyWeather()
            {
                date = Date,
                tempreture = temp,
                iconSource = new BitmapImage(new Uri("ms-appx:///Assets/Icons/white/" + code + "@2x.png")),
                descrip = desc
            };
        }

        public static ObservableCollection<DailyWeather> GetDailyWeathers(int num)
        {
            ObservableCollection<DailyWeather> dailyWeathers = new ObservableCollection<DailyWeather>();
            for(int i = 0; i< num; i++)
            {
               // dailyWeathers.Add(getDaily("nihao", "3", "yty"));

            }
            return dailyWeathers;
        }
    }

    
}