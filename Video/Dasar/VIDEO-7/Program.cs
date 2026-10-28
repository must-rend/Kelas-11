//Method / Fungsi Sederhana

//Method
//kumpulan kode yang digunakan untuk menjalankan tugas tertentu dapat membuat program menjadi rapih, terstruktur, dan dapat digunakan kembali (Reuse).

//pakai void karena method tidak mengembalikan nilai (tanpa return value).
static void Salam ()
{
    Console.WriteLine ("Hello World");
}

Salam();

//Method Dengan Parameter
//parameter digunakan untuk mengirim data ke method.

static void Sapa(string nama)
{
    Console.WriteLine("Halo " + nama);
}

Sapa("Antok");

//Method Dengan Return Value
//Method dapat mengembalikan nilai (return value).

static int Tambah(int a, int b) //int karena method memiliki return value.
{
    return a + b; // return digunakan untuk mengembalikan hasil.
}

//Memanggil method dengan method (return value).
Console.WriteLine(Tambah (5, 7));
//Method digunakan untuk menjalankan tugas tertentu.
//Parameter digunakan untuk menerima data.
//Return digunakan untuk mengembalikan nilai.
