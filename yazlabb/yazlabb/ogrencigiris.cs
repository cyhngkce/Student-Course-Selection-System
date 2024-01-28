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
using NpgsqlTypes;

namespace yazlabb
{
    public partial class ogrencigiris : Form
    {
        public ogrencigiris()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string kullaniciAdi = textBox2.Text;
            string sifre = textBox1.Text;

            string connString = "Host=localHost;Port=5432;user ID=postgres;Password=wasd1234;Database=ogrenciGiris";
            using (NpgsqlConnection conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                string query = "SELECT * FROM ogrenciveri WHERE ogrencikullanici = @kullaniciAdi AND ogrencisifre = @sifre";
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@kullaniciAdi", NpgsqlDbType.Text, kullaniciAdi);
                    cmd.Parameters.AddWithValue("@sifre", NpgsqlDbType.Text, sifre);

                    int result = (int)cmd.ExecuteScalar();

                    if (result > 0)
                    {

                        MessageBox.Show("Hoşgeldiniz " + kullaniciAdi, "Giriş Başarılı!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ogrencipdf form = new ogrencipdf();
                        form.Show();
                    }
                    else
                    {
                        MessageBox.Show("Giriş Başarısız. Lütfen kullanıcı adı ve şifrenizi kontrol edin.");
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
