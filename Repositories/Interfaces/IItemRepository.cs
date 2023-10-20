using System.Collections.Generic;
using Projeto.Models;
using PROJETO.Models;
namespace Projeto.Repositories.Interfaces
{
public interface IItemRepository
{
IEnumerable<Item> Itens { get; }
IEnumerable<Item> ItensEmDestaque { get; }
public Item GetMovelById(int movelId);
}
}