using DespesasAutomotivas.Infra;
using DespesasAutomotivas.Interfaces;
using DespesasAutomotivas.Models;
using Microsoft.EntityFrameworkCore;

namespace DespesasAutomotivas.Repositories;

public class OficinaRepository : IOficinaRepository
{
    private readonly AppDbContext _context;

    public OficinaRepository(AppDbContext context)
    {
        _context = context;
    }


    public async Task<IEnumerable<Oficina>> GetAllAsync()
    {
        return await _context.Oficinas
            .Where(c => !c.Excluido)
            .ToListAsync();
    }

    public async Task<Oficina?> GetByIdAsync(int id)
    {
        return await _context.Oficinas.FindAsync(id);
    }

    public async Task AddAsync(Oficina oficina)
    {
        _context.Oficinas.Add(oficina);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Oficina oficina)
    {
        _context.Oficinas.Update(oficina);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var oficina = await _context.Oficinas.FindAsync(id);
        if (oficina != null)
        {
            oficina.Excluido = true;
            oficina.ExcluidoEm = DateTime.UtcNow;

            _context.Oficinas.Update(oficina);
            await _context.SaveChangesAsync();
        }
    }
}
