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
    public partial class Form10ListPenerbangan : Form
    {
        BandaraEntities db = new BandaraEntities();

        private Form9CustomerMain formSebelumnya;
        private int bandaraAsalID;
        private int bandaraTujuanID;
        private DateTime tanggalBerangkat;
        private int jumlahPenumpang;

        public Form10ListPenerbangan(Form9CustomerMain formSebelumnya,
                                    int bandaraAsalID,
                                    int bandaraTujuanID,
                                    DateTime tanggalBerangkat,
                                    int jumlahPenumpang)
        {
            InitializeComponent();
            UIHelper.SetupGrid(dataGridView1);
            this.StartPosition = FormStartPosition.CenterScreen;

            this.formSebelumnya = formSebelumnya;
            this.bandaraAsalID = bandaraAsalID;
            this.bandaraTujuanID = bandaraTujuanID;
            this.tanggalBerangkat = tanggalBerangkat;
            this.jumlahPenumpang = jumlahPenumpang;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (formSebelumnya != null && !formSebelumnya.IsDisposed)
            {
                formSebelumnya.Show();
            }
            else
            {
                new Form9CustomerMain().Show();
            }
            this.Close();
        }

        private void Form10ListPenerbangan_Load(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                comboBox1.SelectedIndex = 0;
            }

            if (dataGridView1.Columns["HargaPerTiket"] != null)
            {
                dataGridView1.Columns["HargaPerTiket"].DefaultCellStyle.Format = "N0";
                dataGridView1.Columns["HargaPerTiket"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            ShowParameter();
            LoadData();

            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Tidak ada penerbangan yang cocok dengan pencarian ini.\nSilahkan coba tanggal, rute, atau filter waktu lain.",
                                "Penerbangan tidak ditemukan", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ShowParameter()
        {
            var bandaraAsal = db.Bandaras.FirstOrDefault(b => b.ID == bandaraAsalID);
            var bandaraTujuan = db.Bandaras.FirstOrDefault(b => b.ID == bandaraTujuanID);

            if (bandaraAsal != null)
            {
                label2.Text = $"{bandaraAsal.Nama} ({bandaraAsal.KodeIATA})";
            }

            if (bandaraTujuan != null)
            {
                label3.Text = $"{bandaraTujuan.Nama} ({bandaraTujuan.KodeIATA})";
            }

            label4.Text = tanggalBerangkat.ToString("ddd, dd MMM yyyy");
            label5.Text = jumlahPenumpang.ToString() + " Penumpang";
        }

        private void LoadData()
        {
            DateTime awalHari = tanggalBerangkat.Date;
            DateTime akhirHari = awalHari.AddDays(1);
            DateTime sekarang = DateTime.Now;

            var query = db.JadwalPenerbangans
                        .Include(j => j.Maskapai)
                        .Include(j => j.Bandara)
                        .Include(j => j.Bandara1)
                        .Where(j => j.BandaraKeberangkatanID == bandaraAsalID
                                 && j.BandaraTujuanID == bandaraTujuanID
                                 && j.TanggalWaktuKeberangkatan >= awalHari
                                 && j.TanggalWaktuKeberangkatan < akhirHari
                                 && j.TanggalWaktuKeberangkatan > sekarang);

            bool adaFilter = checkBox1.Checked || checkBox2.Checked || checkBox3.Checked || checkBox4.Checked;

            if (adaFilter)
            {
                query = query.Where(j => (checkBox1.Checked && j.TanggalWaktuKeberangkatan.Hour >= 0 && j.TanggalWaktuKeberangkatan.Hour < 6)
                                      || (checkBox2.Checked && j.TanggalWaktuKeberangkatan.Hour >= 6 && j.TanggalWaktuKeberangkatan.Hour < 12)
                                      || (checkBox3.Checked && j.TanggalWaktuKeberangkatan.Hour >= 12 && j.TanggalWaktuKeberangkatan.Hour < 18)
                                      || (checkBox4.Checked && j.TanggalWaktuKeberangkatan.Hour >= 18 && j.TanggalWaktuKeberangkatan.Hour < 24));
            }

            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    query = query.OrderBy(j => j.HargaPerTiket);
                    break;
                case 1:
                    query = query.OrderBy(j => j.TanggalWaktuKeberangkatan);
                    break;
                case 2:
                    query = query.OrderByDescending(j => j.TanggalWaktuKeberangkatan);
                    break;
                case 3:
                    query = query.OrderBy(j => DbFunctions.AddMinutes(j.TanggalWaktuKeberangkatan, j.DurasiPenerbangan));
                    break;
                case 4:
                    query = query.OrderByDescending(j => DbFunctions.AddMinutes(j.TanggalWaktuKeberangkatan, j.DurasiPenerbangan));
                    break;
                default:
                    query = query.OrderBy(j => j.HargaPerTiket);
                    break;
            }

            var data = query.ToList()
                            .Select(j => new
                            {
                                j.ID,
                                j.KodePenerbangan,
                                Maskapai = j.Maskapai.Nama,
                                BandaraAsal = j.Bandara.Nama,
                                BandaraTujuan = j.Bandara1.Nama,
                                j.HargaPerTiket,
                                Tanggal = j.TanggalWaktuKeberangkatan.ToString("dd-MM-yyyy"),
                                Jam = j.TanggalWaktuKeberangkatan.ToString("HH:mm")
                            })
                            .ToList();

            dataGridView1.DataSource = data;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dataGridView1.Columns[e.ColumnIndex].Name == "BeliTiket")
            {
                int id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value);
                Form11BeliTiket beliTiket = new Form11BeliTiket(this, formSebelumnya, id, jumlahPenumpang);
                beliTiket.Show();
                this.Hide();
            }
        }
    }
}
