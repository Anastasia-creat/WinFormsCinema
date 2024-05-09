using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursovaya_V._1
{
    public partial class FormEditCinemaFilms : Form
    {
        

        private DataBaseManager _dbManager;
        private string id;
        private string _selectedCinemaId;
        private DataView cinemaView;
        public FormEditCinemaFilms(DataBaseManager dbManager)
        {
            InitializeComponent();
            _dbManager = dbManager;

            dataGridView1.DataSource =
                _dbManager
                .ViewTable(EnumTable.Cinema);

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
            dataGridView1.ReadOnly = true;
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;
            var row = dataGridView1.SelectedRows[0];
            
            // string _selectedCinemaId = row.Cells["CinemaId"].Value.ToString();

            // if (string.IsNullOrEmpty(cinemaid)) return;
            id = row.Cells["CinemaId"].Value.ToString();

            string NameCinema = row.Cells["NameCinema"].Value.ToString();
            string DistrictOfTheCity = row.Cells["DistrictOfTheCity"].Value.ToString();
            string Category = row.Cells["CategoryOfCinema"].Value.ToString();
            string Capacity = row.Cells["Capacity"].Value.ToString();

            textBoxCinema.Text = NameCinema;
            textBoxDistrict.Text = DistrictOfTheCity;
            textBoxCategory.Text = Category;
            textBoxCapacity.Text = Capacity;

            // идишник группы, выбранный в данный момент!
            if (cinemaView == null || string.IsNullOrEmpty(id))
                return;

            // применим фильрацию данных - синтаксис SQL
            cinemaView.RowFilter = $"CinemaId = {id}";
        }


      

        private void AddCinema_Click(object sender, EventArgs e)
        {
            _dbManager.AddCinema(textBoxCinema.Text,
             textBoxDistrict.Text, textBoxCategory.Text, textBoxCapacity.Text);
        }

        private void RemoveCinema_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("Выберите сначала кинотеатр для удаления ");
                return;
            }
            _dbManager.RemoveCinema(id);
            id = string.Empty;

        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (_dbManager.SaveChanges(EnumTable.Cinema))
            {
                MessageBox.Show("Успешно сохранили!");
            }
        }

        
    }
}
