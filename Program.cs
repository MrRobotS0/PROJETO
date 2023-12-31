using Projeto.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Projeto.Repositories.Interfaces;
using InduMovel.Repositories;
using Microsoft.AspNetCore.Http;
using PROJETO.Models;
using Microsoft.AspNetCore.Identity;
using PROJETO.Services;
using PROJETO.Repositories.Interfaces;
using PROJETO.Repositories;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddTransient<IPedidoRepository, PedidoRepository>();
builder.Services.AddScoped<IUserRoleInicial, UserRoleInicial>();
builder.Services.AddIdentity<UserAccount, IdentityRole>().AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
builder.Services.AddScoped(sp => Carrinho.GetCarrinhoCompra(sp));
builder.Services.AddMemoryCache();
builder.Services.AddSession();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddTransient<ICategoriaRepository, CategoriaRepository>();

builder.Services.AddTransient<IItemRepository, ItemRepository>();
builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlite(builder.Configuration.GetConnectionString("DefaulConnection")));
builder.Services.AddControllersWithViews();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
CriarPerfisUsuarios(app);
app.UseSession();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
name: "areas",
pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}");
app.MapControllerRoute(
name: "default",
pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
name: "categoriaFiltro",
pattern: "Movel/{action}/{categoria?}",
defaults: new { Controller = "Item", action = "List" }
);

app.Run();

static void CriarPerfisUsuarios(WebApplication app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();
    using var scope = scopedFactory?.CreateScope();
    var service = scope?.ServiceProvider.GetService<IUserRoleInicial>();
    service?.SeedRoles();
    service?.SeedUsers();
}