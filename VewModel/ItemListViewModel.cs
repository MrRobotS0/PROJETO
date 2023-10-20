using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PROJETO.Models;

namespace Projeto.VewModel
{
    public class ItemListViewModel
    {
        public IEnumerable<Item> Itens { get; set; }
        public string CategoriaAtual { get; set; }
    }
}