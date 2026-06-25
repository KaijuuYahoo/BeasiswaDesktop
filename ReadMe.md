## Skenario SQL Injection: Penyerang Membypass Login

### Latar Belakang

Sebuah aplikasi beasiswa memiliki halaman login yang meminta pengguna memasukkan username dan password.

Developer membuat kode login seperti berikut:

```sql
SELECT *
FROM Users
WHERE Username = 'input_username'
AND Password = 'input_password'
```

Aplikasi menggabungkan input pengguna langsung ke dalam query SQL tanpa validasi atau parameter.

---

### Skenario Serangan

Seorang penyerang ingin masuk ke sistem administrator, tetapi tidak mengetahui username maupun password yang benar.

Pada form login, penyerang memasukkan:

**Username**

```text
' OR 1=1 --
```

**Password**

```text
bebas
```

---

### Query yang Terbentuk

Aplikasi akan membentuk query:

```sql
SELECT *
FROM Users
WHERE Username = '' OR 1=1 --'
AND Password = 'bebas'
```

---

### Analisis

Bagian:

```sql
OR 1=1
```

selalu bernilai TRUE.

Sedangkan:

```sql
--
```

digunakan untuk menjadikan sisa query sebagai komentar.

SQL Server akan membaca query menjadi:

```sql
SELECT *
FROM Users
WHERE Username = ''
OR 1=1
```

Karena kondisi `1=1` selalu benar, database akan mengembalikan seluruh data pengguna.

Aplikasi kemudian menganggap login berhasil dan memberikan akses kepada penyerang.

---

### Dampak

Penyerang dapat:

* Masuk tanpa mengetahui password.
* Mengakses menu administrator.
* Melihat data rahasia.
* Mengubah data beasiswa.
* Menghapus data.
* Melakukan tindakan seolah-olah sebagai admin.

---

### Ilustrasi Sederhana

Bayangkan sebuah gedung memiliki satpam yang hanya membuka pintu jika:

> "Nama cocok DAN kartu identitas cocok"

Aturan aslinya:

```text
Nama = Benar
DAN
Kartu = Benar
```

Namun penyerang berkata:

```text
Nama = Benar ATAU Semua Orang Boleh Masuk
```

Karena ada kondisi "Semua Orang Boleh Masuk", satpam langsung membuka pintu tanpa memeriksa kartu identitas.

Inilah yang terjadi pada SQL Injection ketika query dibuat tanpa parameter.

---

### Solusi

Gunakan:

* Stored Procedure
* Parameterized Query (`@Username`, `@Password`)
* Validasi input
* Hak akses database yang terbatas

Dengan cara tersebut input pengguna akan dianggap sebagai data biasa, bukan sebagai bagian dari perintah SQL.
