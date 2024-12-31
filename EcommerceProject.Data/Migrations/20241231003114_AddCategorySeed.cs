using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceProject.Data.Migrations
{
    public partial class AddCategorySeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1307c130-7655-4541-88b5-3440a132fb1e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29c60197-ffad-406f-b26e-d81c23472605");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9f608dc3-e45c-4b17-909f-f57538737a31");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "752fcda7-3e6c-42af-b67f-b5520fdb63e0", null, "Admin", "ADMIN" },
                    { "7aa1d6da-0992-49a9-91af-7d1512c6ffa7", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e6e4f163-3441-4ee0-b490-4389c23d4fee", 0, "a37a427c-8dd9-48a6-a761-a21077abbd15", new DateTime(2024, 12, 31, 0, 31, 13, 791, DateTimeKind.Utc).AddTicks(4582), "UserAccount", "admin@gmail.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEJ5L82+WaOdAzKO6xyCfVLjramixF46q0VYi5UhYq6vZMPlnzIKDlImlYmRRFVQF7A==", null, false, "17dc1102-61d9-4a90-95a1-4ed91c1b2dc9", false, "Admin" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("6f1392c0-bf53-4e79-b20f-d019f0c257ad"), "Electronics category", "Electronics" },
                    { new Guid("f97f6d3d-60f3-4886-9cae-e2eb3e5c43c8"), "Clothing category", "Clothing" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "752fcda7-3e6c-42af-b67f-b5520fdb63e0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7aa1d6da-0992-49a9-91af-7d1512c6ffa7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e6e4f163-3441-4ee0-b490-4389c23d4fee");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6f1392c0-bf53-4e79-b20f-d019f0c257ad"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f97f6d3d-60f3-4886-9cae-e2eb3e5c43c8"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1307c130-7655-4541-88b5-3440a132fb1e", null, "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "29c60197-ffad-406f-b26e-d81c23472605", null, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9f608dc3-e45c-4b17-909f-f57538737a31", 0, "784a5a59-da86-42f9-b60e-c4c4b7eae396", new DateTime(2024, 12, 28, 2, 4, 27, 828, DateTimeKind.Utc).AddTicks(5837), "UserAccount", "admin@gmail.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEKZMhe6Egflg5NfM4cVdHhnCFShX6lQnDZ2JbD/tXAr7dgK+lPJk8ILJwQqYciDphw==", null, false, "fde552bd-4d3b-463d-a434-4a833f245f65", false, "Admin" });
        }
    }
}
