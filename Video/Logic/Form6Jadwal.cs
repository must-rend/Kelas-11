using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContohSoal1
{
    public partial class Form6Jadwal : Form
    {
        private BandaraEntities db;
        private int idJadwal = -1; // -1 = mode tambah

        public Form6Jadwal()
        {
            InitializeComponent();
            UIHelper.SetupGrid(dataGridJadwal);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form6Jadwal_Load(object sender, EventArgs e)
        {
            db = new BandaraEntities();
            LoadComboBoxes();
            LoadJadwal();
            ResetForm();
        }

        private void LoadComboBoxes()
        {
            var daftarBandaraAsal = db.Bandaras.OrderBy(b => b.Nama).ToList();
            var daftarBandaraTujuan = db.Bandaras.OrderBy(b => b.Nama).ToList();
            var daftarMaskapai = db.Maskapais.OrderBy(m => m.Nama).ToList();

            comboBox1.DataSource = daftarBandaraAsal;
            comboBox1.DisplayMember = "Nama";
            comboBox1.ValueMember = "ID";
            comboBox1.SelectedIndex = -1;

            comboBox3.DataSource = daftarBandaraTujuan;
            comboBox3.DisplayMember = "Nama";
            comboBox3.ValueMember = "ID";
            comboBox3.SelectedIndex = -1;

            comboBox2.DataSource = daftarMaskapai;
            comboBox2.DisplayMember = "Nama";
            comboBox2.ValueMember = "ID";
            comboBox2.SelectedIndex = -1;
        }

        private void LoadJadwal()
        {
            var data = db.JadwalPenerbangans
                         .Include(j => j.Bandara)
                         .Include(j => j.Bandara1)
                         .Include(j => j.Maskapai)
                         .Where(j => j.TanggalWaktuKeberangkatan >= DateTime.Today)
                         .OrderBy(j => j.TanggalWaktuKeberangkatan)
                         .Take(300)
                         .ToList()
                         .Select(j => new
                         {
                             j.ID,
                             j.KodePenerbangan,
                             BandaraAsal = j.Bandara.Nama,
                             BandaraTujuan = j.Bandara1.Nama,
                             Maskapai = j.Maskapai.Nama,
                             TanggalKeberangkatan = j.TanggalWaktuKeberangkatan.ToString("dd/MM/yyyy"),
                             WaktuKeberangkatan = j.TanggalWaktuKeberangkatan.ToString("HH:mm"),
                             DurasiPenerbangan = (j.DurasiPenerbangan / 60) + " Jam " + (j.DurasiPenerbangan % 60) + " Menit",
                             j.HargaPerTiket
                         })
                         .ToList();

            dataGridJadwal.DataSource = data;
        }

        private void ResetForm()
        {
            idJadwal = -1;
            textBox1.Clear();
            comboBox1.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            dateTimePicker1.Value = DateTime.Today;
            textBox2.Text = "00:00";
            textBox3.Text = "1 Jam 0 Menit";
            numericUpDown1.Value = numericUpDown1.Minimum;
            button2.Text = "Simpan";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string kode = textBox1.Text.Trim().ToUpper();

            if (!Regex.IsMatch(kode, @"^[A-Z]{2}-\d{4}$"))
            {
                MessageBox.Show("Format Kode Penerbangan harus: 2 Huruf Besar, strip, 4 Angka (Contoh: AA-1234)", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboBox1.SelectedIndex < 0 || comboBox3.SelectedIndex < 0 || comboBox2.SelectedIndex < 0)
            {
                MessageBox.Show("Silahkan pilih Bandara Asal, Bandara Tujuan, dan Maskapai!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int bandaraAsalID = Convert.ToInt32(comboBox1.SelectedValue);
            int bandaraTujuanID = Convert.ToInt32(comboBox3.SelectedValue);
            int maskapaiID = Convert.ToInt32(comboBox2.SelectedValue);

            if (bandaraAsalID == bandaraTujuanID)
            {
                MessageBox.Show("Bandara keberangkatan dan tujuan tidak boleh sama!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validasi waktu
            TimeSpan waktu;
            if (!TimeSpan.TryParse(textBox2.Text.Trim(), out waktu))
            {
                MessageBox.Show("Format waktu harus HH:mm (contoh: 08:30)", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime keberangkatan = dateTimePicker1.Value.Date + waktu;

            // Validasi durasi (xx Jam xx Menit)
            string[] durasi = textBox3.Text.Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int totalMenit = 0;
            if (durasi.Length == 4 && durasi[1].Equals("Jam", StringComparison.OrdinalIgnoreCase) && durasi[3].Equals("Menit", StringComparison.OrdinalIgnoreCase))
            {
                int jam, menit;
                if (int.TryParse(durasi[0], out jam) && int.TryParse(durasi[2], out menit))
                {
                    totalMenit = (jam * 60) + menit;
                }
            }
            else
            {
                // Fallback coba parse menit langsung
                int m;
                if (int.TryParse(textBox3.Text.Trim(), out m))
                {
                    totalMenit = m;
                }
            }

            if (totalMenit <= 0)
            {
                MessageBox.Show("Format durasi harus: 'xx Jam xx Menit' (contoh: 1 Jam 30 Menit)", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (idJadwal == -1)
                {
                    JadwalPenerbangan jadwalBaru = new JadwalPenerbangan
                    {
                        KodePenerbangan = kode,
                        BandaraKeberangkatanID = bandaraAsalID,
                        BandaraTujuanID = bandaraTujuanID,
                        MaskapaiID = maskapaiID,
                        TanggalWaktuKeberangkatan = keberangkatan,
                        DurasiPenerbangan = totalMenit,
                        HargaPerTiket = Convert.ToInt32(numericUpDown1.Value)
                    };

                    db.JadwalPenerbangans.Add(jadwalBaru);
                    db.SaveChanges();

                    StatusPenerbangan statusAwal = db.StatusPenerbangans.FirstOrDefault(s => s.Nama == "Tepat Waktu")
                                                ?? db.StatusPenerbangans.FirstOrDefault();
                    if (statusAwal != null)
                    {
                        PerubahanStatusJadwalPenerbangan statusJadwal = new PerubahanStatusJadwalPenerbangan
                        {
                            JadwalPenerbanganID = jadwalBaru.ID,
                            StatusPenerbanganID = statusAwal.ID,
                            WaktuPerubahanTerjadi = DateTime.Now,
                            PerkiraanDurasiDelay = null
                        };
                        db.PerubahanStatusJadwalPenerbangans.Add(statusJadwal);
                        db.SaveChanges();
                    }

                    MessageBox.Show("Data jadwal penerbangan berhasil ditambahkan.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    JadwalPenerbangan editJadwal = db.JadwalPenerbangans.Find(idJadwal);
                    if (editJadwal != null)
                    {
                        editJadwal.KodePenerbangan = kode;
                        editJadwal.BandaraKeberangkatanID = bandaraAsalID;
                        editJadwal.BandaraTujuanID = bandaraTujuanID;
                        editJadwal.MaskapaiID = maskapaiID;
                        editJadwal.TanggalWaktuKeberangkatan = keberangkatan;
                        editJadwal.DurasiPenerbangan = totalMenit;
                        editJadwal.HargaPerTiket = Convert.ToInt32(numericUpDown1.Value);

                        db.SaveChanges();
                        MessageBox.Show("Data jadwal penerbangan berhasil diperbarui.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                LoadJadwal();
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat menyimpan data:\n" + ex.GetBaseException().Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridJadwal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int id = Convert.ToInt32(dataGridJadwal.Rows[e.RowIndex].Cells["ID"].Value);
            string namaKolom = dataGridJadwal.Columns[e.ColumnIndex].Name;

            if (namaKolom == "edit")
            {
                JadwalPenerbangan editJadwal = db.JadwalPenerbangans.Find(id);
                if (editJadwal != null)
                {
                    idJadwal = editJadwal.ID;
                    textBox1.Text = editJadwal.KodePenerbangan;
                    comboBox1.SelectedValue = editJadwal.BandaraKeberangkatanID;
                    comboBox3.SelectedValue = editJadwal.BandaraTujuanID;
                    comboBox2.SelectedValue = editJadwal.MaskapaiID;
                    dateTimePicker1.Value = editJadwal.TanggalWaktuKeberangkatan.Date;
                    textBox2.Text = editJadwal.TanggalWaktuKeberangkatan.ToString("HH:mm");
                    int jam = editJadwal.DurasiPenerbangan / 60;
                    int menit = editJadwal.DurasiPenerbangan % 60;
                    textBox3.Text = $"{jam} Jam {menit} Menit";
                    numericUpDown1.Value = Math.Min(Math.Max((decimal)editJadwal.HargaPerTiket, numericUpDown1.Minimum), numericUpDown1.Maximum);
                    button2.Text = "Ubah";
                }
            }
            else if (namaKolom == "hapus")
            {
                var hasil = MessageBox.Show("Apakah Anda yakin ingin menghapus jadwal ini?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (hasil == DialogResult.Yes)
                {
                    try
                    {
                        JadwalPenerbangan jadwalHapus = db.JadwalPenerbangans.Find(id);
                        if (jadwalHapus != null)
                        {
                            bool adaTransaksi = db.TransaksiHeaders.Any(t => t.JadwalPenerbanganID == id);
                            if (adaTransaksi)
                            {
                                MessageBox.Show("Jadwal ini tidak dapat dihapus karena sudah ada transaksi tiket terkait.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            var statusJadwal = db.PerubahanStatusJadwalPenerbangans.Where(p => p.JadwalPenerbanganID == id).ToList();
                            db.PerubahanStatusJadwalPenerbangans.RemoveRange(statusJadwal);

                            db.JadwalPenerbangans.Remove(jadwalHapus);
                            db.SaveChanges();
                            MessageBox.Show("Data jadwal penerbangan berhasil dihapus.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadJadwal();
                            ResetForm();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Gagal menghapus jadwal:\n" + ex.GetBaseException().Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
