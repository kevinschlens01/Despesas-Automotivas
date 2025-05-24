using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DespesasAutomotivas.Models;

[Table("carros")]
public class Carro
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("nome")]
    [DisplayName("Nome")]
    public string Nome { get; set; } = default!;

    [Column("modelo")]
    [DisplayName("Modelo")]
    public string Modelo { get; set; } = default!;

    [Column("marca")]
    [DisplayName("Marca")]
    public string Marca { get; set; } = default!;

    [Column("ano")]
    [DisplayName("Ano")]
    public int Ano { get; set; }

    [Column("cor")]
    [DisplayName("Cor")]
    public string Cor { get; set; } = default!;

    [Column("versao")]
    [DisplayName("Versão")]
    public string Versao { get; set; } = default!;

    [Column("quilometragem")]
    [DisplayName("Quilometragem")]
    public string Quilometragem { get; set; } = default!;

    [Column("placa")]
    [DisplayName("Placa")]
    public string Placa { get; set; } = default!;

    [Column("excluido_em")]
    public DateTime? ExcluidoEm { get; set; } = null!;

    [Column("excluido")]
    public bool Excluido { get; set; }

    public ICollection<Manutencoes> Manutencoes { get; set; } = new List<Manutencoes>();
}
