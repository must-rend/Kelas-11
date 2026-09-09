using System;
namespace Matematika
{ 
    class Home
    {
      static void Main(string[] args)
        {
            Console.WriteLine("Belajar PBO");

            Kalkulator Kal = new Kalkulator();
            //BangunDatar BDatar = new BangunDatar();
            BangunRuang BRuang = new BangunRuang();

            Kal.Penjumlahan();
            BangunDatar.LuasLingkaran();
            BRuang.VolumeTabung();
            
        }
    }
    class Kalkulator
    {
        public void Penjumlahan()
        {
            Console.WriteLine("Penjumlahan");
        }
        public void Pengurangan()
        {
            Console.WriteLine("Pengurangan");
        }
        public void Perkalian()
        {
            Console.WriteLine("Perkalian") ;
        }
  
    }
    class BangunDatar
    {
        public static void KelilingPersegiPanjang()
        {
            Console.WriteLine("Keliling Persegi Panjang");
        }

        public static void KelilingLingkaran()
        {
            Console.WriteLine("Keliling Lingkaran");
        }
        public static void LuasPersegiPanjang()
        {
            Console.WriteLine("Luas Persegi Panjang");
        }
        public static void LuasLingkaran()
        {
            Console.WriteLine("Luas Lingkaran");
        }
    }
    class BangunRuang
    {
        public void VolumeBalok()
        {
            Console.WriteLine("Volume Balok");
        }
        public void VolumeTabung()
        {
            Console.WriteLine("Volume Tabung");
        }
        public void VolumePiramid()
        {
            Console.WriteLine("Volume Piramid");
        }
    }
    

}