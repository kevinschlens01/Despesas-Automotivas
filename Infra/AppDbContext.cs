using DespesasAutomotivas.Models;
using Microsoft.EntityFrameworkCore;

namespace DespesasAutomotivas.Infra;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Carro> Carros { get; set; }
    public DbSet<Oficina> Oficinas { get; set; }
    public DbSet<Manutencoes> Manutencoes { get; set; }
    public DbSet<Melhoria> Melhorias { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}

