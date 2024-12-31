using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceProject.Data.Migrations
{
    public partial class sadasd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "bd1e463b-a365-45d5-b7b9-6539aa2d081a", null, "User", "USER" },
                    { "c8460c75-e567-4f35-bfca-d5557445d345", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b1c0c79d-c00b-4cb8-a2fb-88a712e7db86", 0, "d3874b1f-9806-4a5f-98f0-b917f1e67112", new DateTime(2024, 12, 31, 2, 4, 38, 452, DateTimeKind.Utc).AddTicks(5809), "UserAccount", "admin@gmail.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEIXDWqHblcSJK4JFJ3SBpJMOQQSw1bOZfMhHTgna7EN5I1MHDHEFexHTIgRBlMPm/Q==", null, false, "c65dc7e4-5662-417b-911c-b3b95b944de0", false, "Admin" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "Description", "ModifiedDate", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { new Guid("4165da1e-8199-49ed-9e52-a35444bfbaeb"), new Guid("6f1392c0-bf53-4e79-b20f-d019f0c257ad"), new DateTime(2024, 12, 30, 23, 4, 38, 632, DateTimeKind.Local).AddTicks(4005), "Powerful laptop for gaming and work", new DateTime(2024, 12, 30, 23, 4, 38, 632, DateTimeKind.Local).AddTicks(4005), "Laptop", 1199.99m, 30 },
                    { new Guid("5c3d96a1-0c3a-4990-bc2c-5c24c59003e7"), new Guid("f97f6d3d-60f3-4886-9cae-e2eb3e5c43c8"), new DateTime(2024, 12, 30, 23, 4, 38, 632, DateTimeKind.Local).AddTicks(4011), "Comfortable cotton T-shirt", new DateTime(2024, 12, 30, 23, 4, 38, 632, DateTimeKind.Local).AddTicks(4011), "T-Shirt", 19.99m, 200 },
                    { new Guid("e0de7dd7-25b6-4666-a65d-cbf85871a411"), new Guid("f97f6d3d-60f3-4886-9cae-e2eb3e5c43c8"), new DateTime(2024, 12, 30, 23, 4, 38, 632, DateTimeKind.Local).AddTicks(4016), "Stylish denim jeans", new DateTime(2024, 12, 30, 23, 4, 38, 632, DateTimeKind.Local).AddTicks(4016), "Jeans", 49.99m, 100 },
                    { new Guid("e75f87a5-c8f5-4658-9ed1-4b0c623eb251"), new Guid("6f1392c0-bf53-4e79-b20f-d019f0c257ad"), new DateTime(2024, 12, 30, 23, 4, 38, 632, DateTimeKind.Local).AddTicks(3945), "High-end smartphone with OLED display", new DateTime(2024, 12, 30, 23, 4, 38, 632, DateTimeKind.Local).AddTicks(3962), "Smartphone", 699.99m, 50 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd1e463b-a365-45d5-b7b9-6539aa2d081a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c8460c75-e567-4f35-bfca-d5557445d345");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b1c0c79d-c00b-4cb8-a2fb-88a712e7db86");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4165da1e-8199-49ed-9e52-a35444bfbaeb"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5c3d96a1-0c3a-4990-bc2c-5c24c59003e7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e0de7dd7-25b6-4666-a65d-cbf85871a411"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e75f87a5-c8f5-4658-9ed1-4b0c623eb251"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "752fcda7-3e6c-42af-b67f-b5520fdb63e0", null, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7aa1d6da-0992-49a9-91af-7d1512c6ffa7", null, "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e6e4f163-3441-4ee0-b490-4389c23d4fee", 0, "a37a427c-8dd9-48a6-a761-a21077abbd15", new DateTime(2024, 12, 31, 0, 31, 13, 791, DateTimeKind.Utc).AddTicks(4582), "UserAccount", "admin@gmail.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEJ5L82+WaOdAzKO6xyCfVLjramixF46q0VYi5UhYq6vZMPlnzIKDlImlYmRRFVQF7A==", null, false, "17dc1102-61d9-4a90-95a1-4ed91c1b2dc9", false, "Admin" });
        }
    }
}
