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
    public partial class Form1Login : Form
    {
        BandaraEntities db = new BandaraEntities();

        public Form1Login()
        {
            InitializeComponent();
            this.AcceptButton = btnLogin;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Username dan password harus diisi.", "Validasi Gagal",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var akun = db.Akuns.FirstOrDefault(a => a.Username == username && a.Password == password);
            if (akun == null)
            {
                MessageBox.Show("Username atau password salah.", "Login Gagal",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Session.loggedIn = akun;

            if (akun.MerupakanAdmin == true)
            {
                Form3Dashboard dashboard = new Form3Dashboard();
                this.Hide();
                dashboard.Show();
            }
            else
            {
                Form9CustomerMain customerMain = new Form9CustomerMain();
                this.Hide();
                customerMain.Show();
            }
        }

        private void lblDaftar_Click(object sender, EventArgs e)
        {
            Form2Register register = new Form2Register();
            this.Hide();
            register.Show();
        }
    }
}
