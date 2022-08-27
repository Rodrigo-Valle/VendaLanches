using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendaLanches.Migrations
{
    public partial class PopularLanches : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Lanches(Nome, DescricaoCurta, DescricaoLonga, Preco, LanchePreferido, Estoque, CategoriaId) " + 
                " Values('Misto Quente', 'Pão, mussarela e presunto', 'Delicioso pão com mussarela e presunto aquecidos na chapa', 2.50, true, true, 1)");
                migrationBuilder.Sql("INSERT INTO Lanches(Nome, DescricaoCurta, DescricaoLonga, Preco, LanchePreferido, Estoque, CategoriaId) " + 
                " Values('Hamburguer', 'Pão, hambúrguer, maionese e molho', 'Delicioso pão com hambúrguer feito na chapa', 4.00, true, true, 1)");
                migrationBuilder.Sql("INSERT INTO Lanches(Nome, DescricaoCurta, DescricaoLonga, Preco, LanchePreferido, Estoque, CategoriaId) " + 
                " Values('Coxinha Vegana', 'Feita com ingredientes integrais e naturais', 'Massa feita com farinha integral e recheio de brócolis frita no óleo de coco', 2.50, true, true, 1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Lanches");
        }
    }
}
