using Microsoft.EntityFrameworkCore.Migrations;

namespace zaap.Migrations
{
    public partial class ApplyConstraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Model_Makes_MakeId",
                table: "Model");

            migrationBuilder.EnsureSchema(
                name: "Models");

            migrationBuilder.RenameTable(
                name: "Model",
                newName: "Model",
                newSchema: "Models");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Makes",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Models",
                table: "Model",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MakeId",
                schema: "Models",
                table: "Model",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Model_Makes_MakeId",
                schema: "Models",
                table: "Model",
                column: "MakeId",
                principalTable: "Makes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Model_Makes_MakeId",
                schema: "Models",
                table: "Model");

            migrationBuilder.RenameTable(
                name: "Model",
                schema: "Models",
                newName: "Model");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Makes",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Model",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<int>(
                name: "MakeId",
                table: "Model",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Model_Makes_MakeId",
                table: "Model",
                column: "MakeId",
                principalTable: "Makes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
