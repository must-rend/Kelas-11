using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace ContohSoal1
{
    public static class UIHelper
    {
        // Pengaturan standar untuk semua DataGridView: kolom mengikuti lebar grid
        // sehingga tombol aksi (Edit/Hapus/Beli Tiket) selalu terlihat tanpa scroll.
        public static void SetupGrid(DataGridView grid)
        {
            grid.AutoGenerateColumns = false;
            grid.AllowUserToAddRows = false;
            grid.ReadOnly = true;
            grid.AllowUserToResizeRows = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect = false;
            grid.RowTemplate.Height = 26;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.BackgroundColor = Color.White;
            grid.BorderStyle = BorderStyle.None;
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 244, 250);
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9F);
            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 251, 253);
        }

        // Merapikan tampilan saat runtime:
        // - PictureBox tanpa gambar disembunyikan supaya tidak tampil sebagai kotak kosong
        // - PictureBox bergambar dibiarkan apa adanya (dipakai sebagai ikon menu yang bisa diklik)
        // - warna tombol/panel tidak diubah supaya tema asli designer tetap dipakai
        public static void Normalize(Control root)
        {
            if (root == null)
            {
                return;
            }

            Stack<Control> antrian = new Stack<Control>();
            antrian.Push(root);

            while (antrian.Count > 0)
            {
                Control kontrol = antrian.Pop();

                PictureBox gambar = kontrol as PictureBox;

                if (gambar != null)
                {
                    if (gambar.Image == null)
                    {
                        gambar.Visible = false;
                    }

                    continue;
                }

                foreach (Control anak in kontrol.Controls)
                {
                    antrian.Push(anak);
                }
            }
        }
    }

    // Tema visual (mengikuti desain versi sebelumnya: header biru, sidebar putih, logo pesawat)
    public static class Theme
    {
        public static readonly Color Brand = Color.FromArgb(0, 102, 204);
        public static readonly Color BrandDark = Color.FromArgb(0, 82, 165);
        public static readonly Color PageBack = Color.FromArgb(245, 247, 251);
        public static readonly Color TextDark = Color.FromArgb(33, 37, 41);
        public static readonly Color TextMuted = Color.FromArgb(106, 116, 132);

        public static Image LoadImage(string namaFile)
        {
            try
            {
                Assembly asm = typeof(Theme).Assembly;

                using (Stream s = asm.GetManifestResourceStream("ContohSoal1.Resources." + namaFile))
                {
                    if (s == null)
                    {
                        return null;
                    }

                    using (MemoryStream ms = new MemoryStream())
                    {
                        s.CopyTo(ms);
                        ms.Position = 0;
                        return Image.FromStream(ms);
                    }
                }
            }
            catch
            {
                return null;
            }
        }

        // Header biru + sidebar putih + judul halaman tebal (dipakai halaman admin)
        public static void ApplyAdminShell(Form form, Panel header, Label headerTitle, Panel sidebar,
                                           Label pageTitle, Label pageSubtitle)
        {
            form.BackColor = PageBack;

            if (header != null)
            {
                header.BackColor = Brand;
            }

            if (headerTitle != null)
            {
                headerTitle.ForeColor = Color.White;
                headerTitle.Font = new Font("Segoe UI Semibold", 11F);
            }

            if (sidebar != null)
            {
                sidebar.BackColor = Color.White;
            }

            if (pageTitle != null)
            {
                pageTitle.ForeColor = TextDark;
                pageTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            }

            if (pageSubtitle != null)
            {
                pageSubtitle.ForeColor = TextMuted;
            }
        }

        // Tombol utama (biru, teks putih, rata tengah)
        public static void StylePrimaryButton(Button tombol)
        {
            tombol.BackColor = Brand;
            tombol.ForeColor = Color.White;
            tombol.FlatStyle = FlatStyle.Flat;
            tombol.FlatAppearance.BorderSize = 0;
            tombol.Font = new Font("Segoe UI Semibold", 9.75F);
            tombol.Cursor = Cursors.Hand;
        }

        // Tombol sekunder (putih dengan garis abu-abu)
        public static void StyleSecondaryButton(Button tombol)
        {
            tombol.BackColor = Color.White;
            tombol.ForeColor = TextDark;
            tombol.FlatStyle = FlatStyle.Flat;
            tombol.FlatAppearance.BorderSize = 1;
            tombol.FlatAppearance.BorderColor = Color.FromArgb(210, 216, 226);
            tombol.Font = new Font("Segoe UI", 9.75F);
            tombol.Cursor = Cursors.Hand;
        }

        // Kotak input seragam
        public static void StyleTextBox(TextBox kotak)
        {
            kotak.BorderStyle = BorderStyle.FixedSingle;
            kotak.Font = new Font("Segoe UI", 10F);
        }

        // Judul halaman (dipakai form customer yang tidak punya panel header)
        public static void StylePageTitle(Label judul)
        {
            if (judul == null)
            {
                return;
            }

            judul.ForeColor = TextDark;
            judul.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        }

        // Garis aksen biru di bagian paling atas form
        public static void AddHeaderStrip(Form form)
        {
            Panel strip = new Panel();
            strip.BackColor = Brand;
            strip.Dock = DockStyle.Top;
            strip.Height = 6;

            form.Controls.Add(strip);
            strip.BringToFront();
        }
    }
}
