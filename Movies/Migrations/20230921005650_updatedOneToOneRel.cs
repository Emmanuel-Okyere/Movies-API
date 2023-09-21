using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Movies.Migrations
{
    /// <inheritdoc />
    public partial class updatedOneToOneRel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ticket_movieshow_MovieShowId",
                table: "ticket");

            migrationBuilder.DropIndex(
                name: "IX_ticket_MovieShowId",
                table: "ticket");

            migrationBuilder.DropColumn(
                name: "MovieShowId",
                table: "ticket");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ticket",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_ticket_movieshow_Id",
                table: "ticket",
                column: "Id",
                principalTable: "movieshow",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ticket_movieshow_Id",
                table: "ticket");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ticket",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "MovieShowId",
                table: "ticket",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ticket_MovieShowId",
                table: "ticket",
                column: "MovieShowId");

            migrationBuilder.AddForeignKey(
                name: "FK_ticket_movieshow_MovieShowId",
                table: "ticket",
                column: "MovieShowId",
                principalTable: "movieshow",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
