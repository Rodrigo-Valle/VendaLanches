using Microsoft.AspNetCore.Mvc;
using VendaLanches.Models;
using VendaLanches.Repositories.Interfaces;

namespace VendaLanches.Controllers;
public class PedidoController : Controller
{
    private readonly IPedidoRepository _pedidoRepository;
    private readonly CarrinhoCompra _carrinhoCompra;

    public PedidoController(IPedidoRepository pedidoRepository, CarrinhoCompra carrinhoCompra)
    {
        _pedidoRepository = pedidoRepository;
        _carrinhoCompra = carrinhoCompra;
    }

    public IActionResult Checkout()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Checkout(Pedido pedido)
    {
        int totalItensPedido = 0;
        decimal precoTotalPeiddo = 0.0m;

        List<CarrinhoCompraItem> itens = _carrinhoCompra.GetCarrinhoCompraItens();
        _carrinhoCompra.CarrinhoCompraItems = itens;

        if (_carrinhoCompra.CarrinhoCompraItems.Count == 0)
        {
            ModelState.AddModelError("", "Seu carrinho está vazio!");
        }

        foreach (var item in itens)
        {
            totalItensPedido += item.Quantidade;
            precoTotalPeiddo += (item.Lanche.Preco * item.Quantidade);
        }

        pedido.TotalItensPedido = totalItensPedido;
        pedido.PedidoTotal = precoTotalPeiddo;

        if (ModelState.IsValid)
        {
            _pedidoRepository.CriarPedido(pedido);

            ViewBag.CheckoutCompletoMensagem = "Obrigado pelo seu pedido";
            ViewBag.TotalPedido = _carrinhoCompra.GetCarrinhoCompraTotal();

            _carrinhoCompra.LimparCarrinho();

            return View("~/Views/Pedido/CheckoutCompleto.cshtml", pedido);
        }

        return View(pedido);
    }
}