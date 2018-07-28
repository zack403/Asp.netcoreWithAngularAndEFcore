using Microsoft.EntityFrameworkCore.Migrations;

namespace zaap.Migrations
{
    public partial class ModelToModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Model_Makes_MakeId",
                schema: "Models",
                table: "Model");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Model",
                schema: "Models",
                table: "Model");

            migrationBuilder.RenameTable(
                name: "Model",
                schema: "Models",
                newName: "Models");

            migrationBuilder.RenameIndex(
                name: "IX_Model_MakeId",
                table: "Models",
                newName: "IX_Models_MakeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Models",
                table: "Models",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Models_Makes_MakeId",
                table: "Models",
                column: "MakeId",
                principalTable: "Makes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Models_Makes_MakeId",
                table: "Models");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Models",
                table: "Models");

            migrationBuilder.EnsureSchema(
                name: "Models");

            migrationBuilder.RenameTable(
                name: "Models",
                newName: "Model",
                newSchema: "Models");

            migrationBuilder.RenameIndex(
                name: "IX_Models_MakeId",
                schema: "Models",
                table: "Model",
                newName: "IX_Model_MakeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Model",
                schema: "Models",
                table: "Model",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Model_Makes_MakeId",
                schema: "Models",
                table: "Model",
                column: "MakeId",
                principalTable: "Makes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
