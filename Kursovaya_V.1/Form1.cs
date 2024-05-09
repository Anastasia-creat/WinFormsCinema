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
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            string login = "12";
            string pas = "12";
            if(textBox1.Text == login && textBox2.Text == pas)
            {
                Form2 form2 = new Form2();
                form2.Show();
                this.Hide();     
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
            }
        }
    }
}
