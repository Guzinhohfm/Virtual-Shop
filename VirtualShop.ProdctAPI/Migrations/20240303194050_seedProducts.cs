using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VirtualShop.ProductAPI.Migrations
{
    /// <inheritdoc />
    public partial class seedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Products(Name, Price, Description, Stock, ImageURL, CategoryId)" +
                "Values('Caderno', 7.55, 'Caderno', 10, 'caderno.jpg', 1)");

            mb.Sql("Insert into Products(Name, Price, Description, Stock, ImageURL, CategoryId)" +
               "Values('Lápis', 1.55, 'Lápis', 30, 'lapis.jpg', 1)");

            mb.Sql("Insert into Products(Name, Price, Description, Stock, ImageURL, CategoryId)" +
               "Values('Relógio', 99.99, 'Relógio', 5, 'relogio.jpg', 2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Products");
        }
    }
}
