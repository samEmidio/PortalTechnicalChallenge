using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalTechnicalChallenge.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "technical_challenge_user",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(255)", nullable: false),
                    last_name = table.Column<string>(type: "varchar(255)", nullable: false),
                    age = table.Column<int>(type: "integer", nullable: false),
                    email = table.Column<string>(type: "varchar(255)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    updated_at = table.Column<DateTime>(type: "date", nullable: true),
                    updated_by = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Identifier = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_technical_challenge_user", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "technical_challenge_user");
        }
    }
}
