using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Pages
{
    public class Parameters
    {
        static string cityName;
        public static void getCity(string s)
        {
            cityName = s;
        }

        public static string setCity()
        {
            return cityName;
        }
    }

    //public class CityName
    //{
       //public static string Name;
    //}
   
}
