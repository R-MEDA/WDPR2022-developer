using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace react.Migrations
{
    /// <inheritdoc />
    public partial class _5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransferedTickets_Performances_PerformanceId",
                table: "TransferedTickets");

            migrationBuilder.DropForeignKey(
                name: "FK_TransferedTickets_Seats_SeatId",
                table: "TransferedTickets");

            migrationBuilder.DropForeignKey(
                name: "FK_TransferedTickets_Visitors_VisitorId",
                table: "TransferedTickets");

            migrationBuilder.DropColumn(
                name: "TicketId",
                table: "TransferedTickets");

            migrationBuilder.AlterColumn<int>(
                name: "VisitorId",
                table: "TransferedTickets",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "SeatId",
                table: "TransferedTickets",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "TransferedTickets",
                type: "REAL",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AlterColumn<int>(
                name: "PerformanceId",
                table: "TransferedTickets",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_TransferedTickets_Performances_PerformanceId",
                table: "TransferedTickets",
                column: "PerformanceId",
                principalTable: "Performances",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TransferedTickets_Seats_SeatId",
                table: "TransferedTickets",
                column: "SeatId",
                principalTable: "Seats",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TransferedTickets_Visitors_VisitorId",
                table: "TransferedTickets",
                column: "VisitorId",
                principalTable: "Visitors",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransferedTickets_Performances_PerformanceId",
                table: "TransferedTickets");

            migrationBuilder.DropForeignKey(
                name: "FK_TransferedTickets_Seats_SeatId",
                table: "TransferedTickets");

            migrationBuilder.DropForeignKey(
                name: "FK_TransferedTickets_Visitors_VisitorId",
                table: "TransferedTickets");

            migrationBuilder.AlterColumn<int>(
                name: "VisitorId",
                table: "TransferedTickets",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SeatId",
                table: "TransferedTickets",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "TransferedTickets",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "REAL",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PerformanceId",
                table: "TransferedTickets",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TicketId",
                table: "TransferedTickets",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_TransferedTickets_Performances_PerformanceId",
                table: "TransferedTickets",
                column: "PerformanceId",
                principalTable: "Performances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransferedTickets_Seats_SeatId",
                table: "TransferedTickets",
                column: "SeatId",
                principalTable: "Seats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransferedTickets_Visitors_VisitorId",
                table: "TransferedTickets",
                column: "VisitorId",
                principalTable: "Visitors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
