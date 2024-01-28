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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace yazlabb
{
    public partial class derssecim : Form
    {
        public derssecim()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        string connString = "Host=localhost;Port=5432;User ID=postgres;Password=wasd1234;Database=ogrenciGiris";
        private void button1_Click(object sender, EventArgs e)
        {

            using (NpgsqlConnection connection = new NpgsqlConnection(connString))
            {
                connection.Open();

                NpgsqlCommand komut3 = new NpgsqlCommand("update ogrenciveri set dersbilgi=@p1 where id=@p2 ", connection);
                komut3.Parameters.AddWithValue("@p1", comboBox1.Text);
                komut3.Parameters.AddWithValue("@p2", int.Parse(textBox1.Text));
                
                komut3.ExecuteNonQuery();
                int rowsAffected = komut3.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Veri eklendi.");
                }
                else
                {
                    MessageBox.Show("Veri eklenirken hata oluştu.");
                }
                connection.Close();
            }
        }
    }
}
