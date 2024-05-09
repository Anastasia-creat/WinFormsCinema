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
    public partial class FormEditMovie : Form
    {
        private readonly DataBaseManager _dbManager;
        private DataView _movieView;
        //combobox
        private DataView _cinemaView;
        private string _selectedCinemaId;
        //нынешний ИД
        private string _selectedMovieId;

        public FormEditMovie(DataBaseManager dbManager)
        {
            InitializeComponent();
            _dbManager = dbManager;

            //для грида (что будет отображено)
            _movieView = _dbManager
                .ViewTable(EnumTable.Movie);

            //для комбобокс
            _cinemaView = _dbManager
                .ViewTable(EnumTable.Cinema);

            dataGridView1.DataSource = _movieView;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;


           comboBox1.DataSource = _cinemaView;
             comboBox1.DisplayMember = "NameCinema";            
              comboBox1.ValueMember = "CinemaId";

            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;

        }
        
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedCinemaId = comboBox1.SelectedIndex.ToString();
            
        }
        
        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;
            var row = dataGridView1.SelectedRows[0];

           // string cinemaId = row.Cells["CinemaId"].Value.ToString();
            //if (string.IsNullOrEmpty(cinemaId)) return;

            _selectedMovieId = row.Cells["MovieId"].Value.ToString();

            string NameMovie = row.Cells["NameMovie"].Value.ToString();
            string Director = row.Cells["Director"].Value.ToString();
            string Operator= row.Cells["Operator"].Value.ToString();
            string Actors = row.Cells["Actors"].Value.ToString();
            string Genre = row.Cells["Genre"].Value.ToString();
            string Country = row.Cells["Country"].Value.ToString();
            string FilmAwards= row.Cells["FilmAwards"].Value.ToString();
            string SessionDuration = row.Cells["SessionDuration"].Value.ToString();
            string CinemaId = row.Cells["CinemaId"].Value.ToString();


            textBoxName.Text = NameMovie;
            textBoxDirector.Text = Director;
            textBoxOperator.Text = Operator;
            textBoxActors.Text = Actors;
            textBoxGenre.Text = Genre;
            textBoxCountry.Text = Country;
            textBoxAwards.Text = FilmAwards;
            textBoxSession.Text = SessionDuration;
            comboBox1.Text = CinemaId;



            
        }

        private void AddMovie_Click(object sender, EventArgs e)
        {
            _dbManager.AddMovie( textBoxName.Text, textBoxDirector.Text, textBoxOperator.Text, textBoxActors.Text, textBoxGenre.Text,
                textBoxCountry.Text, textBoxAwards.Text, textBoxSession.Text/*_selectedMovieId*/, comboBox1.Text);
        }

        private void SaveMovie_Click(object sender, EventArgs e)
        {
            if (_dbManager.SaveChanges(EnumTable.Movie))
            {
                MessageBox.Show("Успешно сохранили!");
            }
        }

        private void RemoveMovie_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedMovieId))
            {
                MessageBox.Show("Выберите фильм для удаления");
                return;
            }

            _dbManager.RemoveMovie(_selectedMovieId);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
