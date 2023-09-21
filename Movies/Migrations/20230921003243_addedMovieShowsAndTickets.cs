using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Movies.Migrations
{
    /// <inheritdoc />
    public partial class addedMovieShowsAndTickets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "movieshow",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ShowTile = table.Column<string>(type: "text", nullable: false),
                    TheatreId = table.Column<int>(type: "integer", nullable: false),
                    MovieId = table.Column<int>(type: "integer", nullable: false),
                    StartTimeOfShow = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndTimeOfShow = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ShowDescription = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movieshow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_movieshow_movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_movieshow_theatre_TheatreId",
                        column: x => x.TheatreId,
                        principalTable: "theatre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ticket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TicketPrice = table.Column<double>(type: "double precision", nullable: false),
                    TotalTicketsAvailable = table.Column<int>(type: "integer", nullable: false),
                    NumberOfTicketsSold = table.Column<int>(type: "integer", nullable: false),
                    MovieShowId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ticket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ticket_movieshow_MovieShowId",
                        column: x => x.MovieShowId,
                        principalTable: "movieshow",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_movieshow_MovieId",
                table: "movieshow",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_movieshow_TheatreId",
                table: "movieshow",
                column: "TheatreId");

            migrationBuilder.CreateIndex(
                name: "IX_ticket_MovieShowId",
                table: "ticket",
                column: "MovieShowId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ticket");

            migrationBuilder.DropTable(
                name: "movieshow");
        }
    }
}
