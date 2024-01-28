using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace yazlabb
{
    public partial class hocapanel : Form
    {
        public hocapanel()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        string connString = "Host=localhost;Port=5432;User ID=postgres;Password=wasd1234;Database=ogrenciGiris";
        private void button4_Click(object sender, EventArgs e)
        {
            string ogrenci = "ogrenciveri";
            string hoca = "hocaveri";

            string hocaAdi = textBox3.Text; 
            string query = $"SELECT {ogrenci}.* " +
                           $"FROM {ogrenci} " +
                           $"WHERE {ogrenci}.dersbilgi IN (SELECT acilandersler FROM {hoca} WHERE adsoyad = @hocaAdi)";

           

            using (NpgsqlConnection connection = new NpgsqlConnection(connString))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@hocaAdi", hocaAdi);
                    using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        if (dataTable.Rows.Count > 0)
                        {
                            dataGridView1.DataSource = dataTable;

                        }
                        else
                        {
                            Console.WriteLine("Eşleşen veri bulunamadı.");
                        }
                    }
                }

                connection.Close();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

            using (NpgsqlConnection connection = new NpgsqlConnection(connString))
            {
                connection.Open();
                string kabul = "Kabul Edildi";
                NpgsqlCommand komut3 = new NpgsqlCommand("update ogrenciveri set anlasmadurumu=@p2 where id=@p1 ", connection);

                komut3.Parameters.AddWithValue("@p1", int.Parse(textBox2.Text));
                komut3.Parameters.AddWithValue("@p2", kabul);
               

                komut3.ExecuteNonQuery();
                int rowsAffected = komut3.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Ders Onaylandı.");
                }
                else
                {
                    MessageBox.Show("Hata");
                }
                connection.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            using (NpgsqlConnection connection = new NpgsqlConnection(connString))
            {
                connection.Open();
                string red = "Reddedildi";
                NpgsqlCommand komut3 = new NpgsqlCommand("update ogrenciveri set anlasmadurumu=@p2 where id=@p1 ", connection);

                komut3.Parameters.AddWithValue("@p1", int.Parse(textBox2.Text));
                komut3.Parameters.AddWithValue("@p2", red);


                komut3.ExecuteNonQuery();
                int rowsAffected = komut3.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Ders Onayı Verilmedi.");
                }
                else
                {
                    MessageBox.Show("Hata");
                }
                connection.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connString))
            {
                connection.Open();
                
                NpgsqlCommand komut3 = new NpgsqlCommand("update hocaveri set ilgialani=@p2 where adsoyad=@p1 ", connection);

                komut3.Parameters.AddWithValue("@p1", textBox3.Text);
                komut3.Parameters.AddWithValue("@p2", textBox1.Text);


                komut3.ExecuteNonQuery();
                int rowsAffected = komut3.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("İlgi alanı eklendi.");
                }
                else
                {
                    MessageBox.Show("Hata");
                }
                connection.Close();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
    
}
