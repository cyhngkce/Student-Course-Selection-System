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

namespace yazlabb
{
    public partial class hocaekle : Form
    {
        public hocaekle()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        string connString = "Host=localhost;Port=5432;User ID=postgres;Password=wasd1234;Database=ogrenciGiris";

        private void button1_Click(object sender, EventArgs e)
        {

            string commandText = "INSERT INTO hocaveri (adsoyad,sicil, ilgialani, kontenjan,acilandersler,kriterdersler) VALUES (@Parametre1, @Parametre2, @Parametre3, @Parametre4,@Parametre5,@Parametre6)";

            using (NpgsqlConnection connection = new NpgsqlConnection(connString))
            {
                connection.Open();

                using (NpgsqlCommand cmd = new NpgsqlCommand(commandText, connection))
                {
                    cmd.Parameters.AddWithValue("@Parametre1", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Parametre2", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Parametre3", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Parametre4", int.Parse(textBox4.Text));
                    cmd.Parameters.AddWithValue("@Parametre5", textBox5.Text);
                    cmd.Parameters.AddWithValue("@Parametre6", textBox6.Text);

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
