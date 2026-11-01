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
    public partial class Form3Dashboard : Form
    {
        public Form3Dashboard()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Form6Jadwal jadwal = new Form6Jadwal();
            jadwal.Show();
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form6Jadwal jadwal = new Form6Jadwal();
            jadwal.Show();
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form7Kode kode = new Form7Kode();
            kode.Show();
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form7Kode kode = new Form7Kode();
            kode.Show();
            this.Close();
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

        private void label6_Click(object sender, EventArgs e)
        {
            Form4Bandara bandara = new Form4Bandara();
            this.Close();
            bandara.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Form4Bandara bandara = new Form4Bandara();
            this.Close();
            bandara.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Form5Maskapai maskapai = new Form5Maskapai();
            this.Close();
            maskapai.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form5Maskapai maskapai = new Form5Maskapai();
            this.Close();
            maskapai.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form8Ubah ubah = new Form8Ubah();
            this.Close();
            ubah.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Form8Ubah ubah = new Form8Ubah();
            this.Close();
            ubah.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form3Dashboard_Load(object sender, EventArgs e)
        {

        }
    }
}
