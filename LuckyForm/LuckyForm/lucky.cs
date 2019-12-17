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

namespace LuckyForm
{
    public partial class lucky : Form
    {
        public int choose;
        //int time=;
       // private int time = 5;
        private StreamReader fileToPrint = null;
        private Font printFont = null;

       
        public  lucky()
        {
            InitializeComponent();

           

          Action<Label, string> updatelabe = (label, text) =>
            {
                if (label.InvokeRequired)
                {
                    this.Invoke(new Action(() =>
                    {
                        label.Text = text;
                    }));
                }
                else
                {
                    label.Text = text;
                }
            };

            Action <int > ShowMessge =(dj)=>
            {
                //更新抽出内容
                if (lblcc.InvokeRequired)
                {
                    this.Invoke(new Action(() =>
                    {
                        lblcc.Text = Award.Award.Award_Num(dj).ToString();
                    }));
                }
                else
                {
                    lblcc.Text = Award.Award.Award_Num(dj).ToString();
                }

                MessageBox.Show("已经抽出所选择的奖项，点击打印");
                try
                {
                   Award.Award.WriteNumText(this.choose, Convert.ToInt32(this.lblcc.Text));
                    this.fileToPrint = new StreamReader(@"D:\AwardNumFile.txt");
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
            };
      
           Award.Award.labels = this.panel1;
            if (Award.Award.UpdateLabel != null)
            {
                Award.Award.UpdateLabel -= Award.Award.UpdateLabel;
            }
            if (Award.Award.ShowMessage != null)
            {
                Award.Award.ShowMessage -= Award.Award.ShowMessage;
            }


            Award.Award.UpdateLabel += updatelabe;
            Award.Award.ShowMessage += ShowMessge;


        }

        private void lucky_Load(object sender, EventArgs e)
        {
            //开始按钮
            this.btnonoff.Enabled = true;
            //结束按钮
            this.btnbc.Enabled = false;

            //显示抽几等奖
            if (choose == 1)
            {
                lblno.Text = "一等奖";
                lblset.Text = ConfigNumer.one.ToString();  //设置名额
                lblcc.Text = Award.Award.Award_Num(1).ToString();    //抽出名额
                                                                     //string path = System.Windows.Forms.Application.StartupPath;
                                                                     //path += "\\1.jpg";
                                                                     ////this.label1.Text = "全自动豪华按摩椅";
                                                                     //this.pictureBox1.Visible = false;
                                                                     //this.pictureBox1.Image = Image.FromFile(path);
                for (int i = 0; i < 1; i++)
                {
                    Label label = new Label();
                    label.Name = "award" + i;
                    label.Font = new Font("隶书", 36, FontStyle.Bold);
                    label.ForeColor = Color.Yellow;
                    label.Text = "";
                    label.Size = new Size(170, 48);
                    label.Location = new Point(10, 10 + 48 * i);
                    panel1.Controls.Add(label);
                }
            }
            else if (choose == 2)
            {
                //string path = System.Windows.Forms.Application.StartupPath;
                //path += "\\2.jpg";
                //this.BackgroundImage = Image.FromFile(path);
                lblno.Text = "二等奖";
                int set = ConfigNumer.two;
                int cc = Award.Award.Award_Num(2);
                lblset.Text = set.ToString();
                lblcc.Text = cc.ToString();
                //string path = System.Windows.Forms.Application.StartupPath;
                //path += "\\2.jpg";
                ////this.label1.Text = "飞利浦空气炸锅";
                //this.pictureBox1.Visible = false;
                //this.pictureBox1.Image = Image.FromFile(path);
                //if (award.Award_Num(choose) > 0)
                //{
                //    this.btnonoff.Text = "开始";
                //    foreach (string n in Award.erwinner)
                //    {
                //        if (n != null)
                //        {
                //            this.listBox1.Items.Add(n);
                //        }
                //    }
                //}
                //10个每次抽出2个 
                int k = 2;
                if ((set - cc) < 2)
                    k = set - cc;
                for (int i = 0; i < k; i++)
                {
                    Label label = new Label();
                    label.Name = "award" + i;
                    label.Font = new Font("隶书", 36, FontStyle.Bold);
                    label.ForeColor = Color.Yellow;
                    label.Text = "";
                    label.Size = new Size(170, 48);
                    label.Location = new Point(10, 10 + 48 * i);
                    panel1.Controls.Add(label);
                }
            }
            else if (choose == 3)
            {
                //string path = System.Windows.Forms.Application.StartupPath;
                //path += "\\3.jpg";
                //this.pictureBox1.Visible = false;
                //this.pictureBox1.Image = Image.FromFile(path);
                ////this.label1.Text = "艾美特电暖气";
                lblno.Text = "三等奖";
                lblset.Text = ConfigNumer.three.ToString();
                lblcc.Text = Award.Award.Award_Num(3).ToString();
                for (int i = 0; i < 10; i++)
                {
                    Label label = new Label();
                    label.Name = "award" + i;
                    label.Font = new Font("隶书", 36, FontStyle.Bold);
                    label.ForeColor = Color.Yellow;
                    label.Text = "";
                    label.Size = new Size(170, 48);
                    label.Location = new Point(10, 10 + 48 * i);
                    panel1.Controls.Add(label);
                }
            }
            else if (choose == 4)
            {
                lblno.Text = "幸运奖";
                lblset.Text = ConfigNumer.four.ToString();
                lblcc.Text = Award.Award.Award_Num(4).ToString();
                //this.pictureBox1.Visible = false;
                for (int i = 0; i < 10; i++)
                {
                    Label label = new Label();
                    label.Name = "award" + i;
                    label.Font = new Font("隶书", 36, FontStyle.Bold);
                    label.ForeColor = Color.Yellow;
                    label.Text = "";
                    label.Size = new Size(170, 48);
                    label.Location = new Point(10, 10 + 48 * i);
                    panel1.Controls.Add(label);
                }
            }
            else if (choose == 5)
            {
                lblno.Text = "重新奖";
                lblset.Text = ConfigNumer.again.ToString();
                lblcc.Text = Award.Award.Award_Num(5).ToString();
                //this.pictureBox1.Visible = false;
                for (int i = 0; i < 1; i++)
                {
                    Label label = new Label();
                    label.Name = "award" + i;
                    label.Font = new Font("隶书", 36, FontStyle.Bold);
                    label.ForeColor = Color.Yellow;
                    label.Text = "";
                    label.Size = new Size(170, 48);
                    label.Location = new Point(10, 10 + 48 * i);
                    panel1.Controls.Add(label);
                }
            }

        }

        private void btnonoff_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(this.lblset.Text) > Convert.ToInt32(this.lblcc.Text))
            {

                Award.Award.Award_Start(choose);
                this.btnonoff.Enabled = false;
                this.btnbc.Enabled = true;
            }
            else
            {
                MessageBox.Show("已经抽出所有的奖项");
            }
        }

        private void btnbc_Click(object sender, EventArgs e)
        {
            Award.Award.Stop();
            this.btnonoff.Enabled = true;
            this.btnbc.Enabled = false ;
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
