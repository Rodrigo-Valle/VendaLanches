﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendaLanches.Migrations
{
    public partial class PopularCategoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categorias(CategoriaNome, Descricao) " + 
                " Values('Normal', 'Lanche feito com ingredientes normais')");
            migrationBuilder.Sql("INSERT INTO Categorias(CategoriaNome, Descricao) " + 
                " Values('Natural', 'Lanche feito com ingredientes naturais/integrais')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categorias");
        }
    }
}
