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
    public partial class yoneticipanel : Form
    {
        public yoneticipanel()
        {
            InitializeComponent();
        }


        string connString = "Host=localHost;Port=5432;user ID=postgres;Password=wasd1234;Database=ogrenciGiris";
        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            string listele = "select * from ogrenciveri";
            NpgsqlDataAdapter da=new NpgsqlDataAdapter(listele,connString);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string listele = "select * from hocaveri";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(listele, connString);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ogrenciekle form = new ogrenciekle();
            form.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            hocaekle form = new hocaekle();
            form.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connString))
            {
                connection.Open();

                NpgsqlCommand komut3 = new NpgsqlCommand("update ogrenciveri set ogrencikullanici=@p2,ogrencisifre=@p3,ilgialani=@p4 where id=@p1 ", connection);
                
                komut3.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
                komut3.Parameters.AddWithValue("@p2", textBox3.Text);
                komut3.Parameters.AddWithValue("@p3", textBox2.Text);
                komut3.Parameters.AddWithValue("@p4", textBox4.Text);

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

        private void sil_Click(object sender, EventArgs e)
        {
            string commandText = "INSERT INTO ogrenciveri (id,ogrencikullanici, ogrencisifre, ilgialani) VALUES (@Parametre1, @Parametre2, @Parametre3, @Parametre4)";

            using (NpgsqlConnection connection = new NpgsqlConnection(connString))
            {
                connection.Open();

                using (NpgsqlCommand cmd = new NpgsqlCommand("Delete from ogrenciveri where id=@Parametre1", connection))
                {
                    cmd.Parameters.AddWithValue("@Parametre1", int.Parse(textBox1.Text));
                   
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Veri silindi.");
                    }
                    else
                    {
                        MessageBox.Show("Veri silinirken hata oluştu.");
                    }
                }

                connection.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

           
            using (NpgsqlConnection connection = new NpgsqlConnection(connString))
            {
                connection.Open();

                using (NpgsqlCommand cmd = new NpgsqlCommand("Delete from hocaveri where adsoyad=@Parametre1", connection))
                {
                    cmd.Parameters.AddWithValue("@Parametre1", textBox3.Text);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Veri silindi.");
                    }
                    else
                    {
                        MessageBox.Show("Veri silinirken hata oluştu.");
                    }
                }

                connection.Close();
            }
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connString))
            {
                connection.Open();

                NpgsqlCommand komut3 = new NpgsqlCommand("update hocaveri set sicil=@p3,ilgialani=@p4,kontenjan=@p5,acilandersler=@p6,kriterdersler=@p7 where adsoyad=@p2 ", connection);

                
                komut3.Parameters.AddWithValue("@p2", textBox3.Text);
                komut3.Parameters.AddWithValue("@p3", textBox2.Text);
                komut3.Parameters.AddWithValue("@p4", textBox4.Text);
                komut3.Parameters.AddWithValue("@p6", textBox5.Text);
                komut3.Parameters.AddWithValue("@p5", int.Parse(textBox6.Text));
                komut3.Parameters.AddWithValue("@p7", textBox7.Text);

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
