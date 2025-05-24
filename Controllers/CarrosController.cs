using DespesasAutomotivas.Interfaces;
using DespesasAutomotivas.Models;
using Microsoft.AspNetCore.Mvc;

namespace DespesasAutomotivas.Controllers;

public class CarrosController : Controller
{
    private readonly ICarroRepository _carroRepository;

    public CarrosController(ICarroRepository carroRepository)
    {
        _carroRepository = carroRepository;
    }

    // GET: Carros
    public async Task<IActionResult> Index()
    {
        var carros = await _carroRepository.GetAllAsync();
        return View(carros);
    }

    // GET: Carros/Details/5
    public async Task<IActionResult> Details(int id)
    {
        var carro = await _carroRepository.GetByIdAsync(id);
        if (carro == null || carro.Excluido)
            return NotFound();

        return View(carro);
    }

    // GET: Carros/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Carros/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Carro carro)
    {
        if (ModelState.IsValid)
        {
            await _carroRepository.AddAsync(carro);
            return RedirectToAction(nameof(Index));
        }
        return View(carro);
    }

    // GET: Carros/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
        var carro = await _carroRepository.GetByIdAsync(id);
        if (carro == null || carro.Excluido)
            return NotFound();

        return View(carro);
    }

    // POST: Carros/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Carro carro)
    {
        if (id != carro.Id)
            return NotFound();

        if (ModelState.IsValid)
        {
            await _carroRepository.UpdateAsync(carro);
            return RedirectToAction(nameof(Index));
        }
        return View(carro);
    }

    // GET: Carros/Delete/5
    public async Task<IActionResult> Delete(int id)
    {
        var carro = await _carroRepository.GetByIdAsync(id);
        if (carro == null || carro.Excluido)
            return NotFound();

        return View(carro);
    }

    // POST: Carros/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _carroRepository.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
