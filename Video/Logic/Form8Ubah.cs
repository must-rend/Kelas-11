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
    public partial class Form8Ubah : Form
    {
        BandaraEntities db = new BandaraEntities();
        private int idJadwalTerpilih = -1;

        public Form8Ubah()
        {
            InitializeComponent();
            UIHelper.SetupGrid(dataGridStatus);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form8Ubah_Load(object sender, EventArgs e)
        {
            LoadStatus();
            LoadData();
            ResetForm();
        }

        private void LoadStatus()
        {
            statusBox.DataSource = db.StatusPenerbangans.OrderBy(s => s.Nama).ToList();
            statusBox.DisplayMember = "Nama";
            statusBox.ValueMember = "ID";
            statusBox.SelectedIndex = -1;
        }

        private void LoadData()
        {
            DateTime mulai = DateTime.Today;
            DateTime selesai = DateTime.Today.AddDays(14);

            List<JadwalPenerbangan> daftarJadwal = db.JadwalPenerbangans
                .Include(j => j.Bandara)
                .Include(j => j.Bandara1)
                .Include(j => j.Maskapai)
                .Where(j => j.TanggalWaktuKeberangkatan >= mulai
                         && j.TanggalWaktuKeberangkatan <= selesai)
                .OrderBy(j => j.TanggalWaktuKeberangkatan)
                .Take(200)
                .ToList();

            List<int> idJadwal = daftarJadwal.Select(j => j.ID).ToList();

            List<PerubahanStatusJadwalPenerbangan> semuaStatus = db.PerubahanStatusJadwalPenerbangans
                .Include(p => p.StatusPenerbangan)
                .Where(p => idJadwal.Contains(p.JadwalPenerbanganID))
                .ToList();

            Dictionary<int, PerubahanStatusJadwalPenerbangan> statusTerakhir = semuaStatus
                .GroupBy(p => p.JadwalPenerbanganID)
                .ToDictionary(g => g.Key, g => g.OrderByDescending(p => p.WaktuPerubahanTerjadi).First());

            var data = daftarJadwal
                .Select(j =>
                {
                    PerubahanStatusJadwalPenerbangan terakhir;
                    statusTerakhir.TryGetValue(j.ID, out terakhir);

                    return new
                    {
                        j.ID,
                        j.KodePenerbangan,
                        BandaraAsal = j.Bandara.Nama,
                        BandaraTujuan = j.Bandara1.Nama,
                        Maskapai = j.Maskapai.Nama,
                        TanggalKeberangkatan = j.TanggalWaktuKeberangkatan.ToString("dd/MM/yyyy"),
                        WaktuKeberangkatan = j.TanggalWaktuKeberangkatan.ToString("HH:mm"),
                        DurasiPenerbangan = (j.DurasiPenerbangan / 60) + " Jam " + (j.DurasiPenerbangan % 60) + " Menit",
                        StatusTerakhir = terakhir == null ? "Sesuai Jadwal" : terakhir.StatusPenerbangan.Nama,
                        TerakhirDiubah = terakhir == null ? "-" : terakhir.WaktuPerubahanTerjadi.ToString("HH:mm")
                    };
                })
                .ToList();

            dataGridStatus.DataSource = data;
        }

        private void ResetForm()
        {
            idJadwalTerpilih = -1;
            statusBox.SelectedIndex = -1;
            textBox1.Text = "__ Jam __ Menit";
            button2.Text = "Simpan";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void dataGridStatus_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            idJadwalTerpilih = Convert.ToInt32(dataGridStatus.Rows[e.RowIndex].Cells["ID"].Value);
            string namaKolom = dataGridStatus.Columns[e.ColumnIndex].Name;

            if (namaKolom == "hapus")
            {
                var hasil = MessageBox.Show("Hapus riwayat status terakhir untuk penerbangan ini?", "Konfirmasi",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (hasil != DialogResult.Yes) return;

                try
                {
                    PerubahanStatusJadwalPenerbangan terakhir = db.PerubahanStatusJadwalPenerbangans
                        .Where(p => p.JadwalPenerbanganID == idJadwalTerpilih)
                        .OrderByDescending(p => p.WaktuPerubahanTerjadi)
                        .FirstOrDefault();

                    if (terakhir != null)
                    {
                        db.PerubahanStatusJadwalPenerbangans.Remove(terakhir);
                        db.SaveChanges();
                        MessageBox.Show("Status terakhir berhasil dihapus.", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Belum ada riwayat status untuk penerbangan ini.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Status gagal dihapus:\n" + ex.GetBaseException().Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    db.Dispose();
                    db = new BandaraEntities();
                }

                LoadData();
                ResetForm();
                return;
            }

            // Edit
            JadwalPenerbangan jadwal = db.JadwalPenerbangans.Find(idJadwalTerpilih);
            if (jadwal == null)
            {
                MessageBox.Show("Data penerbangan tidak ditemukan.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PerubahanStatusJadwalPenerbangan statusSaatIni = db.PerubahanStatusJadwalPenerbangans
                .Where(p => p.JadwalPenerbanganID == idJadwalTerpilih)
                .OrderByDescending(p => p.WaktuPerubahanTerjadi)
                .FirstOrDefault();

            if (statusSaatIni != null)
            {
                statusBox.SelectedValue = statusSaatIni.StatusPenerbanganID;

                if (statusSaatIni.PerkiraanDurasiDelay.HasValue && statusSaatIni.PerkiraanDurasiDelay.Value > 0)
                {
                    int total = statusSaatIni.PerkiraanDurasiDelay.Value;
                    textBox1.Text = $"{total / 60} Jam {total % 60} Menit";
                }
                else
                {
                    textBox1.Text = "__ Jam __ Menit";
                }
            }
            else
            {
                statusBox.SelectedIndex = -1;
                textBox1.Text = "__ Jam __ Menit";
            }

            button2.Text = "Simpan";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (idJadwalTerpilih < 0)
            {
                MessageBox.Show("Silahkan pilih penerbangan dari tabel terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (statusBox.SelectedIndex < 0 || statusBox.SelectedValue == null)
            {
                MessageBox.Show("Silahkan pilih status penerbangan.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int statusID = Convert.ToInt32(statusBox.SelectedValue);
            string namaStatus = ((StatusPenerbangan)statusBox.SelectedItem).Nama;

            int? durasiDelay = null;

            if (namaStatus.IndexOf("Delay", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                string input = textBox1.Text.Trim();
                string[] parts = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                int jam = 0, menit = 0;
                bool valid = false;

                if (parts.Length == 4 && parts[1].Equals("Jam", StringComparison.OrdinalIgnoreCase) && parts[3].Equals("Menit", StringComparison.OrdinalIgnoreCase))
                {
                    valid = int.TryParse(parts[0], out jam) && int.TryParse(parts[2], out menit);
                }

                if (!valid)
                {
                    MessageBox.Show("Untuk status Delay, format durasi harus: 'xx Jam xx Menit' (contoh: 1 Jam 30 Menit)", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                durasiDelay = (jam * 60) + menit;
            }

            try
            {
                PerubahanStatusJadwalPenerbangan perubahan = new PerubahanStatusJadwalPenerbangan
                {
                    JadwalPenerbanganID = idJadwalTerpilih,
                    StatusPenerbanganID = statusID,
                    WaktuPerubahanTerjadi = DateTime.Now,
                    PerkiraanDurasiDelay = durasiDelay
                };

                db.PerubahanStatusJadwalPenerbangans.Add(perubahan);
                db.SaveChanges();

                MessageBox.Show("Status penerbangan berhasil diperbarui.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat menyimpan status:\n" + ex.GetBaseException().Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
