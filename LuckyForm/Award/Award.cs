using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Award
{
    public static class Award
    {
        //生成乱序随机数
        static RandomHelp r = new RandomHelp();
        
        //取随机数信号量
          static bool IsGoOn;

        public static Panel labels
        {
            get;
            set;
        }

        #region 界面委托
        public static Action<Label, string> UpdateLabel;
        public static Action<int> ShowMessage;
     
        #endregion 界面委托




        #region 中奖保存数组
        static int i = 0;

        static int index;             //中奖者的下标(滚动下标)    
        static int wined = 0;         //已抽出的中奖人数

        public static int Wined
        {
            get { return wined; }
            set { wined = value; }
        }

        private static object WriteLock=new object ();
        public static string[] AwardName;                     //奖票号数组(所有成员)

        public static string[] wintemp = new string[ConfigNumer.allAwardCount]; //保存中等奖的下标(防止重复中奖)

        public static string[] yiwinner = new string[ConfigNumer.one];  //一等奖获得者
        public static string[] erwinner = new string[ConfigNumer.two];  //二等奖获得者
        public static string[] sanwinner = new string[ConfigNumer.three]; //三等奖获得者
        public static string[] siwinner = new string[ConfigNumer.four]; //四等奖获得者
        public static string[] againwinner = new string[ConfigNumer.again]; //重新抽奖获得者
        #endregion 中奖保存数组

        //加载所有奖券号码到数组AwardName
        public static string[] Award_Load()
        {
            int s = ConfigNumer.start;
            AwardName = new string[ConfigNumer.AllPer + s];

            int j;
            for (j = s; j <= (s + ConfigNumer.AllPer); j++)
            {
                AwardName[i] = j.ToString();
                i++;
            }
            return AwardName;
        }


        //产生随机数
        public static string Award_Random_Next()
        {
            
            string Text = "";
            bool ishave = true;//是否重复   
            while (ishave)
            {
                ishave = false;      //初始化
                index = r.GetNumber(0, ConfigNumer.AllPer);
                Text = AwardName[index];
                foreach (string awin in wintemp)
                {
                    if (Text == awin)
                    {
                        ishave = true;
                        break;
                    }
                }

                ishave = ishave || CheckLabel(Text);
            }
            return Text.Trim();
        }

        /// <summary>
        /// 检查label中存在此文本内容
        /// </summary>
        /// <param name="text">文本内容</param>
        /// <returns></returns>
        public static bool CheckLabel(string text)
        {
            bool ishave = false;
            foreach (Control c in labels.Controls)
            {
                if (c is Label && ((Label)c).Name.Contains("award"))
                {
                    if (text == ((Label)c).Text)
                    {
                        ishave = true;
                        break;
                    }
                }
            }

            return ishave;
        }



        //点击停止时再次查重
        /// <summary>
        /// 这时label不运动停止，如有重复在取出一个替换.主要确保label不重复。
        /// </summary>
        /// <returns></returns>
        public static void  CheckLabelStop()
        {
            
           
            foreach (Control c in labels.Controls)
            {
                if (c is Label && ((Label)c).Name.Contains("award"))
                {
                    string text = ((Label)c).Text;
                   if (CheckLabel(text))
                   {
                        
                        UpdateLabel(((Label)c), Award_Random_Next());
                    }
                }
            }

           
        }


        /// <summary>
        /// 保存label上的内容到数组
        /// </summary>
        /// <param name="dj">抽奖等级</param>
        public static void Save(int dj)
        {
            lock (WriteLock)
            {
                foreach (Control c in labels.Controls)
                {
                    if (c is Label && ((Label)c).Name.Contains("award")&& ((Label)c).Name!="")
                    {
                        string text = ((Label)c).Text;
                        Award_Save(dj, text);
                    }
                }
            }
        }


        //计算一等奖 二等奖 数组中已经存放了多少人(未考虑线程安全)
        public static int Award_Num(int dj)
        {
            int re = 0;  //计数器

            if (dj == 1)
            {
                foreach (string n in yiwinner)
                {
                    if (n != null)
                    {
                        re++;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else if (dj == 2)
            {
                foreach (string n in erwinner)
                {
                    if (n != null)
                    {
                        re = re + 1;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else if (dj == 3)
            {
                foreach (string n in sanwinner)
                {
                    if (n != null)
                    {
                        re = re + 1;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            else if (dj == 4)
            {
                foreach (string n in siwinner)
                {
                    if (n != null)
                    {
                        re = re + 1;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else if (dj == 5)
            {
                foreach (string n in againwinner)
                {
                    if (n != null)
                    {
                        re = re + 1;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return re;
        }

       

        //保存选出的数组(未考虑线程安全)
        public static void Award_Save(int dj, string Text)
        {
       
                int save = Award_Num(dj);
                switch (dj)
                {
                    case 1:

                        yiwinner[save] = Text;
                        wintemp[wined] = Text;         //已抽出的中奖人数
                        wined++;
                        break;
                    case 2:
                        erwinner[save] = Text;
                        wintemp[wined] = Text;         //已抽出的中奖人数
                        wined++;
                        break;
                    case 3:
                        sanwinner[save] = Text;
                        wintemp[wined] = Text;         //已抽出的中奖人数
                        wined++;
                        break;
                    case 4:
                        siwinner[save] = Text;
                        wintemp[wined] = Text;         //已抽出的中奖人数
                        wined++;
                        break;
                    case 5:
                        againwinner[save] = Text;
                        wintemp[wined] = Text;         //已抽出的中奖人数
                        wined++;
                        break;

                }
            
        }


        

        //把全部中奖名单存放在D:\\AwardFile.txt
        public static   void Writetext()
        {
            using (StreamWriter sw = new StreamWriter("D:\\AwardFile.txt", false))
            {

                sw.Write("中奖人名单 ");
                sw.WriteLine("中奖人名单");
                sw.WriteLine("-------------------");
                // Arbitrary objects can also be written to the file.
                sw.Write("一等奖： ");
                foreach (string n in yiwinner)
                {
                    sw.WriteLine(n);

                }
                sw.WriteLine("-------------------");
                sw.WriteLine("二等奖： ");
                foreach (string n in erwinner)
                {
                    sw.WriteLine(n);

                }
                sw.WriteLine("-------------------");
                sw.WriteLine("三等奖： ");
                foreach (string n in sanwinner)
                {
                    sw.WriteLine(n);
                }
                sw.WriteLine("-------------------");
                sw.WriteLine("纪念奖： ");
                foreach (string n in siwinner)
                {
                    sw.WriteLine(n);
                }
                sw.WriteLine("-------------------");
                sw.WriteLine("重新抽奖： ");
                foreach (string n in againwinner)
                {
                    sw.WriteLine(n);
                }
                sw.Close();
            }

        }

        //打印当前抽出号码如三等奖 1到10 号
        public static void WriteNumText(int dj, int cc)
        {
            using (StreamWriter sw = new StreamWriter("D:\\AwardNumFile.txt", false))
            {
                if (dj == 1)
                {
                    sw.WriteLine("一等奖");
                    if (cc < 10)
                    {
                        sw.WriteLine("第1到" + cc.ToString() + "获奖者：");
                        for (i = 0; i < cc; i++)
                        {
                            if (yiwinner[i] == null)
                                break;
                            sw.WriteLine(yiwinner[i]);
                        }
                    }

                }
                if (dj == 2)
                {
                    sw.WriteLine("二等奖：");
                    if (cc < 10)
                    {
                        sw.WriteLine("第1到" + cc.ToString() + "获奖者为：");
                        for (i = 0; i < cc; i++)
                        {
                            if (erwinner[i] == null)
                                break;
                            sw.WriteLine(erwinner[i]);
                        }
                    }

                }
                if (dj == 3)
                {

                    sw.WriteLine("三等奖：");
                    sw.WriteLine("第" + (cc - 10 + 1).ToString() + "到" + cc.ToString() + "获奖者为：");
                    for (i = (cc - 10); i < cc; i++)
                    {
                        if (sanwinner[i] == null)
                            break;
                        sw.WriteLine(sanwinner[i]);
                    }

                }
                if (dj == 4)
                {

                    sw.WriteLine("幸运奖：");
                    sw.WriteLine("第" + (cc - 10 + 1).ToString() + "到" + cc.ToString() + "获奖者为：");
                    for (i = (cc - 10); i < cc; i++)
                    {
                        if (siwinner[i] == null)
                            break;
                        sw.WriteLine(siwinner[i]);
                    }

                }
                if (dj == 5)
                {
                    sw.WriteLine("重新抽奖获奖者为：");
                    if (cc < 10)
                    {
                        sw.WriteLine("第1到" + cc.ToString() + "获奖者为：");
                        for (i = 0; i < cc; i++)
                        {
                            if (againwinner[i] == null)
                                break;
                            sw.WriteLine(againwinner[i]);
                        }
                    }
                    else
                    {
                        sw.WriteLine("第" + (cc - 10 + 1).ToString() + "到" + cc.ToString() + "获奖者为：");
                        for (i = (cc - 10); i < cc; i++)
                        {
                            if (againwinner[i] == null)
                                break;
                            sw.WriteLine(againwinner[i]);
                        }
                    }
                }

            }

        }
        //把当前中奖打印存放到D:\\AwardTmpFile.txt
        public static void WriteTmptext()
        {
            using (StreamWriter sw = new StreamWriter("D:\\AwardTmpFile.txt", false))
            {
                foreach (string n in wintemp)
                {
                    sw.WriteLine(n);
                }
                sw.Close();
            }
        }


        /// <summary>
        /// 查重复
        /// </summary>
        /// <returns>重复返回true 不重复返回false</returns>
        public static  bool IsRepeat()
        {
            bool Repeated = false;
            foreach (string text in wintemp)
            {
                int i = 0;
                foreach (string text2 in wintemp)
                {
                    if (text == text2 && text != null && text2 != null)
                    {
                        i++;
                    }
                }
                if (i > 1)
                {
                    //againwinner[0] = text;
                    Repeated = true;
                    break;
                }
            }
            return Repeated;
        }



        #region 处理Label

        private static List<Task> listtasks = new List<Task>();
        private static TaskFactory tf = new TaskFactory();

        //public Award()
        //{

        //}

        //             labels                        更新委托                           Form的ShowMessage方法
        //public  Award(Panel labels, Action<Label, string> UpdateLabel , Func<string, DialogResult> ShowMessage)
        //{
        //    this.labels = labels;
        //    this.UpdateLabel += UpdateLabel;
        //    this.ShowMessage += ShowMessage;
        //}

        public static void Award_Start(int dj)
        {
            try
            {
                IsGoOn = true;
                foreach (Control c in labels.Controls)
                {
                    if (c is Label)
                    {
                        Label mylabel = (Label)c;
                        c.Text = "";
                        Task t = tf.StartNew(() =>
                         {
                             while (IsGoOn)
                             {
                                 string text = Award_Random_Next();
                                
                                 UpdateLabel(mylabel, text);
                                 Thread.Sleep(100);
                             }
                         });
                        listtasks.Add(t);
                    }
                }

                tf.ContinueWhenAll(listtasks.ToArray(), t =>
                 {
                     CheckLabelStop();
                     Save(dj);
                     ShowMessage(dj);
                 }
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static void Stop()
        {
            IsGoOn = false;
        }

        #endregion 处理Label
    }
}
