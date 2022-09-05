using Microsoft.AspNetCore.Mvc;
using VendaLanches.Repositories.Interfaces;

namespace VendaLanches.Components;
public class CategoriaMenu : ViewComponent
{
    public readonly ICategoriaRepository _categoriaRepositório;

    public CategoriaMenu(ICategoriaRepository categoriaRepositório)
    {
        _categoriaRepositório = categoriaRepositório;
    }

    public IViewComponentResult Invoke()
    {
        var categorias = _categoriaRepositório.Categorias.OrderBy(c => c.CategoriaNome);
        return View(categorias);
    }
}