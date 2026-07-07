using System;
using Projeto.Context;
using PROJETO.Models;
using PROJETO.Repositories.Interfaces;

namespace PROJETO.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly AppDbContext _context;
        private readonly Carrinho _carrinho;
        public PedidoRepository(AppDbContext context, Carrinho carrinho)
        {
            _context = context;
            _carrinho = carrinho;
        }

        public void CriarPedido(Pedido pedido)
        {
            pedido.PedidoEnviado = DateTime.Now;
            _context.Pedidos.Add(pedido);
            _context.SaveChanges();
            var carrinhoItens = _carrinho.CarrinhoItens;
            pedido.PedidoItens = new System.Collections.Generic.List<PedidoItem>();
            foreach (var carI in carrinhoItens)
            {
                var pm = new PedidoItem()
                {
                    Quantidade = carI.Quantidade,
                    ItemId = carI.Item.ItemId,
                    PedidoId = pedido.PedidoId,
                    Preco = carI.Item.Preco,
                    Item = carI.Item
                };
                _context.PedidoItens.Add(pm);
                pedido.PedidoItens.Add(pm);
            }
            _context.SaveChanges();
        }
    }
}