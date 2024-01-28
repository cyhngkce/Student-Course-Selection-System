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
    public partial class girisekrani : Form
    {
        public girisekrani()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ogrencigiris form = new ogrencigiris();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            yoneticigiris form = new yoneticigiris();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            hocagiris form = new hocagiris();
            form.Show();
        }
    }
}
