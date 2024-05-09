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
    public partial class FormHelpDesk : Form

    {

        private DataBaseManager _dbManager;
        private string connectionString
            = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=CinemaDb2;Integrated Security=True";
        private DataView _repertoireView;
        private string _selectedRepertoireCombobox;
        private string _selectedfilm;


        //переменные на ворд
    
        public FormHelpDesk()
        {
            InitializeComponent();
          
            _dbManager = new DataBaseManager(connectionString);
           

        }

      

      

        private void button6_Click(object sender, EventArgs e)
        {
            var windowback = new Form2();
            windowback.Show();
            this.Hide();
        }

       

     

        private void FormHelpDesk_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "cinemaDb2DataSet.Movie". При необходимости она может быть перемещена или удалена.
            this.movieTableAdapter.Fill(this.cinemaDb2DataSet.Movie);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "cinemaDb2DataSet.Session". При необходимости она может быть перемещена или удалена.
            //this.sessionTableAdapter.Fill(this.cinemaDb2DataSet.Session);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "cinemaDb2DataSet.Cinema". При необходимости она может быть перемещена или удалена.
            this.cinemaTableAdapter.Fill(this.cinemaDb2DataSet.Cinema);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "cinemaDb2DataSet1.Repertoire". При необходимости она может быть перемещена или удалена.
         

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

       

      

        private void button4_Click_1(object sender, EventArgs e)
        {
            FormViewAddress formview = new FormViewAddress();
            formview.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormViewFreeSeats formview = new FormViewFreeSeats();
            formview.Show();
            this.Hide();
        }

    

        private void button7_Click(object sender, EventArgs e)
        {
            FormDataFilm formdata = new FormDataFilm();
            formdata.Show();
            this.Hide();
        }

        
    }
}
