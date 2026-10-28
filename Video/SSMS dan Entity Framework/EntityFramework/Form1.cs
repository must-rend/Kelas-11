using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFramework
{
    public partial class Form1 : Form
    {
        SekolahDBEntities db = new SekolahDBEntities();
        private int idSiswa = -1;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            loadData();
            dataGridView1.DataSource = db.Siswas.Select(s => new
            {
                s.Id,
                s.Nama,
                s.Umur,
                s.Alamat,
                Jurusan = s.Jurusan.NamaJurusan
            }).ToList();

            jurusanBox.DataSource = db.Jurusans.ToList();
            jurusanBox.DisplayMember = "NamaJurusan";
            jurusanBox.ValueMember = "Id";
            jurusanBox.SelectedIndex = -1;
        }

        private void loadData()
        {
            dataGridView1.DataSource = db.Siswas.Select(s => new
            {
                s.Id,
                s.Nama,
                s.Umur,
                s.Alamat,
                
            }).ToList();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (namaText.Text == "" || umurText.Text == "" || alamatText.Text == "" || jurusanBox.SelectedIndex == -1)
            {
                MessageBox.Show("Semua field harus diisi!");
                return;
            }
            var siswa = new Siswa();

            siswa.Nama = namaText.Text;
            siswa.Umur = Convert.ToInt32(umurText.Text);
            siswa.Alamat = alamatText.Text;
            siswa.JurusanID = Convert.ToInt32(jurusanBox.SelectedValue);

            db.Siswas.Add(siswa);
            db.SaveChanges();

            MessageBox.Show("Data Berhasil Ditambahkan!");

            loadData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            } //Error handling agar ketika pengguna mengklik Headewr DGV, nilai rowindex akan bernilai -1
              //Jika kondisi tersebut terjadi, program akan langsung berhenti menggunakan perintah return

            string columnName = dataGridView1.Columns[e.ColumnIndex].Name; //untuk mengambil nama kolom

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            if (columnName == "update")
            {
                idSiswa = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value); //mengambil value kolom id dari baris yang dipilih

                namaText.Text = row.Cells["Nama"].Value.ToString();
                umurText.Text = row.Cells["Umur"].Value.ToString();
                alamatText.Text = row.Cells["Alamat"].Value.ToString();
                jurusanBox.Text = row.Cells["Jurusan"].Value.ToString();

                addBtn.Text = "Update";
            } else if (columnName == "delete")
            {
                var result = MessageBox.Show("Hapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo);

                if(result == DialogResult.Yes)
                {
                    int idDelete = Convert.ToInt32(row.Cells["Id"].Value);

                    var siswa = db.Siswas.Find(idDelete); //untuk mencari id pada siswa yang mau di delete

                    if (siswa != null)
                    {
                        db.Siswas.Remove(siswa);
                        db.SaveChanges();

                        MessageBox.Show("Data Berhasil Dihapus!");
                    }
                }

                loadData();
            }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            string key = searchTxt.Text;

            if (key == "") //Memasukkan error handling jika textBox search Kosong
            {
                loadData(); // data akan terefresh jika textBox kosong
                return;
            }

            //logic untuk search
            dataGridView1.DataSource = db.Siswas.Where(s => s.Nama.Contains(key) || s.Umur.ToString().Contains(key) || s.Alamat.Contains(key) || s.Jurusan.NamaJurusan.Contains(key))
                .Select(s => new
                {
                    s.Id,
                    s.Nama,
                    s.Umur,
                    s.Alamat,
                    Jurusan = s.Jurusan.NamaJurusan
                })
                .ToList();
        }
    }
}
