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
    public partial class AddMaster : Form
    {
        public int idKey;
        public AddMaster()
        {
            InitializeComponent();
            UpdateTable();
        }

        private void BtnAddMaster_Click(object sender, EventArgs e)
        {
            AddMasterForm addMasterForm = new(true, 0)
            {
                StartPosition = FormStartPosition.CenterParent
            };
            addMasterForm.ShowDialog();
            UpdateTable();
        }

        private void BtnChangeMaster_Click(object sender, EventArgs e)
        {
            using Context context = new();
            int numberRow = dataGridView1.CurrentCell.RowIndex;
            int id = Convert.ToInt32(dataGridView1.Rows[numberRow].Cells[0].Value);

            AddMasterForm addMasterForm = new(false, id) 
            {
                StartPosition = FormStartPosition.CenterParent,
                Text = "Изменение информации о мастере"
            };
            addMasterForm.ShowDialog();
            UpdateTable();

        }

        private void BtnDeleteMaster_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                int numberRow = dataGridView1.CurrentCell.RowIndex;
                int id = Convert.ToInt32(dataGridView1.Rows[numberRow].Cells[0].Value);
                CRUD.RemoveMaster(id);
                UpdateTable();
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateTable()
        {
            using Context context = new();
            dataGridView1.DataSource = context.Masters.Select(i => new { i.Id, i.NameMaster, i.NumberPhone}).ToList();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "ФИО";
            dataGridView1.Columns[1].Width = 300;
            dataGridView1.Columns[2].HeaderText = "Телефон";
            dataGridView1.Columns[2].Width = 142;
            if (context.Masters.Any())
            {
                idKey = context.Masters.OrderBy(i => i.Id).Last().Id;
                idKey++;
            }
            else { idKey = 1; }
        }
    }
}
