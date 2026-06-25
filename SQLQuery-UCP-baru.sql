CREATE DATABASE beasiswaDB;
GO

USE beasiswaDB;
GO

CREATE TABLE Jenjang (
	id_jenjang INT PRIMARY KEY IDENTITY(1,1),
    nama_jenjang VARCHAR(10),
	deskripsi TEXT
);

CREATE TABLE Kategori (
	id_kategori INT PRIMARY KEY IDENTITY(1,1),
    nama_kategori VARCHAR(30),
	deskripsi TEXT
);

CREATE TABLE Beasiswa (
    id_beasiswa INT PRIMARY KEY IDENTITY(1,1),
    nama_beasiswa VARCHAR(50) NOT NULL,
    tgl_buka DATE NOT NULL,
    tgl_tutup DATE NOT NULL,
    link_beasiswa VARCHAR(50) NOT NULL,
	id_jenjang INT,
    id_kategori INT,
    deskripsi TEXT,
	dibuat DATETIME DEFAULT GETDATE(),
    
    CONSTRAINT CHK_TanggalValid CHECK (tgl_tutup > tgl_buka),
    CONSTRAINT CHK_LinkHttps CHECK (link_beasiswa LIKE 'https://%'),
    
    CONSTRAINT FK_Jenjang FOREIGN KEY (id_jenjang) REFERENCES Jenjang(id_jenjang),
    CONSTRAINT FK_Kategori FOREIGN KEY (id_kategori) REFERENCES Kategori(id_kategori)
);

INSERT INTO Jenjang (nama_jenjang, deskripsi) VALUES
('SMA', 'Jenjang pendidikan Sekolah Menengah Atas'),
('D3', 'Jenjang Diploma 3'),
('D4', 'Jenjang Diploma 4'),
('S1', 'Jenjang Sarjana'),
('S2', 'Jenjang Magister'),
('S3', 'Jenjang Doktor');

INSERT INTO Kategori (nama_kategori, deskripsi) VALUES
('Prestasi', 'Beasiswa berdasarkan prestasi akademik maupun non-akademik'),
('Pemerintah', 'Beasiswa yang diselenggarakan oleh pemerintah'),
('Swasta', 'Beasiswa dari perusahaan atau yayasan swasta'),
('Ikatan Dinas', 'Beasiswa dengan ikatan kerja setelah lulus');

INSERT INTO Beasiswa (nama_beasiswa, tgl_buka, tgl_tutup, link_beasiswa, id_jenjang, id_kategori, deskripsi)
VALUES
(
    'Beasiswa Bidikmisi',
    '2025-01-01', '2025-06-30',
    'https://bidikmisi.kemdikbud.go.id',
    (SELECT id_jenjang  FROM Jenjang  WHERE nama_jenjang  = 'S1'),
    (SELECT id_kategori FROM Kategori WHERE nama_kategori = 'Pemerintah'),
    'Beasiswa untuk mahasiswa kurang mampu berprestasi dari pemerintah.'
),
(
    'Beasiswa Tanoto Foundation',
    '2025-03-01', '2025-08-31',
    'https://www.tanotofoundation.org',
    (SELECT id_jenjang  FROM Jenjang  WHERE nama_jenjang  = 'S1'),
    (SELECT id_kategori FROM Kategori WHERE nama_kategori = 'Swasta'),
    'Beasiswa dari Tanoto Foundation untuk mahasiswa S1 berprestasi.'
),
(
    'Beasiswa Djarum Plus',
    '2025-04-01', '2025-09-30',
    'https://www.djarumbeasiswa.com',
    (SELECT id_jenjang  FROM Jenjang  WHERE nama_jenjang  = 'S1'),
    (SELECT id_kategori FROM Kategori WHERE nama_kategori = 'Prestasi'),
    'Beasiswa dari Djarum Foundation khusus mahasiswa S1 berprestasi tinggi.'
),
(
    'Beasiswa LPDP S3',
    '2025-05-01', '2025-10-31',
    'https://lpdp.kemenkeu.go.id',
    (SELECT id_jenjang  FROM Jenjang  WHERE nama_jenjang  = 'S3'),
    (SELECT id_kategori FROM Kategori WHERE nama_kategori = 'Pemerintah'),
    'Beasiswa LPDP untuk jenjang S3 dalam dan luar negeri.'
);


--SELECT NO PARAMETER
CREATE PROCEDURE sp_GetBeasiswa
AS
BEGIN
    BEGIN TRY
        SET NOCOUNT ON;

        SELECT
            b.id_beasiswa,
            b.nama_beasiswa,
            b.tgl_buka,
            b.tgl_tutup,
            b.link_beasiswa,
            j.nama_jenjang,
            k.nama_kategori,
            b.deskripsi

        FROM Beasiswa b
        INNER JOIN Jenjang j
            ON b.id_jenjang = j.id_jenjang
        INNER JOIN Kategori k
            ON b.id_kategori = k.id_kategori;

    END TRY

    BEGIN CATCH
        SELECT
            ERROR_NUMBER() AS ErrorNumber,
            ERROR_MESSAGE() AS ErrorMessage;
    END CATCH
END

--SELECT SEARCH
CREATE PROCEDURE sp_SearchBeasiswa
    @keyword VARCHAR(50)
AS
BEGIN
    BEGIN TRY
        SET NOCOUNT ON;

        SELECT
            b.id_beasiswa,
            b.nama_beasiswa,
            b.tgl_buka,
            b.tgl_tutup,
            b.link_beasiswa,
            j.nama_jenjang,
            k.nama_kategori,
            b.deskripsi
        FROM Beasiswa b
        INNER JOIN Jenjang j
            ON b.id_jenjang = j.id_jenjang
        INNER JOIN Kategori k
            ON b.id_kategori = k.id_kategori
        WHERE
            b.nama_beasiswa LIKE '%' + @keyword + '%'
            OR j.nama_jenjang LIKE '%' + @keyword + '%'
            OR k.nama_kategori LIKE '%' + @keyword + '%';

    END TRY

    BEGIN CATCH
        SELECT
            ERROR_NUMBER() AS ErrorNumber,
            ERROR_MESSAGE() AS ErrorMessage;
    END CATCH
END


--INSERT BEASISWA
ALTER PROCEDURE sp_InsertBeasiswa
    @nama_beasiswa VARCHAR(50),
	@id_jenjang INT,
    @id_kategori INT,
    @tgl_buka DATETIME,
    @tgl_tutup DATETIME,
    @link_beasiswa VARCHAR(50),
    @deskripsi TEXT,
	@dibuat DATETIME = NULL
AS
BEGIN
    BEGIN TRY
        SET NOCOUNT ON;

		IF @dibuat IS NULL
        BEGIN
            SET @dibuat = GETDATE();
        END

        INSERT INTO Beasiswa
        (
            nama_beasiswa,
            id_jenjang,
            id_kategori,
			tgl_buka,
            tgl_tutup,
            link_beasiswa,
            deskripsi,
			dibuat
        )
        VALUES
        (
            @nama_beasiswa,
            @id_jenjang,
            @id_kategori,
			@tgl_buka,
            @tgl_tutup,
            @link_beasiswa,
            @deskripsi,
			@dibuat
        );

        PRINT 'Data berhasil ditambahkan';

    END TRY

    BEGIN CATCH
        SELECT
            ERROR_NUMBER() AS ErrorNumber,
            ERROR_MESSAGE() AS ErrorMessage;
    END CATCH
END


--UPDATE BEASISWA
alter PROCEDURE sp_UpdateBeasiswa
    @id_beasiswa INT,
    @nama_beasiswa VARCHAR(50),
    @id_jenjang INT,
    @id_kategori INT,
	@tgl_buka DATETIME,
    @tgl_tutup DATETIME,
    @link_beasiswa VARCHAR(50),
    @deskripsi TEXT
AS
BEGIN
    BEGIN TRY
        SET NOCOUNT ON;

        UPDATE Beasiswa
        SET
            nama_beasiswa = @nama_beasiswa,
            id_jenjang = @id_jenjang,
            id_kategori = @id_kategori,
			tgl_buka = @tgl_buka,
            tgl_tutup = @tgl_tutup,
            link_beasiswa = @link_beasiswa,
            deskripsi = @deskripsi
        WHERE id_beasiswa = @id_beasiswa;

        PRINT 'Data berhasil diupdate';

    END TRY

    BEGIN CATCH
        SELECT
            ERROR_NUMBER() AS ErrorNumber,
            ERROR_MESSAGE() AS ErrorMessage;
    END CATCH
END

--DELETE BEASISWA
CREATE PROCEDURE sp_DeleteBeasiswa
    @id_beasiswa INT
AS
BEGIN
    BEGIN TRY
        SET NOCOUNT ON;

        DELETE FROM Beasiswa
        WHERE id_beasiswa = @id_beasiswa;

        PRINT 'Data berhasil dihapus';

    END TRY

    BEGIN CATCH
        SELECT
            ERROR_NUMBER() AS ErrorNumber,
            ERROR_MESSAGE() AS ErrorMessage;
    END CATCH
END


--VIEW 
ALTER VIEW vw_Beasiswa
AS
SELECT
    b.id_beasiswa as 'ID',
    b.nama_beasiswa as 'Nama Beasiswa',
    b.tgl_buka as 'Tanggal Buka',
    b.tgl_tutup as 'Tanggal Tutup',
    b.link_beasiswa 'Link Beasiswa',
    j.nama_jenjang as 'Nama Jenjang',
    k.nama_kategori as 'Nama Kategori',
    b.deskripsi as ' Kategori'
FROM Beasiswa b
INNER JOIN Jenjang j
    ON b.id_jenjang = j.id_jenjang
INNER JOIN Kategori k
    ON b.id_kategori = k.id_kategori;


alter VIEW vw_Beasiswa2
AS
SELECT
    b.nama_beasiswa as 'Nama Beasiswa',
    b.tgl_buka as 'Tanggal Buka',
    b.tgl_tutup as 'Tanggal Tutup',
    b.link_beasiswa 'Link Beasiswa',
    j.nama_jenjang as 'Nama Jenjang',
    k.nama_kategori as 'Nama Kategori',
    b.deskripsi as ' Kategori'
FROM Beasiswa b
INNER JOIN Jenjang j
    ON b.id_jenjang = j.id_jenjang
INNER JOIN Kategori k
    ON b.id_kategori = k.id_kategori;



CREATE PROCEDURE sp_GetViewBeasiswa
AS
BEGIN
    BEGIN TRY
        SET NOCOUNT ON;

        SELECT *
        FROM vw_Beasiswa
        ORDER BY dibuat DESC;

    END TRY

    BEGIN CATCH
        SELECT
            ERROR_NUMBER() AS ErrorNumber,
            ERROR_MESSAGE() AS ErrorMessage;
    END CATCH
END

CREATE PROCEDURE sp_CountBeasiswa
	@Total INT OUTPUT
AS
BEGIN
	SET NOCOUNT ON;
	SELECT @Total = COUNT(*) FROM Beasiswa
END

EXEC sp_SearchBeasiswa;
SELECT * From vw_Beasiswa;
SELECT * from Beasiswa

CREATE TABLE LogError
(
	id_log INT IDENTITY(1,1) PRIMARY KEY,
	waktu DATETIME,
	pesan_error VARCHAR (MAX)
);


CREATE TABLE LogAktivitas
(
	id_log INT IDENTITY(1,1),
	aktivitas VARCHAR(100),
	waktu DATETIME
);

CREATE TRIGGER trg_InsertBeasiswa
ON Beasiswa
AFTER INSERT
AS
BEGIN
	INSERT INTO LogAktivitas
	VALUES('Tambah data beasiswa', GETDATE());
END;

CREATE TRIGGER trg_DeleteBeasiswa
ON Beasiswa
AFTER DELETE
AS
BEGIN
	INSERT INTO LogAktivitas
	VALUES('Hapus data beasiswa', GETDATE());
END;

CREATE TABLE LogKeamanan
(
	id_log INT IDENTITY(1,1),
	aktivitas VARCHAR(200),
	jumlah_data INT,
	waktu DATETIME
);

CREATE TRIGGER trg_PreventBeaUpdate
ON Beasiswa
AFTER UPDATE
AS
BEGIN
	DECLARE @jumlah INT;

	SELECT @jumlah = COUNT(*) FROM inserted;

	--Jika update lebih dari 5 data
	IF @jumlah > 1
	BEGIN
		--Simpan log keamanan
		INSERT INTO LogKeamanan
		VALUES(
			'WARNING: Update massal terdeteksi',
			@jumlah,
			GETDATE()
		);

		--Membatalkan transaksi
		ROLLBACK TRANSACTION;

		--Menampilkan pesan error
		RAISERROR(
		'Update dibatalkan! Terlalu banyak data diubah.',
		16,
		1
		);
	END
END;

ALTER PROCEDURE sp_Report
    @inJenjang VARCHAR(50),
    @inKategori VARCHAR(50),
    @inTglMsuk INT
AS
BEGIN
    SELECT
        b.nama_beasiswa AS Nama,
        j.nama_jenjang AS Jenjang,
        k.nama_kategori AS Kategori,
        b.dibuat AS TanggalInput
    FROM Beasiswa b
    INNER JOIN Jenjang j
        ON b.id_jenjang = j.id_jenjang
    INNER JOIN Kategori k
        ON b.id_kategori = k.id_kategori
    WHERE
        j.nama_jenjang = @inJenjang
        AND k.nama_kategori = @inKategori
        AND MONTH(b.dibuat) = @inTglMsuk
END

select *from vw_Beasiswa
SELECT *
FROM Beasiswa;
select *from Kategori
select *from logaktivitas
select *from LogError
EXEC sp_Report
    'S1',
    'Prestasi',
    5

--- Baru DI execute dulu
CREATE TABLE Users (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Username  VARCHAR(50)  NOT NULL UNIQUE,
    Password  VARCHAR(255) NOT NULL
);

CREATE PROCEDURE sp_Login
    @Username VARCHAR(50),
    @Password VARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Id, Username
    FROM   Users
    WHERE  Username = @Username
	AND Password = @Password
END

INSERT INTO Users (Username, Password) VALUES
('BatmanMabur', 'JokerTerbang'),
('admin',       'admin'),
('Admin123',    'Admin123');
