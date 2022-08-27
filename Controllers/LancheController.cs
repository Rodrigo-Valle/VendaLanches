using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using VendaLanches.Models;
using VendaLanches.Repositories.Interfaces;
using VendaLanches.ViewModels;

namespace VendaLanches.Controllers;

public class LancheController : Controller
{
    private readonly ILancheRepository _lancheRepository;

    public LancheController(ILancheRepository lancheRepository)
    {
        _lancheRepository = lancheRepository;
    }
    public IActionResult List() 
    {
        var lanches = _lancheRepository.Lanches;
        var lancheList = new LancheListViewModel();
        lancheList.Lanches = lanches;
        lancheList.CategoriaAtual = "Categoria";

        return View(lancheList);
    }
}
