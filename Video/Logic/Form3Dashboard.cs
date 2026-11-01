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
            this.StartPosition = FormStartPosition.CenterScreen;
            TampilkanRingkasan();
        }

        private void TampilkanRingkasan()
        {
            string namaAdmin = Session.loggedIn != null ? Session.loggedIn.Nama : "Admin";

            Label sapaan = new Label
            {
                AutoSize = true,
                Location = new Point(290, 100),
                Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold),
                ForeColor = Color.Black,
                Text = "Selamat datang, " + namaAdmin
            };

            Label ringkasan = new Label
            {
                AutoSize = true,
                Location = new Point(292, 135),
                Font = new Font("Microsoft Sans Serif", 9F),
                ForeColor = Color.DimGray,
                Text = "Memuat ringkasan data..."
            };

            Controls.Add(sapaan);
            Controls.Add(ringkasan);
            sapaan.BringToFront();
            ringkasan.BringToFront();

            try
            {
                using (BandaraEntities db = new BandaraEntities())
                {
                    int bandara = db.Bandaras.Count();
                    int maskapai = db.Maskapais.Count();
                    int jadwal = db.JadwalPenerbangans.Count();
                    int promo = db.KodePromoes.Count();

                    ringkasan.Text =
                        $"Bandara: {bandara}   |   Maskapai: {maskapai}   |   Jadwal: {jadwal}   |   Promo: {promo}";
                }
            }
            catch (Exception ex)
            {
                ringkasan.Text = "Ringkasan tidak bisa dimuat: " + ex.GetBaseException().Message;
            }
        }

        // Master Bandara
        private void label6_Click(object sender, EventArgs e)
        {
            Form4Bandara form = new Form4Bandara();
            this.Close();
            form.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Form4Bandara form = new Form4Bandara();
            this.Close();
            form.Show();
        }

        // Master Maskapai
        private void label5_Click(object sender, EventArgs e)
        {
            Form5Maskapai form = new Form5Maskapai();
            this.Close();
            form.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form5Maskapai form = new Form5Maskapai();
            this.Close();
            form.Show();
        }

        // Master Jadwal
        private void label4_Click(object sender, EventArgs e)
        {
            Form6Jadwal form = new Form6Jadwal();
            this.Close();
            form.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form6Jadwal form = new Form6Jadwal();
            this.Close();
            form.Show();
        }

        // Master Kode Promo
        private void label3_Click(object sender, EventArgs e)
        {
            Form7Kode form = new Form7Kode();
            this.Close();
            form.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form7Kode form = new Form7Kode();
            this.Close();
            form.Show();
        }

        // Ubah Status
        private void label2_Click(object sender, EventArgs e)
        {
            Form8Ubah form = new Form8Ubah();
            this.Close();
            form.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form8Ubah form = new Form8Ubah();
            this.Close();
            form.Show();
        }

        // Logout
        private void label7_Click(object sender, EventArgs e)
        {
            Session.loggedIn = null;
            Form1Login login = new Form1Login();
            this.Close();
            login.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Session.loggedIn = null;
            Form1Login login = new Form1Login();
            this.Close();
            login.Show();
        }
    }
}
