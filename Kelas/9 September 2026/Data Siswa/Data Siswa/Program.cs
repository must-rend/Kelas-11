using System;

namespace DataSiswa
{
    class Home
    {
        static void Main(string[] args)
        {
            Identitas Idt = new Identitas();
            Mapel Mpl = new Mapel();
            Absensi Absn = new Absensi();
            Nilai Nli = new Nilai();

            int pilihan;

            do
            {
                Console.Clear();

                Console.WriteLine("================================");
                Console.WriteLine("          DATA SISWA");
                Console.WriteLine("================================");
                Console.WriteLine("1. Identitas Siswa");
                Console.WriteLine("2. Data Wali");
                Console.WriteLine("3. Riwayat Sekolah");
                Console.WriteLine("4. Mata Pelajaran");
                Console.WriteLine("5. Absensi");
                Console.WriteLine("6. Nilai");
                Console.WriteLine("0. Keluar");
                Console.WriteLine("================================");
                Console.Write("Pilih Menu : ");

                pilihan = Convert.ToInt32(Console.ReadLine());

                Console.Clear();

                if (pilihan == 1)
                {
                    Idt.Siswa();
                }
                else if (pilihan == 2)
                {
                    Idt.Wali();
                }
                else if (pilihan == 3)
                {
                    Idt.RiwayatSekolah();
                }
                else if (pilihan == 4)
                {
                    Mpl.NProduktif();
                    Mpl.Produktif();
                }
                else if (pilihan == 5)
                {
                    Absn.Bulan();
                }
                else if (pilihan == 6)
                {
                    Nli.Mapel();
                    Nli.NilaiMapel();
                }
                else if (pilihan == 0)
                {
                    Console.WriteLine("Program selesai.");
                }
                else
                {
                    Console.WriteLine("Menu tidak tersedia.");
                }

                if (pilihan != 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Tekan ENTER untuk kembali ke menu...");
                    Console.ReadLine();
                }

            } while (pilihan != 0);
        }
    }

    class Identitas
    {
        public void Siswa()
        {
            Console.WriteLine("=== IDENTITAS SISWA ===");
            Console.WriteLine("Nama Siswa : Mas Rendi Robertho");
            Console.WriteLine("NISN : 1234567890");
            Console.WriteLine("Alamat : Tokyo, Jepang");
            Console.WriteLine("Nomor Telepon : 08123456789");
        }

        public void Wali()
        {
            Console.WriteLine("=== DATA WALI ===");
            Console.WriteLine("Nama Wali : Alberto Junior");
            Console.WriteLine("Alamat : Tokyo, Jepang");
            Console.WriteLine("Nomor Telepon Wali : 08123456789");
        }

        public void RiwayatSekolah()
        {
            Console.WriteLine("=== RIWAYAT SEKOLAH ===");
            Console.WriteLine("TK : Tadika Mesra");
            Console.WriteLine("SD : SD Negeri Swasta");
            Console.WriteLine("SMP : SMPN 123 Kemarin");
        }
    }

    class Mapel
    {
        public void NProduktif()
        {
            Console.WriteLine("=== MAPEL NON PRODUKTIF ===");
            Console.WriteLine("Bahasa Indonesia");
            Console.WriteLine("Matematika");
            Console.WriteLine("Bahasa Inggris");
            Console.WriteLine("Bahasa Jepang");
            Console.WriteLine("Bahasa Jawa");
            Console.WriteLine("Bahasa Jerman");
            Console.WriteLine("Penjaskes");
            Console.WriteLine("PKWU/KIK");
            Console.WriteLine("Sejarah");
            Console.WriteLine("Pendidikan Pancasila");
        }

        public void Produktif()
        {
            Console.WriteLine();
            Console.WriteLine("=== MAPEL PRODUKTIF ===");
            Console.WriteLine("Pemrograman");
            Console.WriteLine("Basis Data");
            Console.WriteLine("Pemrograman Web");
        }
    }

    class Absensi
    {
        public void Bulan()
        {
            int pilihan;

            do
            {
                Console.Clear();

                Console.WriteLine("================================");
                Console.WriteLine("          DATA ABSENSI");
                Console.WriteLine("================================");
                Console.WriteLine("1. Januari");
                Console.WriteLine("2. Februari");
                Console.WriteLine("3. Maret");
                Console.WriteLine("4. April");
                Console.WriteLine("5. Mei");
                Console.WriteLine("6. Juni");
                Console.WriteLine("7. Juli");
                Console.WriteLine("8. Agustus");
                Console.WriteLine("9. September");
                Console.WriteLine("10. Oktober");
                Console.WriteLine("11. November");
                Console.WriteLine("12. Desember");
                Console.WriteLine("0. Kembali");
                Console.WriteLine("================================");
                Console.Write("Pilih Bulan : ");

                pilihan = Convert.ToInt32(Console.ReadLine());

                Console.Clear();

                if (pilihan == 1)
                {
                    DataAbsen("Januari");
                }
                else if (pilihan == 2)
                {
                    DataAbsen("Februari");
                }
                else if (pilihan == 3)
                {
                    DataAbsen("Maret");
                }
                else if (pilihan == 4)
                {
                    DataAbsen("April");
                }
                else if (pilihan == 5)
                {
                    DataAbsen("Mei");
                }
                else if (pilihan == 6)
                {
                    DataAbsen("Juni");
                }
                else if (pilihan == 7)
                {
                    DataAbsen("Juli");
                }
                else if (pilihan == 8)
                {
                    DataAbsen("Agustus");
                }
                else if (pilihan == 9)
                {
                    DataAbsen("September");
                }
                else if (pilihan == 10)
                {
                    DataAbsen("Oktober");
                }
                else if (pilihan == 11)
                {
                    DataAbsen("November");
                }
                else if (pilihan == 12)
                {
                    DataAbsen("Desember");
                }
                else if (pilihan == 0)
                {
                }
                else
                {
                    Console.WriteLine("Bulan tidak tersedia.");
                    Console.ReadLine();
                }

            } while (pilihan != 0);
        }

        public void DataAbsen(string bulan)
        {
            Console.Clear();

            Console.WriteLine("================================");
            Console.WriteLine("       ABSENSI " + bulan.ToUpper());
            Console.WriteLine("================================");

            if (bulan == "Januari")
            {
                Console.WriteLine("Hadir : 25");
                Console.WriteLine("Izin  : 2");
                Console.WriteLine("Sakit : 2");
                Console.WriteLine("Alfa  : 1");
            }
            else if (bulan == "Februari")
            {
                Console.WriteLine("Hadir : 22");
                Console.WriteLine("Izin  : 3");
                Console.WriteLine("Sakit : 4");
                Console.WriteLine("Alfa  : 1");
            }
            else if (bulan == "Maret")
            {
                Console.WriteLine("Hadir : 27");
                Console.WriteLine("Izin  : 1");
                Console.WriteLine("Sakit : 1");
                Console.WriteLine("Alfa  : 1");
            }
            else if (bulan == "April")
            {
                Console.WriteLine("Hadir : 20");
                Console.WriteLine("Izin  : 2");
                Console.WriteLine("Sakit : 3");
                Console.WriteLine("Alfa  : 0");
            }
            else if (bulan == "Mei")
            {
                Console.WriteLine("Hadir : 24");
                Console.WriteLine("Izin  : 1");
                Console.WriteLine("Sakit : 2");
                Console.WriteLine("Alfa  : 1");
            }
            else if (bulan == "Juni")
            {
                Console.WriteLine("Hadir : 23");
                Console.WriteLine("Izin  : 2");
                Console.WriteLine("Sakit : 1");
                Console.WriteLine("Alfa  : 2");
            }
            else if (bulan == "Juli")
            {
                Console.WriteLine("Hadir : 26");
                Console.WriteLine("Izin  : 1");
                Console.WriteLine("Sakit : 1");
                Console.WriteLine("Alfa  : 0");
            }
            else if (bulan == "Agustus")
            {
                Console.WriteLine("Hadir : 24");
                Console.WriteLine("Izin  : 3");
                Console.WriteLine("Sakit : 1");
                Console.WriteLine("Alfa  : 1");
            }
            else if (bulan == "September")
            {
                Console.WriteLine("Hadir : 21");
                Console.WriteLine("Izin  : 2");
                Console.WriteLine("Sakit : 4");
                Console.WriteLine("Alfa  : 1");
            }
            else if (bulan == "Oktober")
            {
                Console.WriteLine("Hadir : 26");
                Console.WriteLine("Izin  : 2");
                Console.WriteLine("Sakit : 1");
                Console.WriteLine("Alfa  : 1");
            }
            else if (bulan == "November")
            {
                Console.WriteLine("Hadir : 23");
                Console.WriteLine("Izin  : 1");
                Console.WriteLine("Sakit : 3");
                Console.WriteLine("Alfa  : 1");
            }
            else if (bulan == "Desember")
            {
                Console.WriteLine("Hadir : 20");
                Console.WriteLine("Izin  : 2");
                Console.WriteLine("Sakit : 2");
                Console.WriteLine("Alfa  : 0");
            }

            Console.WriteLine("================================");
            Console.WriteLine();
            Console.WriteLine("Tekan ENTER untuk kembali...");
            Console.ReadLine();
        }
    }

    class Nilai
    {
        public void Mapel()
        {
            Console.WriteLine("================================");
            Console.WriteLine("          NILAI SISWA");
            Console.WriteLine("================================");

            Console.WriteLine("=== MAPEL NON PRODUKTIF ===");
            Console.WriteLine("Bahasa Indonesia       : 92");
            Console.WriteLine("Matematika             : 90");
            Console.WriteLine("Bahasa Inggris         : 91");
            Console.WriteLine("Bahasa Jepang          : 89");
            Console.WriteLine("Bahasa Jawa            : 88");
            Console.WriteLine("Bahasa Jerman          : 87");
            Console.WriteLine("Penjaskes              : 93");
            Console.WriteLine("PKWU/KIK               : 90");
            Console.WriteLine("Sejarah                : 91");
            Console.WriteLine("Pendidikan Pancasila   : 94");

            Console.WriteLine();

            Console.WriteLine("=== MAPEL PRODUKTIF ===");
            Console.WriteLine("Pemrograman            : 95");
            Console.WriteLine("Basis Data             : 93");
            Console.WriteLine("Pemrograman Web        : 96");
        }

        public void NilaiMapel()
        {
            Console.WriteLine();
            Console.WriteLine("================================");
            Console.WriteLine("        RATA-RATA NILAI");
            Console.WriteLine("================================");
            Console.WriteLine("Rata-rata Nilai : 91.38");
            Console.WriteLine("Predikat        : Sangat Baik");
        }
    }
}