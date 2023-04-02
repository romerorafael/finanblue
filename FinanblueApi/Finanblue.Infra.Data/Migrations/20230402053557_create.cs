using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Finanblue.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'1', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Cnpj = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Activity = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "purchase",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'1', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CompanyId = table.Column<int>(type: "integer", nullable: false),
                    Total = table.Column<decimal>(type: "numeric(15,2)", precision: 15, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_purchase", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'1', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Price = table.Column<decimal>(type: "numeric(15,2)", precision: 15, scale: 2, nullable: false),
                    PurchaseId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_product_purchase_PurchaseId",
                        column: x => x.PurchaseId,
                        principalTable: "purchase",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "productspurchase",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'1', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    PurchaseId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productspurchase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_productspurchase_product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_productspurchase_purchase_PurchaseId",
                        column: x => x.PurchaseId,
                        principalTable: "purchase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "company",
                columns: new[] { "Id", "Activity", "Cnpj", "Name" },
                values: new object[,]
                {
                    { 1, "Jogos e derivados", "44788866/0001-9", "Niantic" },
                    { 2, "Jogos e derivados", "55877733/0001-9", "Blizzard" }
                });

            migrationBuilder.InsertData(
                table: "product",
                columns: new[] { "Id", "Description", "Name", "Price", "PurchaseId" },
                values: new object[,]
                {
                    { 1, "Uma caneta bic preta", "Caneta Preta", 1.5m, null },
                    { 2, "Uma caneta bic azul", "Caneta Azul", 1.5m, null },
                    { 3, "Uma borracha do Ben10", "Borracha Ben10", 3.5m, null },
                    { 4, "Lapiz do Pokemon", "Lapiz Pokemon", 0.55m, null }
                });

            migrationBuilder.InsertData(
                table: "purchase",
                columns: new[] { "Id", "CompanyId", "Total" },
                values: new object[] { 1, 1, 1.1m });

            migrationBuilder.InsertData(
                table: "productspurchase",
                columns: new[] { "Id", "ProductId", "PurchaseId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_product_PurchaseId",
                table: "product",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_productspurchase_ProductId",
                table: "productspurchase",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_productspurchase_PurchaseId",
                table: "productspurchase",
                column: "PurchaseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "company");

            migrationBuilder.DropTable(
                name: "productspurchase");

            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "purchase");
        }
    }
}
