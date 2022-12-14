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
    public IActionResult List(string categoria) 
    {
        IEnumerable<Lanche> lanches;
        string categoriaAtual = string.Empty;

        if(string.IsNullOrEmpty(categoria))
        {
            lanches = _lancheRepository.Lanches.OrderBy(l => l.LancheId);
            categoriaAtual = "Todos os lanches";
        }
        else
        {
            lanches = _lancheRepository.Lanches
                .Where(l => l.Categoria.CategoriaNome.Equals(categoria))
                .OrderBy(l => l.Nome);

            categoriaAtual = categoria;
        }

        var lanchesList = new LancheListViewModel
        {
            Lanches = lanches,
            CategoriaAtual = categoriaAtual
        };

        return View(lanchesList);
    }

    public IActionResult Details(int lancheId) 
    {
        var lanche = _lancheRepository.Lanches.FirstOrDefault(l => l.LancheId == lancheId);
        return View(lanche);
    }

    public ViewResult Search(string searchString)
    {
        IEnumerable<Lanche> lanches;
        string categoriaAtual = string.Empty;

        if(string.IsNullOrEmpty(searchString))
        {
            lanches = _lancheRepository.Lanches.OrderBy(l => l.LancheId);
            categoriaAtual = "Todos os lanches";
        }
        else
        {
            lanches = _lancheRepository.Lanches
                .Where(l => l.Nome.ToLower().Contains(searchString.ToLower()));

            if (lanches.Any()) categoriaAtual = "Lanches";
            else categoriaAtual = "nenhum lanche encontrado";
        }

        return View("~/Views/Lanche/List.cshtml", new LancheListViewModel
        {
            Lanches = lanches,
            CategoriaAtual = categoriaAtual
        });
    }

}
