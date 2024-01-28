using Npgsql;
using NpgsqlTypes;
using System;
using System.Windows.Forms;

namespace yazlabb
{
    public partial class yoneticigiris : Form
    {
        public yoneticigiris()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        string connString = "Host=localhost;Port=5432;User ID=postgres;Password=wasd1234;Database=ogrenciGiris";

        private void button1_Click(object sender, EventArgs e)
        {
            string admin = textBox3.Text;
            string sifre = textBox1.Text;
            using (NpgsqlConnection conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM yoneticiveri WHERE admin = @admin AND sifre = @sifre";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@admin", admin);
                    cmd.Parameters.AddWithValue("@sifre", sifre);

                    Int64 count = (Int64)cmd.ExecuteScalar(); 

                    if (count > 0)
                    {
                        MessageBox.Show("Hoşgeldiniz " + admin, "Giriş Başarılı!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        yoneticipanel form = new yoneticipanel();
                        form.Show();
                    }
                    else
                    {
                        MessageBox.Show("Geçersiz ad soyad veya şifre.", "Giriş Başarısız!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                conn.Close();
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}