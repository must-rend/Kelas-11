\-- 1. MEMBUAT DATABASE BARU

CREATE DATABASE BromoAirlines;

GO



USE BromoAirlines;

GO



\-- 2. MEMBUAT TABEL AKUN

CREATE TABLE Akun (

&#x20;   ID INT IDENTITY(1,1) PRIMARY KEY,

&#x20;   Username VARCHAR(200) NOT NULL,

&#x20;   Password VARCHAR(200) NOT NULL,

&#x20;   Nama VARCHAR(200) NOT NULL,

&#x20;   TanggalLahir DATE NOT NULL,

&#x20;   NomorTelepon VARCHAR(20) NOT NULL,

&#x20;   MerupakanAdmin BIT NOT NULL

);

GO



\-- 3. MEMBUAT TABEL NEGARA

CREATE TABLE Negara (

&#x20;   ID INT IDENTITY(1,1) PRIMARY KEY,

&#x20;   Nama VARCHAR(200) NOT NULL,

&#x20;   IbukotaNegara VARCHAR(200) NOT NULL

);

GO



\-- 4. MEMBUAT TABEL KODE PROMO

CREATE TABLE KodePromo (

&#x20;   ID INT IDENTITY(1,1) PRIMARY KEY,

&#x20;   Kode VARCHAR(100) NOT NULL,

&#x20;   PersentaseDiskon FLOAT NOT NULL,

&#x20;   MaksimumDiskon FLOAT NOT NULL,

&#x20;   BerlakuSampai DATE NOT NULL,

&#x20;   Deskripsi TEXT NOT NULL

);

GO



\-- 5. MEMBUAT TABEL MASKAPAI

CREATE TABLE Maskapai (

&#x20;   ID INT IDENTITY(1,1) PRIMARY KEY,

&#x20;   Nama VARCHAR(200) NOT NULL,

&#x20;   Perusahaan VARCHAR(200) NOT NULL,

&#x20;   JumlahKru INT NOT NULL,

&#x20;   Deskripsi TEXT NOT NULL

);

GO



\-- 6. MEMBUAT TABEL STATUS PENERBANGAN

CREATE TABLE StatusPenerbangan (

&#x20;   ID INT IDENTITY(1,1) PRIMARY KEY,

&#x20;   Nama VARCHAR(200) NOT NULL

);

GO



\-- 7. MEMBUAT TABEL BANDARA (Memiliki relasi ke Negara)

CREATE TABLE Bandara (

&#x20;   ID INT IDENTITY(1,1) PRIMARY KEY,

&#x20;   Nama VARCHAR(200) NOT NULL,

&#x20;   KodeIATA VARCHAR(5) NOT NULL,

&#x20;   Kota VARCHAR(200) NOT NULL,

&#x20;   NegaraID INT NOT NULL,

&#x20;   JumlahTerminal INT NOT NULL,

&#x20;   Alamat TEXT NOT NULL,

&#x20;   CONSTRAINT FK\_Bandara\_Negara FOREIGN KEY (NegaraID) REFERENCES Negara(ID)

);

GO



\-- 8. MEMBUAT TABEL JADWAL PENERBANGAN (Relasi ke Bandara \& Maskapai)

CREATE TABLE JadwalPenerbangan (

&#x20;   ID INT IDENTITY(1,1) PRIMARY KEY,

&#x20;   KodePenerbangan VARCHAR(10) NOT NULL,

&#x20;   BandaraKeberangkatanID INT NOT NULL,

&#x20;   BandaraTujuanID INT NOT NULL,

&#x20;   MaskapaiID INT NOT NULL,

&#x20;   TanggalWaktuKeberangkatan DATETIME NOT NULL,

&#x20;   HargaPerTiket FLOAT NOT NULL,

&#x20;   DurasiPenerbangan INT NOT NULL,

&#x20;   CONSTRAINT FK\_JadwalPenerbangan\_BandaraKeberangkatan FOREIGN KEY (BandaraKeberangkatanID) REFERENCES Bandara(ID),

&#x20;   CONSTRAINT FK\_JadwalPenerbangan\_BandaraTujuan FOREIGN KEY (BandaraTujuanID) REFERENCES Bandara(ID),

&#x20;   CONSTRAINT FK\_JadwalPenerbangan\_Maskapai FOREIGN KEY (MaskapaiID) REFERENCES Maskapai(ID)

);

GO



\-- 9. MEMBUAT TABEL PERUBAHAN STATUS JADWAL PENERBANGAN

CREATE TABLE PerubahanStatusJadwalPenerbangan (

&#x20;   ID INT IDENTITY(1,1) PRIMARY KEY,

&#x20;   JadwalPenerbanganID INT NOT NULL,

&#x20;   StatusPenerbanganID INT NOT NULL,

&#x20;   WaktuPerubahanTerjadi DATETIME NOT NULL,

&#x20;   PerkiraanDurasiDelay INT NULL,

&#x20;   CONSTRAINT FK\_PerubahanStatus\_Jadwal FOREIGN KEY (JadwalPenerbanganID) REFERENCES JadwalPenerbangan(ID),

&#x20;   CONSTRAINT FK\_PerubahanStatus\_Status FOREIGN KEY (StatusPenerbanganID) REFERENCES StatusPenerbangan(ID)

);

GO



\-- 10. MEMBUAT TABEL TRANSAKSI HEADER

CREATE TABLE TransaksiHeader (

&#x20;   ID INT IDENTITY(1,1) PRIMARY KEY,

&#x20;   AkunID INT NOT NULL,

&#x20;   TanggalTransaksi DATETIME NOT NULL,

&#x20;   JadwalPenerbanganID INT NOT NULL,

&#x20;   JumlahPenumpang INT NOT NULL,

&#x20;   TotalHarga FLOAT NOT NULL,

&#x20;   KodePromoID INT NULL, -- Boleh NULL karena promo opsional

&#x20;   CONSTRAINT FK\_TransaksiHeader\_Akun FOREIGN KEY (AkunID) REFERENCES Akun(ID),

&#x20;   CONSTRAINT FK\_TransaksiHeader\_Jadwal FOREIGN KEY (JadwalPenerbanganID) REFERENCES JadwalPenerbangan(ID),

&#x20;   CONSTRAINT FK\_TransaksiHeader\_KodePromo FOREIGN KEY (KodePromoID) REFERENCES KodePromo(ID)

);

GO



\-- 11. MEMBUAT TABEL TRANSAKSI DETAIL

CREATE TABLE TransaksiDetail (

&#x20;   ID INT IDENTITY(1,1) PRIMARY KEY,

&#x20;   TransaksiHeaderID INT NOT NULL,

&#x20;   TitelPenumpang VARCHAR(20) NOT NULL,

&#x20;   NamaLengkapPenumpang VARCHAR(200) NOT NULL,

&#x20;   CONSTRAINT FK\_TransaksiDetail\_Header FOREIGN KEY (TransaksiHeaderID) REFERENCES TransaksiHeader(ID)

);

GO



