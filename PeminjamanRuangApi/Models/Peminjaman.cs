using System.ComponentModel.DataAnnotations;

namespace PeminjamanRuangApi.Models
{
    public class Peminjaman
    {
        public int Id { get; set; }
        public string NamaPeminjam { get; set; } = string.Empty;
        public string NamaRuangan { get; set; } = string.Empty;
        public DateTime Tanggal { get; set; }
        
        // Properti ini yang akan mengisi kolom Status di phpMyAdmin
        public string Status { get; set; } = "Menunggu Persetujuan"; 
    }
}