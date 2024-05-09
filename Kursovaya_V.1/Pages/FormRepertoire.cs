using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kursovaya_V._1.Pages;

namespace Kursovaya_V._1.Pages
{
    public partial class FormRepertoire : Form
    {
        private DataBaseManager _dbManager;
        private string connectionString
            = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=CinemaDb2;Integrated Security=True";

        private DataView reperView;
        public FormRepertoire()
        {
            InitializeComponent();
            _dbManager = new DataBaseManager(connectionString);


            dataGridView1.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;
            var selectedRow = dataGridView1.SelectedRows[0];

            // идишник группы, выбранный в данный момент!
            string id = selectedRow
                .Cells["RepertoireId"]
                .Value
                .ToString();

            if (reperView == null || string.IsNullOrEmpty(id))
                return;

            // применим фильрацию данных - синтаксис SQL
            reperView.RowFilter = $"RepertoireId = {id}";
        }

      
        private void button1_Click(object sender, EventArgs e)
        {
            _dbManager.LoadTable(EnumTable.Repertoire);
          //  reperView = _dbManager.ViewTable(EnumTable.Repertoire);
            dataGridView1.DataSource = _dbManager.ViewTable(EnumTable.Repertoire);

            dataGridView1
                .Columns["RepertoireId"].Visible = false;



            dataGridView1.Columns["Movie"].HeaderText = "Фильм";
            dataGridView1.Columns["Cinema"].HeaderText = "Кинотеатр";
            dataGridView1.Columns["Date"].HeaderText = "Дата";
            dataGridView1.Columns["NumberSeats"].HeaderText = "Кол-во свободных мест";
            dataGridView1.Columns["Price"].HeaderText = "Цена";

            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToResizeRows = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var window = new FormEditRepertoire(_dbManager);
            window.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var windowback = new Form2();
            windowback.Show();
            this.Hide();
        }

      
    }
}
