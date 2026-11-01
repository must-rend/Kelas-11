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
        //private int jadwalID;

        public Form10ListPenerbangan(Form9CustomerMain formSebelumnya,
                                    int bandaraAsalID,
                                    int bandaraTujuanID,
                                    DateTime tanggalBerangkat,
                                    int jumlahPenumpang)
        {
            InitializeComponent();

            this.formSebelumnya = formSebelumnya;
            this.bandaraAsalID = bandaraAsalID;
            this.bandaraTujuanID = bandaraTujuanID;
            this.tanggalBerangkat = tanggalBerangkat;
            this.jumlahPenumpang = jumlahPenumpang;
            //this.jadwalID = jadwalID;

            // untuk menerima, menampani kiriman parameter dari customer main form
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Form9CustomerMain customerMain = new Form9CustomerMain();

            customerMain.Show();
            this.Hide();
        }

        private void Form10ListPenerbangan_Load(object sender, EventArgs e)
        {
            dataGridPenerbangan.AutoGenerateColumns = false;
            dataGridPenerbangan.AllowUserToAddRows = false;
            dataGridPenerbangan.ReadOnly = true;

            ShowParameter();
            LoadData();
        }

        private void ShowParameter()
        {
            var bandaraAsal = db.Bandaras.FirstOrDefault(b => b.ID == bandaraAsalID);
            var bandaraTujuan = db.Bandaras.FirstOrDefault(b => b.ID == bandaraTujuanID);

            if (bandaraAsal != null)
            {
                departureLabel.Text = $"{bandaraAsal.Nama} ({bandaraAsal.KodeIATA})";
            }

            if (bandaraTujuan != null)
            {
                destinationLabel.Text = $"{bandaraTujuan.Nama} ({bandaraTujuan.KodeIATA})";
            }

            dateLabel.Text = tanggalBerangkat.ToString("dddd, dd MMMM yyyy");
            passengerLabel.Text = jumlahPenumpang.ToString() + " Penumpang";
        }

        private void LoadData()
        {
            var query = db.JadwalPenerbangans
                        .Include(j => j.Maskapai)
                        .Include(j => j.Bandara)
                        .Include(j => j.Bandara1)
                        .Where(j => j.BandaraKeberangkatanID == bandaraAsalID && j.BandaraTujuanID == bandaraTujuanID && DbFunctions.TruncateTime(j.TanggalWaktuKeberangkatan) == DbFunctions.TruncateTime(tanggalBerangkat));

            bool adaFilter = timeCheck1.Checked || timeCheck2.Checked || timeCheck3.Checked || timeCheck4.Checked;

            if (adaFilter)
            {
                query = query.Where(j => (timeCheck1.Checked && j.TanggalWaktuKeberangkatan.Hour >= 0 && j.TanggalWaktuKeberangkatan.Hour < 6) || (timeCheck2.Checked && j.TanggalWaktuKeberangkatan.Hour >= 6 && j.TanggalWaktuKeberangkatan.Hour < 12) || (timeCheck3.Checked && j.TanggalWaktuKeberangkatan.Hour >= 12 && j.TanggalWaktuKeberangkatan.Hour < 18) || (timeCheck4.Checked && j.TanggalWaktuKeberangkatan.Hour >= 18 && j.TanggalWaktuKeberangkatan.Hour < 24));
            }

            switch (sortBox.SelectedIndex)
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
                case 5:
                    query = query.OrderBy(j => j.DurasiPenerbangan);
                    break;
            }

            dataGridPenerbangan.DataSource = query.AsEnumerable().Select(j => new 
            {
                j.ID,
                j.KodePenerbangan,
                Maskapai = j.Maskapai.Nama,
                BandaraKeberangkatan = j.Bandara.Nama,
                BandaraTujuan = j.Bandara1.Nama,
                j.HargaPerTiket,
                Tanggal = j.TanggalWaktuKeberangkatan.ToString("dd-MM-yyyy"),
                Jam = j.TanggalWaktuKeberangkatan.ToString("HH:mm") + " - " + j.TanggalWaktuKeberangkatan.AddMinutes(j.DurasiPenerbangan).ToString("HH:mm")
            }).ToList();
        }

        private void applyBtn_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataGridPenerbangan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            if (dataGridPenerbangan.Columns[e.ColumnIndex].Name == "BeliTiket")
            {
                int jadwalID = Convert.ToInt32(dataGridPenerbangan.Rows[e.RowIndex].Cells["ID"].Value);

                Form11BeliTiket formBeliTiket = new Form11BeliTiket(this, formSebelumnya, jadwalID, jumlahPenumpang);

                this.Hide();
                formBeliTiket.Show();
            }
        }
    }
}
