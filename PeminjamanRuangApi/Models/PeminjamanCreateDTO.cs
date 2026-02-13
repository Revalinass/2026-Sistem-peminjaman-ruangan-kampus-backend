public class PeminjamanCreateDto
{
    public string NamaPeminjam { get; set; } = string.Empty;
    public DateTime Tanggal { get; set; }
    public int RuangId { get; set; } // Cukup kirim ID-nya saja di Swagger
}