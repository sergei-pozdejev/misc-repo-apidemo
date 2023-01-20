using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductApiDemo.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Code", "ExpirationDate", "Name" },
                values: new object[,]
                {
                    { new Guid("0b1a02c2-0c71-49b3-a374-0b0745af2ffc"), "CB12", new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cereal" },
                    { new Guid("24529d6e-e0ea-4d52-8c27-fb8b9e003cba"), "CB15", new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Strawberry cookies" },
                    { new Guid("2a02dd05-604f-41c0-8be2-9a0251575523"), "CB11", new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chocolade" },
                    { new Guid("357380fe-9f42-43ab-89d9-6d92bfab1a30"), "DB13", new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Limonade" },
                    { new Guid("4adb3e6e-55bc-4cd8-aaa5-6f3ef7b3f730"), "BB11", new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pineapple" },
                    { new Guid("7025c81b-e44d-4a78-bf6f-914414946a68"), "AB11", new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Banana chips" },
                    { new Guid("777a2917-65ae-47c6-a62d-df53eabbfd2b"), "BB12", new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lime" },
                    { new Guid("79b37c8a-250d-42b3-876f-bc0accbc83fc"), "EB12", new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Strawberry icecream" },
                    { new Guid("94346c0a-a803-4e27-8749-6ad547cb3978"), "AB13", new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Potato chips" },
                    { new Guid("9533ec53-0d6a-4264-8034-bb62f11df282"), "DB11", new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Water" },
                    { new Guid("a58c5b46-3ea5-41d6-8467-10dca04ab0fa"), "BB14", new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Banana" },
                    { new Guid("adbfdf00-315e-4d2f-9d9f-608d336e46a5"), "DB12", new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sparkling water" },
                    { new Guid("ade84630-c3d3-462d-a958-c5592916ef76"), "AB12", new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Apple chips" },
                    { new Guid("b462e0cb-c45c-4956-95ea-9252a234c835"), "EB13", new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chocolate icecream" },
                    { new Guid("bd61b7dc-e4af-4940-a468-5fcd9093ae10"), "CB14", new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chocolade cookies" },
                    { new Guid("e3f3a6da-60db-4818-8e3c-af1787762224"), "BB13", new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Apple" },
                    { new Guid("e477ccc0-6286-43f9-a9fc-5e9486a6a93d"), "EB14", new DateTime(2022, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pineapple icecream" },
                    { new Guid("e8fa1755-5c55-41ae-a822-5a0bad0fe65f"), "EB11", new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vanilla icecream" },
                    { new Guid("f9becdc8-a694-48cd-8245-19e254fb049b"), "CB13", new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vanilla cookies" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_Code",
                table: "Products",
                column: "Code",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
