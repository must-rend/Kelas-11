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
    public partial class Form3Dashboard : Form
    {
        public Form3Dashboard()
        {
            InitializeComponent();
            UIHelper.Normalize(this);
        }


        // Dashboard
        // private void label8_Click(object sender, EventArgs e)
        // {
        //     Form3Dashboard dashboard = new Form3Dashboard();
        //     this.Close();
        //     dashboard.Show();
        // }

        // private void pictureBox2_Click(object sender, EventArgs e)
        // {
        //     Form3Dashboard dashboard = new Form3Dashboard();
        //     this.Close();
        //     dashboard.Show();
        // }


        // About
        private void label2_Click(object sender, EventArgs e)
        {
            Form4About about = new Form4About();
            this.Close();
            about.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form4About about = new Form4About();
            this.Close();
            about.Show();
        }


        // Struktur
        private void label3_Click(object sender, EventArgs e)
        {
            Form5Struktur struktur = new Form5Struktur();
            this.Close();
            struktur.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form5Struktur struktur = new Form5Struktur();
            this.Close();
            struktur.Show();
        }


        // Bidang
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form6Bidang bidang = new Form6Bidang();
            this.Close();
            bidang.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Form6Bidang bidang = new Form6Bidang();
            this.Close();
            bidang.Show();
        }


        // Sejarah
        private void label5_Click(object sender, EventArgs e)
        {
            Form7Sejarah sejarah = new Form7Sejarah();
            this.Close();
            sejarah.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Form7Sejarah sejarah = new Form7Sejarah();
            this.Close();
            sejarah.Show();
        }


        // Slot
        private void label6_Click(object sender, EventArgs e)
        {
            Form8Slot slot = new Form8Slot();
            this.Close();
            slot.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Form8Slot slot = new Form8Slot();
            this.Close();
            slot.Show();
        }


        // Logout
        private void label7_Click(object sender, EventArgs e)
        {
            Form1Login login = new Form1Login();
            this.Close();
            login.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1Login login = new Form1Login();
            this.Close();
            login.Show();
        }
    }
}
