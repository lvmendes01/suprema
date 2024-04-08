using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Suprema.Comum.Infra.Migrations
{
    /// <inheritdoc />
    public partial class inicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tb_Suprema_User",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cpf = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Username = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataCadastro = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Suprema_User", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tb_Suprema_PokerTable",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WinnerId = table.Column<long>(type: "bigint", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Suprema_PokerTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tb_Suprema_PokerTable_Tb_Suprema_User_WinnerId",
                        column: x => x.WinnerId,
                        principalTable: "Tb_Suprema_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tb_Suprema_PlayerTable",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserEntidadeId = table.Column<long>(type: "bigint", nullable: false),
                    PokerTableEntidadeId = table.Column<long>(type: "bigint", nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Suprema_PlayerTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tb_Suprema_PlayerTable_Tb_Suprema_PokerTable_PokerTableEntid~",
                        column: x => x.PokerTableEntidadeId,
                        principalTable: "Tb_Suprema_PokerTable",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tb_Suprema_PlayerTable_Tb_Suprema_User_UserEntidadeId",
                        column: x => x.UserEntidadeId,
                        principalTable: "Tb_Suprema_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Suprema_PlayerTable_PokerTableEntidadeId",
                table: "Tb_Suprema_PlayerTable",
                column: "PokerTableEntidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Suprema_PlayerTable_UserEntidadeId",
                table: "Tb_Suprema_PlayerTable",
                column: "UserEntidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Suprema_PokerTable_WinnerId",
                table: "Tb_Suprema_PokerTable",
                column: "WinnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tb_Suprema_PlayerTable");

            migrationBuilder.DropTable(
                name: "Tb_Suprema_PokerTable");

            migrationBuilder.DropTable(
                name: "Tb_Suprema_User");
        }
    }
}
