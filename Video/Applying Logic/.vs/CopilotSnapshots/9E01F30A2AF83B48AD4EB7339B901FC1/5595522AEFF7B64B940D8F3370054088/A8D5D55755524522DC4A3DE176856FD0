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
    public partial class Form9CustomerMain : Form
    {
        BandaraEntities db = new BandaraEntities();

        public Form9CustomerMain()
        {
            InitializeComponent();
        }

        private void Form9CustomerMain_Load(object sender, EventArgs e)
        {
            welcomeLabel.Text = $"Mau terbang ke mana hari ini, {Session.loggedIn.Nama}?";

            // mengatur tanggal keberangkatan
            departureDate.MinDate = DateTime.Today;
            departureDate.Value = DateTime.Today;

            // memuat data bandara untuk autocomplete
            BandaraAutoComplete();
        }

        private void BandaraAutoComplete()
        {
            var semuaBandara = db.Bandaras.ToList();

            AutoCompleteStringCollection daftarSaran = new AutoCompleteStringCollection();

            foreach (var bandara in semuaBandara)
            {
                string teks = $"{bandara.Nama}, {bandara.Kota} ({bandara.KodeIATA})";
                daftarSaran.Add(teks);
            }

            foreach (TextBox txt in new[] { departureText, destinationText })
            {
                txt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txt.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txt.AutoCompleteCustomSource = daftarSaran;
            }
        }

        private string AmbilKodeIATA(string teksInput)
        {
            if (string.IsNullOrWhiteSpace(teksInput)) // error handling jika textbox kosong
            {
                return null;
            }

            // mencari posisi tanda "()"
            int posisiBukaKurung = teksInput.LastIndexOf('(');
            int posisiTutupKurung = teksInput.LastIndexOf(')');

            // memastikan format input benar
            if (posisiBukaKurung == -1 || posisiTutupKurung == -1 || posisiBukaKurung == posisiTutupKurung)
            {
                return null;
            }

            // menghitung jumlah karakter di antara kedua tanda kurung
            int panjangKode = posisiTutupKurung - posisiBukaKurung - 1;

            // mengambil kode IATA
            string kodeIATA = teksInput.Substring(posisiBukaKurung + 1, panjangKode);

            return kodeIATA.Trim();
        }

        private void logOutBtn_Click(object sender, EventArgs e)
        {
            Session.loggedIn = null;

            MessageBox.Show("Terimakasih sudah menggunakan layanan kami \nSampai jumpa :D");

            Form1Login loginForm = new Form1Login();
            loginForm.Show();

            this.Close();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Form12TiketSaya tiketSaya = new Form12TiketSaya();
            tiketSaya.Show();

            this.Hide();
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            

            string kodeAsal = AmbilKodeIATA(departureText.Text);
            string kodeTujuan = AmbilKodeIATA(destinationText.Text);

            // memastikan bandara keberangkatan dipilih dari daftar AutoComplete
            if (kodeAsal == null)
            {
                MessageBox.Show("Bandara keberangkatan tidak valid. Silahkan pilih dari daftar saran", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (passengerCount.Value <= 0)
            {
                MessageBox.Show("Jumlah penumpang minimal 1", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // memastikan bandara tujuan dipilih dari daftar AutoComplete
            if (kodeTujuan == null)
            {
                MessageBox.Show("Bandara tujuan tidak valid. Silahkan pilih dari daftar saran", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // mengambil data bandara asal dan tujuan berdasarkan kode IATA
            var daftarBandara = db.Bandaras.Where(b => b.KodeIATA == kodeAsal || b.KodeIATA == kodeTujuan).ToList();

            var bandaraAsal = daftarBandara.FirstOrDefault(b => b.KodeIATA == kodeAsal);
            var bandaraTujuan = daftarBandara.FirstOrDefault(b => b.KodeIATA == kodeTujuan);

            //Form10ListPenerbangan listPenerbangan = new Form10ListPenerbangan(this, bandaraAsal.ID, bandaraTujuan.ID, departureDate.Value, Convert.ToInt32(passengerCount.Value));
            //listPenerbangan.Show();

            if (bandaraAsal == null || bandaraTujuan == null)
            {
                MessageBox.Show("Bandara tidak ditemukan di database", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            welcomeLabel.Text = "Kode Asal: " + kodeAsal + ". Kode Tujuan: " + kodeTujuan;


            // membuka form list penerbangan dan mengirim parameter pencarian jika data berhasil ditemukan di database
            Hide();

            new Form10ListPenerbangan(this,
                                    bandaraAsal.ID,
                                    bandaraTujuan.ID,
                                    departureDate.Value,
                                    Convert.ToInt32(passengerCount.Value)).Show(); ;

            
            //Hide();

            //new Form10ListPenerbangan(this, bandaraAsal.ID, bandaraTujuan.ID, departureDate.Value, Convert.ToInt32(passengerCount.Value)).Show(); ;
            //this.Hide();
        }
    }
}
