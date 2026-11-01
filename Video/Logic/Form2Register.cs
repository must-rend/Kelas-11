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
    public partial class Form2Register : Form
    {
        BandaraEntities db = new BandaraEntities();

        public Form2Register()
        {
            InitializeComponent();
            
            // tanggal lahir: default 17 tahun lalu
            dateTimePicker1.MaxDate = DateTime.Today.AddDays(-1);
            dateTimePicker1.MinDate = new DateTime(1900, 1, 1);
            dateTimePicker1.Value = DateTime.Today.AddYears(-17);

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Form1Login login = new Form1Login();
            this.Close();
            login.Show();
        }

        private void btnDaftar_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string namaLengkap = textBox5.Text.Trim();
            string nomorTelepon = textBox2.Text.Trim();
            string password = textBox4.Text;

            // cek semua textbox
            if (username.Length == 0 || namaLengkap.Length == 0 || nomorTelepon.Length == 0 || password.Length == 0)
            {
                MessageBox.Show("Tolong lengkapi semua data yang diperlukan untuk membuat akun baru", "Validasi Gagal",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // username harus unik
            bool usernameSudahAda = db.Akuns.Any(a => a.Username == username);
            if (usernameSudahAda)
            {
                MessageBox.Show("Username sudah digunakan", "Validasi Gagal",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // validasi nomor telepon
            if (!nomorTelepon.All(char.IsDigit))
            {
                MessageBox.Show("Nomor telepon hanya boleh berisikan angka", "Validasi Gagal",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (nomorTelepon.Length < 10 || nomorTelepon.Length > 15)
            {
                MessageBox.Show("Nomor telepon harus 10 - 15 digit", "Validasi Gagal",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // validasi password
            if (password.Length < 8)
            {
                MessageBox.Show("Password minimal 8 karakter", "Validasi Gagal",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // validasi tanggal lahir (minimal 17 tahun)
            int umur = DateTime.Now.Year - dateTimePicker1.Value.Year;
            if (dateTimePicker1.Value.Date > DateTime.Today.AddYears(-umur))
            {
                umur--;
            }

            if (umur < 17)
            {
                MessageBox.Show("Umur minimal 17 tahun!", "Validasi Gagal",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Akun akunBaru = new Akun
                {
                    Username = username,
                    Nama = namaLengkap,
                    TanggalLahir = dateTimePicker1.Value.Date,
                    NomorTelepon = nomorTelepon,
                    Password = password,
                    MerupakanAdmin = false
                };

                db.Akuns.Add(akunBaru);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Akun gagal dibuat.\n\nDetail: " + ex.GetBaseException().Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Berhasil membuat akun baru. \nSilahkan login", "Informasi",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            Form1Login login = new Form1Login();
            login.Show();
            this.Close();
        }
    }
}
