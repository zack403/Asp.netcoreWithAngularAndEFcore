using Microsoft.EntityFrameworkCore.Migrations;

namespace zaap.Migrations
{
    public partial class SeedFeatures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Feautures (Name) VALUES ('Feature1')");
            migrationBuilder.Sql("INSERT INTO Feautures (Name) VALUES ('Feature2')");
            migrationBuilder.Sql("INSERT INTO Feautures (Name) VALUES ('Feature3')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Feautures WHERE Name IN ('Feature1', 'Feature2', 'Feature3')");

        }
    }
}
