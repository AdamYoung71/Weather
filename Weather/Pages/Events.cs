using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LLQ;

namespace Weather.Pages
{
    class Events
    {
        //声明一种通知事件
        public class getMyCity
        {
            public string cityName { get; set; }
        }
        
    }
}


//注册并监听事件
/*public class subscriber
{

    public subscriber()
    {
        LLQNotifier.Default.Register(this);
    }
    //给收到通知后要回调的方法加上SubscriberCallback属性

    [SubscriberCallback(typeof(getMyCity), NotifyPriority.Normal, ThreadMode.Background)]
    public void Test()
    {
        Pages.Parameters.cityName = "nihao";
    }
}*/