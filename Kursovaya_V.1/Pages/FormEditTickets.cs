using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursovaya_V._1.Pages
{
    public partial class FormEditTickets : Form
    {
        private DataBaseManager _dbManager;
        private DataView _ticketsView;
  
        private DataView _ticketsSessionView;

        private string _selectedTicketsId;
        private string _selectedSessionId;
        public FormEditTickets(DataBaseManager dataManager)
        {
            InitializeComponent();
            _dbManager = dataManager;
            _ticketsView = _dbManager.ViewTable(EnumTable.Tickets);
            _ticketsSessionView = _dbManager.ViewTable(EnumTable.Session);

            dataGridView1.DataSource = _ticketsView;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;

            comboBox1.DataSource = _ticketsView;
            comboBox1.DisplayMember = "Date";
            comboBox1.ValueMember = "SessionId";

            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedSessionId = comboBox1.SelectedIndex.ToString();
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;
            var row = dataGridView1.SelectedRows[0];

            _selectedTicketsId = row.Cells["TicketsId"].Value.ToString();
            string price = row.Cells["Price"].Value.ToString();
            string sessionid = row.Cells["SessionId"].Value.ToString();

            textBoxPrice.Text = price;
            comboBox1.Text = sessionid;

        }

       

        private void AddTickets_Click(object sender, EventArgs e)
        {
            _dbManager.AddTickets(textBoxPrice.Text, comboBox1.Text);
        }

        private void SaveTickets_Click(object sender, EventArgs e)
        {
            if (_dbManager.SaveChanges(EnumTable.Tickets))
            {
                MessageBox.Show("Успешно сохранено");
            }
        }

        private void RemoveTickets_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedTicketsId))
            {
                MessageBox.Show("Выберите билет для удаления");
                return;
            }
            _dbManager.RemoveTickets(_selectedTicketsId);
        }
    }
}
