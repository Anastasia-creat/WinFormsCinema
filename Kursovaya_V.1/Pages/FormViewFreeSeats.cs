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
    public partial class FormViewFreeSeats : Form
    {
        private string connectionString
          = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=CinemaDb2;Integrated Security=True";
        private DataBaseManager _dbManager;
        private DataView cinemaView;
        private DataView movieView;
        private DataView sessionView;

        public FormViewFreeSeats()
        {
            InitializeComponent();
           
            _dbManager = new DataBaseManager(connectionString);

            dataGridView1.SelectionMode =
               DataGridViewSelectionMode.FullRowSelect;

            dataGridView2.SelectionMode =
               DataGridViewSelectionMode.FullRowSelect;

            dataGridView3.SelectionMode =
              DataGridViewSelectionMode.FullRowSelect;
        }

       

        //кинотеатр
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;
            var selectedRow = dataGridView1.SelectedRows[0];

            // идишник группы, выбранный в данный момент!
            string id = selectedRow
                .Cells["CinemaId"]
                .Value
                .ToString();

            if (cinemaView == null || string.IsNullOrEmpty(id))
                return;

            // применим фильрацию данных - синтаксис SQL
            cinemaView.RowFilter = $"CinemaId = {id}";
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 0) return;
            var selectedRow = dataGridView2.SelectedRows[0];

            // идишник группы, выбранный в данный момент!
            string id = selectedRow
                .Cells["MovieId"]
                .Value
                .ToString();

            if (movieView == null || string.IsNullOrEmpty(id))
                return;

            // применим фильрацию данных - синтаксис SQL
           movieView.RowFilter = $"MovieId = {id}";
        }

       

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView3.SelectedRows.Count == 0) return;
            var selectedRow = dataGridView3.SelectedRows[0];

            string id = selectedRow
                .Cells["SessionId"]
                .Value
                .ToString();

            if (sessionView == null || string.IsNullOrEmpty(id))
                return;

            sessionView.RowFilter = $"SessionId = {id}";
        }


        //кнопка для кинотеатра
        private void button4_Click(object sender, EventArgs e)
        {
            _dbManager.LoadTable(EnumTable.Cinema);
            cinemaView = _dbManager.ViewTable(EnumTable.Cinema);
            dataGridView1.DataSource = cinemaView;

            dataGridView1
                .Columns["CinemaId"]
                .Visible = false;
            dataGridView1
                .Columns["NameCinema"]
                .HeaderText = "Кинотеатр";
            dataGridView1
                .Columns["DistrictOfTheCity"]
                .HeaderText = "Адрес";
            dataGridView1
                .Columns["CategoryOfCinema"]
                .HeaderText = "Категория кинотеатра";
            dataGridView1
               .Columns["Capacity"]
               .HeaderText = "Вместимость";

            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToResizeRows = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _dbManager.LoadTable(EnumTable.Movie);
            movieView = _dbManager.ViewTable(EnumTable.Movie);
            dataGridView2.DataSource = movieView;

            dataGridView2.ReadOnly = true;
            dataGridView2.AllowUserToResizeRows = false;

            dataGridView2
                .Columns["MovieId"]
                .Visible = false;
            dataGridView2
                .Columns["NameMovie"]
                .HeaderText = "Фильм";
            dataGridView2
                .Columns["Director"]
                .HeaderText = "Режиссер";
            dataGridView2
                .Columns["Operator"]
                .HeaderText = "Оператор";
            dataGridView2
                .Columns["Actors"]
                .HeaderText = "Актеры";
            dataGridView2
                .Columns["Genre"]
                .HeaderText = "Жанр";
            dataGridView2
               .Columns["Country"]
               .HeaderText = "Страна";
            dataGridView2
               .Columns["FilmAwards"]
               .HeaderText = "Награды";
            dataGridView2
               .Columns["SessionDuration"]
               .HeaderText = "Статус номера";
            dataGridView2
                .Columns["CinemaId"]
                .Visible = false;
               // .HeaderText = "Ид кинотеатра";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _dbManager.LoadTable(EnumTable.Session);
            movieView = _dbManager.ViewTable(EnumTable.Session);
            dataGridView3.DataSource = movieView;

            dataGridView3.ReadOnly = true;
            dataGridView3.AllowUserToResizeRows = false;

            dataGridView3
                .Columns["SessionId"]
                .Visible = false;
            dataGridView3
                .Columns["Date"]
                .HeaderText = "Дата/Время";
            dataGridView3
                .Columns["NumberFreeSeats"]
                .HeaderText = "Количество свободных мест";
            dataGridView3
                .Columns["MovieId"]
                .Visible = false;
               // .HeaderText = "ИД Фильма";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _dbManager.LoadTable(EnumTable.Tickets);
            sessionView = _dbManager.ViewTable(EnumTable.Tickets);
            dataGridView4.DataSource = sessionView;

            dataGridView4.ReadOnly = true;
            dataGridView4.AllowUserToResizeRows = false;

            dataGridView4
                .Columns["TicketsId"]
                .Visible = false;
            dataGridView4
                .Columns["Price"]
                .HeaderText = "Цена билета";
            dataGridView4
                .Columns["SessionId"]
                .Visible = false;
               // .HeaderText = "ИД Сеанса";
        }

      


        private void button6_Click(object sender, EventArgs e)
        {
            var windowback = new FormHelpDesk();
            windowback.Show();
            this.Hide();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            if (movieView == null) return;
            string textFilter = textBox1.Text;

            movieView.RowFilter =
                $"Genre like '%{textFilter}%' or " +
                $"NameMovie like '%{textFilter}%'";
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (cinemaView == null) return;
            string textFilter = textBox2.Text;

            cinemaView.RowFilter =

                $"NameCinema like '%{textFilter}%'";
        }
    }
}
