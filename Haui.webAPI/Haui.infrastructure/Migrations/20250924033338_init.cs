using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Haui.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileData = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateNy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateNy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateNy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateNy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSkill",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSkill", x => new { x.UserId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_UserSkill_Skill_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSkill_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreateDate", "CreateNy", "RoleName", "UpdateBy", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("64c68fc8-7974-4622-b042-e1c3b58ecb43"), new DateTime(2025, 9, 24, 10, 33, 36, 934, DateTimeKind.Local).AddTicks(8199), new Guid("00000000-0000-0000-0000-000000000000"), "User", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 9, 24, 10, 33, 36, 934, DateTimeKind.Local).AddTicks(8199) },
                    { new Guid("a5e36cff-9698-4a1c-a8ac-b3e8b0dc25f0"), new DateTime(2025, 9, 24, 10, 33, 36, 934, DateTimeKind.Local).AddTicks(8184), new Guid("00000000-0000-0000-0000-000000000000"), "Admin", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 9, 24, 10, 33, 36, 934, DateTimeKind.Local).AddTicks(8197) }
                });

            migrationBuilder.InsertData(
                table: "Skill",
                columns: new[] { "Id", "CreateDate", "CreateNy", "Name", "UpdateBy", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("327afb34-6df6-4297-b00b-adb37832af14"), new DateTime(2025, 9, 24, 10, 33, 36, 934, DateTimeKind.Local).AddTicks(8283), new Guid("00000000-0000-0000-0000-000000000000"), "SQL", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 9, 24, 10, 33, 36, 934, DateTimeKind.Local).AddTicks(8284) },
                    { new Guid("88e2fb0f-d378-4fec-b84d-6bce7ecb8ef7"), new DateTime(2025, 9, 24, 10, 33, 36, 934, DateTimeKind.Local).AddTicks(8285), new Guid("00000000-0000-0000-0000-000000000000"), "C#", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 9, 24, 10, 33, 36, 934, DateTimeKind.Local).AddTicks(8286) }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreateDate", "CreateNy", "DateOfBirth", "Email", "FullName", "RoleId", "UpdateBy", "UpdateDate" },
                values: new object[] { new Guid("10ab4b78-bcc3-491a-97a9-5fa136a3f41b"), new DateTime(2025, 9, 24, 10, 33, 36, 934, DateTimeKind.Local).AddTicks(8303), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 9, 24, 10, 33, 36, 934, DateTimeKind.Local).AddTicks(8302), " ngoc@gmail.com", "Nguyen Bao Ngoc", new Guid("a5e36cff-9698-4a1c-a8ac-b3e8b0dc25f0"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 9, 24, 10, 33, 36, 934, DateTimeKind.Local).AddTicks(8303) });

            migrationBuilder.InsertData(
                table: "UserSkill",
                columns: new[] { "SkillId", "UserId" },
                values: new object[,]
                {
                    { new Guid("327afb34-6df6-4297-b00b-adb37832af14"), new Guid("10ab4b78-bcc3-491a-97a9-5fa136a3f41b") },
                    { new Guid("88e2fb0f-d378-4fec-b84d-6bce7ecb8ef7"), new Guid("10ab4b78-bcc3-491a-97a9-5fa136a3f41b") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId",
                table: "User",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSkill_SkillId",
                table: "UserSkill",
                column: "SkillId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "UserSkill");

            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
