using DespesasAutomotivas.Infra;
using DespesasAutomotivas.Interfaces;
using DespesasAutomotivas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DespesasAutomotivas.Controllers;

public class ManutencoesController : Controller
{
    private readonly IManutencaoRepository _manutencaoRepository;
    private readonly ICarroRepository _carroRepository;
    private readonly IOficinaRepository _oficinaRepository;
    private readonly AppDbContext _context;

    public ManutencoesController(IManutencaoRepository manutencaoRepository, ICarroRepository carroRepository, IOficinaRepository oficinaRepository, AppDbContext context)
    {
        _manutencaoRepository = manutencaoRepository;
        _carroRepository = carroRepository;
        _oficinaRepository = oficinaRepository;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var manutencoes = await _manutencaoRepository.GetAllAsync();
        return View(manutencoes);
    }

    public async Task<IActionResult> Details(int id)
    {
        var manutencao = await _manutencaoRepository.GetByIdAsync(id);
        if (manutencao == null || manutencao.Excluido)
            return NotFound();

        return View(manutencao);
    }

    public async Task<IActionResult> Create()
    {

        var carros = await _carroRepository.GetAllAsync();
        var oficinas = await _oficinaRepository.GetAllAsync();

        ViewBag.CarroId = new SelectList(carros, "Id", "Modelo");
        ViewBag.OficinaId = new SelectList(oficinas, "Id", "Nome");

        return View();
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Manutencoes manutencao)
    {
        if (ModelState.IsValid)
        {
            await _manutencaoRepository.AddAsync(manutencao);
            return RedirectToAction(nameof(Index));
        }

        var carros = await _carroRepository.GetAllAsync();
        var oficinas = await _oficinaRepository.GetAllAsync();

        ViewBag.CarroId = new SelectList(carros, "Id", "Modelo", manutencao.CarroId);
        ViewBag.OficinaId = new SelectList(oficinas, "Id", "Nome", manutencao.OficinaId);

        return View(manutencao);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var manutencao = await _manutencaoRepository.GetByIdAsync(id);
        if (manutencao == null || manutencao.Excluido)
            return NotFound();

        var carros = await _carroRepository.GetAllAsync();
        var oficinas = await _oficinaRepository.GetAllAsync();

        ViewBag.CarroId = new SelectList(carros, "Id", "Modelo");
        ViewBag.OficinaId = new SelectList(oficinas, "Id", "Nome");

        return View(manutencao);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Manutencoes manutencao)
    {
        if (id != manutencao.Id)
            return NotFound();

        if (ModelState.IsValid)
        {
            await _manutencaoRepository.UpdateAsync(manutencao);
            return RedirectToAction(nameof(Index));
        }

        var carros = await _carroRepository.GetAllAsync();
        var oficinas = await _oficinaRepository.GetAllAsync();

        ViewBag.CarroId = new SelectList(carros, "Id", "Modelo", manutencao.CarroId);
        ViewBag.OficinaId = new SelectList(oficinas, "Id", "Nome", manutencao.OficinaId);

        return View(manutencao);
    }


    public async Task<IActionResult> Delete(int id)
    {
        var manutencao = await _manutencaoRepository.GetByIdAsync(id);
        if (manutencao == null || manutencao.Excluido)
            return NotFound();

        return View(manutencao);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _manutencaoRepository.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
