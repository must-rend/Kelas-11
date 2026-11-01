# Bromo Airlines (ContohSoal1)

Aplikasi desktop WinForms + Entity Framework 6 (EDMX) untuk pemesanan tiket pesawat.
Database: SQL Server, nama database **BromoAirlines**.

---

## Cara menjalankan

### 1. Pastikan SQL Server aktif

Aplikasi memakai **instance default** `localhost` (bukan `localhost\SQLEXPRESS`).

```powershell
Get-Service MSSQLSERVER      # harus Running
sqlcmd -S localhost -E -Q "SELECT name FROM sys.databases"
```

### 2. Siapkan database

Kalau database belum ada / ingin dibuat ulang dari nol:

```powershell
sqlcmd -S localhost -E -i Database\Schema.sql
```

### 3. Isi data contoh (wajib untuk pertama kali)

```powershell
sqlcmd -S localhost -E -d BromoAirlines -i Database\SeedData.sql
```

Skrip ini idempotent (aman dijalankan berulang) dan mengisi:

- 8 negara, 10 bandara, 6 maskapai, 4 status penerbangan, 5 kode promo
- 1.920 jadwal penerbangan untuk **60 hari ke depan** (CGK, DPS, SUB, JOG, KNO, UPG, BPN, SIN, KUL, NRT)
- 3 akun contoh + 1 transaksi contoh

### 4. Jalankan aplikasi

Buka `ContohSoal1.slnx` di Visual Studio, lalu F5. Atau langsung:

```
bin\Debug\ContohSoal1.exe
```

---

## Akun demo

| Username | Password      | Peran                        |
|----------|---------------|------------------------------|
| `admin`  | `Admin#12345` | Admin (dashboard + CRUD)     |
| `budi`   | `Budi#12345`  | Customer (sudah punya tiket) |
| `sari`   | `Sari#12345`  | Customer                     |

Kode promo aktif: `HEMAT10`, `HEMAT25`, `BROMO50`, `NEWUSER`, `UJI25`.
(`PROMOLAMA` sengaja kadaluarsa untuk menguji validasi.)

---

## Alur pemakaian

**Customer**

1. Login → halaman beranda.
2. Isi "Berangkat Dari" dan "Tujuan" (pilih dari saran autocomplete, format `Nama Bandara, Kota (KODE)`).
3. Tentukan tanggal & jumlah penumpang → **Cari Penerbangan**.
4. Klik **Beli Tiket** pada penerbangan yang dipilih.
5. Isi titel + nama setiap penumpang.
6. (Opsional) masukkan kode promo → **Pakai**.
7. **Konfirmasi Pembayaran** → transaksi tersimpan, kembali ke beranda.
8. Ikon tiket di kanan atas → **Tiket Saya** (hanya tiket yang belum berangkat + status terakhir).

**Admin**

| Menu | Fungsi |
|------|--------|
| About | CRUD data bandara |
| Struktur | CRUD data maskapai |
| Bidang | CRUD jadwal penerbangan (kode format `AA-0000`) |
| Sejarah | CRUD kode promo |
| Slot | Perubahan status penerbangan (Delay/Dibatalkan/dll) + hapus riwayat status |

---

## Catatan teknis

- Connection string ada di `App.config` (`BandaraEntities`), memakai `data source=localhost`.
- Semua DataGridView diatur lewat `UIHelper.SetupGrid` supaya kolom aksi (Edit/Hapus/Beli Tiket) selalu terlihat.
- Penerbangan yang sudah lewat tidak ditampilkan lagi di daftar pencarian customer.
- Penghapusan data yang masih dipakai tabel lain (bandara/maskapai/promo/jadwal) memunculkan pesan yang jelas, bukan crash.
- Skema tabel: `Database/Schema.sql`. Data contoh: `Database/SeedData.sql`.
