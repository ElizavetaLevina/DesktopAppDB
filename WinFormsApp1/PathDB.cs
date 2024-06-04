using System;

namespace WinFormsApp1
{
    public partial class PathDB : Form
    {
        public PathDB()
        {
            InitializeComponent();
            textBoxPath.Text = Properties.Settings.Default.PathDB;
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var dir = Path.GetDirectoryName(Properties.Settings.Default.PathDB);
            openFileDialog1.FileName = "computerservice";
            openFileDialog1.InitialDirectory = dir;
            openFileDialog1.Filter = "Data base files(*.db)|*.db|All files(*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            string fileName = openFileDialog1.FileName;

            Properties.Settings.Default.PathDB = fileName;
            Properties.Settings.Default.Save();

            textBoxPath.Text = Properties.Settings.Default.PathDB;
        }
    }
}
