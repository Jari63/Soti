using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Soti.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostalAddress = table.Column<string>(nullable: true),
                    Zip = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "Play",
                columns: table => new
                {
                    PlayId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Play", x => x.PlayId);
                });

            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    AuthorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    AuthorType = table.Column<int>(nullable: false),
                    ContactPerson = table.Column<string>(nullable: true),
                    AddressId = table.Column<int>(nullable: true),
                    SSN = table.Column<string>(nullable: true),
                    CompanyId = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    IBAN = table.Column<string>(nullable: true),
                    BIC = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.AuthorId);
                    table.ForeignKey(
                        name: "FK_Author_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Theatre",
                columns: table => new
                {
                    TheatreId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TheatreType = table.Column<int>(nullable: false),
                    ContactPerson = table.Column<string>(nullable: true),
                    AddressId = table.Column<int>(nullable: true),
                    CompanyId = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Theatre", x => x.TheatreId);
                    table.ForeignKey(
                        name: "FK_Theatre_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AuthorPlay",
                columns: table => new
                {
                    AuthorId = table.Column<int>(nullable: false),
                    PlayId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorPlay", x => new { x.AuthorId, x.PlayId });
                    table.ForeignKey(
                        name: "FK_AuthorPlay_Author_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Author",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorPlay_Play_PlayId",
                        column: x => x.PlayId,
                        principalTable: "Play",
                        principalColumn: "PlayId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contract",
                columns: table => new
                {
                    TheatreId = table.Column<int>(nullable: false),
                    PlayId = table.Column<int>(nullable: false),
                    IsPerformanceEnded = table.Column<bool>(nullable: false),
                    Music = table.Column<string>(nullable: true),
                    Stage = table.Column<string>(nullable: true),
                    ValidMonths = table.Column<int>(nullable: false),
                    PlayTimes = table.Column<int>(nullable: false),
                    PaymentInAnticipation = table.Column<decimal>(type: "money", nullable: false),
                    PercentageFee = table.Column<decimal>(type: "money", nullable: false),
                    Range = table.Column<int>(nullable: false),
                    Premiere = table.Column<DateTime>(nullable: false),
                    Seats = table.Column<int>(nullable: false),
                    InvoiceDate = table.Column<DateTime>(nullable: false),
                    MinimumPayment = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contract", x => new { x.TheatreId, x.PlayId });
                    table.ForeignKey(
                        name: "FK_Contract_Play_PlayId",
                        column: x => x.PlayId,
                        principalTable: "Play",
                        principalColumn: "PlayId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contract_Theatre_TheatreId",
                        column: x => x.TheatreId,
                        principalTable: "Theatre",
                        principalColumn: "TheatreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Author_AddressId",
                table: "Author",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorPlay_PlayId",
                table: "AuthorPlay",
                column: "PlayId");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_PlayId",
                table: "Contract",
                column: "PlayId");

            migrationBuilder.CreateIndex(
                name: "IX_Theatre_AddressId",
                table: "Theatre",
                column: "AddressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorPlay");

            migrationBuilder.DropTable(
                name: "Contract");

            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropTable(
                name: "Play");

            migrationBuilder.DropTable(
                name: "Theatre");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
