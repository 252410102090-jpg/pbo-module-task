using System;
using System.Collections.Generic;

namespace SistemProdukToko
{
    // ==========================================
    // 2.a Kelas Produk (Superclass Utama)
    // ==========================================
    public class Produk
    {
        public string Nama { get; set; }
        public double Harga { get; set; }

        public virtual void InfoProduk()
        {
            Console.WriteLine($"Nama: {Nama}, Harga: Rp{Harga}");
        }

        // Virtual agar bisa di-override di subclass
        public virtual void Kategori()
        {
            Console.WriteLine("Kategori: Produk Umum");
        }
    }

    // ==========================================
    // 2.b Kelas Elektronik (Mewarisi Produk)
    // ==========================================
    public class Elektronik : Produk
    {
        public int Garansi { get; set; } // dalam bulan

        public void CekGaransi()
        {
            Console.WriteLine($"Garansi untuk {Nama} adalah {Garansi} bulan.");
        }

        public override void Kategori()
        {
            Console.WriteLine("Kategori: Elektronik");
        }
    }

    // ==========================================
    // 2.c Kelas Makanan (Mewarisi Produk)
    // ==========================================
    public class Makanan : Produk
    {
        public DateTime TanggalKadaluarsa { get; set; }

        public void CekKadaluarsa()
        {
            Console.WriteLine($"Tanggal Kadaluarsa {Nama}: {TanggalKadaluarsa.ToString("dd MMM yyyy")}");
        }

        public override void Kategori()
        {
            Console.WriteLine("Kategori: Makanan");
        }
    }

    // ==========================================
    // 2.d Kelas Laptop dan HP (Mewarisi Elektronik)
    // ==========================================
    public class Laptop : Elektronik
    {
        public void InstallSoftware()
        {
            Console.WriteLine($"[Aksi] Menginstall software di laptop {Nama}...");
        }

        public override void Kategori()
        {
            Console.WriteLine("Kategori: Elektronik -> Laptop");
        }

        // Jawaban untuk Soal 3: Menampilkan info lengkap
        public override void InfoProduk()
        {
            Console.WriteLine($"Nama: {Nama}, Harga: Rp{Harga}, Garansi: {Garansi} bulan");
        }
    }

    public class HP : Elektronik
    {
        public void Telepon()
        {
            Console.WriteLine($"[Aksi] Memanggil seseorang menggunakan HP {Nama}...");
        }

        public override void Kategori()
        {
            Console.WriteLine("Kategori: Elektronik -> Handphone");
        }
    }

    // ==========================================
    // 2.e Kelas Snack dan Minuman (Mewarisi Makanan)
    // ==========================================
    public class Snack : Makanan
    {
        public void Makan()
        {
            Console.WriteLine($"[Aksi] Memakan snack {Nama}. Krenyes!");
        }

        public override void Kategori()
        {
            Console.WriteLine("Kategori: Makanan -> Snack");
        }
    }

    public class Minuman : Makanan
    {
        public void Dinginkan()
        {
            Console.WriteLine($"[Aksi] Mendinginkan minuman {Nama} di dalam kulkas...");
        }

        public override void Kategori()
        {
            Console.WriteLine("Kategori: Makanan -> Minuman");
        }
    }

    // ==========================================
    // 2.f Kelas Toko
    // ==========================================
    public class Toko
    {
        public List<Produk> daftarProduk = new List<Produk>();

        public void TambahProduk(Produk produk)
        {
            daftarProduk.Add(produk);
            Console.WriteLine($"[+] {produk.Nama} berhasil ditambahkan ke toko.");
        }

        public void DaftarProduk()
        {
            Console.WriteLine("\n=== DAFTAR PRODUK DI TOKO ===");
            foreach (var produk in daftarProduk)
            {
                produk.InfoProduk();
            }
            Console.WriteLine("=============================\n");
        }
    }

    // ==========================================
    // METHOD MAIN
    // ==========================================
    class Program
    {
        static void Main(string[] args)
        {
            // 6.a Buat objek toko
            Toko tokoKelontong = new Toko();

            // 6.b Buat beberapa objek produk
            Laptop laptopAsus = new Laptop { Nama = "Asus ROG", Harga = 15000000, Garansi = 24 };
            HP hpSamsung = new HP { Nama = "Samsung Galaxy S23", Harga = 12000000, Garansi = 12 };
            Snack chitato = new Snack { Nama = "Chitato Sapi Panggang", Harga = 15000, TanggalKadaluarsa = new DateTime(2025, 12, 1) };
            Minuman sprite = new Minuman { Nama = "Sprite 1 Liter", Harga = 12000, TanggalKadaluarsa = new DateTime(2026, 8, 15) };

            // 6.c Tambahkan ke toko
            Console.WriteLine("--- Menambah Produk ke Toko ---");
            tokoKelontong.TambahProduk(laptopAsus);
            tokoKelontong.TambahProduk(hpSamsung);
            tokoKelontong.TambahProduk(chitato);
            tokoKelontong.TambahProduk(sprite);

            // 6.d Tampilkan semua data
            tokoKelontong.DaftarProduk();

            // 6.e Demonstrasikan polymorphism
            Console.WriteLine("--- Demonstrasi Polymorphism dari List<Produk> ---");
            foreach (var produk in tokoKelontong.daftarProduk)
            {
                Console.Write($"{produk.Nama} -> ");
                produk.Kategori(); // Akan memanggil method override masing-masing secara dinamis
            }
            Console.WriteLine();


            // ==========================================
            // TEST KASUS SOAL 1 HINGGA 5
            // ==========================================
            Console.WriteLine("\n========= IMPLEMENTASI SOAL =========");

            // Soal 1: Jalankan Kategori() pada Laptop dan Snack
            Console.WriteLine("\n[Soal 1] Memanggil method Kategori() pada Laptop dan Snack:");
            laptopAsus.Kategori();
            chitato.Kategori();

            // Soal 2: Jalankan InstallSoftware() pada objek Laptop
            Console.WriteLine("\n[Soal 2] Memanggil method InstallSoftware() pada Laptop:");
            laptopAsus.InstallSoftware();

            // Soal 3: Tampilkan informasi lengkap dari Laptop
            Console.WriteLine("\n[Soal 3] Menampilkan informasi lengkap Laptop:");
            laptopAsus.InfoProduk(); // Method ini sudah di-override di kelas Laptop untuk menampikan Garansi

            // Soal 4: Jalankan Dinginkan() pada objek Minuman
            Console.WriteLine("\n[Soal 4] Memanggil method Dinginkan() pada Minuman:");
            sprite.Dinginkan();

            // Soal 5: Buat variabel tipe Produk, isi dengan objek HP, panggil Kategori()
            Console.WriteLine("\n[Soal 5] Variabel Produk diisi HP lalu panggil Kategori():");
            Produk produkHP = new HP { Nama = "iPhone 15", Harga = 15000000, Garansi = 12 };
            produkHP.Kategori(); // Polymorphism terjadi di sini (yang dipanggil adalah milik HP)

            Console.ReadLine(); // Menahan console agar tidak langsung tertutup
        }
    }
}