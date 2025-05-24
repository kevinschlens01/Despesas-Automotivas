using DespesasAutomotivas.Infra;
using DespesasAutomotivas.Interfaces;
using DespesasAutomotivas.Models;
using Microsoft.EntityFrameworkCore;

namespace DespesasAutomotivas.Repositories;

public class ManutencaoRepository : IManutencaoRepository
{
    private readonly AppDbContext _context;

    public ManutencaoRepository(AppDbContext context)
    {
        _context = context;
    }


    public async Task<IEnumerable<Manutencoes>> GetAllAsync()
    {
        return await _context.Manutencoes
            .Where(m => !m.Excluido)
            .Include(m => m.Carro)
            .Include(m => m.Oficina)
            .OrderByDescending(m => m.DataSaida)
            .ToListAsync();
    }


    public async Task<Manutencoes?> GetByIdAsync(int id)
    {
        return await _context.Manutencoes
            .Include(m => m.Carro)
            .Include(m => m.Oficina)
            .FirstOrDefaultAsync(m => m.Id == id && !m.Excluido);
    }


    public async Task AddAsync(Manutencoes manutencoes)
    {
        _context.Manutencoes.Add(manutencoes);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Manutencoes manutencoes)
    {
        _context.Manutencoes.Update(manutencoes);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var manutencoes = await _context.Manutencoes.FindAsync(id);
        if (manutencoes != null)
        {
            manutencoes.Excluido = true;
            manutencoes.ExcluidoEm = DateTime.UtcNow;

            _context.Manutencoes.Update(manutencoes);
            await _context.SaveChangesAsync();
        }
    }
}
