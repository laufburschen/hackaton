using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class order_and_order_items : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "comment",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "items",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "max_price_per_item",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "product",
                table: "orders");

            migrationBuilder.CreateTable(
                name: "order_items",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    order_id = table.Column<string>(nullable: true),
                    product = table.Column<string>(nullable: true),
                    items = table.Column<int>(nullable: false),
                    max_price_per_item = table.Column<float>(nullable: false),
                    comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_items", x => x.id);
                    table.ForeignKey(
                        name: "FK_order_items_orders_order_id",
                        column: x => x.order_id,
                        principalTable: "orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_order_items_order_id",
                table: "order_items",
                column: "order_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "order_items");

            migrationBuilder.AddColumn<string>(
                name: "comment",
                table: "orders",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "items",
                table: "orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "max_price_per_item",
                table: "orders",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "product",
                table: "orders",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
