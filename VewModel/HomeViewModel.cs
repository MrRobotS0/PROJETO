using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PROJETO.Models;

namespace Projeto.VewModel
{
    public class HomeViewModel
    {
         public IEnumerable<Item> ItensEmDestaque { get; set; }
    }
}