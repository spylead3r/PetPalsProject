using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PetPals.Data.Migrations
{
    /// <inheritdoc />
    public partial class PetSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
