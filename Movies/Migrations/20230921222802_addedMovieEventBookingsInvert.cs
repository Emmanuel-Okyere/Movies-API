using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Movies.Migrations
{
    /// <inheritdoc />
    public partial class addedMovieEventBookingsInvert : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_movieeventbooking_movieshow_Id",
                table: "movieeventbooking");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "movieeventbooking",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "MovieShowId",
                table: "movieeventbooking",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_movieeventbooking_MovieShowId",
                table: "movieeventbooking",
                column: "MovieShowId");

            migrationBuilder.AddForeignKey(
                name: "FK_movieeventbooking_movieshow_MovieShowId",
                table: "movieeventbooking",
                column: "MovieShowId",
                principalTable: "movieshow",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_movieeventbooking_movieshow_MovieShowId",
                table: "movieeventbooking");

            migrationBuilder.DropIndex(
                name: "IX_movieeventbooking_MovieShowId",
                table: "movieeventbooking");

            migrationBuilder.DropColumn(
                name: "MovieShowId",
                table: "movieeventbooking");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "movieeventbooking",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_movieeventbooking_movieshow_Id",
                table: "movieeventbooking",
                column: "Id",
                principalTable: "movieshow",
                principalColumn: "Id");
        }
    }
}
