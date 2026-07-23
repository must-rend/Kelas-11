using System;

class Program
{
    static void Main()
    {
        Dasar d = new Dasar();
        Datar dr = new Datar();
        Ruang rg = new Ruang();
        Zodiak z = new Zodiak();

        bool lanjutProgram = true;

        while (lanjutProgram)
        {
            Console.Clear();
            Console.WriteLine("=== KALKULATOR GEOMETRI & ZODIAK ===");
            Console.WriteLine("1. Kalkulator Sederhana");
            Console.WriteLine("2. Kalkulator Bangun Datar");
            Console.WriteLine("3. Kalkulator Bangun Ruang");
            Console.WriteLine("4. Zodiak");
            Console.WriteLine("5. Keluar");
            Console.Write("Pilih menu (1-5): ");
            string menu = Console.ReadLine();

            if (menu == "1")
            {
                Console.Write("Masukkan angka 1: ");
                d.x = double.Parse(Console.ReadLine());
                Console.Write("Masukkan angka 2: ");
                d.y = double.Parse(Console.ReadLine());
                Console.WriteLine("Pilih Operasi: 1. Tambah, 2. Kurang, 3. Kali, 4. Bagi");
                string operasi = Console.ReadLine();

                if (operasi == "1") Console.WriteLine("Hasil Tambah: " + d.Tambah);
                if (operasi == "2") Console.WriteLine("Hasil Kurang: " + d.Kurang);
                if (operasi == "3") Console.WriteLine("Hasil Kali: " + d.Kali);
                if (operasi == "4") Console.WriteLine("Hasil Bagi: " + d.Bagi);
            }
            else if (menu == "2")
            {
                Console.WriteLine("Pilih Bangun Datar: 1. Persegi, 2. Segitiga, 3. Lingkaran");
                string bangun = Console.ReadLine();

                if (bangun == "1")
                {
                    Console.Write("Masukkan Sisi: ");
                    dr.sisi = double.Parse(Console.ReadLine());
                    Console.WriteLine("Luas Persegi: " + dr.Persegi);
                }
                if (bangun == "2")
                {
                    Console.Write("Masukkan Alas: ");
                    dr.alas = double.Parse(Console.ReadLine());
                    Console.Write("Masukkan Tinggi: ");
                    dr.tinggi = double.Parse(Console.ReadLine());
                    Console.WriteLine("Luas Segitiga: " + dr.Segitiga);
                }
                if (bangun == "3")
                {
                    Console.Write("Masukkan Jari-jari: ");
                    dr.jari = double.Parse(Console.ReadLine());
                    Console.WriteLine("Luas Lingkaran: " + dr.Lingkaran);
                }
            }
            else if (menu == "3")
            {
                Console.WriteLine("Pilih Bangun Ruang: 1. Kubus, 2. Tabung");
                string ruang = Console.ReadLine();

                if (ruang == "1")
                {
                    Console.Write("Masukkan Sisi Kubus: ");
                    rg.sisi = double.Parse(Console.ReadLine());
                    Console.WriteLine("Volume Kubus: " + rg.kubus);
                }
                if (ruang == "2")
                {
                    Console.Write("Masukkan Jari-jari: ");
                    rg.jari = double.Parse(Console.ReadLine());
                    Console.Write("Masukkan Tinggi: ");
                    rg.tinggi = double.Parse(Console.ReadLine());
                    Console.WriteLine("Volume Tabung: " + rg.tabung);
                }
            }
            else if (menu == "4")
            {
                Console.Write("Masukkan Tanggal (1-31): ");
                z.tanggal = int.Parse(Console.ReadLine());
                Console.Write("Masukkan Bulan (1-12): ");
                z.bulan = int.Parse(Console.ReadLine());

                Console.WriteLine("Zodiak Anda Adalah: " + z.Hasil);
            }
            else if (menu == "5")
            {
                lanjutProgram = false;
            }

            if (menu != "5")
            {
                Console.Write("\nIngin lanjut ke tugas lain? (y/n): ");
                string pilihanLanjut = Console.ReadLine().ToLower();
                if (pilihanLanjut != "y")
                {
                    lanjutProgram = false;
                }
            }
        }

        Console.WriteLine("Terima kasih. Tekan Enter untuk keluar.");
        Console.ReadLine();
    }
}

// --- CLASS LOGIKA ---

class Dasar
{
    public double x, y;
    public double Tambah { get { return x + y; } }
    public double Kurang { get { return x - y; } }
    public double Kali { get { return x * y; } }
    public double Bagi { get { return x / y; } }
}

class Datar
{
    public double sisi, alas, tinggi, jari;
    public double Persegi { get { return sisi * sisi; } }
    public double Segitiga { get { return 0.5 * alas * tinggi; } }
    public double Lingkaran { get { return 3.14 * jari * jari; } }
}

class Ruang
{
    public double sisi, jari, tinggi;
    public double kubus { get { return sisi * sisi * sisi; } }
    public double tabung { get { return 3.14 * jari * jari * tinggi; } }
}

class Zodiak
{
    public int tanggal, bulan;

    public string Hasil
    {
        get
        {
            // --- VALIDASI TANGGAL ---
            if (bulan < 1 || bulan > 12 || tanggal < 1 || tanggal > 31) return "Data Salah!";

            // Cek bulan April, Juni, September, November (maks 30 hari)
            if ((bulan == 4 || bulan == 6 || bulan == 9 || bulan == 11) && tanggal > 30) return "Tanggal " + tanggal + " tidak ada di bulan " + bulan;

            // Cek bulan Februari (maks 29 hari)
            if (bulan == 2 && tanggal > 29) return "Tanggal " + tanggal + " tidak ada di bulan Februari";

            // --- LOGIKA ZODIAK ---
            if ((bulan == 3 && tanggal >= 21) || (bulan == 4 && tanggal <= 19)) return "Aries";
            if ((bulan == 4 && tanggal >= 20) || (bulan == 5 && tanggal <= 20)) return "Taurus";
            if ((bulan == 5 && tanggal >= 21) || (bulan == 6 && tanggal <= 20)) return "Gemini";
            if ((bulan == 6 && tanggal >= 21) || (bulan == 7 && tanggal <= 22)) return "Cancer";
            if ((bulan == 7 && tanggal >= 23) || (bulan == 8 && tanggal <= 22)) return "Leo";
            if ((bulan == 8 && tanggal >= 23) || (bulan == 9 && tanggal <= 22)) return "Virgo";
            if ((bulan == 9 && tanggal >= 23) || (bulan == 10 && tanggal <= 22)) return "Libra";
            if ((bulan == 10 && tanggal >= 23) || (bulan == 11 && tanggal <= 21)) return "Scorpio";
            if ((bulan == 11 && tanggal >= 22) || (bulan == 12 && tanggal <= 21)) return "Sagitarius";
            if ((bulan == 12 && tanggal >= 22) || (bulan == 1 && tanggal <= 19)) return "Capricorn";
            if ((bulan == 1 && tanggal >= 20) || (bulan == 2 && tanggal <= 18)) return "Aquarius";
            if ((bulan == 2 && tanggal >= 19) || (bulan == 3 && tanggal <= 20)) return "Pisces";

            return "Data Salah!";
        }
    }
}