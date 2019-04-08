using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool_SqlInjectionBlind_Dvwa
{
    public static class Confirm
    {
        private static bool is_Click_btnGNameColumns = false;
        private static bool find_Quantity_Done = false;

        public static bool Is_Click_btnGNameColumns
        {
            get
            {
                return is_Click_btnGNameColumns;
            }

            set
            {
                is_Click_btnGNameColumns = value;
            }
        }

        public static bool Find_Quantity_Done
        {
            get
            {
                return find_Quantity_Done;
            }

            set
            {
                find_Quantity_Done = value;
            }
        }
    }
}
