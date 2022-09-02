using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendaLanches.Models;

namespace VendaLanches.ViewModels;
public class HomeViewModel
{
    public IEnumerable<Lanche> LanchesPreferidos { get; set; }
}