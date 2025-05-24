using DespesasAutomotivas.Interfaces;
using DespesasAutomotivas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DespesasAutomotivas.Controllers;

public class RelatoriosController : Controller
{
    private readonly ICarroRepository _carroRepository;
    private readonly IManutencaoRepository _manutencaoRepository;

    public RelatoriosController(ICarroRepository carroRepository, IManutencaoRepository manutencaoRepository)
    {
        _carroRepository = carroRepository;
        _manutencaoRepository = manutencaoRepository;
    }

    [HttpGet]
    public async Task<IActionResult> Index(int? carroId)
    {
        var carros = await _carroRepository.GetAllAsync();
        var manutencoes = await _manutencaoRepository.GetAllAsync();

        var manutencoesFiltradas = carroId.HasValue
            ? manutencoes.Where(m => m.CarroId == carroId.Value)
            : manutencoes;

        var viewModel = new RelatorioViewModel
        {
            Carros = carros.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = $"{c.Nome} {c.Modelo}"
            }).ToList(),

            CarroIdSelecionado = carroId,
            TotalManutencoes = manutencoesFiltradas.Count(),
            CustoTotal = manutencoesFiltradas.Sum(m => m.ValorTotal)
        };

        return View(viewModel);
    }
}
