using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalogo.Migrations
{
    /// <inheritdoc />
    public partial class PopulaProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Produtos (Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId)  VALUES ('Coca-cola Diet', 'Refrigerante de cola diet 350ml', 5.45, 'coca-cola.jpg', 50, now(), 1)");

            mb.Sql("INSERT INTO Produtos (Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId)  VALUES ('Pizza Margherita', 'Pizza de margherita com mussarela e manjericão', 25.00, 'pizza-margherita.jpg', 30, now(), 2)");

            mb.Sql("INSERT INTO Produtos (Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId)  VALUES ('Chocolate Branco', 'Barra de chocolate branco LAKTA', 5.50, 'chocolatebranco-lakta.jpg', 20, now(), 3)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Produtos");
        }
    }
}
