using Microsoft.AspNetCore.Mvc;
using PROJETO.Models;

namespace PROJETO.VewModel
{
    public class CarrinhoViewModel 
    {
        public Carrinho Carrinho { get; set; }
        public double CarrinhoTotal { get; set; }
    }
}