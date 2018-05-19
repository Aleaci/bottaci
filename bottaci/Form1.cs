using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bottaci
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Path.Text = Properties.Settings.Default.bluestack_path;
            try
            {
                Process.Start(Properties.Settings.Default.bluestack_path);
            }
            catch (Exception)
            {
                MessageBox.Show("Errore nell'apertura di Bluestacks", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Browse_Click(object sender, EventArgs e)
        {
            openDir.InitialDirectory = "C:\\";
            openDir.Filter = "Bluestacks.exe|*.exe";
            openDir.Multiselect = false;

            if (openDir.ShowDialog() == DialogResult.OK)
            {
                Path.Text = openDir.FileName;
            }
        }
        private void Save_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.bluestack_path = Path.Text;
            Properties.Settings.Default.Save();
            MessageBox.Show("Path salvata!", "Completato", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void openBlues_Click_1(object sender, EventArgs e)
        {
            try
            {
                Process.Start(Path.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Errore nell'apertura di Bluestacks", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
