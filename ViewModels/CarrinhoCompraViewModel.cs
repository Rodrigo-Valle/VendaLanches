using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendaLanches.Models;

namespace VendaLanches.ViewModels;
public class CarrinhoCompraViewModel
{
    public CarrinhoCompra CarrinhoCompra { get; set; }
    public decimal CarrinhoCompraTotal { get; set; }
}