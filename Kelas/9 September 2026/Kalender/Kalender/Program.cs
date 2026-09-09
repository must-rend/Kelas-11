using System;

namespace Jadwal
{
    class Program
    {
        static void Main(string[] args)
        {
            Senin Sen = new Senin();
            Selasa Sel = new Selasa();
            Rabu Rab = new Rabu();

            Sen.Sesi1();
            Sen.Sesi2();
            Sen.Sesi3();

            Sel.Sesi1();
            Sel.Sesi2();
            Sel.Sesi3();

            Rab.Sesi1();
            Rab.Sesi2();
            Rab.Sesi3();

            Kamis.Sesi1();
            Kamis.Sesi2();
            Kamis.Sesi3();

            Jumat.Sesi1();
            Jumat.Sesi2();

        }
    }

    class Senin
    {
        public void Sesi1()
        {
            Console.WriteLine("============== Senin ==============");
            Console.WriteLine("============== Sesi 1 =============");
            Console.WriteLine("B.Jepang (07.35 - 08.45)");
            Console.WriteLine("B.Inggris (08.45 - 09.55)");
            Console.WriteLine("ISTIRAHAT (09.55 - 10.10)");

        }

        public void Sesi2()
        {
            Console.WriteLine("============== Sesi 2 =============");
            Console.WriteLine("Matematika (10.10 - 11.40)");
            Console.WriteLine("ISTIRAHAT (MBG) (11.40 - 12.30)");
        }

        public void Sesi3()
        {
            Console.WriteLine("============== Sesi 3 =============");
            Console.WriteLine("PPLG (12.30 - 14.00)\n \n");
        }
    }

    class Selasa
    {
        public void Sesi1()
        {
            Console.WriteLine("============== Selasa =============");
            Console.WriteLine("============== Sesi 1 =============");
            Console.WriteLine("PKWU/KIK (07.00 - 08.10)");
            Console.WriteLine("PJOK (08.10 - 09.20)");
            Console.WriteLine("ISTIRAHAT (09.20 - 09.35)");
        }

        public void Sesi2()
        {
            Console.WriteLine("============== Sesi 2 =============");
            Console.WriteLine("B.Indonesia (09.30 - 11.35)");
            Console.WriteLine("ISTIRAHAT (MBG) (11.35 - 12.30)");
        }

        public void Sesi3()
        {
            Console.WriteLine("============== Sesi 3 =============");
            Console.WriteLine("PPLG (12.30 - 14.30)\n \n");
        }
    }

    class Rabu
    {
        public void Sesi1()
        {
            Console.WriteLine("============== Rabu ===============");
            Console.WriteLine("============== Sesi 1 =============");
            Console.WriteLine("PPLG (07.00 - 08.10)");
            Console.WriteLine("PPLG (08.10 - 09.20)");
            Console.WriteLine("ISTIRAHAT (09.20 - 09.35)");
        }

        public void Sesi2()
        {
            Console.WriteLine("============== Sesi 2 =============");
            Console.WriteLine("PPLG (09.30 - 11.35)");
            Console.WriteLine("ISTIRAHAT (MBG) (11.35 - 12.30)");
        }

        public void Sesi3()
        {
            Console.WriteLine("============== Sesi 3 =============");
            Console.WriteLine("PPLG (12.30 - 13.30)");
            Console.WriteLine("BK (13.30 - 14.00\n \n");
        }
    }

    class Kamis
    {
        public static void Sesi1()
        {
            Console.WriteLine("============== Kamis ==============");
            Console.WriteLine("============== Sesi 1 =============");
            Console.WriteLine("B.Jerman (07.00 - 08.10)");
            Console.WriteLine("B.Jawa (08.10 - 09.20)");
            Console.WriteLine("ISTIRAHAT (09.20 - 09.35)");
        }

        public static void Sesi2()
        {
            Console.WriteLine("============== Sesi 2 =============");
            Console.WriteLine("PKWU/KIK (09.30 - 11.35)");
            Console.WriteLine("ISTIRAHAT (MBG) (11.35 - 12.30)");
        }

        public static void Sesi3()
        {
            Console.WriteLine("============== Sesi 3 =============");
            Console.WriteLine("PAI (12.30 - 13.30\n \n");
        }
    }

    class Jumat
    {
        public static void Sesi1()
        {
            Console.WriteLine("============== Jumat ==============");
            Console.WriteLine("============== Sesi 1 =============");
            Console.WriteLine("B.Inggris (08.00 - 09.00)");
            Console.WriteLine("Sejarah (09.00 - 09.30)");
            Console.WriteLine("ISTIRAHAT (MBG) S(09.30 - 09.45)");
        }

        public static void Sesi2()
        {
            Console.WriteLine("============== Sesi 2 =============");
            Console.WriteLine("PPKN (09.45 - 11.15)\n \n");
        }
    }
}