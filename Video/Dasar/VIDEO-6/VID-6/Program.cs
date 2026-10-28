// MATERI ARRAY DAN KOLEKSI DASAR


// 1. Array
// Digunakan untuk menyimpan banyak data dalam satu variabel.
//Array biasanya digunakan ketika data memiliki tipe yang sama.

string[] namaBuah = { "Apel", "Mangga", "Jeruk" };


// penjelasan struktur array
// string[] <- tanda [] menunjukkan bahwa variabel adalah array

// Mengambil data dari array
Console.WriteLine(namaBuah[0]); // Output: Apel (isi pertama dari array)
Console.WriteLine(namaBuah[1]); // Output: Mangga (isi kedua dari array)
Console.WriteLine(namaBuah[2]); // Output: Jeruk (isi ketiga dari array)

// array juga sering digunakan bersama dengan perulangan foreach

foreach (string buah in namaBuah)
{
    Console.WriteLine(buah);
}

// Dengan pengulangan, kita dapat menghemat penulisan array tanoa harus menulis satu per satu.


// 2. Koleksi dasar
//Adalah koleksi data yang lebih fleksibel dibandingkan array.

List<String> namaSiswa = new List<string>(); //membuat list untuk menampung data siswa

// menambahkan data ke dalam list
namaSiswa.Add("Budi"); //.Add digunakan untuk menambahkan data ke dalam list
namaSiswa.Add("Siti");
namaSiswa.Add("Antok");

// menampilkan data dari list
foreach (string siswa in namaSiswa)
{ 
    Console.WriteLine(siswa);
}

//Bedanya dengan array, ukuran dari List lebih fleksibel dibandingkan dengan array yang memiliki ukuran tetap dan cocok untuk data
//yang sering berubah-ubah(dinamis)

// dengan ini kita sudah mempelajari array dan koleksi dasar untuk menyimpan banyak dalam satu tempat.