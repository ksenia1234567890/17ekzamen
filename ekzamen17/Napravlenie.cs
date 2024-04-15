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
    public partial class Napravlenie : Form
    {
        public Napravlenie()
        {
            InitializeComponent();
        }

        private void Napravlenie_Load(object sender, EventArgs e)
        {
            Refresh();
        }

        public void Refresh()
        {
            NpgsqlConnection connect = new NpgsqlConnection("Host=localhost;Username=postgres;Password=cxNTVJas;Database=17ekzamen");
            string query = "select * from nap";
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connect);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[0].HeaderText = "Идентификатор";
            dataGridView1.Columns[1].HeaderText = "Уровень образования";
            dataGridView1.Columns[2].HeaderText = "Специальность";
        }

        // Добавление
        private void button1_Click(object sender, EventArgs e)
        {
            NpgsqlConnection contact = new NpgsqlConnection("Host=localhost;Username=postgres;Password=cxNTVJas;Database=17ekzamen");
            string query2 = "insert into nap(id,level,specialization) values (@id,@level,@specialization)";
            NpgsqlCommand cmd = new NpgsqlCommand(query2, contact);
            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(textBox1.Text));
            cmd.Parameters.AddWithValue("@level", comboBox1.Text);
            cmd.Parameters.AddWithValue("@specialization", textBox2.Text);
            contact.Open();
            cmd.ExecuteNonQuery();
            contact.Close();
            Refresh();
        }

        // Изменение

        private void button2_Click(object sender, EventArgs e)
        {

            NpgsqlConnection contact2 = new NpgsqlConnection("Host=localhost;Username=postgres;Password=cxNTVJas;Database=17ekzamen");
            string query3 = "update nap set level=@level, specialization=@specialization where id=@id";
            NpgsqlCommand cmd2 = new NpgsqlCommand(query3, contact2);
            cmd2.Parameters.AddWithValue("@id", Convert.ToInt32(textBox1.Text));
            cmd2.Parameters.AddWithValue("@level", comboBox1.Text);
            cmd2.Parameters.AddWithValue("@specialization", textBox2.Text);
            contact2.Open();
            cmd2.ExecuteNonQuery();
            contact2.Close();
            Refresh();
        }

        // Удаление

        private void button3_Click(object sender, EventArgs e)
        {

            NpgsqlConnection contact3 = new NpgsqlConnection("Host=localhost;Username=postgres;Password=cxNTVJas;Database=17ekzamen");
            string query4 = "delete from nap where id=@id";
            NpgsqlCommand cmd3 = new NpgsqlCommand(query4, contact3);
            cmd3.Parameters.AddWithValue("@id", Convert.ToInt32(textBox1.Text));
            contact3.Open();
            cmd3.ExecuteNonQuery();
            contact3.Close();
            Refresh(); 
        }
    }
}
