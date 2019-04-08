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
    public partial class ViewProcess : Form
    {
        public ViewProcess()
        {
            InitializeComponent();
        }

        private void rtxt_View_TextChanged(object sender, EventArgs e)
        {
            rtxt_View.SelectionStart = rtxt_View.Text.Length;
            // scroll it automatically
            rtxt_View.ScrollToCaret();
        }
    }
}
