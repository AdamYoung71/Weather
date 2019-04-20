using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;


namespace Weather.Models
{
   

    public class Items
    {
        public BitmapImage icon { get; set; }
        public string text { get; set; }
        public string figure { get; set; }

        public Items()
        {
            icon = new BitmapImage();
            text = string.Empty;
            figure = string.Empty;
        }

        public static Items GetItems(string ic, string Text, string num)
        {
            return new Items()
            {
                figure = num,
                text = Text,
                icon = new BitmapImage(new Uri("ms-appx:///Assets/Icons/others/" + ic)),

            };
        }
    }
}
