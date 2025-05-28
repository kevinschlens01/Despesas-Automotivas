using DespesasAutomotivas.Models;


namespace DespesasAutomotivas.Interfaces;

public interface IMelhoriaRepository
{
    Task<IEnumerable<Melhoria>> GetAllAsync();
    Task<Melhoria> GetByIdAsync(int id);
    Task AddAsync(Melhoria melhoria);
    Task UpdateAsync(Melhoria melhoria);
    Task DeleteAsync(int id);
}
