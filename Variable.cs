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
    }
}
