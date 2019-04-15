using LLQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Pages
{
    public class Parameters
    {
        public static string cityName = "北京";
        public static Boolean signal = false;
        public static void getCity(string s)
        {
            cityName = s;
        }

        public static string setCity()
        {
            return cityName;
        }

        public static void setSig()
        {
            signal = true;
                 
        }
    }
    
    
    
}
