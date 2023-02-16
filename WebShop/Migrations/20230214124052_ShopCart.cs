using Microsoft.EntityFrameworkCore.Migrations;

namespace WebShop.Migrations
{
    public partial class ShopCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
                //name: "FK_ShopCartItem_Car_Carid",
                //table: "ShopCartItem");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "ShopCartItem",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Carid",
                table: "ShopCartItem",
                newName: "carid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ShopCartItem",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ShopCarId",
                table: "ShopCartItem",
                newName: "ShopCartId");

            migrationBuilder.RenameIndex(
                name: "IX_ShopCartItem_Carid",
                table: "ShopCartItem",
                newName: "IX_ShopCartItem_carid");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopCartItem_Car_carid",
                table: "ShopCartItem",
                column: "carid",
                principalTable: "Car",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopCartItem_Car_carid",
                table: "ShopCartItem");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "ShopCartItem",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "carid",
                table: "ShopCartItem",
                newName: "Carid");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ShopCartItem",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ShopCartId",
                table: "ShopCartItem",
                newName: "ShopCarId");

            migrationBuilder.RenameIndex(
                name: "IX_ShopCartItem_carid",
                table: "ShopCartItem",
                newName: "IX_ShopCartItem_Carid");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopCartItem_Car_Carid",
                table: "ShopCartItem",
                column: "Carid",
                principalTable: "Car",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
