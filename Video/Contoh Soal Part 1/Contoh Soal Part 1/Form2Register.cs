using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contoh_Soal_Part_1
{
    public partial class Form2Register : Form
    {
        public Form2Register()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnDaftar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Berhasil Daftar, Silahkan Login");
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Form1Login loginForm = new Form1Login();
            this.Close();
            loginForm.ShowDialog();
        }
    }
}
