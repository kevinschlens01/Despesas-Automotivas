using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace DespesasAutomotivas.Models;


[Table("manutencoes")]
public class Manutencoes
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [ForeignKey("Carro")]
    [Column("carro_id")]
    [DisplayName("Carro")]
    public int CarroId { get; set; }

    public Carro? Carro { get; set; }

    [ForeignKey("Oficina")]
    [Column("oficina_id")]
    [DisplayName("Oficina")]
    public int OficinaId { get; set; }

    public Oficina? Oficina { get; set; }

    [Column("data_entrada")]
    [DisplayName("Data de Entrada")]
    public DateTime DataEntrada { get; set; }

    [Column("hora_entrada")]
    [DisplayName("Horário de Entrada")]
    public TimeSpan HoraEntrada { get; set; }

    [Column("data_saida")]
    [DisplayName("Data de Saída")]
    public DateTime? DataSaida { get; set; }

    [Column("hora_saida")]
    [DisplayName("Horário de Saída")]
    public TimeSpan? HoraSaida { get; set; }

    [Column("descricao_servico")]
    [DisplayName("Descrição do Serviço")]
    public string DescricaoServico { get; set; } = string.Empty;

    [Column("servicos_executados")]
    [DisplayName("Serviços Executados")]
    public string ServicosExecutados { get; set; } = string.Empty;

    [Column("pecas_substituidas")]
    [DisplayName("Peças Substituídas")]
    public string PecasSubstituidas { get; set; } = string.Empty;

    [Column("valor_total_pecas")]
    [DisplayName("Valor Total de Peças")]
    [DataType(DataType.Currency)]
    public decimal ValorTotalPecas { get; set; }

    [Column("valor_total_servicos")]
    [DisplayName("Valor Total de Serviços")]
    [DataType(DataType.Currency)]
    public decimal ValorTotalServicos { get; set; }

    public string NomeCarro => Carro?.Nome + '-' + Carro?.Modelo;

    [NotMapped]
    [DisplayName("Valor Total da Manutenção")]
    public decimal ValorTotal => ValorTotalPecas + ValorTotalServicos;

    [Column("excluido_em")]
    public DateTime? ExcluidoEm { get; set; }

    [Column("excluido")]
    public bool Excluido { get; set; }
}


