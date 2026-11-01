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

    public partial class Form1Login : Form
    {
        public Form1Login()
        {
            InitializeComponent();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            Form3Dashboard dashboardForm = new Form3Dashboard();
            this.Hide();
            dashboardForm.Show();

        }

        private void lblDaftar_Click(object sender, EventArgs e)
        {
            Form2Register registerForm = new Form2Register();
            this.Hide();
            registerForm.Show();

        }
    }
}
