using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Suprema.Comum.Infra.Migrations
{
    /// <inheritdoc />
    public partial class inicioajuste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tb_Suprema_PokerTable_Tb_Suprema_User_WinnerId",
                table: "Tb_Suprema_PokerTable");

            migrationBuilder.DropIndex(
                name: "IX_Tb_Suprema_PokerTable_WinnerId",
                table: "Tb_Suprema_PokerTable");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Tb_Suprema_PokerTable_WinnerId",
                table: "Tb_Suprema_PokerTable",
                column: "WinnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_Suprema_PokerTable_Tb_Suprema_User_WinnerId",
                table: "Tb_Suprema_PokerTable",
                column: "WinnerId",
                principalTable: "Tb_Suprema_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
