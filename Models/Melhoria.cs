using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DespesasAutomotivas.Models;

[Table("melhorias")]
public class Melhoria
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [ForeignKey("Carro")]
    [Column("carro_id")]
    [DisplayName("Carro")]
    public int CarroId { get; set; }

    public Carro? Carro { get; set; }

    [Column("nome_peca")]
    [DisplayName("Nome da Peça")]
    public string NomePeca { get; set; } = default!;

    [Column("data_avaliacao")]
    [DisplayName("Data da Avaliação")]
    public DateTime DataAvaliacao { get; set; } = DateTime.Now;

    public Prioridade Prioridade { get; set; }

    public StatusMelhoria Status { get; set; }

    [Column("excluido")]
    public bool Excluido { get; set; }

    [Column("excluido_em")]
    public DateTime? ExcluidoEm { get; set; }
}

public enum Prioridade
{
    Alta = 0,

    [Display(Name = "Média")]
    Media = 1,
    Baixa = 2
}

public enum StatusMelhoria
{
    Futuro,

    [Display(Name = "Em Andamento")]
    EmAndamento,

    [Display(Name = "Concluída")]
    Concluida
}
