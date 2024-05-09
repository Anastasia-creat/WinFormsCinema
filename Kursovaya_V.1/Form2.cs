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

namespace Kursovaya_V._1
{
    public partial class Form2 : Form
    {
        private DataBaseManager _dbManager;
        public Form2()
        {
            InitializeComponent();
        }

       

        private void button1_Click_1(object sender, EventArgs e)
        {
            FormFilm formFilm = new FormFilm();
            formFilm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormRepertoire formRepertoire = new FormRepertoire();
            formRepertoire.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            FormHelpDesk formHelp = new FormHelpDesk();
            formHelp.Show();
            this.Hide();

        }
    }
}
