using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportsApp.Migrations
{
    /// <inheritdoc />
    public partial class deleteUnmatchedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Products WHERE ProductCategoryID NOT IN (SELECT ProductCategoryID FROM ProductCategories)");

            migrationBuilder.Sql("DELETE FROM ProductReviews WHERE ProductID NOT IN (SELECT ProductID FROM Products)");

            

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCategoryID",
                table: "Products",
                column: "ProductCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReviews_ProductID",
                table: "ProductReviews",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductReviews_Products_ProductID",
                table: "ProductReviews",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductCategories_ProductCategoryID",
                table: "Products",
                column: "ProductCategoryID",
                principalTable: "ProductCategories",
                principalColumn: "ProductCategoryID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductReviews_Products_ProductID",
                table: "ProductReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductCategories_ProductCategoryID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductCategoryID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_ProductReviews_ProductID",
                table: "ProductReviews");
        }
    }
}
