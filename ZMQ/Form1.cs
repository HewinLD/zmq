using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ZMQ
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (File.Exists("00.txt"))
            {
                try
                {
                    Oculus.Newtonsoft.Json.Linq.JObject jo = Oculus.Newtonsoft.Json.Linq.JObject.Parse(File.ReadAllText("00.txt"));
                    string json = jo.ToString();
                    StringBuilder stb = new StringBuilder("");
                    for (int i = 0; i < json.Length; i++)
                    {
                        bool flag2 = Regex.IsMatch(json[i].ToString(), "[\\u4e00-\\u9fa5]|[\\（\\）\\《\\》\\—\\；\\，\\。\\“\\”\\！\\？\\｛\\｝\\【\\】\\、\\‘\\’]");
                        if (flag2)
                        {
                            stb.Append("\\u" + ((int)json[i]).ToString("x"));
                        }
                        else
                        {
                            stb.Append(json[i].ToString());
                        }
                    }
                    stb.Insert(1, "//制作者：碧蓝之星汉化组，下载地址：http://blzxteam.com/blbzcn");
                    File.WriteAllText(Path.Combine("汉化.txt"), stb.ToString());
                    MessageBox.Show("操作完成");
                }
                catch (Exception ex){ MessageBox.Show(ex.ToString(), "发生了错误"); }
                }
            else MessageBox.Show("未找到00.txt");
        }
    }
}
