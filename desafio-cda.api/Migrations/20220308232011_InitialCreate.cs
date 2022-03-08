using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace desafio_cda.api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "status",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "varchar", nullable: false),
                    createdAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_status", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userName = table.Column<string>(type: "varchar", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    createdAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "criminalCodes",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "varchar", nullable: false),
                    description = table.Column<string>(type: "varchar", nullable: false),
                    penalty = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    prisonTime = table.Column<int>(type: "integer", nullable: false),
                    statusId = table.Column<long>(type: "bigint", nullable: false),
                    createUserId = table.Column<long>(type: "bigint", nullable: false),
                    updateUserId = table.Column<long>(type: "bigint", nullable: false),
                    createdAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_criminalCodes", x => x.id);
                    table.ForeignKey(
                        name: "FK_criminalCodes_status_statusId",
                        column: x => x.statusId,
                        principalTable: "status",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_criminalCodes_users_createUserId",
                        column: x => x.createUserId,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_criminalCodes_users_updateUserId",
                        column: x => x.updateUserId,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_criminalCodes_createUserId",
                table: "criminalCodes",
                column: "createUserId");

            migrationBuilder.CreateIndex(
                name: "IX_criminalCodes_statusId",
                table: "criminalCodes",
                column: "statusId");

            migrationBuilder.CreateIndex(
                name: "IX_criminalCodes_updateUserId",
                table: "criminalCodes",
                column: "updateUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "criminalCodes");

            migrationBuilder.DropTable(
                name: "status");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
