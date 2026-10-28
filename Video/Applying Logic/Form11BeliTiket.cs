using System;
using System.Globalization;
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
    public partial class Form11BeliTiket : Form
    {
        private Form10ListPenerbangan formSebelumnya;
        private Form9CustomerMain formCustomerMain;
        private int jadwalID;
        private int jumlahPenumpang;

        private List<PenumpangControl> daftarKartuPenumpang = new List<PenumpangControl>();

        private BandaraEntities db = new BandaraEntities();
        private JadwalPenerbangan jadwal;

        private double totalDiskon;
        private double totalPembayaranAkhir;
        private int? kodePromoID = null;

        private bool transaksiBerhasil;

        public Form11BeliTiket(Form10ListPenerbangan formSebelumnya, Form9CustomerMain formCustomerMain, int jadwalID, int jumlahPenumpang)
        {
            InitializeComponent();

            UIHelper.Normalize(this);
            this.formSebelumnya = formSebelumnya;
            this.formCustomerMain = formCustomerMain;
            this.jadwalID = jadwalID;
            this.jumlahPenumpang = jumlahPenumpang;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Hide();
            formSebelumnya.Show();
        }

        private void Form11BeliTiket_Load(object sender, EventArgs e)
        {
            if (!ValidatePenerbangan()) // jika data penerbangan tidak ditemukan
            {
                Close(); // tutup form dan hentikan fungsi
                return;
            }

            ShowParameter();
            GeneratePassengerCard();
            TotalCount();
        }

        private bool ValidatePenerbangan()
        {
            jadwal = db.JadwalPenerbangans.FirstOrDefault(j => j.ID == jadwalID);

            if (jadwal == null)
            {
                MessageBox.Show("Data penerbangan tidak ditemukan", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void ShowParameter()
        {
            DateTime waktuBerangkat = jadwal.TanggalWaktuKeberangkatan;

            departureLabel.Text = $"{jadwal.Bandara.Nama} ({jadwal.Bandara.KodeIATA})";
            destinationLabel.Text = $"{jadwal.Bandara1.Nama} ({jadwal.Bandara.KodeIATA})";

            maskapaiLabel.Text = jadwal.Maskapai.Nama;

            dateLabel.Text = waktuBerangkat.ToString("dddd, dd MM yyyy");

            timeLabel.Text = waktuBerangkat.ToString("HH:mm") + " - " + waktuBerangkat.AddMinutes(jadwal.DurasiPenerbangan).ToString("HH:mm");

            passengerLabel.Text = jumlahPenumpang + " Penumpang";
        }

        private void GeneratePassengerCard()
        {
            // hapus semua kartu yang sebelumnya ada di flowLayoutPanel
            flpPassenger.Controls.Clear();

            // kosongkan daftar card agar tidak menyimpan card lama
            daftarKartuPenumpang.Clear();

            for (int nomor = 1; nomor <= jumlahPenumpang; nomor++)
            {
                // membuat satu objek User Control untuk satu penumpang
                PenumpangControl card = new PenumpangControl();

                // mengirim nomor urut penumpang ke user control
                card.NomorPenumpang = nomor;

                // mengatur lebar card
                card.Width = flpPassenger.ClientSize.Width - SystemInformation.VerticalScrollBarWidth - 10;

                // menyimpan card ke dalam List agar datanya bisa dibaca kembali saat tombol konfirmasi pembayaran ditekan
                daftarKartuPenumpang.Add(card);

                // menampilkan User Control ke FlowLayoutPanel
                flpPassenger.Controls.Add(card);
            }
        }

        private void TotalCount()
        {
            // menghitung harga tiket sebelum diskon
            double totalSebelumDiskon = jadwal.HargaPerTiket * jumlahPenumpang;

            // mengurangi total harga dengan jumlah diskon
            totalPembayaranAkhir = totalSebelumDiskon - totalDiskon;

            // memastikan total pembayaran tidak menjadi negatif
            totalPembayaranAkhir = Math.Max(totalPembayaranAkhir, 0);

            // menampilkan hasil ke label
            priceLabel.Text = "IDR " + totalPembayaranAkhir.ToString("N0", CultureInfo.GetCultureInfo("id-ID")); // untuk format currency Indonesia
        }

        private void useBtn_Click(object sender, EventArgs e)
        {
            // mengambil teks dari Textbox kode promo
            string kodeInput = promoText.Text.Trim().ToUpper();

            // memeriksa apakah input kosong
            if (string.IsNullOrWhiteSpace(kodeInput))
            {
                MessageBox.Show("Masukkan kode promo terlebih dahulu", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ApplyPromoCode(kodeInput);
        }

        private void ApplyPromoCode(string kodeInput)
        {
            KodePromo promo = db.KodePromoes.FirstOrDefault(p => p.Kode == kodeInput);

            if (promo == null || promo.BerlakuSampai < DateTime.Today) // jika promo tidak valid
            {
                kodePromoID = null;
                totalDiskon = 0;
                TotalCount();
                MessageBox.Show("Kode promo tidak valid atau sudah kadaluarsa", "Kode Promo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // kode ini akan berjalan jika promo valid

            // ID ini nantinya akan digunakan saat menyimpan transaksi
            kodePromoID = promo.ID;

            double totalSebelumDiskon = jadwal.HargaPerTiket * jumlahPenumpang;

            // menghitung diskon berdasarkan persentase promo
            double diskonBerdasarkanPersen = totalSebelumDiskon * promo.PersentaseDiskon / 100.0;

            // memastikan diskon tidak melebihi batas maksimum
            totalDiskon = Math.Min(diskonBerdasarkanPersen, promo.MaksimumDiskon);

            TotalCount();

            MessageBox.Show("Kode promo berhasil digunakan", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool ValidateDataPenumpang()
        {
            // perulangan untuk memeriksa setiap User Control
            for (int i = 0; i < daftarKartuPenumpang.Count; i++)
            {
                // ambil kartu penumpang berdasarkan index
                PenumpangControl card = daftarKartuPenumpang[i];

                // cek input User Control
                if (!card.DataSudahLengkap)
                {
                    MessageBox.Show("Mohon lengkapi data penumpang #" + (i + 1), "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            // jika semua kartu sudah memiliki data yang lengkap, maka hasilnya akan true
            return true;
        }

        private void payBtn_Click(object sender, EventArgs e)
        {
            // periksa seluruh data penumpang terlebih dahulu, jika ada satu saja yang belum lengkap maka fungsi akan langsung dihentikan
            if (!ValidateDataPenumpang())
            {
                return;
            }


            // jika penyimpanan gagal, fungsi juga akan dihentikan
            if (!SaveTransaction())
            {
                return;
            }

            // menandai bahwa transaksi berhasil
            transaksiBerhasil = true;

            MessageBox.Show("Pembayaran berhasil! \nTerima kasih telah menggunakan Bromo Airlines.", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // setelah Close() dijalankan, event FormCLosing akan otomatis dipanggil
            Close();
        }

        private bool SaveTransaction()
        {
            // membuat database transaction agar header dan detail dianggap sebagai satu proses transaksi
            using (var databaseTransaction = db.Database.BeginTransaction())
            {
                try
                {
                    // membuat transaksi header
                    TransaksiHeader header = new TransaksiHeader
                    {
                        // ID akun customer yang sedang login
                        AkunID = Session.loggedIn.ID,

                        // waktu transaksi dilakukan
                        TanggalTransaksi = DateTime.Now,

                        // ID jadwal penerbangan yang dibeli
                        JadwalPenerbanganID = jadwalID,

                        // jumlah penumpang
                        JumlahPenumpang = jumlahPenumpang,

                        // total harga setelah diskon
                        TotalHarga = totalPembayaranAkhir,

                        // ID promo yang digunakan. (Bisa bernilai null jika tidak ada promo)
                        KodePromoID = kodePromoID
                    };

                    // memasukkan header ke entity framework
                    db.TransaksiHeaders.Add(header);

                    // menyimpan header ke database
                    db.SaveChanges();

                    // menyimpan detail penumpang
                    SavePassengerDetail(header.ID);

                    // menyimpan seluruh detail ke Database
                    db.SaveChanges();

                    // jika semua berhasil, transaction akan disahkan
                    databaseTransaction.Commit();

                    // memberitahu bahwa penyimpanan berhasil
                    return true;
                }
                catch (Exception ex)
                {
                    // jika terjadi error, batalkan semua perubahan
                    databaseTransaction.Rollback();

                    MessageBox.Show("Transaksi gagal disimpan. \n\n" + "Detail error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // memberitahu tombol konfirmasi bahwa penyimpanan gagal
                    return false;
                }
            }
        }

        private void SavePassengerDetail(int transaksiHeaderID)
        {
            // mengulang seluruh User Control yang tersimpan dalam daftarKartuPenumpang
            foreach (PenumpangControl card in daftarKartuPenumpang)
            {
                TransaksiDetail detail = new TransaksiDetail
                {
                    // menghubungkan detail dengan transaksi utama
                    TransaksiHeaderID = transaksiHeaderID,

                    // mengambil titel melalui property User Control
                    TitelPenumpang = card.Titel,

                    // mengambil nama melalui property User Control

                    NamaLengkapPenumpang = card.NamaLengkap
                };

                // menambahkan detail ke entity framework
                db.TransaksiDetails.Add(detail);
            }
        }

        private void Form11BeliTiket_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (transaksiBerhasil)
            {
                formCustomerMain.Show();
            }
            else
            {
                // Jika transaksi belum berhasil. Berarti customer kembali atau menutup form. Maka tampilkan kembali daftar penerbangan
                formSebelumnya.Show();
            }
        }
    }
}
