using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContohSoal1
{
    public partial class Form4Bandara : Form
    {
        BandaraEntities db = new BandaraEntities();
        private int idBandara = -1; // -1 = mode tambah, > 0 = mode edit

        public Form4Bandara()
        {
            InitializeComponent();
            UIHelper.SetupGrid(dataGridBandara);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form4Bandara_Load(object sender, EventArgs e)
        {
            LoadNegara();
            LoadBandara();
            ResetForm();
        }

        private void LoadNegara()
        {
            List<Negara> daftarNegara = db.Negaras.OrderBy(n => n.Nama).ToList();
            comboBox1.DataSource = daftarNegara;
            comboBox1.DisplayMember = "Nama";
            comboBox1.ValueMember = "ID";
            comboBox1.SelectedIndex = -1;
        }

        private void LoadBandara()
        {
            var data = db.Bandaras
                         .Include(b => b.Negara)
                         .OrderBy(b => b.Nama)
                         .Select(b => new
                         {
                             b.ID,
                             b.Nama,
                             b.KodeIATA,
                             b.Kota,
                             Negara = b.Negara.Nama,
                             b.JumlahTerminal,
                             b.Alamat
                         })
                         .ToList();

            dataGridBandara.DataSource = data;
        }

        private void ResetForm()
        {
            idBandara = -1;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox5.Clear();
            comboBox1.SelectedIndex = -1;
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
            string kodeIATA = textBox2.Text.Trim().ToUpper();
            string kota = textBox3.Text.Trim();
            string alamat = textBox5.Text.Trim();

            if (nama.Length == 0 || kodeIATA.Length == 0 || kota.Length == 0 || alamat.Length == 0)
            {
                MessageBox.Show("Semua data bandara harus diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (kodeIATA.Length != 3 || !kodeIATA.All(char.IsLetter))
            {
                MessageBox.Show("Kode IATA harus terdiri dari 3 huruf (contoh: CGK)!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboBox1.SelectedIndex < 0 || comboBox1.SelectedValue == null)
            {
                MessageBox.Show("Pilih negara terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int negaraID = Convert.ToInt32(comboBox1.SelectedValue);

            bool kodeSudahDipakai = db.Bandaras.Any(b => b.KodeIATA == kodeIATA && b.ID != idBandara);
            if (kodeSudahDipakai)
            {
                MessageBox.Show($"Kode IATA '{kodeIATA}' sudah digunakan oleh bandara lain!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (idBandara == -1)
                {
                    Bandara bandaraBaru = new Bandara
                    {
                        Nama = nama,
                        KodeIATA = kodeIATA,
                        Kota = kota,
                        NegaraID = negaraID,
                        JumlahTerminal = Convert.ToInt32(numericUpDown1.Value),
                        Alamat = alamat
                    };

                    db.Bandaras.Add(bandaraBaru);
                    db.SaveChanges();
                    MessageBox.Show("Data bandara berhasil ditambahkan.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Bandara bandaraEdit = db.Bandaras.Find(idBandara);
                    if (bandaraEdit != null)
                    {
                        bandaraEdit.Nama = nama;
                        bandaraEdit.KodeIATA = kodeIATA;
                        bandaraEdit.Kota = kota;
                        bandaraEdit.NegaraID = negaraID;
                        bandaraEdit.JumlahTerminal = Convert.ToInt32(numericUpDown1.Value);
                        bandaraEdit.Alamat = alamat;

                        db.SaveChanges();
                        MessageBox.Show("Data bandara berhasil diperbarui.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                LoadBandara();
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat menyimpan data:\n" + ex.GetBaseException().Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridBandara_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int id = Convert.ToInt32(dataGridBandara.Rows[e.RowIndex].Cells["ID"].Value);
            string namaKolom = dataGridBandara.Columns[e.ColumnIndex].Name;

            if (namaKolom == "edit")
            {
                Bandara bandaraEdit = db.Bandaras.Find(id);
                if (bandaraEdit != null)
                {
                    idBandara = bandaraEdit.ID;
                    textBox1.Text = bandaraEdit.Nama;
                    textBox2.Text = bandaraEdit.KodeIATA;
                    textBox3.Text = bandaraEdit.Kota;
                    textBox5.Text = bandaraEdit.Alamat;
                    comboBox1.SelectedValue = bandaraEdit.NegaraID;
                    numericUpDown1.Value = Math.Max(bandaraEdit.JumlahTerminal, (int)numericUpDown1.Minimum);
                    button2.Text = "Ubah";
                }
            }
            else if (namaKolom == "hapus")
            {
                var hasil = MessageBox.Show("Apakah Anda yakin ingin menghapus bandara ini?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (hasil == DialogResult.Yes)
                {
                    try
                    {
                        Bandara bandaraHapus = db.Bandaras.Find(id);
                        if (bandaraHapus != null)
                        {
                            bool dipakaiDiJadwal = db.JadwalPenerbangans.Any(j => j.BandaraKeberangkatanID == id || j.BandaraTujuanID == id);
                            if (dipakaiDiJadwal)
                            {
                                MessageBox.Show("Bandara ini tidak bisa dihapus karena masih terdaftar di jadwal penerbangan.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            db.Bandaras.Remove(bandaraHapus);
                            db.SaveChanges();
                            MessageBox.Show("Data bandara berhasil dihapus.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadBandara();
                            ResetForm();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Gagal menghapus bandara:\n" + ex.GetBaseException().Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
