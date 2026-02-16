namespace PeminjamanRuangApi.Models
{
    public class PeminjamanCreateDto
    {
        public string NamaPeminjam { get; set; } = string.Empty;
        public DateTime Tanggal { get; set; }
        public int RuangId { get; set; } // Menggunakan ID Ruangan untuk konsistensi data
    }
}