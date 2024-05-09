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
    public partial class FormDataFilm : Form
    {
        private string connectionString
          = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=CinemaDb2;Integrated Security=True";
        private DataBaseManager _dbManager;
        private DataView movieView;

    
        public FormDataFilm()
        {
            InitializeComponent();
            _dbManager = new DataBaseManager(connectionString);

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;
            var row = dataGridView1.SelectedRows[0];

          
            string Director = row.Cells["Director"].Value.ToString();
            string Genre = row.Cells["Genre"].Value.ToString();
            string Country = row.Cells["Country"].Value.ToString();
          


            textBox1.Text = Genre;
            textBox2.Text = Country;
            textBox3.Text = Director;
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;
            var selectedRow = dataGridView1.SelectedRows[0];

            // идишник группы, выбранный в данный момент!
            string id = selectedRow
                .Cells["MovieId"]
                .Value
                .ToString();

            if (movieView == null || string.IsNullOrEmpty(id))
                return;

            // применим фильрацию данных - синтаксис SQL
            movieView.RowFilter = $"CinemaId = {id}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _dbManager.LoadTable(EnumTable.Movie);
            movieView = _dbManager.ViewTable(EnumTable.Movie);
            dataGridView1.DataSource = movieView;

            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToResizeRows = false;

            dataGridView1
                .Columns["MovieId"]
                .Visible = false;
            dataGridView1
                .Columns["NameMovie"]
                .HeaderText = "Фильм";
            dataGridView1
                .Columns["Director"]
                  .Visible = false;
               // .HeaderText = "Режиссер";
            dataGridView1
                .Columns["Operator"]
                  .Visible = false;
               // .HeaderText = "Оператор";
            dataGridView1
                .Columns["Actors"]
                  .Visible = false;
                //.HeaderText = "Актеры";
            dataGridView1
                .Columns["Genre"]
                  .Visible = false;
                //.HeaderText = "Жанр";
            dataGridView1
               .Columns["Country"]
                 .Visible = false;
              // .HeaderText = "Страна";
            dataGridView1
               .Columns["FilmAwards"]
                 .Visible = false;
               //.HeaderText = "Награды";
            dataGridView1
               .Columns["SessionDuration"]
                 .Visible = false;
              // .HeaderText = "Статус номера";
            dataGridView1
                .Columns["CinemaId"]
                .Visible = false;
            // .HeaderText = "Ид кинотеатра";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var windowback = new FormHelpDesk();
            windowback.Show();
            this.Hide();
        }

       
    }
}
