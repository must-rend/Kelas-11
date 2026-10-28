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
            UIHelper.Normalize(this);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Form2Register register = new Form2Register();
            this.Hide();
            register.Show();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if (usernameTxt.Text == "" || passwordTxt.Text == "")
            {
                // Jika textbox kosong proses login dihentikan
                MessageBox.Show("Username dan Password harus diisi"); 
                return;
            }

            // Cari Akun berdasarkan username dan password
            var user = db.Akuns.FirstOrDefault(a => a.Username == usernameTxt.Text && a.Password == passwordTxt.Text);

            // Cek User
            if (user == null) // Jika user ditemukan
            {
                MessageBox.Show("Password atau Username salah");
                return;                
            }

            MessageBox.Show("Login Berhasil"); // Messagebox tampil
            Session.loggedIn = user;

            if (user.MerupakanAdmin)
            {
                // Masuk ke dashboard
                Form3Dashboard dashboard = new Form3Dashboard();
                dashboard.Show();
                this.Hide();
            }
            else
            {
                Form9CustomerMain customer = new Form9CustomerMain();
                customer.Show();
                this.Hide();
            }
        }
    }
}
