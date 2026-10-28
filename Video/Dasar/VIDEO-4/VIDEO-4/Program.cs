// Materi Percabangan

int umur = 15;

if (umur >= 17)
{
    Console.WriteLine("Boleh membuat KTP");
}
else
{
    Console.WriteLine("Belum boleh membuat KTP");
}

int nilai = 85;

if (nilai >= 90)
{
    Console.WriteLine("Nilai A");

} else if (nilai >= 75)
{
    Console.WriteLine("Nilai B");
}
else
{
    Console.WriteLine("Nilai C");

}

// Switch

String hari = "Minggu";

switch (hari) // switch digunakan untuk memeriksa nilai variabel
{
    case "senin": // case adalah pilihan kondisi
        Console.WriteLine("Hari pertama");
        break; // untuk menghentikan switch

    case "Minggu":
        Console.WriteLine("Hari ketujuh");
        break;

    default: // default dijalankan jika tidak ada kondisi yang cocok (mirip seperti false di else if)
        Console.WriteLine("Hari lain");
        break;
}