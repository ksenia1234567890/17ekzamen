using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace ekzamen17
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            
        }
        public string path = "Host=localhost;Username=postgres;Password=cxNTVJas;Database=";


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // Нажатие на кнопку  "Создать заявление"
        private void add_letter_Click(object sender, EventArgs e)
        {
            NpgsqlConnection connect = new NpgsqlConnection("Host=localhost;Username=postgres;Password=cxNTVJas;Database=17ekzamen");
            string query = "insert into data_ab(" +
                "id, surname, name, patronymic,level_edu,coins_edu,snils,seria,number_pass,when_pass," +
                "how_pass,phone,email,path_edu,address_pass,institut) values " +
                "(@id, @surname, @name, @patronymic,@level_edu,@coins_edu,@snils,@seria,@number_pass," +
                "@when_pass,@how_pass,@phone,@email,@path_edu,@address_pass,@institut)" ;
            NpgsqlCommand cmd = new NpgsqlCommand(query, connect);
            cmd.Parameters.AddWithValue("@id", textBox15.Text);
            cmd.Parameters.AddWithValue("@surname", textBox1.Text);
            cmd.Parameters.AddWithValue("@name", textBox2.Text);
            cmd.Parameters.AddWithValue("@patronymic", textBox3.Text);
            cmd.Parameters.AddWithValue("@level_edu", comboBox1.Text);
            cmd.Parameters.AddWithValue("@coins_edu", textBox14.Text);
            cmd.Parameters.AddWithValue("@snils", textBox9.Text);
            cmd.Parameters.AddWithValue("@seria", textBox15.Text);
            cmd.Parameters.AddWithValue("@number_pass", textBox1.Text);
            cmd.Parameters.AddWithValue("@when_pass", textBox2.Text);
            cmd.Parameters.AddWithValue("@how_pass", textBox3.Text);
            cmd.Parameters.AddWithValue("@phone", comboBox1.Text);
            cmd.Parameters.AddWithValue("@email", textBox14.Text);
            cmd.Parameters.AddWithValue("@path_edu", textBox9.Text);
            cmd.Parameters.AddWithValue("@address_pass", textBox1.Text);
            cmd.Parameters.AddWithValue("@institut", textBox2.Text);
        }
    }

        private void printBut_Click(object sender, EventArgs e)
        {
            Print print = new Print(textBox1.Text, textBox2.Text, textBox3.Text, 
                comboBox2.Text, comboBox5.Text, comboBox3.Text, comboBox4.Text, comboBox6.Text);
            print.ShowDialog();
        }

        // Загрузка документа
        private void documentBut_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            string path = file.FileName;
        }
    }

