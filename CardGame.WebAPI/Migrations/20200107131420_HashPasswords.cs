using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CardGame.WebAPI.Migrations
{
    public partial class HashPasswords : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2020, 1, 7, 14, 14, 19, 793, DateTimeKind.Local).AddTicks(6784));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2020, 1, 7, 14, 14, 19, 793, DateTimeKind.Local).AddTicks(6911));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2020, 1, 7, 14, 14, 19, 793, DateTimeKind.Local).AddTicks(6998));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2020, 1, 7, 14, 14, 19, 793, DateTimeKind.Local).AddTicks(7077));

            migrationBuilder.UpdateData(
                table: "Decks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2020, 1, 7, 14, 14, 20, 78, DateTimeKind.Local).AddTicks(9679));

            migrationBuilder.UpdateData(
                table: "Decks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2020, 1, 7, 14, 14, 20, 78, DateTimeKind.Local).AddTicks(9774));

            migrationBuilder.UpdateData(
                table: "Decks",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2020, 1, 7, 14, 14, 20, 78, DateTimeKind.Local).AddTicks(9829));

            migrationBuilder.UpdateData(
                table: "Decks",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2020, 1, 7, 14, 14, 20, 78, DateTimeKind.Local).AddTicks(9883));

            migrationBuilder.UpdateData(
                table: "Decks",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2020, 1, 7, 14, 14, 20, 78, DateTimeKind.Local).AddTicks(9937));

            migrationBuilder.UpdateData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2020, 1, 7, 14, 14, 20, 79, DateTimeKind.Local).AddTicks(3));

            migrationBuilder.UpdateData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2020, 1, 7, 14, 14, 20, 79, DateTimeKind.Local).AddTicks(57));

            migrationBuilder.UpdateData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2020, 1, 7, 14, 14, 20, 79, DateTimeKind.Local).AddTicks(147));

            migrationBuilder.UpdateData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2020, 1, 7, 14, 14, 20, 79, DateTimeKind.Local).AddTicks(204));

            migrationBuilder.UpdateData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2020, 1, 7, 14, 14, 20, 79, DateTimeKind.Local).AddTicks(259));

            migrationBuilder.UpdateData(
                table: "Monsters",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2020, 1, 7, 14, 14, 20, 79, DateTimeKind.Local).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "Monsters",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2020, 1, 7, 14, 14, 20, 79, DateTimeKind.Local).AddTicks(378));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDateTime", "Password" },
                values: new object[] { new DateTime(2020, 1, 7, 14, 14, 19, 886, DateTimeKind.Local).AddTicks(2166), "WYYulfQEqq9b6ZxH12kfYTwqfU6+JmXJKQhfjRPs9sKYXvOFXDSzwdESgoUbbg5J" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDateTime", "Password" },
                values: new object[] { new DateTime(2020, 1, 7, 14, 14, 19, 886, DateTimeKind.Local).AddTicks(2330), "oy2i01JhAoNt8qr/Y80klQ0KX33EvWdrK6OCEEuhUuhBvJLRtK4UKARI6UdLBQWl" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2019, 11, 11, 15, 15, 34, 57, DateTimeKind.Local).AddTicks(4082));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2019, 11, 11, 15, 15, 34, 57, DateTimeKind.Local).AddTicks(4185));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2019, 11, 11, 15, 15, 34, 57, DateTimeKind.Local).AddTicks(4273));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2019, 11, 11, 15, 15, 34, 57, DateTimeKind.Local).AddTicks(4352));

            migrationBuilder.UpdateData(
                table: "Decks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: null);

            migrationBuilder.UpdateData(
                table: "Decks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: null);

            migrationBuilder.UpdateData(
                table: "Decks",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: null);

            migrationBuilder.UpdateData(
                table: "Decks",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: null);

            migrationBuilder.UpdateData(
                table: "Decks",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: null);

            migrationBuilder.UpdateData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: null);

            migrationBuilder.UpdateData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: null);

            migrationBuilder.UpdateData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: null);

            migrationBuilder.UpdateData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: null);

            migrationBuilder.UpdateData(
                table: "Effects",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: null);

            migrationBuilder.UpdateData(
                table: "Monsters",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: null);

            migrationBuilder.UpdateData(
                table: "Monsters",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDateTime", "Password" },
                values: new object[] { new DateTime(2019, 11, 11, 15, 15, 34, 58, DateTimeKind.Local).AddTicks(533), "password" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDateTime", "Password" },
                values: new object[] { new DateTime(2019, 11, 11, 15, 15, 34, 58, DateTimeKind.Local).AddTicks(639), "password" });
        }
    }
}
