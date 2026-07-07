# 🍔 Brasa Burger

Site de uma hamburgueria fictícia com vitrine de cardápio, carrinho, checkout e uma área administrativa para gerenciar os lanches. Feito em **ASP.NET Core MVC** com visual moderno e vibrante (tema laranja e vermelho).

## O que dá pra fazer

* 🏠 **Vitrine** com hero, destaques e busca
* 🍟 **Cardápio** navegável por categoria, com página de detalhe de cada lanche
* 🛒 **Carrinho** de compras (por sessão)
* 📦 **Checkout** com dados de entrega e confirmação do pedido
* 🔐 **Login e cadastro** de clientes (ASP.NET Identity)
* ⚙️ **Área Admin** (perfil `Admin`) para cadastrar, editar e remover itens e categorias

## Tecnologias

* **.NET 8** com ASP.NET Core MVC (Razor / `.cshtml`)
* **Entity Framework Core** com **SQLite** (`Movel.db`)
* **ASP.NET Identity** (autenticação e perfis)
* **Bootstrap 5** com CSS próprio (design system em `wwwroot/css/site.css`)
* Fontes: **Bebas Neue** e **Poppins**

## Como rodar

Pré-requisito: **.NET 8 SDK**.

```bash
dotnet restore
dotnet run
```

Acesse **http://localhost:5206**.

> O projeto já vem com o banco `Movel.db` populado com alguns lanches de exemplo.

### Entrar como administrador

As credenciais do admin ficam na configuração, nunca no código. Em desenvolvimento, elas estão em `appsettings.Development.json`, na seção `SeedAdmin`:

```json
"SeedAdmin": {
  "Email": "admin@localhost",
  "Password": "informe a senha aqui"
}
```

Faça login com esse email e senha, e o link **Admin** aparece no menu.
Em produção, prefira **User Secrets** ou variáveis de ambiente para a senha.

## Estrutura

```
Controllers/        Home, Item, Carrinho, Pedido, Account
Areas/Admin/        Painel e CRUD de Itens e Categorias
Models/             Item, Categoria, Pedido, Carrinho, UserAccount...
Repositories/       Acesso a dados (Item, Categoria, Pedido)
Services/           Seed de perfis e usuário admin
VewModel/           ViewModels das telas
Views/              Telas Razor
wwwroot/            CSS, JS e imagens
Migrations/         Migrations do EF Core
```

## Observações

* Banco de dados (`*.db`) e artefatos de build (`bin/`, `obj/`) não entram no versionamento. Veja o `.gitignore`.
* Valores monetários usam `decimal`, evitando erros de arredondamento.
