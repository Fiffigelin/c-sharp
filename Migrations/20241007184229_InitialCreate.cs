using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace c_sharp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    HashPassword = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CreatedAt", "Email", "FirstName", "HashPassword", "LastName" },
                values: new object[] { new Guid("f8fc8e02-c7fa-4066-9150-c0989d29964b"), new DateTime(2024, 10, 7, 20, 42, 27, 349, DateTimeKind.Local).AddTicks(9675), "bamse.stark@mail.com", "Bamse", "$2a$11$mMT.tFsQVHaG1DEaVoSRkuwzepTvCJfjv3G5//mLs7DKiCIpLf6RS", "Stark" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
