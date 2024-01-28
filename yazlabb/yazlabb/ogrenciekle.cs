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
using System.Data.SqlClient;
using Npgsql;

namespace yazlabb
{
    public partial class ogrenciekle : Form
    {
        public ogrenciekle()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }


        string connString = "Host=localhost;Port=5432;User ID=postgres;Password=wasd1234;Database=ogrenciGiris";

        private void button1_Click(object sender, EventArgs e)
        {
            string commandText = "INSERT INTO ogrenciveri (id,ogrencikullanici, ogrencisifre, ilgialani) VALUES (@Parametre1, @Parametre2, @Parametre3, @Parametre4)";

            using (NpgsqlConnection connection = new NpgsqlConnection(connString))
            {
                connection.Open();

                using (NpgsqlCommand cmd = new NpgsqlCommand(commandText, connection))
                {
                    cmd.Parameters.AddWithValue("@Parametre1", int.Parse(textBox4.Text));
                    cmd.Parameters.AddWithValue("@Parametre2", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Parametre3", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Parametre4", textBox3.Text);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Veri eklendi.");
                    }
                    else
                    {
                        MessageBox.Show("Veri eklenirken hata oluştu.");
                    }
                }

                connection.Close();
            }
        }
    }
}
