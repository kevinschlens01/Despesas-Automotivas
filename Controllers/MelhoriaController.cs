using DespesasAutomotivas.Interfaces;
using DespesasAutomotivas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DespesasAutomotivas.Controllers;

public class MelhoriaController : Controller
{
    private readonly IMelhoriaRepository _melhoriaRepository;
    private readonly ICarroRepository _carroRepository;

    public MelhoriaController(IMelhoriaRepository melhoriaRepository, ICarroRepository carroRepository)
    {
        _melhoriaRepository = melhoriaRepository;
        _carroRepository = carroRepository;
    }

    public async Task<IActionResult> Index(int? carroId)
    {
        var melhorias = await _melhoriaRepository.GetAllAsync();

        if (carroId.HasValue)
            melhorias = melhorias.Where(m => m.CarroId == carroId.Value).ToList();

        var carros = await _carroRepository.GetAllAsync();
        ViewBag.CarroId = new SelectList(carros, "Id", "Modelo");

        return View(melhorias);
    }


    public async Task<IActionResult> Details(int id)
    {
        var melhoria = await _melhoriaRepository.GetByIdAsync(id);
        if (melhoria == null || melhoria.Excluido)
            return NotFound();

        return View(melhoria);
    }

    public async Task<IActionResult> Create()
    {
        var carros = await _carroRepository.GetAllAsync();
        var carrosSelectList = carros.Select(c => new
        {
            Id = c.Id,
            NomeModelo = $"{c.Nome} - {c.Modelo}"
        });
        ViewBag.CarroId = new SelectList(carrosSelectList, "Id", "NomeModelo");

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Melhoria melhoria)
    {
        if (ModelState.IsValid)
        {
            await _melhoriaRepository.AddAsync(melhoria);
            return RedirectToAction(nameof(Index));
        }

        var carros = await _carroRepository.GetAllAsync();
        var carrosSelectList = carros.Select(c => new
        {
            Id = c.Id,
            NomeModelo = $"{c.Nome} - {c.Modelo}"
        });
        ViewBag.CarroId = new SelectList(carrosSelectList, "Id", "NomeModelo", melhoria.CarroId);

        return View(melhoria);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var melhoria = await _melhoriaRepository.GetByIdAsync(id);
        if (melhoria == null || melhoria.Excluido)
            return NotFound();

        var carros = await _carroRepository.GetAllAsync();
        var carrosSelectList = carros.Select(c => new
        {
            Id = c.Id,
            NomeModelo = $"{c.Nome} - {c.Modelo}"
        });
        ViewBag.CarroId = new SelectList(carrosSelectList, "Id", "NomeModelo");

        return View(melhoria);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Melhoria melhoria)
    {
        if (id != melhoria.Id)
            return NotFound();

        if (ModelState.IsValid)
        {
            await _melhoriaRepository.UpdateAsync(melhoria);
            return RedirectToAction(nameof(Index));
        }

        var carros = await _carroRepository.GetAllAsync();

        ViewBag.CarroId = new SelectList(carros, "Id", "Modelo", melhoria.CarroId);
        return View(melhoria);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var melhoria = await _melhoriaRepository.GetByIdAsync(id);
        if (melhoria == null || melhoria.Excluido)
            return NotFound();

        return View(melhoria);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _melhoriaRepository.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
