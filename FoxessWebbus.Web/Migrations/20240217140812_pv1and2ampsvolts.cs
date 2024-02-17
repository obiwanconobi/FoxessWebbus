using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoxessWebbus.Web.Migrations
{
    /// <inheritdoc />
    public partial class pv1and2ampsvolts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<short>(
                name: "PV1Amps",
                table: "FoxH1",
                type: "INTEGER",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "PV1Voltage",
                table: "FoxH1",
                type: "INTEGER",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "PV2Amps",
                table: "FoxH1",
                type: "INTEGER",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "PV2Voltage",
                table: "FoxH1",
                type: "INTEGER",
                nullable: false,
                defaultValue: (short)0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PV1Amps",
                table: "FoxH1");

            migrationBuilder.DropColumn(
                name: "PV1Voltage",
                table: "FoxH1");

            migrationBuilder.DropColumn(
                name: "PV2Amps",
                table: "FoxH1");

            migrationBuilder.DropColumn(
                name: "PV2Voltage",
                table: "FoxH1");
        }
    }
}
