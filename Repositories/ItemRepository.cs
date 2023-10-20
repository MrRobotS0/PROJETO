using Projeto.Context;
using Projeto.Models;
using Projeto.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using PROJETO.Models;
using System.Linq;
namespace InduMovel.Repositories
{
public class ItemRepository: IItemRepository
{
private readonly AppDbContext _context;
public ItemRepository(AppDbContext context)
{
_context = context;
}

public IEnumerable<Item> Itens => _context.Itens.Include(c =>
c.Categoria);
public IEnumerable<Item> ItensEmDestaque =>
_context.Itens.Where(m => m.Destaque).Include(c => c.Categoria);

        

        public Item GetMovelById(int movelId)
{
return _context.Itens.FirstOrDefault(m => m.ItemId ==

movelId);
}
}
}