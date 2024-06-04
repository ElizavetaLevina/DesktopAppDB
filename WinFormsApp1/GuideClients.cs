using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.Model;

namespace WinFormsApp1
{
    public partial class GuideClients : Form
    {
        public GuideClients()
        {
            InitializeComponent();
        }

        private void UpdateTable()
        {
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "ФИО клиента";
            dataGridView1.Columns[1].Width = 270;
            dataGridView1.Columns[2].HeaderText = "Раб. телефон";
            dataGridView1.Columns[2].Width = 170;
            dataGridView1.Columns[3].HeaderText = "Дом. телефон";
            dataGridView1.Columns[3].Width = 170;

        }

        private void GuideClients_Activated(object sender, EventArgs e)
        {
            buttonAll.Focus();
            using Context context = new();
            var list = context.Clients.Select(a => new
            {
                a.Id,
                a.NameClient,
                a.NumberPhoneWork,
                a.NumberPhoneHome
            }).ToList();
            dataGridView1.DataSource = list;
            UpdateTable();
        }

        private void TextBoxEnterName_TextChanged(object sender, EventArgs e)
        {
            using Context context = new();
            var list = context.Clients.Where(i => i.NameClient.IndexOf(textBoxEnterName.Text) > -1).Select(a => new
            {
                a.Id,
                a.NameClient,
                a.NumberPhoneWork,
                a.NumberPhoneHome
            }).ToList();
            dataGridView1.DataSource = list;
        }

        private void ButtonAll_Click(object sender, EventArgs e)
        {
            using Context context = new();
            var list = context.Clients.Select(a => new
            {
                a.Id,
                a.NameClient,
                a.NumberPhoneWork,
                a.NumberPhoneHome
            }).ToList();
            dataGridView1.DataSource = list;
            UpdateTable();
        }

        private void ButtonWhite_Click(object sender, EventArgs e)
        {
            using Context context = new();
            var list = context.Clients.Where(i => i.TypeClient == "white").Select(a => new
            {
                a.Id,
                a.NameClient,
                a.NumberPhoneWork,
                a.NumberPhoneHome
            }).ToList();
            dataGridView1.DataSource = list;
            UpdateTable();
        }

        private void ButtonNormal_Click(object sender, EventArgs e)
        {
            using Context context = new();
            var list = context.Clients.Where(i => i.TypeClient == "normal").Select(a => new
            {
                a.Id,
                a.NameClient,
                a.NumberPhoneWork,
                a.NumberPhoneHome
            }).ToList();
            dataGridView1.DataSource = list;
            UpdateTable();
        }

        private void ButtonBlack_Click(object sender, EventArgs e)
        {
            using Context context = new();
            var list = context.Clients.Where(i => i.TypeClient == "black").Select(a => new
            {
                a.Id,
                a.NameClient,
                a.NumberPhoneWork,
                a.NumberPhoneHome
            }).ToList();
            dataGridView1.DataSource = list;
            UpdateTable();
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
