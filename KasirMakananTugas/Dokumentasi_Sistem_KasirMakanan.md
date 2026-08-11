# Dokumentasi Sistem Aplikasi Kasir Makanan

## 1. Identitas aplikasi

Nama aplikasi: **Kasir Makanan**  
Jenis aplikasi: aplikasi desktop kasir sederhana  
Bahasa pemrograman: **C#**  
Framework: **.NET Framework 4.7.2**  
Teknologi UI: **Windows Forms / WinForms**  
Database: tidak menggunakan database  
Lokasi project: `KasirMakananTugas`

Dokumen ini dibuat untuk membantu memahami sistem yang digunakan dalam aplikasi kasir makanan. Penjelasannya dibuat dari sudut pandang pembelajaran, supaya mudah dipakai untuk presentasi, laporan, atau belajar ulang kode.

## 2. Tujuan aplikasi

Aplikasi ini dibuat untuk membantu proses transaksi makanan secara sederhana. Pengguna dapat memilih menu, memasukkan menu ke keranjang, menghitung subtotal, diskon, pajak, total bayar, uang bayar, kembalian, dan membuat struk transaksi.

Karena aplikasi ini ditujukan untuk tugas sederhana, data tidak disimpan ke database. Semua data menu dan transaksi hanya ada selama aplikasi berjalan. Saat aplikasi ditutup, data transaksi akan hilang.

## 3. Fitur utama

Fitur yang tersedia:

- Menampilkan daftar menu makanan, minuman, dan snack.
- Menambahkan item ke keranjang dengan klik kartu menu.
- Menambahkan item yang sama akan menaikkan jumlah barang.
- Mengurangi jumlah item di keranjang.
- Menghapus item dari keranjang.
- Menghitung subtotal otomatis.
- Menghitung diskon berdasarkan persen.
- Menghitung pajak 10%.
- Menghitung total akhir.
- Memasukkan uang bayar pelanggan.
- Menghitung uang kembalian.
- Memproses pembayaran dengan validasi.
- Menampilkan struk transaksi.
- Reset transaksi untuk memulai transaksi baru.

## 4. Struktur folder penting

Struktur utama project:

```text
KasirMakananTugas/
├── KasirMakananTugas.slnx
├── Dokumentasi_Sistem_KasirMakanan.md
├── Dokumentasi_Sistem_KasirMakanan.docx
├── KasirMakananTugas/
│   ├── KasirMakananTugas.csproj
│   ├── Program.cs
│   ├── Form1.cs
│   ├── Form1.Designer.cs
│   ├── App.config
│   └── Properties/
│       ├── AssemblyInfo.cs
│       ├── Resources.resx
│       └── Settings.settings
└── docs/
    └── superpowers/
        ├── specs/
        └── plans/
```

Penjelasan file:

- `KasirMakananTugas.slnx`: file solution yang dibuka di Visual Studio.
- `KasirMakananTugas.csproj`: file project C# yang menyimpan pengaturan build dan daftar file.
- `Program.cs`: titik awal aplikasi. File ini menjalankan `Form1`.
- `Form1.cs`: file utama yang berisi logika aplikasi, desain UI runtime, data menu, keranjang, pembayaran, dan struk.
- `Form1.Designer.cs`: file designer WinForms. Di project ini file tersebut berisi preview aman untuk Visual Studio Designer.
- `App.config`: konfigurasi aplikasi .NET Framework.
- `Properties`: folder bawaan WinForms untuk resource, settings, dan informasi assembly.

## 5. Alur kerja aplikasi

Alur penggunaan aplikasi:

1. Aplikasi dibuka.
2. Sistem membuat daftar menu makanan dan minuman.
3. Sistem membuat tampilan kasir.
4. Pengguna klik menu.
5. Menu masuk ke keranjang.
6. Sistem menghitung ulang subtotal, diskon, pajak, total, dan kembalian.
7. Pengguna memasukkan uang bayar.
8. Pengguna klik tombol proses bayar.
9. Sistem memvalidasi transaksi.
10. Jika valid, sistem menampilkan struk.
11. Pengguna dapat menekan reset untuk transaksi baru.

## 6. Teknologi yang digunakan

### 6.1 C#

C# digunakan sebagai bahasa utama. Semua logika aplikasi ditulis di C#, termasuk:

- data menu,
- data keranjang,
- event klik tombol,
- perhitungan total,
- validasi pembayaran,
- pembuatan struk,
- tampilan runtime WinForms.

### 6.2 .NET Framework 4.7.2

Project memakai .NET Framework 4.7.2. Ini adalah framework yang umum digunakan untuk aplikasi desktop Windows lama maupun tugas sekolah yang memakai Visual Studio dan WinForms.

### 6.3 Windows Forms

WinForms digunakan untuk membuat tampilan desktop. Komponen yang digunakan antara lain:

- `Form`
- `Panel`
- `TableLayoutPanel`
- `FlowLayoutPanel`
- `Label`
- `Button`
- `TextBox`
- `DataGridView`

WinForms bekerja dengan event. Contohnya, saat tombol diklik, method tertentu dijalankan.

## 7. Konsep data dalam aplikasi

Aplikasi memakai dua model data kecil di dalam `Form1.cs`.

### 7.1 MenuProduct

`MenuProduct` menyimpan data satu menu.

Properti:

- `Name`: nama menu.
- `Category`: kategori menu.
- `Price`: harga menu.

Contoh data:

```csharp
new MenuProduct("Nasi Goreng Spesial", "Makanan", 18000m)
```

Artinya:

- nama menu: Nasi Goreng Spesial,
- kategori: Makanan,
- harga: Rp 18.000.

### 7.2 CartLine

`CartLine` menyimpan satu baris item dalam keranjang.

Properti:

- `Product`: menu yang dipilih.
- `Quantity`: jumlah item.
- `LineTotal`: total harga untuk item tersebut.

Rumus `LineTotal`:

```text
LineTotal = harga menu x jumlah
```

Contoh:

```text
Nasi Goreng Spesial x 2
Harga satuan: Rp 18.000
LineTotal: Rp 36.000
```

## 8. Daftar menu

Menu dibuat secara statis di method `InitializeMenuData()`. Artinya menu langsung ditulis di kode, bukan diambil dari database.

Daftar menu:

| Nama menu | Kategori | Harga |
|---|---|---:|
| Nasi Goreng Spesial | Makanan | Rp 18.000 |
| Mie Ayam Bakso | Makanan | Rp 16.000 |
| Ayam Geprek | Makanan | Rp 17.000 |
| Bakso Kuah | Makanan | Rp 15.000 |
| Soto Ayam | Makanan | Rp 14.000 |
| Es Teh Manis | Minuman | Rp 5.000 |
| Es Jeruk | Minuman | Rp 7.000 |
| Kopi Susu | Minuman | Rp 9.000 |
| Air Mineral | Minuman | Rp 4.000 |
| Pisang Goreng | Snack | Rp 8.000 |

## 9. Penjelasan tampilan UI

Tampilan aplikasi dibagi menjadi tiga bagian besar:

### 9.1 Header

Header berada di bagian atas. Isinya:

- judul aplikasi,
- deskripsi singkat,
- tanggal,
- label meja kasir.

Header dibuat dengan warna gelap agar terlihat seperti dashboard kasir modern.

### 9.2 Daftar menu

Panel daftar menu berada di kiri. Setiap menu ditampilkan sebagai kartu. Kartu menu berisi:

- kategori,
- nama menu,
- harga,
- tombol tambah.

Saat kartu diklik, menu akan masuk ke keranjang.

### 9.3 Keranjang

Panel keranjang berada di tengah. Keranjang memakai `DataGridView` agar data transaksi terlihat rapi dalam bentuk tabel.

Kolom keranjang:

- Item
- Harga
- Qty
- Total

Tombol pada keranjang:

- `+`: menambah jumlah item terpilih.
- `-`: mengurangi jumlah item terpilih.
- `Hapus`: menghapus item terpilih.

### 9.4 Pembayaran

Panel pembayaran berada di kanan. Bagian ini menampilkan:

- subtotal,
- diskon,
- pajak,
- total,
- uang kembalian,
- input diskon,
- input uang bayar,
- tombol proses bayar,
- tombol reset,
- struk.

## 10. Rumus perhitungan

### 10.1 Subtotal

Subtotal adalah total seluruh item sebelum diskon dan pajak.

```text
Subtotal = jumlah semua LineTotal
```

Contoh:

```text
Nasi Goreng x 2 = Rp 36.000
Es Teh x 1 = Rp 5.000
Subtotal = Rp 41.000
```

### 10.2 Diskon

Diskon dihitung berdasarkan persen yang dimasukkan pengguna.

```text
Diskon = Subtotal x (persen diskon / 100)
```

Contoh:

```text
Subtotal = Rp 41.000
Diskon = 10%
Diskon = Rp 4.100
```

### 10.3 Pajak

Pajak aplikasi ini adalah 10%.

```text
Pajak = (Subtotal - Diskon) x 10%
```

### 10.4 Total akhir

Total akhir adalah subtotal setelah diskon ditambah pajak.

```text
Total = Subtotal - Diskon + Pajak
```

### 10.5 Kembalian

Kembalian dihitung dari uang bayar dikurangi total.

```text
Kembalian = Uang bayar - Total
```

## 11. Method penting di Form1.cs

### 11.1 InitializeMenuData()

Method ini mengisi daftar menu awal. Method ini dipanggil saat form dibuat.

Tugasnya:

- membuat object `MenuProduct`,
- memasukkan object tersebut ke list `_menu`.

### 11.2 BuildInterface()

Method ini membuat tampilan utama aplikasi saat runtime.

Tugasnya:

- membersihkan preview designer,
- membuat root layout,
- membuat header,
- membuat panel daftar menu,
- membuat panel keranjang,
- membuat panel pembayaran.

### 11.3 AddToCart(MenuProduct product)

Method ini dipanggil saat pengguna klik kartu menu.

Logikanya:

- jika menu belum ada di keranjang, buat baris baru,
- jika menu sudah ada, tambah quantity,
- refresh tampilan keranjang,
- refresh total pembayaran.

### 11.4 RefreshCartGrid()

Method ini memperbarui isi tabel keranjang.

Tugasnya:

- menghapus baris lama di grid,
- membaca data dari `_cart`,
- memasukkan data terbaru ke `DataGridView`.

### 11.5 RefreshTotals()

Method ini menghitung ulang semua nominal pembayaran.

Yang dihitung:

- subtotal,
- diskon,
- pajak,
- total,
- kembalian.

Method ini dipanggil setelah perubahan keranjang, perubahan diskon, atau perubahan uang bayar.

### 11.6 ProcessPayment()

Method ini memproses pembayaran.

Validasi yang dilakukan:

- keranjang tidak boleh kosong,
- diskon harus valid,
- uang bayar harus angka,
- uang bayar harus cukup.

Jika semua valid, sistem:

- menghitung kembalian,
- membuat struk,
- menampilkan pesan pembayaran berhasil.

### 11.7 ResetTransaction()

Method ini menghapus transaksi saat ini.

Yang dibersihkan:

- isi keranjang,
- input diskon,
- input uang bayar,
- label kembalian,
- isi struk,
- tabel keranjang,
- total pembayaran.

### 11.8 BuildReceipt(decimal cash, decimal change)

Method ini membuat teks struk.

Isi struk:

- nama aplikasi,
- tanggal transaksi,
- daftar item,
- subtotal,
- diskon,
- pajak,
- total,
- uang bayar,
- kembalian,
- ucapan terima kasih.

## 12. Validasi input

Validasi diperlukan supaya aplikasi tidak error saat pengguna memasukkan data yang salah.

Contoh validasi:

- Jika keranjang kosong, pembayaran tidak bisa diproses.
- Jika uang bayar kosong, muncul pesan peringatan.
- Jika uang bayar kurang dari total, muncul pesan uang belum cukup.
- Jika diskon bukan angka, muncul pesan input tidak valid.
- Jika diskon kurang dari 0 atau lebih dari 100, muncul pesan input tidak valid.

Validasi angka memakai `decimal.TryParse()`. Ini lebih aman daripada langsung mengubah teks ke angka, karena aplikasi tidak crash jika input salah.

## 13. Kenapa tidak memakai database

Aplikasi ini tidak memakai database karena fokusnya adalah memahami dasar sistem kasir dan UI WinForms.

Keuntungan tanpa database:

- lebih sederhana,
- lebih mudah dipelajari,
- tidak perlu konfigurasi tambahan,
- cocok untuk tugas dasar.

Kekurangan tanpa database:

- transaksi tidak tersimpan,
- menu tidak bisa diubah dari luar aplikasi,
- tidak ada riwayat penjualan,
- tidak ada laporan harian.

Jika ingin dikembangkan, database bisa ditambahkan memakai SQLite, SQL Server, atau MySQL.

## 14. Cara menjalankan aplikasi

Cara menjalankan lewat Visual Studio:

1. Buka Visual Studio.
2. Buka file `KasirMakananTugas.slnx`.
3. Pastikan project `KasirMakananTugas` terbuka.
4. Tekan tombol hijau **Start**.
5. Aplikasi kasir akan muncul.

Cara menjalankan lewat file EXE:

1. Buka folder `KasirMakananTugas/KasirMakananTugas/bin/Debug`.
2. Jalankan `KasirMakananTugas.exe`.

## 15. Cara melihat tampilan designer

Untuk melihat preview di Visual Studio:

1. Buka `Form1.cs`.
2. Klik kanan file tersebut.
3. Pilih **View Designer**.

Catatan penting: tampilan lengkap dan interaktif dibuat saat aplikasi dijalankan. Designer menampilkan preview aman agar Visual Studio tidak error saat membuka desain.

## 16. Cara build aplikasi

Build lewat Visual Studio:

1. Buka solution.
2. Klik menu **Build**.
3. Pilih **Build Solution**.

Build lewat MSBuild:

```powershell
& "C:\Program Files\Microsoft Visual Studio\18\Community\MSBuild\Current\Bin\MSBuild.exe" KasirMakananTugas.slnx /p:Configuration=Debug
```

Jika build berhasil, output akan menampilkan:

```text
Build succeeded.
0 Warning(s)
0 Error(s)
```

## 17. Cara membaca kode untuk belajar

Urutan belajar yang disarankan:

1. Buka `Program.cs` untuk melihat titik awal aplikasi.
2. Buka `Form1.cs`.
3. Cari constructor `public Form1()`.
4. Ikuti urutan method yang dipanggil:
   - `InitializeComponent()`
   - `InitializeMenuData()`
   - `BuildInterface()`
   - `RefreshCartGrid()`
   - `RefreshTotals()`
5. Pelajari class `MenuProduct`.
6. Pelajari class `CartLine`.
7. Pelajari method `AddToCart()`.
8. Pelajari method `RefreshTotals()`.
9. Pelajari method `ProcessPayment()`.
10. Pelajari method `BuildReceipt()`.

## 18. Ide pengembangan lanjutan

Aplikasi ini bisa dikembangkan lagi dengan fitur:

- login kasir,
- database menu,
- database transaksi,
- cetak struk ke printer,
- laporan penjualan harian,
- filter menu berdasarkan kategori,
- pencarian menu,
- stok barang,
- export laporan ke Excel,
- mode admin untuk mengubah harga.

## 19. Kesimpulan

Aplikasi Kasir Makanan adalah aplikasi desktop sederhana berbasis C# WinForms. Sistem ini memakai data menu statis dan keranjang transaksi dalam memori. Meskipun tidak memakai database, aplikasi sudah memiliki fitur inti kasir: memilih menu, menghitung total, diskon, pajak, pembayaran, kembalian, struk, dan reset transaksi.

Konsep utama yang dipelajari dari project ini adalah:

- struktur project WinForms,
- event klik tombol,
- penggunaan list untuk menyimpan data sementara,
- penggunaan class sebagai model data,
- penggunaan `DataGridView`,
- perhitungan transaksi,
- validasi input,
- pembuatan struk sederhana,
- pemisahan antara preview designer dan UI runtime.
