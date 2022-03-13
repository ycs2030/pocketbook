using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bulkybook.Migrations
{
    public partial class l : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_Categoy_CategoyId",
                table: "products");

            migrationBuilder.RenameColumn(
                name: "CategoyId",
                table: "products",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_products_CategoyId",
                table: "products",
                newName: "IX_products_CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_products_Categoy_CategoryId",
                table: "products",
                column: "CategoryId",
                principalTable: "Categoy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_Categoy_CategoryId",
                table: "products");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "products",
                newName: "CategoyId");

            migrationBuilder.RenameIndex(
                name: "IX_products_CategoryId",
                table: "products",
                newName: "IX_products_CategoyId");

            migrationBuilder.AddForeignKey(
                name: "FK_products_Categoy_CategoyId",
                table: "products",
                column: "CategoyId",
                principalTable: "Categoy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
