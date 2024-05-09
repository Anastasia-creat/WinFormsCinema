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
    public partial class FormEditRepertoire : Form
    {
        private  DataBaseManager _dbManager;
        private DataView _repertoire;
        private string _selectedSessionId;

        private DataView _MovieView;
        private string _selectedMovieId;
        public FormEditRepertoire(DataBaseManager dbManager)
        {
            InitializeComponent();
            _dbManager = dbManager;

            _repertoire = _dbManager.ViewTable(EnumTable.Repertoire);
         
           

            dataGridViewEdit.DataSource = _repertoire;
            dataGridViewEdit.ReadOnly = true;
            dataGridViewEdit.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewEdit.SelectionChanged += DataGridView1_SelectionChanged;


           
           
        }

        

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
           if (dataGridViewEdit.SelectedRows.Count == 0) return;
            var row = dataGridViewEdit.SelectedRows[0];

            _selectedSessionId = row.Cells["RepertoireId"].Value.ToString();
            string movie = row.Cells["Movie"].Value.ToString();
            string cinema = row.Cells["Cinema"].Value.ToString();
            string price= row.Cells["Date"].Value.ToString();
            string number = row.Cells["NumberSeats"].Value.ToString();
            string session = row.Cells["Price"].Value.ToString();

             textBox1.Text = movie;
           // comboBox1.Text = movie;
            textBox2.Text = cinema;
            textBox3.Text = price;
            textBox4.Text = number;
            textBox5.Text = session;



        }

        private void button1_Click(object sender, EventArgs e)
        {
            _dbManager.AddRepertoire(textBox1.Text, textBox2.Text, textBox3.Text,
                textBox4.Text, textBox5.Text);
        }

        private void FormEditRepertoire_Load(object sender, EventArgs e)
        {
            // ритеTODO: данная строка кода позволяет загрузить данные в таблицу "cinemaDb2DataSet.Movie". При необходимости она может быть перемещена или удалена.
            this.movieTableAdapter.Fill(this.cinemaDb2DataSet.Movie);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedSessionId))
            {
                MessageBox.Show("Выберите репертуар для удаления");
                return;
            }
            _dbManager.RemoveRepertoire(_selectedSessionId);
        }

        private void button3_Click(object sender, EventArgs e)
        {
           if(_dbManager.SaveChanges(EnumTable.Repertoire))
            {
                MessageBox.Show("Успешно сохранено!");
            }
        }
    }
}
