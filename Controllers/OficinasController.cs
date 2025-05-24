using DespesasAutomotivas.Interfaces;
using DespesasAutomotivas.Models;
using Microsoft.AspNetCore.Mvc;

namespace DespesasAutomotivas.Controllers;

public class OficinasController : Controller
{
    private readonly IOficinaRepository _oficinaRepository;

    public OficinasController(IOficinaRepository oficinaRepository)
    {
        _oficinaRepository = oficinaRepository;
    }

    public async Task<IActionResult> Index()
    {
        var oficinas = await _oficinaRepository.GetAllAsync();
        return View(oficinas);
    }

    public async Task<IActionResult> Details(int id)
    {
        var oficina = await _oficinaRepository.GetByIdAsync(id);
        if (oficina == null || oficina.Excluido)
            return NotFound();

        return View(oficina);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Oficina oficina)
    {
        if (ModelState.IsValid)
        {
            await _oficinaRepository.AddAsync(oficina);
            return RedirectToAction(nameof(Index));
        }
        return View(oficina);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var oficina = await _oficinaRepository.GetByIdAsync(id);
        if (oficina == null || oficina.Excluido)
            return NotFound();

        return View(oficina);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Oficina oficina)
    {
        if (id != oficina.Id)
            return NotFound();

        if (ModelState.IsValid)
        {
            await _oficinaRepository.UpdateAsync(oficina);
            return RedirectToAction(nameof(Index));
        }
        return View(oficina);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var oficina = await _oficinaRepository.GetByIdAsync(id);
        if (oficina == null || oficina.Excluido)
            return NotFound();

        return View(oficina);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _oficinaRepository.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
