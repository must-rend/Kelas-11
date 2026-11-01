/* =====================================================================
   Bromo Airlines - Skema Database
   Jalankan: sqlcmd -S localhost -E -i Schema.sql
   ===================================================================== */
IF DB_ID('BromoAirlines') IS NULL
BEGIN
    CREATE DATABASE BromoAirlines;
END
GO

USE BromoAirlines;
GO

/* 1. AKUN */
IF OBJECT_ID('Akun', 'U') IS NULL
CREATE TABLE Akun (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Username VARCHAR(200) NOT NULL,
    Password VARCHAR(200) NOT NULL,
    Nama VARCHAR(200) NOT NULL,
    TanggalLahir DATE NOT NULL,
    NomorTelepon VARCHAR(20) NOT NULL,
    MerupakanAdmin BIT NOT NULL
);
GO

/* 2. NEGARA */
IF OBJECT_ID('Negara', 'U') IS NULL
CREATE TABLE Negara (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Nama VARCHAR(200) NOT NULL,
    IbukotaNegara VARCHAR(200) NOT NULL
);
GO

/* 3. KODE PROMO */
IF OBJECT_ID('KodePromo', 'U') IS NULL
CREATE TABLE KodePromo (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Kode VARCHAR(100) NOT NULL,
    PersentaseDiskon FLOAT NOT NULL,
    MaksimumDiskon FLOAT NOT NULL,
    BerlakuSampai DATE NOT NULL,
    Deskripsi TEXT NOT NULL
);
GO

/* 4. MASKAPAI */
IF OBJECT_ID('Maskapai', 'U') IS NULL
CREATE TABLE Maskapai (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Nama VARCHAR(200) NOT NULL,
    Perusahaan VARCHAR(200) NOT NULL,
    JumlahKru INT NOT NULL,
    Deskripsi TEXT NOT NULL
);
GO

/* 5. STATUS PENERBANGAN */
IF OBJECT_ID('StatusPenerbangan', 'U') IS NULL
CREATE TABLE StatusPenerbangan (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Nama VARCHAR(200) NOT NULL
);
GO

/* 6. BANDARA (relasi ke Negara) */
IF OBJECT_ID('Bandara', 'U') IS NULL
CREATE TABLE Bandara (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Nama VARCHAR(200) NOT NULL,
    KodeIATA VARCHAR(5) NOT NULL,
    Kota VARCHAR(200) NOT NULL,
    NegaraID INT NOT NULL,
    JumlahTerminal INT NOT NULL,
    Alamat TEXT NOT NULL,
    CONSTRAINT FK_Bandara_Negara FOREIGN KEY (NegaraID) REFERENCES Negara(ID)
);
GO

/* 7. JADWAL PENERBANGAN (relasi ke Bandara & Maskapai) */
IF OBJECT_ID('JadwalPenerbangan', 'U') IS NULL
CREATE TABLE JadwalPenerbangan (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    KodePenerbangan VARCHAR(10) NOT NULL,
    BandaraKeberangkatanID INT NOT NULL,
    BandaraTujuanID INT NOT NULL,
    MaskapaiID INT NOT NULL,
    TanggalWaktuKeberangkatan DATETIME NOT NULL,
    HargaPerTiket FLOAT NOT NULL,
    DurasiPenerbangan INT NOT NULL,
    CONSTRAINT FK_Jadwal_BandaraKeberangkatan FOREIGN KEY (BandaraKeberangkatanID) REFERENCES Bandara(ID),
    CONSTRAINT FK_Jadwal_BandaraTujuan FOREIGN KEY (BandaraTujuanID) REFERENCES Bandara(ID),
    CONSTRAINT FK_Jadwal_Maskapai FOREIGN KEY (MaskapaiID) REFERENCES Maskapai(ID)
);
GO

/* 8. PERUBAHAN STATUS JADWAL PENERBANGAN */
IF OBJECT_ID('PerubahanStatusJadwalPenerbangan', 'U') IS NULL
CREATE TABLE PerubahanStatusJadwalPenerbangan (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    JadwalPenerbanganID INT NOT NULL,
    StatusPenerbanganID INT NOT NULL,
    WaktuPerubahanTerjadi DATETIME NOT NULL,
    PerkiraanDurasiDelay INT NULL,
    CONSTRAINT FK_PerubahanStatus_Jadwal FOREIGN KEY (JadwalPenerbanganID) REFERENCES JadwalPenerbangan(ID),
    CONSTRAINT FK_PerubahanStatus_Status FOREIGN KEY (StatusPenerbanganID) REFERENCES StatusPenerbangan(ID)
);
GO

/* 9. TRANSAKSI HEADER */
IF OBJECT_ID('TransaksiHeader', 'U') IS NULL
CREATE TABLE TransaksiHeader (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    AkunID INT NOT NULL,
    TanggalTransaksi DATETIME NOT NULL,
    JadwalPenerbanganID INT NOT NULL,
    JumlahPenumpang INT NOT NULL,
    TotalHarga FLOAT NOT NULL,
    KodePromoID INT NULL,
    CONSTRAINT FK_TransaksiHeader_Akun FOREIGN KEY (AkunID) REFERENCES Akun(ID),
    CONSTRAINT FK_TransaksiHeader_Jadwal FOREIGN KEY (JadwalPenerbanganID) REFERENCES JadwalPenerbangan(ID),
    CONSTRAINT FK_TransaksiHeader_KodePromo FOREIGN KEY (KodePromoID) REFERENCES KodePromo(ID)
);
GO

/* 10. TRANSAKSI DETAIL */
IF OBJECT_ID('TransaksiDetail', 'U') IS NULL
CREATE TABLE TransaksiDetail (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    TransaksiHeaderID INT NOT NULL,
    TitelPenumpang VARCHAR(20) NOT NULL,
    NamaLengkapPenumpang VARCHAR(200) NOT NULL,
    CONSTRAINT FK_TransaksiDetail_Header FOREIGN KEY (TransaksiHeaderID) REFERENCES TransaksiHeader(ID)
);
GO

PRINT 'Skema BromoAirlines siap.';
