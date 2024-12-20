using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetPals.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedApplicationUserPetEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserPet_AspNetUsers_ApplicationUserId",
                table: "ApplicationUserPet");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserPet_Pets_PetId",
                table: "ApplicationUserPet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUserPet",
                table: "ApplicationUserPet");

            migrationBuilder.RenameTable(
                name: "ApplicationUserPet",
                newName: "ApplicationUserPets");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUserPet_PetId",
                table: "ApplicationUserPets",
                newName: "IX_ApplicationUserPets_PetId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUserPets",
                table: "ApplicationUserPets",
                columns: new[] { "ApplicationUserId", "PetId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserPets_AspNetUsers_ApplicationUserId",
                table: "ApplicationUserPets",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserPets_Pets_PetId",
                table: "ApplicationUserPets",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserPets_AspNetUsers_ApplicationUserId",
                table: "ApplicationUserPets");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserPets_Pets_PetId",
                table: "ApplicationUserPets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUserPets",
                table: "ApplicationUserPets");

            migrationBuilder.RenameTable(
                name: "ApplicationUserPets",
                newName: "ApplicationUserPet");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUserPets_PetId",
                table: "ApplicationUserPet",
                newName: "IX_ApplicationUserPet_PetId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUserPet",
                table: "ApplicationUserPet",
                columns: new[] { "ApplicationUserId", "PetId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserPet_AspNetUsers_ApplicationUserId",
                table: "ApplicationUserPet",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserPet_Pets_PetId",
                table: "ApplicationUserPet",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
