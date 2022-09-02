using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendaLanches.Models;

namespace VendaLanches.Repositories.Interfaces;
public interface IPedidoRepository
{
    void CriarPedido(Pedido pedido);
}   