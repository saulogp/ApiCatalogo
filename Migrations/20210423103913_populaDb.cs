using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiCatalogo.Migrations
{
    public partial class populaDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into Categoria(Nome, ImagemUrl) values('Bebida', 'https://www.hypeness.com.br/1/2018/03/Chu-HiCoke5.jpg')");
            migrationBuilder.Sql("Insert into Categoria(Nome, ImagemUrl) values('Lanche', 'https://img.elo7.com.br/product/zoom/1D37D91/papel-parede-adesivo-painel-fotografico-comida-lanche-03-papelparede.jpg')");
            migrationBuilder.Sql("Insert into Categoria(Nome, ImagemUrl) values('Sobremesa', 'https://receitaculinaria.com.br/wp-content/uploads/2020/11/sobremesa-gelada-sensacao-mega-f.jpg')");
            
            migrationBuilder.Sql("Insert into Produto(Nome, Descrição, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId)"+
            " Values('Coca-zero', 'Refrigerante de coca', 5.5, 'https://www.imigrantesbebidas.com.br/bebida/images/products/full/1986-refrigerante-coca-cola-zero-lata-350ml.jpg', 50, now(),"+
            " (Select CategoriaId from Categoria where Nome='Bebida'))");

            migrationBuilder.Sql("Insert into Produto(Nome, Descrição, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId)"+
            " Values('X-Tudo', 'Vem tudo até cabelo e unha', 15.5, 'https://www.receiteria.com.br/wp-content/uploads/receitas-de-x-tudo.jpg', 20, now(),"+
            " (Select CategoriaId from Categoria where Nome='Lanche'))");

            migrationBuilder.Sql("Insert into Produto(Nome, Descrição, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId)"+
            " Values('Bolo', 'Bolo de chocolate', 4.5, 'https://docepedia.com/wp-content/uploads/2018/08/bolo-bombom.b.jpg', 5, now(),"+
            " (Select CategoriaId from Categoria where Nome='Sobremesa'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Categoria");
            migrationBuilder.Sql("Delete from Produto");
        }
    }
}
