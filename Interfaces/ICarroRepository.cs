using DespesasAutomotivas.Models;

namespace DespesasAutomotivas.Interfaces
{
    public interface ICarroRepository
    {
        Task<IEnumerable<Carro>> GetAllAsync();
        Task<Carro?> GetByIdAsync(int id);
        Task AddAsync(Carro carro);
        Task UpdateAsync(Carro carro);
        Task DeleteAsync(int id);
    }
}
