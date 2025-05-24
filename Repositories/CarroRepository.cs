using DespesasAutomotivas.Infra;
using DespesasAutomotivas.Interfaces;
using DespesasAutomotivas.Models;
using Microsoft.EntityFrameworkCore;

namespace DespesasAutomotivas.Repositories;

public class CarroRepository : ICarroRepository
{
    private readonly AppDbContext _context;

    public CarroRepository(AppDbContext context)
    {
        _context = context;
    }


    public async Task<IEnumerable<Carro>> GetAllAsync()
    {
        return await _context.Carros
            .Where(c => !c.Excluido)
            .ToListAsync();
    }

    public async Task<Carro?> GetByIdAsync(int id)
    {
        return await _context.Carros.FindAsync(id);
    }

    public async Task AddAsync(Carro carro)
    {
        _context.Carros.Add(carro);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Carro carro)
    {
        _context.Carros.Update(carro);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var carro = await _context.Carros.FindAsync(id);
        if (carro != null)
        {
            carro.Excluido = true;
            carro.ExcluidoEm = DateTime.UtcNow;

            _context.Carros.Update(carro);
            await _context.SaveChangesAsync();
        }
    }
}
