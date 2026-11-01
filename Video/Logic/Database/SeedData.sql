/* =====================================================================
   Bromo Airlines - Seed Data
   Jalankan:  sqlcmd -S localhost -E -d BromoAirlines -i SeedData.sql
   Script ini idempotent: aman dijalankan berulang kali.
   ===================================================================== */
SET NOCOUNT ON;
SET XACT_ABORT ON;

BEGIN TRANSACTION;

/* ---------------------------------------------------------------------
   1. NEGARA
   --------------------------------------------------------------------- */
IF NOT EXISTS (SELECT 1 FROM Negara)
BEGIN
    INSERT INTO Negara (Nama, IbukotaNegara) VALUES
        ('Indonesia',   'Jakarta'),
        ('Malaysia',    'Kuala Lumpur'),
        ('Singapura',   'Singapura'),
        ('Thailand',    'Bangkok'),
        ('Jepang',      'Tokyo'),
        ('Australia',   'Canberra'),
        ('Arab Saudi',  'Riyadh'),
        ('Belanda',     'Amsterdam');
END

/* ---------------------------------------------------------------------
   2. BANDARA
   --------------------------------------------------------------------- */
IF NOT EXISTS (SELECT 1 FROM Bandara)
BEGIN
    INSERT INTO Bandara (Nama, KodeIATA, Kota, NegaraID, JumlahTerminal, Alamat)
    SELECT v.Nama, v.KodeIATA, v.Kota, n.ID, v.Terminal, v.Alamat
    FROM (VALUES
        ('Soekarno-Hatta International Airport', 'CGK', 'Jakarta',   'Indonesia', 3, 'Jl. Raya Bandara Soekarno-Hatta, Tangerang, Banten'),
        ('I Gusti Ngurah Rai International Airport', 'DPS', 'Denpasar', 'Indonesia', 1, 'Jl. Raya Gusti Ngurah Rai, Tuban, Badung, Bali'),
        ('Juanda International Airport', 'SUB', 'Surabaya', 'Indonesia', 2, 'Jl. Ir. Haji Juanda, Sidoarjo, Jawa Timur'),
        ('Adisutjipto International Airport', 'JOG', 'Yogyakarta', 'Indonesia', 1, 'Jl. Solo KM 9, Yogyakarta'),
        ('Kualanamu International Airport', 'KNO', 'Medan', 'Indonesia', 1, 'Jl. Bandara Kualanamu, Deli Serdang, Sumatera Utara'),
        ('Sultan Hasanuddin International Airport', 'UPG', 'Makassar', 'Indonesia', 1, 'Jl. Bandara Hasanuddin, Maros, Sulawesi Selatan'),
        ('Sultan Aji Muhammad Sulaiman Sepinggan Airport', 'BPN', 'Balikpapan', 'Indonesia', 1, 'Jl. Marsma R. Iswahyudi, Balikpapan, Kalimantan Timur'),
        ('Changi International Airport', 'SIN', 'Singapura', 'Singapura', 4, '80 Airport Boulevard, Changi, Singapura'),
        ('Kuala Lumpur International Airport', 'KUL', 'Kuala Lumpur', 'Malaysia', 2, '64000 Sepang, Selangor, Malaysia'),
        ('Narita International Airport', 'NRT', 'Tokyo', 'Jepang', 3, '1-1 Furugome, Narita, Chiba, Jepang')
    ) AS v (Nama, KodeIATA, Kota, Negara, Terminal, Alamat)
    JOIN Negara n ON n.Nama = v.Negara;
END

/* ---------------------------------------------------------------------
   3. MASKAPAI
   --------------------------------------------------------------------- */
IF NOT EXISTS (SELECT 1 FROM Maskapai)
BEGIN
    INSERT INTO Maskapai (Nama, Perusahaan, JumlahKru, Deskripsi) VALUES
        ('Garuda Indonesia', 'PT Garuda Indonesia (Persero) Tbk', 520, 'Maskapai nasional Indonesia dengan layanan full service.'),
        ('Lion Air',         'PT Lion Mentari Airlines',           400, 'Maskapai swasta dengan jaringan rute domestik terluas.'),
        ('Citilink',         'PT Citilink Indonesia',              300, 'Maskapai bertarif rendah milik Garuda Indonesia.'),
        ('Batik Air',        'PT Batik Air Indonesia',             350, 'Maskapai full service milik Lion Group.'),
        ('Indonesia AirAsia','PT Indonesia AirAsia',               250, 'Maskapai bertarif rendah dengan rute internasional.'),
        ('Singapore Airlines','Singapore Airlines Limited',        600, 'Maskapai full service dengan peringkat bintang lima.');
END

/* ---------------------------------------------------------------------
   4. STATUS PENERBANGAN
   --------------------------------------------------------------------- */
IF NOT EXISTS (SELECT 1 FROM StatusPenerbangan)
BEGIN
    INSERT INTO StatusPenerbangan (Nama) VALUES
        ('Tepat Waktu'),
        ('Delay'),
        ('Dibatalkan'),
        ('Dialihkan');
END

/* ---------------------------------------------------------------------
   5. KODE PROMO
   --------------------------------------------------------------------- */
IF NOT EXISTS (SELECT 1 FROM KodePromo)
BEGIN
    INSERT INTO KodePromo (Kode, PersentaseDiskon, MaksimumDiskon, BerlakuSampai, Deskripsi) VALUES
        ('HEMAT10',  10, 150000,  DATEADD(MONTH, 12, GETDATE()), 'Diskon 10% maksimal Rp150.000 untuk semua rute.'),
        ('HEMAT25',  25, 500000,  DATEADD(MONTH, 12, GETDATE()), 'Diskon 25% maksimal Rp500.000 untuk semua rute.'),
        ('BROMO50',  50, 1000000, DATEADD(MONTH, 12, GETDATE()), 'Diskon 50% maksimal Rp1.000.000, promo ulang tahun Bromo Airlines.'),
        ('NEWUSER',  15, 200000,  DATEADD(MONTH, 6,  GETDATE()), 'Diskon 15% khusus pengguna baru.'),
        ('PROMOLAMA',30, 300000,  DATEADD(YEAR, -1, GETDATE()),  'Promo lama yang sudah kadaluarsa (untuk uji validasi).');
END

/* ---------------------------------------------------------------------
   6. AKUN (admin + customer contoh)
   --------------------------------------------------------------------- */
IF NOT EXISTS (SELECT 1 FROM Akun)
BEGIN
    INSERT INTO Akun (Username, Password, Nama, TanggalLahir, NomorTelepon, MerupakanAdmin) VALUES
        ('admin',  'Admin#12345', 'Administrator Bromo', '1990-01-15', '081200000001', 1),
        ('budi',   'Budi#12345',  'Budi Santoso',        '1995-06-20', '081234567890', 0),
        ('sari',   'Sari#12345',  'Sari Wulandari',      '1998-11-03', '081298765432', 0);
END

/* ---------------------------------------------------------------------
   7. JADWAL PENERBANGAN - 60 hari ke depan, semua rute
   --------------------------------------------------------------------- */
IF NOT EXISTS (SELECT 1 FROM JadwalPenerbangan WHERE TanggalWaktuKeberangkatan >= CAST(GETDATE() AS DATE))
BEGIN
    CREATE TABLE #Rute (
        Kode       VARCHAR(10),
        Asal       VARCHAR(5),
        Tujuan     VARCHAR(5),
        Maskapai   VARCHAR(200),
        Harga      FLOAT,
        Durasi     INT,
        Jam        TIME
    );

    INSERT INTO #Rute (Kode, Asal, Tujuan, Maskapai, Harga, Durasi, Jam) VALUES
        ('GA-401', 'CGK', 'DPS', 'Garuda Indonesia',  1450000, 105, '07:00'),
        ('GA-402', 'CGK', 'DPS', 'Garuda Indonesia',  1450000, 105, '12:30'),
        ('GA-403', 'CGK', 'DPS', 'Garuda Indonesia',  1450000, 105, '18:15'),
        ('GA-411', 'DPS', 'CGK', 'Garuda Indonesia',  1450000, 110, '09:20'),
        ('GA-412', 'DPS', 'CGK', 'Garuda Indonesia',  1450000, 110, '20:05'),
        ('QG-721', 'CGK', 'SUB', 'Citilink',           950000,  80, '06:30'),
        ('QG-722', 'CGK', 'SUB', 'Citilink',           950000,  80, '14:00'),
        ('QG-731', 'SUB', 'CGK', 'Citilink',           950000,  85, '10:10'),
        ('JT-551', 'CGK', 'JOG', 'Lion Air',           780000,  70, '09:00'),
        ('JT-552', 'CGK', 'JOG', 'Lion Air',           780000,  70, '16:45'),
        ('JT-561', 'JOG', 'CGK', 'Lion Air',           780000,  75, '08:15'),
        ('GA-181', 'CGK', 'KNO', 'Garuda Indonesia',  1650000, 140, '08:15'),
        ('GA-182', 'CGK', 'KNO', 'Garuda Indonesia',  1650000, 140, '19:00'),
        ('GA-191', 'KNO', 'CGK', 'Garuda Indonesia',  1650000, 145, '11:30'),
        ('ID-631', 'CGK', 'UPG', 'Batik Air',         1850000, 155, '10:00'),
        ('ID-632', 'CGK', 'UPG', 'Batik Air',         1850000, 155, '20:30'),
        ('ID-641', 'UPG', 'CGK', 'Batik Air',         1850000, 160, '13:45'),
        ('JT-761', 'CGK', 'BPN', 'Lion Air',          1500000, 130, '07:45'),
        ('JT-762', 'CGK', 'BPN', 'Lion Air',          1500000, 130, '17:30'),
        ('JT-771', 'BPN', 'CGK', 'Lion Air',          1500000, 135, '09:15'),
        ('SQ-951', 'CGK', 'SIN', 'Singapore Airlines',1900000,  95, '09:30'),
        ('SQ-952', 'CGK', 'SIN', 'Singapore Airlines',1900000,  95, '21:00'),
        ('SQ-961', 'SIN', 'CGK', 'Singapore Airlines',1900000, 100, '11:20'),
        ('QZ-751', 'CGK', 'KUL', 'Indonesia AirAsia', 1750000, 120, '08:00'),
        ('QZ-752', 'CGK', 'KUL', 'Indonesia AirAsia', 1750000, 120, '18:00'),
        ('QZ-761', 'KUL', 'CGK', 'Indonesia AirAsia', 1750000, 125, '10:40'),
        ('QG-781', 'DPS', 'SUB', 'Citilink',           900000,  60, '11:00'),
        ('QG-791', 'SUB', 'DPS', 'Citilink',           900000,  65, '15:30'),
        ('SQ-971', 'DPS', 'SIN', 'Singapore Airlines',1600000, 150, '13:00'),
        ('SQ-981', 'SIN', 'DPS', 'Singapore Airlines',1600000, 150, '08:45'),
        ('GA-881', 'SUB', 'KNO', 'Garuda Indonesia',  1550000, 175, '17:10'),
        ('GA-891', 'KNO', 'SUB', 'Garuda Indonesia',  1550000, 180, '12:25');

    ;WITH Hari AS (
        SELECT 0 AS n
        UNION ALL
        SELECT n + 1 FROM Hari WHERE n < 59
    )
    INSERT INTO JadwalPenerbangan
        (KodePenerbangan, BandaraKeberangkatanID, BandaraTujuanID, MaskapaiID,
         TanggalWaktuKeberangkatan, HargaPerTiket, DurasiPenerbangan)
    SELECT r.Kode, ba.ID, bt.ID, m.ID,
           DATEADD(MINUTE, DATEDIFF(MINUTE, CAST('00:00' AS TIME), r.Jam),
                   DATEADD(DAY, h.n, CAST(CAST(GETDATE() AS DATE) AS DATETIME))),
           r.Harga, r.Durasi
    FROM #Rute r
    JOIN Bandara  ba ON ba.KodeIATA = r.Asal
    JOIN Bandara  bt ON bt.KodeIATA = r.Tujuan
    JOIN Maskapai m  ON m.Nama      = r.Maskapai
    CROSS JOIN Hari h
    OPTION (MAXRECURSION 0);

    DROP TABLE #Rute;
END

/* ---------------------------------------------------------------------
   8. PERUBAHAN STATUS (supaya kolom status & Form Slot ada isinya)
   --------------------------------------------------------------------- */
IF NOT EXISTS (SELECT 1 FROM PerubahanStatusJadwalPenerbangan)
BEGIN
    -- 3 penerbangan besok DELAY 45 menit
    INSERT INTO PerubahanStatusJadwalPenerbangan
        (JadwalPenerbanganID, StatusPenerbanganID, WaktuPerubahanTerjadi, PerkiraanDurasiDelay)
    SELECT TOP 3 j.ID, s.ID, DATEADD(HOUR, -2, GETDATE()), 45
    FROM JadwalPenerbangan j
    CROSS JOIN StatusPenerbangan s
    WHERE s.Nama = 'Delay'
      AND CAST(j.TanggalWaktuKeberangkatan AS DATE) = CAST(DATEADD(DAY, 1, GETDATE()) AS DATE)
      AND j.BandaraKeberangkatanID IN (SELECT ID FROM Bandara WHERE KodeIATA = 'CGK')
    ORDER BY j.TanggalWaktuKeberangkatan;

    -- 1 penerbangan minggu depan DIBATALKAN
    INSERT INTO PerubahanStatusJadwalPenerbangan
        (JadwalPenerbanganID, StatusPenerbanganID, WaktuPerubahanTerjadi, PerkiraanDurasiDelay)
    SELECT TOP 1 j.ID, s.ID, DATEADD(HOUR, -5, GETDATE()), NULL
    FROM JadwalPenerbangan j
    CROSS JOIN StatusPenerbangan s
    WHERE s.Nama = 'Dibatalkan'
      AND CAST(j.TanggalWaktuKeberangkatan AS DATE) = CAST(DATEADD(DAY, 7, GETDATE()) AS DATE)
      AND j.BandaraKeberangkatanID IN (SELECT ID FROM Bandara WHERE KodeIATA = 'CGK')
    ORDER BY j.TanggalWaktuKeberangkatan;
END

/* ---------------------------------------------------------------------
   9. TRANSAKSI CONTOH untuk akun 'budi' (2 penumpang)
   --------------------------------------------------------------------- */
IF NOT EXISTS (SELECT 1 FROM TransaksiHeader)
BEGIN
    DECLARE @akunBudi INT = (SELECT ID FROM Akun WHERE Username = 'budi');
    DECLARE @promoId  INT = (SELECT ID FROM KodePromo WHERE Kode = 'HEMAT10');
    DECLARE @jadwalId INT = (
        SELECT TOP 1 j.ID
        FROM JadwalPenerbangan j
        JOIN Bandara ba ON ba.ID = j.BandaraKeberangkatanID
        JOIN Bandara bt ON bt.ID = j.BandaraTujuanID
        WHERE ba.KodeIATA = 'CGK' AND bt.KodeIATA = 'DPS'
          AND j.TanggalWaktuKeberangkatan >= DATEADD(DAY, 5, CAST(GETDATE() AS DATE))
        ORDER BY j.TanggalWaktuKeberangkatan
    );
    DECLARE @harga FLOAT = (SELECT HargaPerTiket FROM JadwalPenerbangan WHERE ID = @jadwalId);

    IF @akunBudi IS NOT NULL AND @jadwalId IS NOT NULL
    BEGIN
        INSERT INTO TransaksiHeader
            (AkunID, TanggalTransaksi, JadwalPenerbanganID, JumlahPenumpang, TotalHarga, KodePromoID)
        VALUES
            (@akunBudi, GETDATE(), @jadwalId, 2, (@harga * 2), @promoId);

        DECLARE @headerId INT = SCOPE_IDENTITY();

        INSERT INTO TransaksiDetail (TransaksiHeaderID, TitelPenumpang, NamaLengkapPenumpang) VALUES
            (@headerId, 'Tn.',  'Budi Santoso'),
            (@headerId, 'Ny.',  'Ani Santoso');
    END
END

COMMIT TRANSACTION;

SELECT 'Negara' AS Tabel, COUNT(*) AS Jumlah FROM Negara
UNION ALL SELECT 'Bandara', COUNT(*) FROM Bandara
UNION ALL SELECT 'Maskapai', COUNT(*) FROM Maskapai
UNION ALL SELECT 'StatusPenerbangan', COUNT(*) FROM StatusPenerbangan
UNION ALL SELECT 'KodePromo', COUNT(*) FROM KodePromo
UNION ALL SELECT 'Akun', COUNT(*) FROM Akun
UNION ALL SELECT 'JadwalPenerbangan', COUNT(*) FROM JadwalPenerbangan
UNION ALL SELECT 'PerubahanStatus', COUNT(*) FROM PerubahanStatusJadwalPenerbangan
UNION ALL SELECT 'TransaksiHeader', COUNT(*) FROM TransaksiHeader
UNION ALL SELECT 'TransaksiDetail', COUNT(*) FROM TransaksiDetail;
