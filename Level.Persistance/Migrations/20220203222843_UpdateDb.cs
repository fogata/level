using Microsoft.EntityFrameworkCore.Migrations;

namespace Level.Persistance.Migrations
{
    public partial class UpdateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Article_Cart_cartid",
                table: "Article");

            migrationBuilder.DropIndex(
                name: "IX_Article_cartid",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "cartid",
                table: "Article");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Article",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ArticleItem",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cartId = table.Column<int>(type: "int", nullable: false),
                    articleId = table.Column<int>(type: "int", nullable: false),
                    articlesid = table.Column<int>(type: "int", nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    discountType = table.Column<string>(type: "varchar(50)", nullable: true),
                    discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleItem", x => x.id);
                    table.ForeignKey(
                        name: "FK_ArticleItem_Article_articlesid",
                        column: x => x.articlesid,
                        principalTable: "Article",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArticleItem_Cart_cartId",
                        column: x => x.cartId,
                        principalTable: "Cart",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleItem_articlesid",
                table: "ArticleItem",
                column: "articlesid");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleItem_cartId",
                table: "ArticleItem",
                column: "cartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleItem");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Article",
                type: "varchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AddColumn<int>(
                name: "cartid",
                table: "Article",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Article_cartid",
                table: "Article",
                column: "cartid");

            migrationBuilder.AddForeignKey(
                name: "FK_Article_Cart_cartid",
                table: "Article",
                column: "cartid",
                principalTable: "Cart",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
