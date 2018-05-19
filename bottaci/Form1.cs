using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bottaci
{
    public partial class Form1 : Layer
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            string path = Path.Text;
            Properties.Settings.Default["we"] = path;
            Properties.Settings.Default.Save();
        }

    }
}
