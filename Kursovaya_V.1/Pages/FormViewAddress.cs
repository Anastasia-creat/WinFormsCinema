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

namespace Kursovaya_V._1.Pages
{
    public partial class FormViewAddress : Form
    {
        private DataBaseManager _dbManager;
        private string connectionString
            = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=CinemaDb2;Integrated Security=True";
       
        public FormViewAddress()
        {
            InitializeComponent();
            _dbManager = new DataBaseManager(connectionString);

      
        }

        private void FormViewAddress_Load(object sender, EventArgs e)
        {
            
            // TODO: данная строка кода позволяет загрузить данные в таблицу "cinemaDb2DataSet.Movie". При необходимости она может быть перемещена или удалена.
            this.movieTableAdapter.Fill(this.cinemaDb2DataSet.Movie);
            // мяTODO: данная строка кода позволяет загрузить данные в таблицу "cinemaDb2DataSet.Cinema". При необходимости она может быть перемещена или удалена.
            this.cinemaTableAdapter.Fill(this.cinemaDb2DataSet.Cinema);

        }

     


       

        private void comboBoxDistrict_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            // comboBoxDistrict.SelectedIndex.ToString();
            DataRowView row = (DataRowView)comboBoxDistrict.SelectedItem;
            textBox1.Text = row["DistrictOfTheCity"].ToString();

            
           
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //1. Запускаем процесс MS Word
            var wordApp = new MsWord.Application();
            // MessageBox.Show("word запущен");

            //2. Покажем окно ворда
            wordApp.Visible = true;

            //3.Добавим документ
            wordApp.Documents.Add();

            //4. Добавим текст
            //Сначала выбираем документ
            MsWord.Document doc = wordApp.Documents[1];

            


            doc.Paragraphs.Add();
            MsWord.Paragraph paragraph = doc.Paragraphs[1];
            paragraph.Range.Text = $"Адрес кинотеатра";

            doc.Paragraphs.Add();
            paragraph = doc.Paragraphs[2];
            paragraph.Range.Text = textBox1.Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var windowback = new FormHelpDesk();
            windowback.Show();
            this.Hide();
        }

        

       
    }
}
