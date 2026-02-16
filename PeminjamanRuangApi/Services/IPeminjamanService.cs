using PeminjamanRuangApi.Models;

namespace PeminjamanRuangApi.Services
{
    public interface IPeminjamanService // Ganti dari BookService
    {
        Task<IEnumerable<Peminjaman>> GetAllAsync();
        Task AddAsync(PeminjamanCreateDto dto); 
        Task<bool> UpdateAsync(int id, Peminjaman dataUpdate);
        Task<bool> DeleteAsync(int id);
    }
}