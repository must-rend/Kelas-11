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
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form9CustomerMain_Load(object sender, EventArgs e)
        {
            if (Session.loggedIn == null)
            {
                MessageBox.Show("Sesi login sudah berakhir, silahkan login kembali.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                new Form1Login().Show();
                this.Close();
                return;
            }

            label1.Text = $"Mau terbang ke mana hari ini, {Session.loggedIn.Nama}?";

            dateTimePicker1.MinDate = DateTime.Today;
            dateTimePicker1.Value = DateTime.Today;

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

            foreach (TextBox txt in new[] { textBox1, textBox2 })
            {
                txt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txt.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txt.AutoCompleteCustomSource = daftarSaran;
            }
        }

        private string AmbilKodeIATA(string teksInput)
        {
            if (string.IsNullOrWhiteSpace(teksInput))
            {
                return null;
            }

            int posisiBukaKurung = teksInput.LastIndexOf('(');
            int posisiTutupKurung = teksInput.LastIndexOf(')');

            if (posisiBukaKurung == -1 || posisiTutupKurung == -1 || posisiBukaKurung >= posisiTutupKurung)
            {
                return null;
            }

            int panjangKode = posisiTutupKurung - posisiBukaKurung - 1;
            return teksInput.Substring(posisiBukaKurung + 1, panjangKode).Trim();
        }

        private void logOutBtn_Click(object sender, EventArgs e)
        {
            Session.loggedIn = null;
            MessageBox.Show("Terima kasih sudah menggunakan layanan kami.\nSampai jumpa!", "Logout", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Form1Login loginForm = new Form1Login();
            loginForm.Show();
            this.Close();
        }

        private void ticketBtn_Click(object sender, EventArgs e)
        {
            Form12TiketSaya tiketSaya = new Form12TiketSaya();
            tiketSaya.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kodeAsal = AmbilKodeIATA(textBox1.Text);
            string kodeTujuan = AmbilKodeIATA(textBox2.Text);

            if (kodeAsal == null)
            {
                MessageBox.Show("Bandara keberangkatan tidak valid. Silahkan pilih dari daftar saran.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (kodeTujuan == null)
            {
                MessageBox.Show("Bandara tujuan tidak valid. Silahkan pilih dari daftar saran.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numericUpDown1.Value <= 0)
            {
                MessageBox.Show("Jumlah penumpang minimal 1.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var daftarBandara = db.Bandaras.Where(b => b.KodeIATA == kodeAsal || b.KodeIATA == kodeTujuan).ToList();
            var bandaraAsal = daftarBandara.FirstOrDefault(b => b.KodeIATA == kodeAsal);
            var bandaraTujuan = daftarBandara.FirstOrDefault(b => b.KodeIATA == kodeTujuan);

            if (bandaraAsal == null || bandaraTujuan == null)
            {
                MessageBox.Show("Bandara tidak ditemukan di database.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (bandaraAsal.ID == bandaraTujuan.ID)
            {
                MessageBox.Show("Bandara keberangkatan dan tujuan tidak boleh sama.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.Hide();
            new Form10ListPenerbangan(this,
                                      bandaraAsal.ID,
                                      bandaraTujuan.ID,
                                      dateTimePicker1.Value,
                                      Convert.ToInt32(numericUpDown1.Value)).Show();
        }
    }
}
