using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Projeto.Repositories.Interfaces;
using PROJETO.Models;
using Projeto.VewModel;

namespace PROJETO.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemRepository _itemRespository;
        public ItemController(IItemRepository itemRespository)
        {
            _itemRespository = itemRespository;
        }
        public IActionResult List(string categoria)
        {
            IEnumerable<Item> itens;
            var categoriaAtual = string.Empty;
            if (string.IsNullOrEmpty(categoria))
            {
                itens = _itemRespository.Itens.OrderBy(m => m.ItemId);
                categoriaAtual = "Todos os itens";
            }
            else
            {
                itens = _itemRespository.Itens.Where(m =>
                m.Categoria.Nome.Equals(categoria)).OrderBy(m => m.ItemId);

                categoriaAtual = categoria;
            }
            var itemListViewMovel = new ItemListViewModel
            {
                Itens = itens,
                CategoriaAtual = categoriaAtual
            };
            return View(itemListViewMovel);
        }
        public IActionResult Detail(int itemId)
        {

            var movel = _itemRespository.Itens.FirstOrDefault(m =>

            m.ItemId == itemId);

            return View(movel);
        }

        public IActionResult Search(string searchString)
        {

            IEnumerable<Item> itens;
            string categoriaAtual = string.Empty;
            if (string.IsNullOrEmpty(searchString))
            {
                itens = _itemRespository.Itens.OrderBy(m => m.Nome);
                categoriaAtual = "Todos os Itens";
            }
            else
            {
                itens = _itemRespository.Itens.Where(m =>
                m.Nome.ToLower() == searchString.ToLower()).OrderBy(m => m.Nome);

                if (itens.Any())
                {
                    categoriaAtual = "Itens";
                }
                else
                {
                    categoriaAtual = "Nada encontrado";
                }
            }
            return View("~/Views/Item/List.cshtml", new ItemListViewModel
            {
                CategoriaAtual = categoriaAtual,
                Itens = itens
            });

        }
    }
}