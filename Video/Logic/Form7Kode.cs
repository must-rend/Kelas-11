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
    public partial class Form7Kode : Form
    {
        BandaraEntities db = new BandaraEntities();
        private int idPromo = -1; // -1 = mode tambah

        public Form7Kode()
        {
            InitializeComponent();
            UIHelper.SetupGrid(dataGridPromo);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form7Kode_Load(object sender, EventArgs e)
        {
            LoadPromo();
            ResetForm();
        }

        private void LoadPromo()
        {
            var data = db.KodePromoes
                         .OrderBy(p => p.Kode)
                         .Select(p => new
                         {
                             p.ID,
                             p.Kode,
                             p.PersentaseDiskon,
                             p.MaksimumDiskon,
                             BerlakuSampai = p.BerlakuSampai,
                             p.Deskripsi
                         })
                         .ToList()
                         .Select(p => new
                         {
                             p.ID,
                             p.Kode,
                             p.PersentaseDiskon,
                             MaksimumDiskon = p.MaksimumDiskon.ToString("N0"),
                             BerlakuSampai = p.BerlakuSampai.ToString("dd/MM/yyyy"),
                             p.Deskripsi
                         })
                         .ToList();

            dataGridPromo.DataSource = data;
        }

        private void ResetForm()
        {
            idPromo = -1;
            textBox1.Clear();
            dateTimePicker1.Value = DateTime.Today.AddDays(30);
            numericUpDown2.Value = 10; // Diskon %
            numericUpDown1.Value = 100000; // Maks Diskon
            textBox2.Clear();
            button2.Text = "Simpan";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string kode = textBox1.Text.Trim().ToUpper();
            string deskripsi = textBox2.Text.Trim();

            if (kode.Length == 0 || deskripsi.Length == 0)
            {
                MessageBox.Show("Semua kolom harus diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int diskon = Convert.ToInt32(numericUpDown2.Value);
            int maksDiskon = Convert.ToInt32(numericUpDown1.Value);

            if (diskon <= 0 || diskon > 100)
            {
                MessageBox.Show("Persentase diskon harus di antara 1% - 100%!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool kodeSudahAda = db.KodePromoes.Any(p => p.Kode == kode && p.ID != idPromo);
            if (kodeSudahAda)
            {
                MessageBox.Show($"Kode promo '{kode}' sudah digunakan!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (idPromo == -1)
                {
                    KodePromo promoBaru = new KodePromo
                    {
                        Kode = kode,
                        PersentaseDiskon = diskon,
                        MaksimumDiskon = maksDiskon,
                        BerlakuSampai = dateTimePicker1.Value.Date,
                        Deskripsi = deskripsi
                    };

                    db.KodePromoes.Add(promoBaru);
                    db.SaveChanges();
                    MessageBox.Show("Kode promo berhasil ditambahkan.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    KodePromo promoEdit = db.KodePromoes.Find(idPromo);
                    if (promoEdit != null)
                    {
                        promoEdit.Kode = kode;
                        promoEdit.PersentaseDiskon = diskon;
                        promoEdit.MaksimumDiskon = maksDiskon;
                        promoEdit.BerlakuSampai = dateTimePicker1.Value.Date;
                        promoEdit.Deskripsi = deskripsi;

                        db.SaveChanges();
                        MessageBox.Show("Kode promo berhasil diperbarui.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                LoadPromo();
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat menyimpan promo:\n" + ex.GetBaseException().Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridPromo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int id = Convert.ToInt32(dataGridPromo.Rows[e.RowIndex].Cells["ID"].Value);
            string namaKolom = dataGridPromo.Columns[e.ColumnIndex].Name;

            if (namaKolom == "edit")
            {
                KodePromo promoEdit = db.KodePromoes.Find(id);
                if (promoEdit != null)
                {
                    idPromo = promoEdit.ID;
                    textBox1.Text = promoEdit.Kode;
                    dateTimePicker1.Value = promoEdit.BerlakuSampai;
                    numericUpDown2.Value = Math.Min(Math.Max((decimal)promoEdit.PersentaseDiskon, numericUpDown2.Minimum), numericUpDown2.Maximum);
                    numericUpDown1.Value = Math.Min(Math.Max((decimal)promoEdit.MaksimumDiskon, numericUpDown1.Minimum), numericUpDown1.Maximum);
                    textBox2.Text = promoEdit.Deskripsi;
                    button2.Text = "Ubah";
                }
            }
            else if (namaKolom == "hapus")
            {
                var hasil = MessageBox.Show("Apakah Anda yakin ingin menghapus kode promo ini?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (hasil == DialogResult.Yes)
                {
                    try
                    {
                        KodePromo promoHapus = db.KodePromoes.Find(id);
                        if (promoHapus != null)
                        {
                            bool dipakaiTransaksi = db.TransaksiHeaders.Any(t => t.KodePromoID == id);
                            if (dipakaiTransaksi)
                            {
                                MessageBox.Show("Kode promo ini tidak dapat dihapus karena sudah pernah digunakan dalam transaksi.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            db.KodePromoes.Remove(promoHapus);
                            db.SaveChanges();
                            MessageBox.Show("Kode promo berhasil dihapus.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadPromo();
                            ResetForm();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Gagal menghapus kode promo:\n" + ex.GetBaseException().Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // Navigation
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form3Dashboard form = new Form3Dashboard();
            this.Close();
            form.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Form3Dashboard form = new Form3Dashboard();
            this.Close();
            form.Show();
        }

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
