using Projeto.Context;
using Projeto.Models;
using Projeto.Repositories.Interfaces;
using System.Collections.Generic;
namespace InduMovel.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;
        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Categoria> Categorias => _context.Categorias;
    }
}