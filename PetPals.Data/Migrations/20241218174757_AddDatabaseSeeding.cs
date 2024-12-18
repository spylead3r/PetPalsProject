using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PetPals.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDatabaseSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "Id", "AdoptionFee", "AdoptionStatus", "Age", "Breed", "HealthStatus", "Name", "Species" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), 250.00m, "Available", 3, "Golden Retriever", "Healthy", "Buddy", "Dog" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), 150.00m, "Available", 4, "Siamese", "Healthy", "Bella", "Cat" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), 180.00m, "Available", 5, "Beagle", "Healthy", "Charlie", "Dog" },
                    { new Guid("44444444-4444-4444-4444-444444444444"), 200.00m, "Available", 3, "Maine Coon", "Healthy", "Luna", "Cat" },
                    { new Guid("55555555-5555-5555-5555-555555555555"), 220.00m, "Adopted", 4, "Bulldog", "Healthy", "Rocky", "Dog" },
                    { new Guid("66666666-6666-6666-6666-666666666666"), 180.00m, "Available", 2, "Persian", "Healthy", "Molly", "Cat" },
                    { new Guid("77777777-7777-7777-7777-777777777777"), 230.00m, "Available", 5, "Bengal", "Healthy", "Simba", "Cat" },
                    { new Guid("88888888-8888-8888-8888-888888888888"), 270.00m, "Available", 2, "Husky", "Healthy", "Jake", "Dog" }
                });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new[] { "Id", "PetId", "PhotoPath" },
                values: new object[,]
                {
                    { new Guid("05e9dc2f-0345-47b7-b26a-6be3ad60d657"), new Guid("44444444-4444-4444-4444-444444444444"), "uploads/luna1.jpg" },
                    { new Guid("0eafb057-4454-4f26-bd43-86d263364f95"), new Guid("11111111-1111-1111-1111-111111111111"), "uploads/buddy2.jpg" },
                    { new Guid("1c1eaa4c-dc4c-4ccc-a9ef-1e9fa3b2aee8"), new Guid("33333333-3333-3333-3333-333333333333"), "uploads/charlie3.jpg" },
                    { new Guid("3e0adb83-cb72-46c5-b7e0-9c0dedd6f47b"), new Guid("11111111-1111-1111-1111-111111111111"), "uploads/buddy1.jpg" },
                    { new Guid("40a2ebc5-d690-41f5-96eb-982ac74b16a7"), new Guid("44444444-4444-4444-4444-444444444444"), "uploads/luna3.jpg" },
                    { new Guid("537517e2-daa3-4721-93dd-bf9e88233269"), new Guid("22222222-2222-2222-2222-222222222222"), "uploads/bella1.jpg" },
                    { new Guid("74cc27e5-22d7-428d-9ef3-97101ad3be6f"), new Guid("33333333-3333-3333-3333-333333333333"), "uploads/charlie1.jpg" },
                    { new Guid("850d7988-97f7-4877-a5f7-52b16cf192e1"), new Guid("22222222-2222-2222-2222-222222222222"), "uploads/bella3.jpg" },
                    { new Guid("d5846e09-b10a-48f5-8050-2e02726f7de9"), new Guid("44444444-4444-4444-4444-444444444444"), "uploads/luna2.jpg" },
                    { new Guid("d64d401f-fd5d-4c15-aa22-5d384c1457b6"), new Guid("33333333-3333-3333-3333-333333333333"), "uploads/charlie2.jpg" },
                    { new Guid("d68aa46b-3249-4642-9fd0-de5789c5b14f"), new Guid("22222222-2222-2222-2222-222222222222"), "uploads/bella2.jpg" },
                    { new Guid("fb9b1eb8-0f4e-4acf-9f1c-00385c4fc8e7"), new Guid("11111111-1111-1111-1111-111111111111"), "uploads/buddy3.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"));

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666666"));

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777777"));

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"));

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("05e9dc2f-0345-47b7-b26a-6be3ad60d657"));

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("0eafb057-4454-4f26-bd43-86d263364f95"));

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("1c1eaa4c-dc4c-4ccc-a9ef-1e9fa3b2aee8"));

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("3e0adb83-cb72-46c5-b7e0-9c0dedd6f47b"));

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("40a2ebc5-d690-41f5-96eb-982ac74b16a7"));

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("537517e2-daa3-4721-93dd-bf9e88233269"));

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("74cc27e5-22d7-428d-9ef3-97101ad3be6f"));

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("850d7988-97f7-4877-a5f7-52b16cf192e1"));

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("d5846e09-b10a-48f5-8050-2e02726f7de9"));

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("d64d401f-fd5d-4c15-aa22-5d384c1457b6"));

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("d68aa46b-3249-4642-9fd0-de5789c5b14f"));

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("fb9b1eb8-0f4e-4acf-9f1c-00385c4fc8e7"));

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"));

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
        }
    }
}
