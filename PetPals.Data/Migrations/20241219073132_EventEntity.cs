using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PetPals.Data.Migrations
{
    /// <inheritdoc />
    public partial class EventEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Volunteers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Volunteers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Volunteers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Volunteers_EventId",
                table: "Volunteers",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Volunteers_Events_EventId",
                table: "Volunteers",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Volunteers_Events_EventId",
                table: "Volunteers");

            migrationBuilder.DropIndex(
                name: "IX_Volunteers_EventId",
                table: "Volunteers");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Volunteers");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Volunteers");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Volunteers");

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
    }
}
