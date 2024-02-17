using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoxessWebbus.Web.Migrations
{
    /// <inheritdoc />
    public partial class pv1and2ampsvoltsdecimal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "PV2Voltage",
                table: "FoxH1",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<decimal>(
                name: "PV2Amps",
                table: "FoxH1",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<decimal>(
                name: "PV1Voltage",
                table: "FoxH1",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<decimal>(
                name: "PV1Amps",
                table: "FoxH1",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "INTEGER");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "PV2Voltage",
                table: "FoxH1",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<short>(
                name: "PV2Amps",
                table: "FoxH1",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<short>(
                name: "PV1Voltage",
                table: "FoxH1",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<short>(
                name: "PV1Amps",
                table: "FoxH1",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");
        }
    }
}
