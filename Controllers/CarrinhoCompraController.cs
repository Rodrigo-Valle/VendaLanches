using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VendaLanches.Models;
using VendaLanches.Repositories.Interfaces;
using VendaLanches.ViewModels;

namespace VendaLanches.Controllers;
public class CarrinhoCompraController : Controller
{
    private readonly ILancheRepository _lancheRepository;
    private readonly CarrinhoCompra _carrinhoCompra;

    public CarrinhoCompraController(ILancheRepository lancheRepository, 
                                    CarrinhoCompra carrinhoCompra)
    {
        _lancheRepository = lancheRepository;
        _carrinhoCompra = carrinhoCompra;
    }

    public IActionResult Index()
    {
        var itens = _carrinhoCompra.GetCarrinhoCompraItens();
        _carrinhoCompra.CarrinhoCompraItems = itens;

        var carrinhoCompraVM = new CarrinhoCompraViewModel
        {
            CarrinhoCompra = _carrinhoCompra,
            CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal()

        };

        return View(carrinhoCompraVM);
    }

    public IActionResult AdicionarAoCarrinho(int lancheId)
    {
        var lanche = _lancheRepository.Lanches.FirstOrDefault(l => l.LancheId == lancheId);
        if(lanche != null)
        {
            _carrinhoCompra.AdicionarAoCarrinho(lanche);
        }

        return RedirectToAction("Index");
    }

    public IActionResult RemoverDoCarrinho(int lancheId)
    {
        var lanche = _lancheRepository.Lanches.FirstOrDefault(l => l.LancheId == lancheId);
        if(lanche != null)
        {
            _carrinhoCompra.RemoverDoCarrinho(lanche);
        }

        return RedirectToAction("Index");
    }
}