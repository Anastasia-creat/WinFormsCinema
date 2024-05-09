using Kursovaya_V._1.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

 using MsWord = Microsoft.Office.Interop.Word;

namespace Kursovaya_V._1
{
    public partial class FormFilm : Form
    {

       
        private DataBaseManager _dbManager;
        private string connectionString
            = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=CinemaDb2;Integrated Security=True";

        private DataView cinemaView;
        private DataView movieView;
        private DataView sessionView;
        private DataView ticketView;

        public FormFilm()
        {
            InitializeComponent();
            _dbManager = new DataBaseManager(connectionString);

            
            dataGridView1.SelectionMode =  DataGridViewSelectionMode.FullRowSelect;
           // dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;

            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
          //  dataGridView2.SelectionChanged += DataGridView2_SelectionChanged;

            dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
          //  dataGridView3.SelectionChanged += DataGridView3_SelectionChanged;

            dataGridView4.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
          //  dataGridView4.SelectionChanged += DataGridView4_SelectionChanged;
                

        }

        private void DataGridView4_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView4.SelectedRows.Count == 0) return;
            var selectedRow = dataGridView4.SelectedRows[0];

            string id = selectedRow
                .Cells["TicketsId"]
                .Value
                .ToString();

            if (ticketView == null || string.IsNullOrEmpty(id)) return;
            ticketView.RowFilter = $"TicketsId = {id}";
        }

        private void DataGridView3_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView3.SelectedRows.Count == 0) return;
            var selectedRow = dataGridView3.SelectedRows[0];

            string id = selectedRow
                .Cells["SessionId"]
                .Value
                .ToString();

            if (sessionView == null || string.IsNullOrEmpty(id)) return;
            sessionView.RowFilter = $"SessionId = {id}";
                
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
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

        private void DataGridView2_SelectionChanged(object sender, EventArgs e)
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




        public void LoadCinema()
        {


            _dbManager.LoadTable(EnumTable.Cinema);
            cinemaView = _dbManager.ViewTable(EnumTable.Cinema);
            dataGridView1.DataSource = cinemaView;

            dataGridView1
                .Columns["CinemaId"].Visible = false; 
               


            dataGridView1.Columns["NameCinema"].HeaderText = "Кинотеатр";
            dataGridView1.Columns["DistrictOfTheCity"].HeaderText = "Район";
            dataGridView1.Columns["CategoryOfCinema"].HeaderText = "Категория";
            dataGridView1.Columns["Capacity"].HeaderText = "Вместимость";

            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToResizeRows = false;
        }

        public void LoadMovie()
        {
            _dbManager.LoadTable(EnumTable.Movie);
            movieView = _dbManager.ViewTable(EnumTable.Movie);
            dataGridView2.DataSource = movieView;



            dataGridView2.Columns["MovieId"].Visible = false; ;
            dataGridView2.Columns["NameMovie"].HeaderText = "Фильм";
            dataGridView2.Columns["Director"].HeaderText = "Режиссёр";
            dataGridView2.Columns["Operator"].HeaderText = "Оператор";
            dataGridView2.Columns["Actors"].HeaderText = "Актеры";
            dataGridView2.Columns["Genre"].HeaderText = "Жанр";
            dataGridView2.Columns["Country"].HeaderText = "Страна";
            dataGridView2.Columns["FilmAwards"].HeaderText = "Награды фильма";
            dataGridView2.Columns["SessionDuration"].HeaderText = "Продолжительность сеанса";
           
            // dataGridView2.Columns["CinemaId"].Visible = false;
            dataGridView2.Columns["CinemaId"].HeaderText = " ИД Кинотеатра";
            dataGridView2.ReadOnly = true;
            dataGridView2.AllowUserToResizeRows = false;
        }

        public void LoadSession()
        {
            _dbManager.LoadTable(EnumTable.Session);
            sessionView = _dbManager.ViewTable(EnumTable.Session);
            dataGridView3.DataSource = sessionView;

            dataGridView3.Columns["SessionId"].Visible = false; ;
            dataGridView3.Columns["Date"].HeaderText = "Дата и время";
            dataGridView3.Columns["NumberFreeSeats"].HeaderText = "Количество свободных мест";
            // dataGridView3.Columns["MovieId"].Visible = false;
            dataGridView3.Columns["MovieId"].HeaderText = "ИД Фильма";
            dataGridView3.ReadOnly = true;
            dataGridView3.AllowUserToResizeRows = false;
        }

        public void LoadTickets()
        {
            _dbManager.LoadTable(EnumTable.Tickets);
            dataGridView4.DataSource = _dbManager.ViewTable(EnumTable.Tickets);

            dataGridView4.Columns["TicketsId"].Visible = false; ;
            dataGridView4.Columns["Price"].HeaderText = "Стоимость";
            dataGridView4.Columns["SessionId"].HeaderText = "ИД Сеанса";

            dataGridView4.ReadOnly = true;
            dataGridView4.AllowUserToResizeRows = false;
        }



        private void btnLoadCinema_Click(object sender, EventArgs e)
        {

            LoadCinema();
            LoadMovie();
            LoadSession();
            LoadTickets();


        }

        //Отчет
        private void button7_Click(object sender, EventArgs e)
        {
            //1 - Запускаем процесс MS Word
            var wordApp = new MsWord.Application();

            //2 - Добавим документ
            wordApp.Documents.Add();

            //3 - Добавим текст
            //Сначала нужно выбрать документ - нумерация с единицы
            MsWord.Document doc = wordApp.Documents[1];

            doc.Paragraphs.Add();
            MsWord.Paragraph paragraph = doc.Paragraphs[1];
            paragraph.Range.Text = $"Здравствуйте, сегодня {DateTime.Now}";

            doc.Paragraphs.Add();
            paragraph = doc.Paragraphs[2];
            paragraph.Range.Text = "Отчет о работе кинотеатров за последний месяц";

            paragraph.Alignment = MsWord.WdParagraphAlignment.wdAlignParagraphCenter;
            paragraph.Range.Font.Bold = 1;
            paragraph.Range.Font.Color = MsWord.WdColor.wdColorAqua;

            doc.Paragraphs.Add();
            paragraph = doc.Paragraphs[3];
            paragraph.Range.Text = "Таблица с данными";
            paragraph.Alignment = MsWord.WdParagraphAlignment.wdAlignParagraphCenter;
            paragraph.Range.Font.Bold = 0;
            paragraph.Range.Font.Color = MsWord.WdColor.wdColorBlueGray;

            doc.Paragraphs.Add();
            paragraph = doc.Paragraphs[4];

            doc.Tables.Add(paragraph.Range, 4, 6, true);
            MsWord.Table table = doc.Tables[1];
            table.Borders.OutsideColor = MsWord.WdColor.wdColorDarkBlue;
            table.Borders.OutsideLineStyle = MsWord.WdLineStyle.wdLineStyleDouble;
            table.Borders.InsideLineStyle = MsWord.WdLineStyle.wdLineStyleDot;

          
            //данные в таблицу
            table.Cell(1, 1).Range.Text = "Район";
            table.Cell(1, 2).Range.Text = "Название кинотеатра";
            table.Cell(1, 3).Range.Text = "Название фильма/Кол-во показов";
            table.Cell(1, 4).Range.Text = "Средняя цена билета";
            table.Cell(1, 5).Range.Text = "Доход по кинотеатру";
            table.Cell(1, 6).Range.Text = "Доход по району";
            
            string[] places = { "Курчатовский", "Центральный", "Северо-Западный", "Калининский" };
            string[] namesCinema = { "Мегаполис", "Родник", "Киномакс", "Космос" };
            string[] namesMovie = { "Салют-7/25", "Бабушка/30", "Моя ужасная семья/19", "Вышка" };
            int[] avgtick = {100, 150, 180, 200 };
            int[] moneyCinema = { 10000, 15000, 9000, 5000};
            int[] moneyPlace = { 10000, 13000, 20000, 12000};
            
            


            for (int i = 0; i < places.Length; i++)
            {
                table.Cell(2 + i, 1).Range.Text = places[i];
                table.Cell(2 + i, 2).Range.Text = namesCinema[i];
                table.Cell(2 + i, 3).Range.Text = namesMovie[i].ToString();
                table.Cell(2 + i, 4).Range.Text = avgtick[i].ToString("c");
                table.Cell(2 + i, 5).Range.Text = moneyCinema[i].ToString("c");
                table.Cell(2 + i, 6).Range.Text = moneyPlace[i].ToString("c");
            }

    
          

            doc.Paragraphs.Add();
            paragraph = doc.Paragraphs[33];
            paragraph.Alignment = MsWord.WdParagraphAlignment.wdAlignParagraphLeft;
            paragraph.Range.Text = "Общее количество фильмов  в прокате: 30";

            doc.Paragraphs.Add();
            paragraph = doc.Paragraphs[34];
            paragraph.Alignment = MsWord.WdParagraphAlignment.wdAlignParagraphLeft;
            paragraph.Range.Text = "Количество фильмов, относящихся к жанру 'Ужасы': 1";

            doc.Paragraphs.Add();
            paragraph = doc.Paragraphs[35];
            paragraph.Alignment = MsWord.WdParagraphAlignment.wdAlignParagraphLeft;
            paragraph.Range.Text = "Количество фильмов, относящихся к жанру 'Комедия': 1";

            doc.Paragraphs.Add();
            paragraph = doc.Paragraphs[36];
            paragraph.Alignment = MsWord.WdParagraphAlignment.wdAlignParagraphLeft;
            paragraph.Range.Text = "Количество фильмов, относящихся к жанру 'Семейный': 1";

            doc.Paragraphs.Add();
            paragraph = doc.Paragraphs[37];
            paragraph.Range.Text = "Общий доход кинотеатров: 34 000";



            wordApp.Visible = true;
                





        }

       
        //Редактирование Кинотеатров
        private void button2_Click(object sender, EventArgs e)
        {
            var window = new FormEditCinemaFilms(_dbManager);
            window.ShowDialog();
        }
     
        //Редактирование Фильмов
        private void button3_Click(object sender, EventArgs e)
        {
            var window = new FormEditMovie(_dbManager);
            window.ShowDialog();
        }
        //Редактирование Сеансов
        private void button4_Click(object sender, EventArgs e)
        {
            var window = new FormEditSession(_dbManager);
            window.ShowDialog();
        }
        //Редактирование билетов
        private void button5_Click(object sender, EventArgs e)
        {
            var window = new FormEditTickets(_dbManager);
            window.ShowDialog();
        }

       
        private void button6_Click_1(object sender, EventArgs e)
        {
            var windowback = new Form2();
            windowback.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (cinemaView == null) return;
            string textFilter = textBox1.Text;

            cinemaView.RowFilter =
              
                $"NameCinema like '%{textFilter}%'";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (movieView == null) return;
            string textFilter = textBox2.Text;

            movieView.RowFilter =

            $"NameMovie like '%{textFilter}%' or " +
               $"Genre like '%{textFilter}%'";
        }

       
    }
}
