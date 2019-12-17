using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Award;
using System.Threading;

namespace LuckyForm
{
    public partial class Load : Form
    {
       
        private StreamReader fileToPrint = null;
        private Font printFont = null;
       
        public const int MM_MCINOTIFY = 0x3B9;  //这是声明 播完音乐 mciSendString（）向系统发送的指令
        public Load()
        {
            InitializeComponent();
            Award.Award.Award_Load();

            //Award.MP3 mp3 = new Award.MP3();

            //mp3.FileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "mp3\\" + ConfigNumer.mp3);
            //    mp3.OOPStart();
    
        }


        protected override void DefWndProc(ref Message m)
        {

            base.DefWndProc(ref m);
            //if (m.Msg == MM_MCINOTIFY) //判断指令是不是MM_MCINOTIFY                         //当歌曲播完 mciSendString（）向系统发送的MM_MCINOTIFY指令
            //{
            //    Award.MP3 mp3 = new Award.MP3();
            //    mp3.FileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "mp3\\" + ConfigNumer.mp3);
            //    mp3.OOPStart(); //播完就自动播放这个。。。
            //}
        }

        private void btnstart_Click(object sender, EventArgs e)
        {
        

            if (rdo1.Checked == true)
            {
                lucky luck1 = new lucky();
                luck1.choose = 1;
                
                luck1.ShowDialog();
            }
            else if (rdo2.Checked == true)
            {
                lucky luck2 = new lucky();
                luck2.choose = 2;
               
                luck2.ShowDialog();
            }
            else if (rdo3.Checked == true)
            {
                lucky luck3 = new lucky();
                luck3.choose = 3;
           
                luck3.ShowDialog();
            }

            else if (rdo4.Checked == true)
            {
                lucky luck4 = new lucky();
                luck4.choose = 4;

                luck4.ShowDialog();
            }
            else if (rdo5.Checked == true)
            {
                lucky luck5 = new lucky();
                luck5.choose = 5;
    
                luck5.ShowDialog();
            }
        }

        private void btnrestart_Click(object sender, EventArgs e)
        {
            Award.Award.Writetext();

            DialogResult re = MessageBox.Show(Award.Award.IsRepeat().ToString() , "提醒true是有重复", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            try
            {
                this.fileToPrint = new StreamReader(@"D:\AwardFile.txt");
                this.printFont = new Font("Arial", 50f);
                this.printDocument1.Print();
            }
            catch (Exception te)
            {
                throw te;
            }
            finally
            {
                this.fileToPrint.Close();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            float yPos = 0f;
            int count = 0;
            float leftMargin = e.MarginBounds.Left;
            float topMargin = e.MarginBounds.Top;
            string line = null;
            float linesPerPage = ((float)e.MarginBounds.Height) / this.printFont.GetHeight(e.Graphics);
            while (count < linesPerPage)
            {
                line = this.fileToPrint.ReadLine();
                if (line == null)
                {
                    break;
                }
                yPos = topMargin + (count * this.printFont.GetHeight(e.Graphics));
                e.Graphics.DrawString(line, this.printFont, Brushes.Black, leftMargin, yPos, new StringFormat());
                count++;
            }
            if (line != null)
            {
                e.HasMorePages = true;
            }
        }
    }
}
