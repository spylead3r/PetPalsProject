using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PetPals.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPhotosEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: new Guid("06bb9a1e-180d-480d-b7c0-4e8020521510"));

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: new Guid("1235edff-3456-4e3c-86f9-0b99481bc502"));

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: new Guid("1420c561-d68d-43e1-90c3-d73c5d962971"));

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: new Guid("2186355c-fb91-437e-b798-c15f8bf66748"));

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: new Guid("2c21e949-f40f-4d42-aafe-10539341a995"));

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: new Guid("33efd25e-112e-4b3f-b2e6-ae4b6343af6c"));

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: new Guid("5580c0f2-2405-4abf-9745-692cd086421b"));

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: new Guid("5c89dd6a-5952-4abd-9dc9-27f759d10d6b"));

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: new Guid("7df4f163-4b37-457d-808f-964d081d1e64"));

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: new Guid("8b48ef82-6814-41a9-962b-fdbd7e03714f"));

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: new Guid("932d5ddb-dde0-4e4c-95a4-1a027e0148a5"));

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: new Guid("c117ba2c-0e9f-4481-9caa-74ab3e37e47a"));

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: new Guid("c1e11fbb-f38d-4049-b84e-ced7dd660cfe"));

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: new Guid("ca850304-12e0-4e5f-81ad-0012aa8b9037"));

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: new Guid("d3c6a9d4-9721-4445-bd43-5bccbeb03d52"));

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: new Guid("e2a74697-ff59-4ec5-be88-0debb048198a"));

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: new Guid("e4ed0808-e497-48e6-b20a-374eb4dc1af6"));

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: new Guid("ea5bca3f-322a-4ae2-aa84-846aa5aabf7d"));

            migrationBuilder.DropColumn(
                name: "PhotoPath",
                table: "Pets");

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "Id", "AdoptionFee", "AdoptionStatus", "Age", "Breed", "HealthStatus", "Name", "Species" },
                values: new object[,]
                {
                    { new Guid("10e7c9b2-4dd0-4b53-9313-473208328f7e"), 230.00m, "Available", 5, "Bengal", "Healthy", "Simba", "Cat" },
                    { new Guid("2d6c3eb8-dd6a-470d-94cf-547a6a730e18"), 260.00m, "Available", 3, "German Shepherd", "Healthy", "Oscar", "Dog" },
                    { new Guid("3f21410c-4e18-436c-a490-311f6f30600e"), 210.00m, "Available", 4, "Ragdoll", "Healthy", "Oliver", "Cat" },
                    { new Guid("44ec9bb6-55e1-40eb-bcfe-a42d439d5676"), 250.00m, "Available", 3, "Poodle", "Healthy", "Daisy", "Dog" },
                    { new Guid("4b123c7e-3870-4b69-aea7-0ca6af068345"), 190.00m, "Adopted", 2, "Corgi", "Healthy", "Cooper", "Dog" },
                    { new Guid("518ef4ad-72ab-47b1-8d65-0e0bd3f573a8"), 200.00m, "Available", 2, "Labrador", "Healthy", "Max", "Dog" },
                    { new Guid("6ce3ea28-4664-414e-9dc8-72a3e886deba"), 240.00m, "Available", 4, "Dachshund", "Healthy", "Ruby", "Dog" },
                    { new Guid("6e154231-717e-468e-b9b9-cbbd4da5a3dd"), 270.00m, "Available", 2, "Husky", "Healthy", "Jake", "Dog" },
                    { new Guid("78b2c946-72e9-40e8-93b1-85e0e53c9b92"), 200.00m, "Available", 3, "Maine Coon", "Healthy", "Luna", "Cat" },
                    { new Guid("7ea6e12a-d6c7-4e8a-84c4-bb7488d5fa29"), 150.00m, "Adopted", 4, "Siamese", "Healthy", "Bella", "Cat" },
                    { new Guid("84b0e36a-32d3-4af6-90e6-ebcdf32ca736"), 250.00m, "Available", 3, "Golden Retriever", "Healthy", "Buddy", "Dog" },
                    { new Guid("8b7e7107-2a7b-4ff5-ac51-feef8a26c34b"), 230.00m, "Available", 2, "Boxer", "Healthy", "Zoe", "Dog" },
                    { new Guid("ad0aa1a1-0c19-4dcc-8aa5-087c79931e20"), 220.00m, "Adopted", 3, "Sphynx", "Healthy", "Milo", "Cat" },
                    { new Guid("bdac5c06-634a-48e8-b5d3-f5516aa703c6"), 240.00m, "Available", 5, "Scottish Fold", "Healthy", "Cleo", "Cat" },
                    { new Guid("ea5c1802-3690-4bc0-bc7c-6f6e02c82f6c"), 180.00m, "Adopted", 2, "Persian", "Healthy", "Molly", "Cat" },
                    { new Guid("ef9ac48f-aeb0-43c2-aa98-21f0e21422e0"), 180.00m, "Available", 5, "Beagle", "Healthy", "Charlie", "Dog" },
                    { new Guid("f5c0891f-21df-477d-aa14-499162a5d16c"), 220.00m, "Available", 4, "Bulldog", "Healthy", "Rocky", "Dog" },
                    { new Guid("ff8df123-9050-4d9e-92e8-a72dd2c04589"), 250.00m, "Available", 4, "Abyssinian", "Healthy", "Lilly", "Cat" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Photos_PetId",
                table: "Photos",
                column: "PetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: new Guid("10e7c9b2-4dd0-4b53-9313-473208328f7e"));

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: new Guid("2d6c3eb8-dd6a-470d-94cf-547a6a730e18"));

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: new Guid("3f21410c-4e18-436c-a490-311f6f30600e"));

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: new Guid("44ec9bb6-55e1-40eb-bcfe-a42d439d5676"));

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: new Guid("4b123c7e-3870-4b69-aea7-0ca6af068345"));

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: new Guid("518ef4ad-72ab-47b1-8d65-0e0bd3f573a8"));

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: new Guid("6ce3ea28-4664-414e-9dc8-72a3e886deba"));

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: new Guid("6e154231-717e-468e-b9b9-cbbd4da5a3dd"));

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: new Guid("78b2c946-72e9-40e8-93b1-85e0e53c9b92"));

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: new Guid("7ea6e12a-d6c7-4e8a-84c4-bb7488d5fa29"));

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: new Guid("84b0e36a-32d3-4af6-90e6-ebcdf32ca736"));

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: new Guid("8b7e7107-2a7b-4ff5-ac51-feef8a26c34b"));

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: new Guid("ad0aa1a1-0c19-4dcc-8aa5-087c79931e20"));

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: new Guid("bdac5c06-634a-48e8-b5d3-f5516aa703c6"));

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: new Guid("ea5c1802-3690-4bc0-bc7c-6f6e02c82f6c"));

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: new Guid("ef9ac48f-aeb0-43c2-aa98-21f0e21422e0"));

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: new Guid("f5c0891f-21df-477d-aa14-499162a5d16c"));

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: new Guid("ff8df123-9050-4d9e-92e8-a72dd2c04589"));

            migrationBuilder.AddColumn<string>(
                name: "PhotoPath",
                table: "Pets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "Id", "AdoptionFee", "AdoptionStatus", "Age", "Breed", "HealthStatus", "Name", "PhotoPath", "Species" },
                values: new object[,]
                {
                    { new Guid("06bb9a1e-180d-480d-b7c0-4e8020521510"), 270.00m, "Available", 2, "Husky", "Healthy", "Jake", "https://images.unsplash.com/photo-1570211776045-2c771c36e2e9", "Dog" },
                    { new Guid("1235edff-3456-4e3c-86f9-0b99481bc502"), 240.00m, "Available", 4, "Dachshund", "Healthy", "Ruby", "https://images.unsplash.com/photo-1518717758536-85ae29035b6d", "Dog" },
                    { new Guid("1420c561-d68d-43e1-90c3-d73c5d962971"), 180.00m, "Adopted", 2, "Persian", "Healthy", "Molly", "https://images.unsplash.com/photo-1517423440428-a5a00ad493e8", "Cat" },
                    { new Guid("2186355c-fb91-437e-b798-c15f8bf66748"), 240.00m, "Available", 5, "Scottish Fold", "Healthy", "Cleo", "https://images.unsplash.com/photo-1559235038-1b063ae6fcf6", "Cat" },
                    { new Guid("2c21e949-f40f-4d42-aafe-10539341a995"), 250.00m, "Available", 3, "Golden Retriever", "Healthy", "Buddy", "https://images.unsplash.com/photo-1517849845537-4d257902454a", "Dog" },
                    { new Guid("33efd25e-112e-4b3f-b2e6-ae4b6343af6c"), 150.00m, "Adopted", 4, "Siamese", "Healthy", "Bella", "https://images.unsplash.com/photo-1574158622682-e40e69881006", "Cat" },
                    { new Guid("5580c0f2-2405-4abf-9745-692cd086421b"), 220.00m, "Adopted", 3, "Sphynx", "Healthy", "Milo", "https://images.unsplash.com/photo-1581235720704-dc7318e1c593", "Cat" },
                    { new Guid("5c89dd6a-5952-4abd-9dc9-27f759d10d6b"), 210.00m, "Available", 4, "Ragdoll", "Healthy", "Oliver", "https://images.unsplash.com/photo-1556784344-24eb6fdae062", "Cat" },
                    { new Guid("7df4f163-4b37-457d-808f-964d081d1e64"), 250.00m, "Available", 3, "Poodle", "Healthy", "Daisy", "https://images.unsplash.com/photo-1502673530728-f79b4cab31b1", "Dog" },
                    { new Guid("8b48ef82-6814-41a9-962b-fdbd7e03714f"), 200.00m, "Available", 3, "Maine Coon", "Healthy", "Luna", "https://images.unsplash.com/photo-1560114924-2d5a1c1a0f8d", "Cat" },
                    { new Guid("932d5ddb-dde0-4e4c-95a4-1a027e0148a5"), 250.00m, "Available", 4, "Abyssinian", "Healthy", "Lilly", "https://images.unsplash.com/photo-1592194996308-7b5b5c2f896f", "Cat" },
                    { new Guid("c117ba2c-0e9f-4481-9caa-74ab3e37e47a"), 180.00m, "Available", 5, "Beagle", "Healthy", "Charlie", "https://images.unsplash.com/photo-1558788353-f76d92427f16", "Dog" },
                    { new Guid("c1e11fbb-f38d-4049-b84e-ced7dd660cfe"), 230.00m, "Available", 5, "Bengal", "Healthy", "Simba", "https://images.unsplash.com/photo-1543852786-1cf6624b9987", "Cat" },
                    { new Guid("ca850304-12e0-4e5f-81ad-0012aa8b9037"), 190.00m, "Adopted", 2, "Corgi", "Healthy", "Cooper", "https://images.unsplash.com/photo-1548690590-5b66c99197d2", "Dog" },
                    { new Guid("d3c6a9d4-9721-4445-bd43-5bccbeb03d52"), 230.00m, "Available", 2, "Boxer", "Healthy", "Zoe", "https://images.unsplash.com/photo-1525253086316-d0c936c814f8", "Dog" },
                    { new Guid("e2a74697-ff59-4ec5-be88-0debb048198a"), 260.00m, "Available", 3, "German Shepherd", "Healthy", "Oscar", "https://images.unsplash.com/photo-1583511655857-7b8bd3c22f8f", "Dog" },
                    { new Guid("e4ed0808-e497-48e6-b20a-374eb4dc1af6"), 220.00m, "Available", 4, "Bulldog", "Healthy", "Rocky", "https://images.unsplash.com/photo-1560807707-8cc77767d783", "Dog" },
                    { new Guid("ea5bca3f-322a-4ae2-aa84-846aa5aabf7d"), 200.00m, "Available", 2, "Labrador", "Healthy", "Max", "https://images.unsplash.com/photo-1507149833265-60c372daea22", "Dog" }
                });
        }
    }
}
