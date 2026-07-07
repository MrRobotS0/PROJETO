using PROJETO.Models;
using Microsoft.AspNetCore.Identity;
using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;


namespace PROJETO.Services
{
    public class UserRoleInicial : IUserRoleInicial
    {
        private readonly UserManager<UserAccount> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        public UserRoleInicial(UserManager<UserAccount> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }
        public void SeedRoles()
        {
            if (!_roleManager.RoleExistsAsync("Member").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Member";
                role.NormalizedName = "MEMBER";
                IdentityResult roleResult =
                _roleManager.CreateAsync(role).Result;
            }
            if (!_roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Admin";
                role.NormalizedName = "ADMIN";
                IdentityResult roleResult =
                _roleManager.CreateAsync(role).Result;
            }
        }
        public void SeedUsers()
        {
            // Credenciais do admin vêm da configuração (appsettings.Development.json / User Secrets / variáveis de ambiente),
            // nunca hardcoded no código-fonte.
            var email = _configuration["SeedAdmin:Email"];
            var senha = _configuration["SeedAdmin:Password"];

            // Sem senha configurada => não semeia o admin (evita criar usuário sem credencial definida).
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha))
            {
                return;
            }

            if (_userManager.FindByEmailAsync(email).Result == null)
            {
                UserAccount user = new UserAccount();
                user.UserName = email;
                user.Email = email;
                user.NormalizedUserName = email.ToUpperInvariant();
                user.NormalizedEmail = email.ToUpperInvariant();
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();
                user.Nome = "Administrador";
                user.Endereco = "Rua 1";
                user.Numero = 1;
                user.Bairro = "Bairro1";
                user.Cidade = "Ata";
                user.Cep = 16200000;
                IdentityResult result = _userManager.CreateAsync(user, senha).Result;

                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
        }
    }
}