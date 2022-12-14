using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CardGame.WebAPI.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDateTime = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDateTime = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    IsAdmin = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Effects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDateTime = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    Code = table.Column<string>(nullable: true),
                    Power = table.Column<int>(nullable: false),
                    Chance = table.Column<decimal>(nullable: false),
                    CardId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Effects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Effects_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Decks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDateTime = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    Name = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Decks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Decks_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DeckCards",
                columns: table => new
                {
                    DeckId = table.Column<int>(nullable: false),
                    CardId = table.Column<int>(nullable: false),
                    AmountOfCopies = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeckCards", x => new { x.DeckId, x.CardId });
                    table.ForeignKey(
                        name: "FK_DeckCards_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeckCards_Decks_DeckId",
                        column: x => x.DeckId,
                        principalTable: "Decks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Monsters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDateTime = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    Name = table.Column<string>(nullable: true),
                    Health = table.Column<int>(nullable: false),
                    DeckId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monsters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Monsters_Decks_DeckId",
                        column: x => x.DeckId,
                        principalTable: "Decks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "CreatedDateTime", "Description", "Name" },
                values: new object[] { 1, new DateTime(2019, 11, 11, 15, 15, 33, 809, DateTimeKind.Local).AddTicks(3937), "This is a weak card.", "WeakCard1" });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "CreatedDateTime", "Description", "Name" },
                values: new object[] { 2, new DateTime(2019, 11, 11, 15, 15, 33, 809, DateTimeKind.Local).AddTicks(4097), "This is also a weak card.", "WeakCard2" });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "CreatedDateTime", "Description", "Name" },
                values: new object[] { 3, new DateTime(2019, 11, 11, 15, 15, 33, 809, DateTimeKind.Local).AddTicks(4191), "This is a strong card.", "StrongCard1" });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "CreatedDateTime", "Description", "Name" },
                values: new object[] { 4, new DateTime(2019, 11, 11, 15, 15, 33, 809, DateTimeKind.Local).AddTicks(4273), "This is also a strong card.", "StrongCard2" });

            migrationBuilder.InsertData(
                table: "Decks",
                columns: new[] { "Id", "CreatedDateTime", "Name", "UserId" },
                values: new object[] { 1, new DateTime(2019, 11, 11, 15, 15, 33, 995, DateTimeKind.Local).AddTicks(8181), "WeakMonsterDeck", null });

            migrationBuilder.InsertData(
                table: "Decks",
                columns: new[] { "Id", "CreatedDateTime", "Name", "UserId" },
                values: new object[] { 2, new DateTime(2019, 11, 11, 15, 15, 33, 995, DateTimeKind.Local).AddTicks(8263), "StrongMonsterDeck", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDateTime", "Email", "IsAdmin", "Name", "Password" },
                values: new object[] { 1, new DateTime(2019, 11, 11, 15, 15, 33, 863, DateTimeKind.Local).AddTicks(5224), "regularuser@example.test", false, "RegularUser", "password" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDateTime", "Email", "IsAdmin", "Name", "Password" },
                values: new object[] { 2, new DateTime(2019, 11, 11, 15, 15, 33, 863, DateTimeKind.Local).AddTicks(5330), "admin@example.test", true, "Admin", "password" });

            migrationBuilder.InsertData(
                table: "DeckCards",
                columns: new[] { "DeckId", "CardId", "AmountOfCopies" },
                values: new object[,]
                {
                    { 1, 1, 3 },
                    { 1, 2, 3 },
                    { 2, 3, 3 },
                    { 2, 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "Decks",
                columns: new[] { "Id", "CreatedDateTime", "Name", "UserId" },
                values: new object[] { 3, new DateTime(2019, 11, 11, 15, 15, 33, 995, DateTimeKind.Local).AddTicks(9835), "UserDeck1", 1 });

            migrationBuilder.InsertData(
                table: "Decks",
                columns: new[] { "Id", "CreatedDateTime", "Name", "UserId" },
                values: new object[] { 4, new DateTime(2019, 11, 11, 15, 15, 33, 995, DateTimeKind.Local).AddTicks(9912), "UserDeck2", 1 });

            migrationBuilder.InsertData(
                table: "Decks",
                columns: new[] { "Id", "CreatedDateTime", "Name", "UserId" },
                values: new object[] { 5, new DateTime(2019, 11, 11, 15, 15, 33, 995, DateTimeKind.Local).AddTicks(9969), "UserDeck3", 2 });

            migrationBuilder.InsertData(
                table: "Effects",
                columns: new[] { "Id", "CardId", "Chance", "Code", "CreatedDateTime", "Power" },
                values: new object[] { 1, 1, 0.5m, "WeakEffect1", new DateTime(2019, 11, 11, 15, 15, 33, 996, DateTimeKind.Local).AddTicks(49), 1 });

            migrationBuilder.InsertData(
                table: "Effects",
                columns: new[] { "Id", "CardId", "Chance", "Code", "CreatedDateTime", "Power" },
                values: new object[] { 2, 2, 1m, "WeakEffect2", new DateTime(2019, 11, 11, 15, 15, 33, 996, DateTimeKind.Local).AddTicks(125), 0 });

            migrationBuilder.InsertData(
                table: "Effects",
                columns: new[] { "Id", "CardId", "Chance", "Code", "CreatedDateTime", "Power" },
                values: new object[] { 3, 3, 1m, "StrongEffect1", new DateTime(2019, 11, 11, 15, 15, 33, 996, DateTimeKind.Local).AddTicks(196), 20 });

            migrationBuilder.InsertData(
                table: "Effects",
                columns: new[] { "Id", "CardId", "Chance", "Code", "CreatedDateTime", "Power" },
                values: new object[] { 4, 4, 0.8m, "StrongEffect2", new DateTime(2019, 11, 11, 15, 15, 33, 996, DateTimeKind.Local).AddTicks(268), 30 });

            migrationBuilder.InsertData(
                table: "Effects",
                columns: new[] { "Id", "CardId", "Chance", "Code", "CreatedDateTime", "Power" },
                values: new object[] { 5, 4, 1m, "StrongEffect3", new DateTime(2019, 11, 11, 15, 15, 33, 996, DateTimeKind.Local).AddTicks(337), 0 });

            migrationBuilder.InsertData(
                table: "Monsters",
                columns: new[] { "Id", "CreatedDateTime", "DeckId", "Health", "Name" },
                values: new object[] { 1, new DateTime(2019, 11, 11, 15, 15, 33, 996, DateTimeKind.Local).AddTicks(431), 1, 10, "WeakMonster" });

            migrationBuilder.InsertData(
                table: "Monsters",
                columns: new[] { "Id", "CreatedDateTime", "DeckId", "Health", "Name" },
                values: new object[] { 2, new DateTime(2019, 11, 11, 15, 15, 33, 996, DateTimeKind.Local).AddTicks(506), 2, 2000, "StrongMonster" });

            migrationBuilder.InsertData(
                table: "DeckCards",
                columns: new[] { "DeckId", "CardId", "AmountOfCopies" },
                values: new object[,]
                {
                    { 3, 1, 2 },
                    { 3, 4, 1 },
                    { 4, 2, 3 },
                    { 4, 3, 2 },
                    { 5, 4, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeckCards_CardId",
                table: "DeckCards",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_Decks_UserId",
                table: "Decks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Effects_CardId",
                table: "Effects",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_Monsters_DeckId",
                table: "Monsters",
                column: "DeckId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeckCards");

            migrationBuilder.DropTable(
                name: "Effects");

            migrationBuilder.DropTable(
                name: "Monsters");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Decks");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
