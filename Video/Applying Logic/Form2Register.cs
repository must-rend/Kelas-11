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
            UIHelper.Normalize(this);
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Form1Login login = new Form1Login();
            this.Close();
            login.Show();
        }

        private void daftarBtn_Click(object sender, EventArgs e) // tempat logic simpan user
        {
            // cek semua textbox
            if (usernameTxt.Text == "" || nameTxt.Text == "" || phoneTxt.Text == "" || passwordTxt.Text == "" || lahirDate.Value.Date == DateTime.Today)
            {
                MessageBox.Show("Tolong lengkapi semua data yang diperlukan untuk membuat akun baru");
                return;
            }

            // username harus unik
            bool usernameSudahAda = db.Akuns.Any(a => a.Username == usernameTxt.Text);

            if (usernameSudahAda)
            {
                MessageBox.Show("Username sudah digunakan");
                return;
            }

            // validasi nomor telepon
            if (!phoneTxt.Text.All(char.IsDigit)) // jika nomor telepon terdapat huruf atau simbol lainnya
            {
                MessageBox.Show("Nomor telepon hanya boleh berisikan angka");
                return;
            }

            if (phoneTxt.Text.Length < 10 || phoneTxt.Text.Length > 15) // Nomor telepon harus lebih dari 10 dan tidak lebih dari 15 karakter
            {
                MessageBox.Show("Nomor telepon harus 10 - 15 digit");
                return;
            }

            // validasi password
            if (passwordTxt.Text.Length < 8)
            {
                MessageBox.Show("Password minimal 8 karakter");
                return;
            }

            // validasi tanggal lahir (fitur tambahan)
            int umur = DateTime.Now.Year - lahirDate.Value.Year;

            // jika ulang tahun ini belum lewat (belum genap)
            if (lahirDate.Value.Date > DateTime.Today.AddYears(-umur)) // menyamakan tahun ini dengan tahun lahir agar bisa menghitung genapnya tanggal lahir
            {
                umur--; // mengurangi 1 jika ulang tahun belum terlewat (belum genap)
            }

            if (umur < 17) // validasi minimal 17 tahun untuk membuat akun
            {
                MessageBox.Show("Umur minimal 17 tahun!");
                return;
            }

            // Daftar akun baru dan masukkan ke dalam database
            Akun akunBaru = new Akun();

            akunBaru.Username = usernameTxt.Text;
            akunBaru.Nama = nameTxt.Text;
            akunBaru.TanggalLahir = lahirDate.Value;
            akunBaru.NomorTelepon = phoneTxt.Text;
            akunBaru.Password = passwordTxt.Text;
            akunBaru.MerupakanAdmin = false; // kita membuat akun customer

            db.Akuns.Add(akunBaru);
            db.SaveChanges();

            // tampilkan pesan
            MessageBox.Show("Berhasil membuat akun baru. \nSilahkan login");

            // lompat ke login screen
            Form1Login login = new Form1Login();
            login.Show();
            this.Hide();
        }
    }
}
