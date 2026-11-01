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
        BandaraEntities db = new BandaraEntities();
        private int idMaskapai = -1; // -1 = mode tambah

        public Form5Maskapai()
        {
            InitializeComponent();
            UIHelper.SetupGrid(dataGridMaskapai);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form5Maskapai_Load(object sender, EventArgs e)
        {
            LoadMaskapai();
            ResetForm();
        }

        private void LoadMaskapai()
        {
            var data = db.Maskapais
                         .OrderBy(m => m.Nama)
                         .Select(m => new
                         {
                             m.ID,
                             m.Nama,
                             m.Perusahaan,
                             m.JumlahKru,
                             m.Deskripsi
                         })
                         .ToList();

            dataGridMaskapai.DataSource = data;
        }

        private void ResetForm()
        {
            idMaskapai = -1;
            textBox1.Clear();
            textBox2.Clear();
            textBox5.Clear();
            numericUpDown1.Value = numericUpDown1.Minimum;
            button2.Text = "Simpan";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string nama = textBox1.Text.Trim();
            string perusahaan = textBox2.Text.Trim();
            string deskripsi = textBox5.Text.Trim();

            if (nama.Length == 0 || perusahaan.Length == 0 || deskripsi.Length == 0)
            {
                MessageBox.Show("Semua data maskapai harus diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int jumlahKru = Convert.ToInt32(numericUpDown1.Value);
            if (jumlahKru <= 0)
            {
                MessageBox.Show("Jumlah kru harus lebih dari 0!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (idMaskapai == -1)
                {
                    Maskapai maskapaiBaru = new Maskapai
                    {
                        Nama = nama,
                        Perusahaan = perusahaan,
                        JumlahKru = jumlahKru,
                        Deskripsi = deskripsi
                    };

                    db.Maskapais.Add(maskapaiBaru);
                    db.SaveChanges();
                    MessageBox.Show("Data maskapai berhasil ditambahkan.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Maskapai maskapaiEdit = db.Maskapais.Find(idMaskapai);
                    if (maskapaiEdit != null)
                    {
                        maskapaiEdit.Nama = nama;
                        maskapaiEdit.Perusahaan = perusahaan;
                        maskapaiEdit.JumlahKru = jumlahKru;
                        maskapaiEdit.Deskripsi = deskripsi;

                        db.SaveChanges();
                        MessageBox.Show("Data maskapai berhasil diperbarui.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                LoadMaskapai();
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat menyimpan data:\n" + ex.GetBaseException().Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridMaskapai_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int id = Convert.ToInt32(dataGridMaskapai.Rows[e.RowIndex].Cells["ID"].Value);
            string namaKolom = dataGridMaskapai.Columns[e.ColumnIndex].Name;

            if (namaKolom == "edit")
            {
                Maskapai maskapaiEdit = db.Maskapais.Find(id);
                if (maskapaiEdit != null)
                {
                    idMaskapai = maskapaiEdit.ID;
                    textBox1.Text = maskapaiEdit.Nama;
                    textBox2.Text = maskapaiEdit.Perusahaan;
                    textBox5.Text = maskapaiEdit.Deskripsi;
                    numericUpDown1.Value = Math.Max(maskapaiEdit.JumlahKru, (int)numericUpDown1.Minimum);
                    button2.Text = "Ubah";
                }
            }
            else if (namaKolom == "hapus")
            {
                var hasil = MessageBox.Show("Apakah Anda yakin ingin menghapus maskapai ini?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (hasil == DialogResult.Yes)
                {
                    try
                    {
                        Maskapai maskapaiHapus = db.Maskapais.Find(id);
                        if (maskapaiHapus != null)
                        {
                            bool dipakaiDiJadwal = db.JadwalPenerbangans.Any(j => j.MaskapaiID == id);
                            if (dipakaiDiJadwal)
                            {
                                MessageBox.Show("Maskapai ini tidak bisa dihapus karena masih terdaftar di jadwal penerbangan.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            db.Maskapais.Remove(maskapaiHapus);
                            db.SaveChanges();
                            MessageBox.Show("Data maskapai berhasil dihapus.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadMaskapai();
                            ResetForm();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Gagal menghapus maskapai:\n" + ex.GetBaseException().Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
