using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DespesasAutomotivas.Models;

[Table("oficina")]
public class Oficina
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("nome")]
    [DisplayName("Nome")]
    public string Nome { get; set; } = default!;

    [Column("endereco")]
    [DisplayName("Endereço")]
    public string Endereco { get; set; } = default!;

    [Column("telefone")]
    [DisplayName("Telefone")]
    public string Telefone { get; set; } = default!;

    [Column("email")]
    [DisplayName("Email")]
    public string? Email { get; set; }

    [Column("cnpj")]
    [DisplayName("CNPJ")]
    public string Cnpj { get; set; } = default!;

    [Column("excluido_em")]
    public DateTime? ExcluidoEm { get; set; } = null!;

    [Column("excluido")]
    public bool Excluido { get; set; }

    public ICollection<Manutencoes> Manutencoes { get; set; } = new List<Manutencoes>();
}
