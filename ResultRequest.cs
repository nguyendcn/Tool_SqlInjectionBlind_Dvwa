using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool_SqlInjectionBlind_Dvwa
{
    public class ResultRequest
    {
        public enum Result { Exists, Missing, Fail };
        public enum Mode { Number, String};
        public enum Mode_SQL { DB_Name, TABLES_NAME, COLUMNS_NAME}
        public enum Job { Done_ALL, Done_OnePart, Continue, Fail, None}
    }
}
