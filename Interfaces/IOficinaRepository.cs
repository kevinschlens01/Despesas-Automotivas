using DespesasAutomotivas.Models;

namespace DespesasAutomotivas.Interfaces
{
    public interface IOficinaRepository
    {
        Task<IEnumerable<Oficina>> GetAllAsync();
        Task<Oficina?> GetByIdAsync(int id);
        Task AddAsync(Oficina oficina);
        Task UpdateAsync(Oficina oficina);
        Task DeleteAsync(int id);
    }
}
