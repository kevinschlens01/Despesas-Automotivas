﻿using DespesasAutomotivas.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DespesasAutomotivas.Controllers;


[Route("api/relatorios")]
[ApiController]
public class RelatoriosApiController : ControllerBase
{
    private readonly IManutencaoRepository _manutencaoRepository;
    private readonly ICarroRepository _carroRepository;

    public RelatoriosApiController(IManutencaoRepository manutencaoRepository, ICarroRepository carroRepository)
    {
        _manutencaoRepository = manutencaoRepository;
        _carroRepository = carroRepository;
    }

    [HttpGet("grafico")]
    public async Task<IActionResult> GetGraficoManutencoes([FromQuery] int? carroId)
    {
        var carros = await _carroRepository.GetAllAsync();
        var manutencoes = await _manutencaoRepository.GetAllAsync();

        if (carroId.HasValue)
        {
            var carro = carros.FirstOrDefault(c => c.Id == carroId.Value);
            if (carro == null)
                return NotFound("Carro não encontrado.");

            var totalManutencoes = manutencoes.Count(m => m.CarroId == carroId.Value);

            return Ok(new
            {
                labels = new[] { $"{carro.Nome} {carro.Modelo}" },
                valores = new[] { totalManutencoes }
            });
        }
        else
        {
            var resultado = carros.Select(carro => new
            {
                nome = $"{carro.Nome} {carro.Modelo}",
                total = manutencoes.Count(m => m.CarroId == carro.Id)
            });

            return Ok(new
            {
                labels = resultado.Select(r => r.nome).ToArray(),
                valores = resultado.Select(r => r.total).ToArray()
            });
        }
    }
}
