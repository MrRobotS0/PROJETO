using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projeto.Repositories.Interfaces;
using PROJETO.Models;
using PROJETO.VewModel;

namespace PROJETO.Controllers
{
    [Authorize]
    public class CarrinhoController : Controller
    {
        private readonly Carrinho _carrinho;
        private readonly IItemRepository _itemRepository;
        public CarrinhoController(Carrinho carrinho, IItemRepository itemRepository)
        {
            _carrinho = carrinho;
            _itemRepository = itemRepository;
        }
        public IActionResult Index()
        {
            var itens = _carrinho.GetCarrinhoCompraItems();
            _carrinho.CarrinhoItens = itens;
            var carrinhoVM = new CarrinhoViewModel
            {
                Carrinho = _carrinho,
                CarrinhoTotal = _carrinho.GetCarrinhoCompraTotal()
            };
            return View(carrinhoVM);
        }
        public IActionResult AdicionarItemNoCarrinhoCompra(int iteMId)
        {
            var itemSelecionado = _itemRepository.Itens.FirstOrDefault(l => l.ItemId == iteMId);
            if (itemSelecionado != null)
            {
                _carrinho.AdicionarItemCarrinho(itemSelecionado);
            }
            return RedirectToAction("Index");
        }
        public IActionResult RemoverCarrinho(int iteMId)
        {
            var itemSelecionado = _itemRepository.Itens.FirstOrDefault(l => l.ItemId == iteMId);
            if (itemSelecionado != null)
            {
                _carrinho.RemoverItemDoCarrinhoCompra(itemSelecionado);
            }
            return RedirectToAction("Index");
        }
    }
}