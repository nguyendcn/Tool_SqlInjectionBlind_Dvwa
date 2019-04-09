using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool_SqlInjectionBlind_Dvwa
{
    public static class Variable
    {
        private static int quantity_Tables = 0;
        private static int index_Tables = 0;
        private static List<int> quantity_Columns = new List<int>();
        private static int index_Columns = 0;
        private static List<int> quantity_Row = new List<int>();
        private static int index_Rows = 0;
        private static int index_clb_Show = 0;

        private static int left = 0;
        private static int mid = 127;
        private static int right = 255;
        private static int index_str = 0;
        private static string str_result = "";
        private static string sql_Request = "";

        private static List<List<List<string>>> bd_DataTable = new List<List<List<string>>>();
        private static string db_Name;
        private static List<string> db_TablesName = new List<string>();
        private static List<List<string>> db_ColumnsName = new List<List<string>>();

        public static int Quantity_Tables
        {
            get
            {
                return quantity_Tables;
            }

            set
            {
                quantity_Tables = value;
            }
        }

        public static int Index_Tables
        {
            get
            {
                return index_Tables;
            }

            set
            {
                index_Tables = value;
            }
        }

        public static int Index_Columns
        {
            get
            {
                return index_Columns;
            }

            set
            {
                index_Columns = value;
            }
        }

        public static string Db_Name
        {
            get
            {
                return db_Name;
            }

            set
            {
                db_Name = value;
            }
        }

        public static List<string> Db_TablesName
        {
            get
            {
                return db_TablesName;
            }

            set
            {
                db_TablesName = value;
            }
        }

        public static List<List<string>> Db_ColumnsName
        {
            get
            {
                return db_ColumnsName;
            }

            set
            {
                db_ColumnsName = value;
            }
        }

        public static List<int> Quantity_Columns
        {
            get
            {
                return quantity_Columns;
            }

            set
            {
                quantity_Columns = value;
            }
        }

        public static List<int> Quantity_Row
        {
            get
            {
                return quantity_Row;
            }

            set
            {
                quantity_Row = value;
            }
        }

        public static List<List<List<string>>> Bd_DataTable
        {
            get
            {
                return bd_DataTable;
            }

            set
            {
                bd_DataTable = value;
            }
        }

        public static int Index_Rows
        {
            get
            {
                return index_Rows;
            }

            set
            {
                index_Rows = value;
            }
        }

        public static int Index_clb_Show { get => index_clb_Show; set => index_clb_Show = value; }
        public static int Left { get => left; set => left = value; }
        public static int Mid { get => mid; set => mid = value; }
        public static int Right { get => right; set => right = value; }
        public static int Index_str { get => index_str; set => index_str = value; }
        public static string Sql_Request { get => sql_Request; set => sql_Request = value; }
        public static string Str_result { get => str_result; set => str_result = value; }

        public static void Reset_Data_Variable()
        {
            Left = 0;
            Mid = 127;
            Right = 255;
            Str_result = "";
            Index_str = 0;
        }

        public static void Get_Data_Variable(ref int left, ref int mid, ref int right, ref int index, ref string str_result, ref string sql)
        {
            left = Variable.Left; mid = Variable.Mid; right = Variable.Right; index = Variable.Index_str;
            str_result = Variable.Str_result; sql = Variable.Sql_Request;
        }

        public static void Set_Data_Variable(int left, int mid, int right, int index, string str_result, string sql)
        {
            Variable.Sql_Request = sql;
            Variable.Left = left;
            Variable.Mid = mid;
            Variable.Right = right;
            Variable.Str_result = str_result;
            Variable.Index_str = index;
        }
    }
}
