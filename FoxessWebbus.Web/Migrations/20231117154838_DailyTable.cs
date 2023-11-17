using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoxessWebbus.Web.Migrations
{
    /// <inheritdoc />
    public partial class DailyTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DailyH1",
                columns: table => new
                {
                    EntryId = table.Column<Guid>(type: "TEXT", nullable: false),
                    EntryDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Solar = table.Column<decimal>(type: "TEXT", nullable: false),
                    Grid = table.Column<decimal>(type: "TEXT", nullable: false),
                    Feed = table.Column<decimal>(type: "TEXT", nullable: false),
                    BatteryCharge = table.Column<decimal>(type: "TEXT", nullable: false),
                    BatteryDischarge = table.Column<decimal>(type: "TEXT", nullable: false),
                    Yield = table.Column<decimal>(type: "TEXT", nullable: false),
                    Load = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyH1", x => x.EntryId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyH1");
        }
    }
}
