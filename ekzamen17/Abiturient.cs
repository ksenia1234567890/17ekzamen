using Npgsql;
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
        
        public Abiturient(string login, string password)
        {
            InitializeComponent();
            this.login = login;
            this.password = password;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Abiturient_Load(object sender, EventArgs e)
        {

            try
            {
                NpgsqlConnection con = new NpgsqlConnection("Host=localhost,Username=postgres,Password=cxNTVJAS,Database=17ekzamen");
                string query = "select id from login_password where login=@login and password=@password";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                cmd.Parameters.AddWithValue("@login", login);
                cmd.Parameters.AddWithValue("@password", password);
                con.Open();
                string id = (string)cmd.ExecuteScalar();
                con.Close();
                string sql = "select surname,name,patronymic from data_edu where id=@id";
                NpgsqlCommand command = new NpgsqlCommand(sql, con);
                command.Parameters.AddWithValue("id", id.ToString());
                con.Open();
                string data_ab = (string)command.ExecuteScalar();
                con.Close();
                label2.Text = data_ab;
                string line = "select status from status_letter where id=@id";
                NpgsqlCommand npgsql = new NpgsqlCommand(line, con);
                command.Parameters.AddWithValue("id", id.ToString());
                con.Open();
                string zayavka = (string)npgsql.ExecuteScalar();
                con.Close();
                status.Text = zayavka;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
