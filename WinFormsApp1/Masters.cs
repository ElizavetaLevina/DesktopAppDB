﻿using Microsoft.Extensions.DependencyInjection;
using WinFormsApp1.DTO;
using WinFormsApp1.Logic.Interfaces;

namespace WinFormsApp1
{
    public partial class Masters : Form
    {
        public int IdMaster
        {
            get
            {
                return Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].
                Cells[nameof(MasterDTO.Id)].Value);
            }
        }
        IMastersLogic mastersLogic;
        public Masters(IMastersLogic _mastersLogic)
        {
            mastersLogic = _mastersLogic;
            InitializeComponent();
            UpdateTableAsync();
        }

        private void BtnAddMaster_Click(object sender, EventArgs e)
        {
            MasterEdit addMasterForm = Program.ServiceProvider.GetRequiredService<MasterEdit>();
            addMasterForm.ShowDialog();
            UpdateTableAsync();
        }

        private void BtnChangeMaster_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                MasterEdit addMasterForm = Program.ServiceProvider.GetRequiredService<MasterEdit>();
                addMasterForm.newMaster = false;
                addMasterForm.idMaster = IdMaster;
                addMasterForm.Text = "Изменение информации о мастере";
                addMasterForm.ShowDialog();
                UpdateTableAsync();
            }
        }

        private async void BtnDeleteMaster_ClickAsync(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                var masterDTO = await mastersLogic.GetMasterAsync(IdMaster);
                await mastersLogic.RemoveMasterAsync(masterDTO);
                UpdateTableAsync();
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void UpdateTableAsync()
        {
            dataGridView1.DataSource = await mastersLogic.GetMastersForOutputAsync();
            dataGridView1.Columns[nameof(MasterDTO.Id)].Visible = false;
            dataGridView1.Columns[nameof(MasterDTO.NameMaster)].HeaderText = "ФИО";
            dataGridView1.Columns[nameof(MasterDTO.NumberPhone)].HeaderText = "Телефон";

            int[] percent = [0, 40, 60];
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                double width = Convert.ToDouble(dataGridView1.Width) / 100.0 * percent[i];
                dataGridView1.Columns[i].Width = Convert.ToInt32(width);
            }
        }
    }
}
