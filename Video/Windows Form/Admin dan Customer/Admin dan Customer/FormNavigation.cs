using System;
using System.Windows.Forms;

namespace ContohSoal1
{
    internal static class FormNavigation
    {
        public static void Attach(Form currentForm)
        {
            AttachClick(currentForm, "label2", () => new Form4Bandara());
            AttachClick(currentForm, "pictureBox2", () => new Form4Bandara());
            AttachClick(currentForm, "label3", () => new Form5Maskapai());
            AttachClick(currentForm, "pictureBox3", () => new Form5Maskapai());
            AttachClick(currentForm, "label4", () => new Form6JadwalPenerbangan());
            AttachClick(currentForm, "pictureBox4", () => new Form6JadwalPenerbangan());
            AttachClick(currentForm, "label5", () => new Form7KodePromo());
            AttachClick(currentForm, "pictureBox5", () => new Form7KodePromo());
            AttachClick(currentForm, "label6", () => new Form8UbahStatusPenerbangan());
            AttachClick(currentForm, "pictureBox6", () => new Form8UbahStatusPenerbangan());
            AttachClick(currentForm, "label7", () => new Form1Login(), true);
            AttachClick(currentForm, "pictureBox7", () => new Form1Login(), true);
        }

        private static void AttachClick(Form currentForm, string controlName, Func<Form> createTarget, bool closeCurrent = false)
        {
            Control[] controls = currentForm.Controls.Find(controlName, true);
            foreach (Control control in controls)
            {
                control.Click += (sender, e) =>
                {
                    Form targetForm = createTarget();
                    if (!closeCurrent)
                    {
                        targetForm.FormClosed += (s, args) => currentForm.Show();
                    }

                    targetForm.Show();
                    currentForm.Hide();
                };
            }
        }
    }
}
