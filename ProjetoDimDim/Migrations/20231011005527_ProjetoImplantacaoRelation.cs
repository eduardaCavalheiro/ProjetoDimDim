using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoDimDim.Migrations
{
    /// <inheritdoc />
    public partial class ProjetoImplantacaoRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Implantacoes",
                columns: table => new
                {
                    ImplantacaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusImplantacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VersaoDocker = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServicoNuvem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjetoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Implantacoes", x => x.ImplantacaoId);
                    table.ForeignKey(
                        name: "FK_Implantacoes_Projetos_ProjetoId",
                        column: x => x.ProjetoId,
                        principalTable: "Projetos",
                        principalColumn: "ProjetoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Implantacoes_ProjetoId",
                table: "Implantacoes",
                column: "ProjetoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Implantacoes");
        }
    }
}
