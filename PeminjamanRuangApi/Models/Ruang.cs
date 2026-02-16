using System.ComponentModel.DataAnnotations;

namespace PeminjamanRuangApi.Models
{
    public class Ruang
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string? NamaRuangan { get; set; }

        [Required]
        public int Kapasitas { get; set; }

        [MaxLength(100)]
        public string? Lokasi { get; set; }

    }
}
