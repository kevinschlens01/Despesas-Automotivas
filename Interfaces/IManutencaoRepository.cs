using DespesasAutomotivas.Models;

namespace DespesasAutomotivas.Interfaces
{
    public interface IManutencaoRepository
    {
        Task<IEnumerable<Manutencoes>> GetAllAsync();
        Task<Manutencoes?> GetByIdAsync(int id);
        Task AddAsync(Manutencoes manutencao);
        Task UpdateAsync(Manutencoes manutencao);
        Task DeleteAsync(int id);
    }
}
