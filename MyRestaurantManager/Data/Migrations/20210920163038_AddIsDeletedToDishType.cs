using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyRestaurantManager.Migrations
{
    public partial class AddIsDeletedToDishType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "DishTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "DishTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "DishTypes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "DishTypes");
        }
    }
}
