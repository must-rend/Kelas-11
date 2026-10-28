using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContohSoal1
{
    public partial class Form5Maskapai : Form
    {
        public Form5Maskapai()
        {
            InitializeComponent();
            FormNavigation.Attach(this);
        }
            private void Form4Bandara_Load(object sender, EventArgs e)
            {
                
            }
            // Event Logout 7 hari
            private void label7_Click(object sender, EventArgs e)
            {
                Form1Login form1Login = new Form1Login();
                form1Login.Show(); // Tampilkan Form Login dulu
                this.Close();      // Baru tutup Dashboard
            }

            private void label2_Click(object sender, EventArgs e)
            {
                Form4Bandara form4Bandara = new Form4Bandara();
                form4Bandara.FormClosed += (s, args) => this.Show(); // Munculkan Dashboard jika Form4 ditutup
                form4Bandara.Show();
                this.Hide();
            }

            private void pictureBox2_Click(object sender, EventArgs e)
            {
                Form4Bandara form4Bandara = new Form4Bandara();
                form4Bandara.FormClosed += (s, args) => this.Show();
                form4Bandara.Show();
                this.Hide();
            }

            private void label3_Click(object sender, EventArgs e)
            {
                Form5Maskapai form5Maskapai = new Form5Maskapai();
                form5Maskapai.FormClosed += (s, args) => this.Show();
                form5Maskapai.Show();
                this.Hide();
            }

            private void pictureBox3_Click(object sender, EventArgs e)
            {
                Form5Maskapai form5Maskapai = new Form5Maskapai();
                form5Maskapai.FormClosed += (s, args) => this.Show();
                form5Maskapai.Show();
                this.Hide();
            }

            private void pictureBox5_Click(object sender, EventArgs e)
            {
                Form5Maskapai form5Tiket = new Form5Maskapai();
                form5Tiket.FormClosed += (s, args) => this.Show();
                form5Tiket.Show();
                this.Hide();
            }

            private void label4_Click(object sender, EventArgs e)
            {
                Form6JadwalPenerbangan form6JadwalPenerbangan = new Form6JadwalPenerbangan();
                form6JadwalPenerbangan.FormClosed += (s, args) => this.Show();
                form6JadwalPenerbangan.Show();
                this.Hide();
            }

            private void pictureBox4_Click(object sender, EventArgs e)
            {
                Form6JadwalPenerbangan form6Jadwal = new Form6JadwalPenerbangan();
                form6Jadwal.FormClosed += (s, args) => this.Show();
                form6Jadwal.Show();
                this.Hide();
            }

            private void label5_Click(object sender, EventArgs e)
            {
                Form7KodePromo form7KodePromo = new Form7KodePromo();
                form7KodePromo.FormClosed += (s, args) => this.Show();
                form7KodePromo.Show();
                this.Hide();
            }

            private void pictureBox6_Click(object sender, EventArgs e)
            {
                Form8UbahStatusPenerbangan form8UbahStatusPenerbangan = new Form8UbahStatusPenerbangan();
                form8UbahStatusPenerbangan.FormClosed += (s, args) => this.Show();
                form8UbahStatusPenerbangan.Show();
                this.Hide();
            }

            private void label6_Click(object sender, EventArgs e)
            {

            }

            private void Form3Dashboard_Load(object sender, EventArgs e)
            {

            }
        }
    }