using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Web.Data.Migrations
{
    public partial class AddApplicantClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OfferUser");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Offers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Applicants",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsAccepted = table.Column<bool>(type: "bit", nullable: false),
                    DateOfRequest = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OfferId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Applicants_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Applicants_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Offers_UserId",
                table: "Offers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Applicants_OfferId",
                table: "Applicants",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_Applicants_UserId",
                table: "Applicants",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_AspNetUsers_UserId",
                table: "Offers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_AspNetUsers_UserId",
                table: "Offers");

            migrationBuilder.DropTable(
                name: "Applicants");

            migrationBuilder.DropIndex(
                name: "IX_Offers_UserId",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Offers");

            migrationBuilder.CreateTable(
                name: "OfferUser",
                columns: table => new
                {
                    ApplicantsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OffersId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferUser", x => new { x.ApplicantsId, x.OffersId });
                    table.ForeignKey(
                        name: "FK_OfferUser_AspNetUsers_ApplicantsId",
                        column: x => x.ApplicantsId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfferUser_Offers_OffersId",
                        column: x => x.OffersId,
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OfferUser_OffersId",
                table: "OfferUser",
                column: "OffersId");
        }
    }
}
