using Npgsql;
using NpgsqlTypes;
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
    public partial class hocagiris : Form
    {
        public hocagiris()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string kullaniciAdi = textBox2.Text;
            string sifre = textBox1.Text;

            string connString = "Host=localhost;Port=5432;User ID=postgres;Password=wasd1234;Database=ogrenciGiris";
            using (NpgsqlConnection conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM hocaveri WHERE adsoyad = @kullaniciAdi AND sicil = @sifre";
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@kullaniciAdi", NpgsqlDbType.Text, kullaniciAdi);
                    cmd.Parameters.AddWithValue("@sifre", NpgsqlDbType.Text, sifre);

                    int result = Convert.ToInt32(cmd.ExecuteScalar());

                    if (result > 0)
                    {
                        MessageBox.Show("Hoşgeldiniz " + kullaniciAdi, "Giriş Başarılı!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        hocapanel form = new hocapanel();
                        form.Show();
                    }
                    else
                    {
                        MessageBox.Show("Giriş Başarısız. Lütfen kullanıcı adı ve şifrenizi kontrol edin.");
                    }
                }
            }
        }
    

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
