using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyTodo.Migrations
{
    public partial class ChangeDateFieldToExpire : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Todos",
                newName: "UpdatedAt");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Todos",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Todos",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Expire",
                table: "Todos",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Todos");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Todos");

            migrationBuilder.DropColumn(
                name: "Expire",
                table: "Todos");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Todos",
                newName: "Date");
        }
    }
}
