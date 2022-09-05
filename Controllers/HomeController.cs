using Microsoft.AspNetCore.Mvc;
using VendaLanches.Repositories.Interfaces;
using VendaLanches.ViewModels;

namespace VendaLanches.Controllers;

public class HomeController : Controller
{
    private readonly ILancheRepository _lancheRepository;

    public HomeController(ILancheRepository lancheRepository)
    {
        _lancheRepository = lancheRepository;
    }

    public IActionResult Index()
    {
        var homeViewModel = new HomeViewModel
        {
            LanchesPreferidos = _lancheRepository.LanchesPreferidos
        };
        return View(homeViewModel);
    }
}
