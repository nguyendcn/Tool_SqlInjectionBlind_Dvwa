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
        private static int quantity_Columns = 0;
        private static int index_Columns = 0;

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

        public static int Quantity_Columns
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
    }
}
