using DespesasAutomotivas.Infra;
using DespesasAutomotivas.Interfaces;
using DespesasAutomotivas.Models;
using Microsoft.EntityFrameworkCore;

namespace DespesasAutomotivas.Repositories;

public class MelhoriaRepository : IMelhoriaRepository
{
    private readonly AppDbContext _context;

    public MelhoriaRepository(AppDbContext context)
    {
        _context = context;
    }


    public async Task<IEnumerable<Melhoria>> GetAllAsync()
    {
        return await _context.Melhorias
            .Where(c => !c.Excluido)
            .Include(c => c.Carro)
            .OrderBy(c => c.Prioridade) // prioridade mais alta vem primeiro (caso enum: 0=Alta, 1=Média, 2=Baixa)
            .ThenBy(c => c.DataAvaliacao)
            .ToListAsync();
    }


    public async Task<Melhoria?> GetByIdAsync(int id)
    {
        return await _context.Melhorias
            .Include(c => c.Carro)
            .FirstOrDefaultAsync(m => m.Id == id && !m.Excluido);
    }

    public async Task AddAsync(Melhoria melhoria)
    {
        _context.Melhorias.Add(melhoria);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Melhoria melhoria)
    {
        _context.Melhorias.Update(melhoria);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var melhoria = await _context.Melhorias.FindAsync(id);
        if (melhoria != null)
        {
            melhoria.Excluido = true;
            melhoria.ExcluidoEm = DateTime.UtcNow;

            _context.Melhorias.Update(melhoria);
            await _context.SaveChangesAsync();
        }
    }
}
