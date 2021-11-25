using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraDeVeiculos.Infra.ORM.Migrations
{
    public partial class vai : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TBLocacoes_IdCondutor",
                table: "TBLocacoes");

            migrationBuilder.AddColumn<int>(
                name: "LocacaoId",
                table: "TBClientesCPF",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TBLocacoes_IdCondutor",
                table: "TBLocacoes",
                column: "IdCondutor");

            migrationBuilder.CreateIndex(
                name: "IX_TBClientesCPF_LocacaoId",
                table: "TBClientesCPF",
                column: "LocacaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_TBClientesCPF_TBLocacoes_LocacaoId",
                table: "TBClientesCPF",
                column: "LocacaoId",
                principalTable: "TBLocacoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBClientesCPF_TBLocacoes_LocacaoId",
                table: "TBClientesCPF");

            migrationBuilder.DropIndex(
                name: "IX_TBLocacoes_IdCondutor",
                table: "TBLocacoes");

            migrationBuilder.DropIndex(
                name: "IX_TBClientesCPF_LocacaoId",
                table: "TBClientesCPF");

            migrationBuilder.DropColumn(
                name: "LocacaoId",
                table: "TBClientesCPF");

            migrationBuilder.CreateIndex(
                name: "IX_TBLocacoes_IdCondutor",
                table: "TBLocacoes",
                column: "IdCondutor",
                unique: true,
                filter: "[IdCondutor] IS NOT NULL");
        }
    }
}
