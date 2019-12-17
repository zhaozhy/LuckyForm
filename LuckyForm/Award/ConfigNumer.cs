using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace Award
{
    public static  class ConfigNumer
    {
        public static int one = Convert.ToInt32(ConfigurationManager.AppSettings["one"]);//一等奖人数
        public static int two = Convert.ToInt32(ConfigurationManager.AppSettings["two"]);//二等奖人数
        public static int three = Convert.ToInt32(ConfigurationManager.AppSettings["three"]);//三等奖人数
        public static int four = Convert.ToInt32(ConfigurationManager.AppSettings["four"]);//四等奖人数
        public static int again = Convert.ToInt32(ConfigurationManager.AppSettings["again"]);//如无人领奖补抽
        public static int AllPer = Convert.ToInt32(ConfigurationManager.AppSettings["AllPer"]); //总人数

        public static  int start = Convert.ToInt32(ConfigurationManager.AppSettings["StarNum"]);//印奖票数的开始号码（100开始）

        public static string mp3 = ConfigurationManager.AppSettings["Mp3"].ToString ();

        public static int allAwardCount = one + two + three + four + again;
    }
}
