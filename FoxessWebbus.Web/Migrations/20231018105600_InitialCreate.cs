using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoxessWebbus.Web.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FoxH1",
                columns: table => new
                {
                    EntryId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PVPower1 = table.Column<short>(type: "INTEGER", nullable: false),
                    PVPower2 = table.Column<short>(type: "INTEGER", nullable: false),
                    PVPowerTotal = table.Column<short>(type: "INTEGER", nullable: false),
                    BatteryCharge = table.Column<short>(type: "INTEGER", nullable: false),
                    BatteryDischarge = table.Column<short>(type: "INTEGER", nullable: false),
                    BatterySoc = table.Column<short>(type: "INTEGER", nullable: false),
                    BatteryTemp = table.Column<short>(type: "INTEGER", nullable: false),
                    InverterTemp = table.Column<short>(type: "INTEGER", nullable: false),
                    FeedIn = table.Column<short>(type: "INTEGER", nullable: false),
                    FromGrid = table.Column<short>(type: "INTEGER", nullable: false),
                    LoggedDateTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoxH1", x => x.EntryId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoxH1");
        }
    }
}
