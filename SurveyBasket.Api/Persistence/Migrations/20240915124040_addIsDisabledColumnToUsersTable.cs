﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SurveyBasket.Api.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addIsDisabledColumnToUsersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDisabled",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "79CF1F77-B459-4FB4-9244-DF21652FB7C3",
                columns: new[] { "IsDisabled", "PasswordHash" },
                values: new object[] { false, "AQAAAAIAAYagAAAAEBOn6fJxrgXKXSmaKZZlBAb6lwU1BUWAQHDYneIah1MHb1NHnit/moRXgpobkNKEhQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDisabled",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "79CF1F77-B459-4FB4-9244-DF21652FB7C3",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEP+IlSjS7wWHjRI01rrlTLI30SFsZu6hV54Ecs4nQkMVNVAY/J6xQHY03Q1WhfH/gg==");
        }
    }
}
