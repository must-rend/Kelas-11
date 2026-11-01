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
    public partial class PenumpangControl : UserControl
    {
        public PenumpangControl()
        {
            InitializeComponent();
        }

        public int NomorPenumpang
        {
            set
            {
                numberLabel.Text = "Penumpang #" + value;
            }
        }

        public string Titel
        {
            get
            {
                return titleBox.Text;
            }
        }

        public string NamaLengkap
        {
            get
            {
                return fullNameText.Text.Trim();
            }
        }

        public bool DataSudahLengkap
        {
            get
            {
                return titleBox.SelectedIndex != 1 && !string.IsNullOrWhiteSpace(fullNameText.Text);
            }
        }
    }
}
