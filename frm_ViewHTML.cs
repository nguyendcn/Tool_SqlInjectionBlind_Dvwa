using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tool_SqlInjectionBlind_Dvwa
{
    public partial class frm_ViewHTML : Form
    {
        public frm_ViewHTML(string html)
        {
            InitializeComponent();
            this.rtxt_ContentHTML.Text = html;
        }
    }
}
