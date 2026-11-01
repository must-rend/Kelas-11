using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contoh_Soal_Part_1
{
    public partial class Form5Maskapai : Form
    {
        public Form5Maskapai()
        {
            InitializeComponent();
        }

        private void label6_Click_1(object sender, EventArgs e)
        {
            Form4Bandara bandara = new Form4Bandara();
            this.Close();
            bandara.Show();
        }

        private void pictureBox6_Click_1(object sender, EventArgs e)
        {
            Form4Bandara bandara = new Form4Bandara();
            this.Close();
            bandara.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Form6Jadwal jadwal = new Form6Jadwal();
            this.Close();
            jadwal.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form6Jadwal jadwal = new Form6Jadwal();
            this.Close();
            jadwal.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form7Kode kode = new Form7Kode();
            this.Close();
            kode.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form7Kode kode = new Form7Kode();
            this.Close();
            kode.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Form8Ubah ubah = new Form8Ubah();
            this.Close();
            ubah.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form8Ubah ubah = new Form8Ubah();
            this.Close();
            ubah.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Form3Dashboard dashboard = new Form3Dashboard();
            this.Close();
            dashboard.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form3Dashboard dashboard = new Form3Dashboard();
            this.Close();
            dashboard.Show();
        }

        private void Form5Maskapai_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            Form1Login login = new Form1Login();
            this.Close();
            login.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Form1Login login = new Form1Login();
            this.Close();
            login.Show();
        }
    }
}
