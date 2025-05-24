using Microsoft.AspNetCore.Mvc.Rendering;

namespace DespesasAutomotivas.Models;

public class RelatorioViewModel
{
    public int TotalManutencoes { get; set; }
    public decimal CustoTotal { get; set; }

    public int? CarroIdSelecionado { get; set; }
    public List<SelectListItem> Carros { get; set; } = new();
}

