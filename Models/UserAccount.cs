using Microsoft.AspNetCore.Identity;

namespace PROJETO.Models
{
    public class UserAccount : IdentityUser
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public long Cep { get; set; }
    }
}