using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VirtualShop.ProductAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChangeColumnName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Categories",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
              name: "IX_Products_CategoryId",
              table: "Products",
              newName: "IX_Products_CategoryId");

            migrationBuilder.AddPrimaryKey(
               name: "PK_Categories",
               table: "Categories",
               column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);


        }

      
    }

}
