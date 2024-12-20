using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetPals.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedPetListingEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "PetListings");

            migrationBuilder.DropColumn(
                name: "Breed",
                table: "PetListings");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "PetListings");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "PetListings");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "PetListings");

            migrationBuilder.DropColumn(
                name: "PetName",
                table: "PetListings");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "PetListings");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "PetListings");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "PetListings",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "IsRejected",
                table: "PetListings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "PetId",
                table: "PetListings",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_PetListings_PetId",
                table: "PetListings",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_PetListings_UserId",
                table: "PetListings",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PetListings_AspNetUsers_UserId",
                table: "PetListings",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PetListings_Pets_PetId",
                table: "PetListings",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PetListings_AspNetUsers_UserId",
                table: "PetListings");

            migrationBuilder.DropForeignKey(
                name: "FK_PetListings_Pets_PetId",
                table: "PetListings");

            migrationBuilder.DropIndex(
                name: "IX_PetListings_PetId",
                table: "PetListings");

            migrationBuilder.DropIndex(
                name: "IX_PetListings_UserId",
                table: "PetListings");

            migrationBuilder.DropColumn(
                name: "IsRejected",
                table: "PetListings");

            migrationBuilder.DropColumn(
                name: "PetId",
                table: "PetListings");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "PetListings",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "PetListings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Breed",
                table: "PetListings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "PetListings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "PetListings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "PetListings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PetName",
                table: "PetListings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "PetListings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "PetListings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
