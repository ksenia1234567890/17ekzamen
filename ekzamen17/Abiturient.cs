﻿using Npgsql;
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
    public partial class Abiturient : Form
    {
        public string login;
        public string password;
        public string surname;
        public string name;
        public string patronymic;
        
        public Abiturient(string login, string password)
        {
            InitializeComponent();
            this.login = login;
            this.password = password;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Abiturient_Load(object sender, EventArgs e)
        {

            try
            {
                NpgsqlConnection connect = new NpgsqlConnection("Host=localhost;Username=postgres;Password=cxNTVJas;Data=17ekzamen");
                string query = "select id from login_password where login=@login and password=@password";
                NpgsqlCommand cmd = new NpgsqlCommand(query, connect);
                cmd.Parameters.AddWithValue("@login", login);
                cmd.Parameters.AddWithValue("@password", password);
                connect.Open();
                int id = Convert.ToInt32(cmd.ExecuteScalar());
                connect.Close();

                NpgsqlConnection contact = new NpgsqlConnection("Host=localhost;Username=postgres;Password=cxNTVJas;Data=17ekzamen");
                string query2 = "select surname from data_ab where id=@id";
                NpgsqlCommand cmd2 = new NpgsqlCommand(query2, contact);
                cmd2.Parameters.AddWithValue("@id", id);
                contact.Open();
                string 
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
