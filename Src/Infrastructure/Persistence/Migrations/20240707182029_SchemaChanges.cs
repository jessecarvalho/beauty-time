using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SchemaChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Clients_ClientId",
                table: "Appointments");

            migrationBuilder.DropTable(
                name: "ClientEstablishment");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Appointments",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_ClientId",
                table: "Appointments",
                newName: "IX_Appointments_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Users_UserId",
                table: "Appointments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Users_UserId",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Appointments",
                newName: "ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_UserId",
                table: "Appointments",
                newName: "IX_Appointments_ClientId");

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientEstablishment",
                columns: table => new
                {
                    ClientsId = table.Column<int>(type: "integer", nullable: false),
                    EstablishmentsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientEstablishment", x => new { x.ClientsId, x.EstablishmentsId });
                    table.ForeignKey(
                        name: "FK_ClientEstablishment_Clients_ClientsId",
                        column: x => x.ClientsId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientEstablishment_Establishments_EstablishmentsId",
                        column: x => x.EstablishmentsId,
                        principalTable: "Establishments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientEstablishment_EstablishmentsId",
                table: "ClientEstablishment",
                column: "EstablishmentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_UserId",
                table: "Clients",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Clients_ClientId",
                table: "Appointments",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
