using System.ComponentModel.DataAnnotations;

namespace PeminjamanRuangApi.Models
{
    public class Ruang
    {
        public int Id { get; set; }

        [Required]
        public string NamaRuangan { get; set; } = string.Empty;

        public int Kapasitas { get; set; }
        public string Lokasi { get; set; } = string.Empty; 
    }
}