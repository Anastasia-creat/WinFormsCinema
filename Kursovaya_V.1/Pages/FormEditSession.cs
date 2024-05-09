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
    public partial class FormEditSession : Form
    {
        private DataBaseManager _dbManager;
        private DataView _session;
        private string _selectedSessionId;

        private DataView _sessionMovieView;
        private string _selectedMovieId;
        public FormEditSession(DataBaseManager dataManager)
        {
            InitializeComponent();
            _dbManager = dataManager;

            _session = _dbManager.ViewTable(EnumTable.Session);

            _sessionMovieView = _dbManager.ViewTable(EnumTable.Movie);

            dataGridView1.DataSource = _session;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;

            comboBox1.DataSource = _sessionMovieView;
            comboBox1.DisplayMember = "NameMovie";
            comboBox1.ValueMember = "MovieId";

            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedMovieId = comboBox1.SelectedIndex.ToString();
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;
            var row = dataGridView1.SelectedRows[0];

            _selectedSessionId = row.Cells["SessionId"].Value.ToString();
            string day = row.Cells["Date"].Value.ToString();
            string time = row.Cells["NumberFreeSeats"].Value.ToString();
            string movieId = row.Cells["MovieId"].Value.ToString();

            textBoxDay.Text = day;
            textBoxTime.Text = time;
            comboBox1.Text = movieId;



        }

        private void AddSession_Click(object sender, EventArgs e)
        {
            _dbManager.AddSession(textBoxDay.Text, textBoxTime.Text, comboBox1.Text);
        }

        private void SaveSession_Click(object sender, EventArgs e)
        {
            if (_dbManager.SaveChanges(EnumTable.Session))
            {
                MessageBox.Show("Успешно сохранено");
            }
        }

        private void RemoveSession_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedSessionId))
            {
                MessageBox.Show("Выберите сеанс для удаления");
                return;
            }
            _dbManager.RemoveSession(_selectedSessionId);
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
