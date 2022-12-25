using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hermes.Persistence.Migrations
{
    public partial class InitDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserMessages",
                columns: table => new
                {
                    DeviceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMessages", x => x.DeviceId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeviceIdentifier = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "UserMessages",
                columns: new[] { "DeviceId", "Content", "Status" },
                values: new object[,]
                {
                    { new Guid("4610790d-c36b-468f-9894-e80d27d611e8"), "TestMessage", false },
                    { new Guid("49c2ea60-789c-457b-8e03-70c60097d9d5"), "TestMessage", false },
                    { new Guid("aa6588e0-818b-496c-b10f-2f6953bdd46c"), "TestMessage", false }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DeviceIdentifier", "IsActive", "IsDeleted", "RegisterDate", "UserName" },
                values: new object[,]
                {
                    { new Guid("18bf0830-2bf9-4f2a-a308-264c79226f56"), new Guid("023688aa-cd06-4735-9b07-65a6bc73b931"), true, false, new DateTime(2022, 12, 25, 12, 23, 57, 420, DateTimeKind.Local).AddTicks(779), "Aidin" },
                    { new Guid("36fadeb8-2dcc-4b0a-8ea8-e7ec071c25f7"), new Guid("49c2ea60-789c-457b-8e03-70c60097d9d5"), true, false, new DateTime(2022, 12, 25, 12, 23, 57, 420, DateTimeKind.Local).AddTicks(736), "Mora" },
                    { new Guid("38aa2230-9ffc-4375-8b07-c9e08bfaf829"), new Guid("aa6588e0-818b-496c-b10f-2f6953bdd46c"), true, false, new DateTime(2022, 12, 25, 12, 23, 57, 420, DateTimeKind.Local).AddTicks(753), "Ali" },
                    { new Guid("64bfc194-9ad2-45d6-b3b8-8aedad21d52e"), new Guid("a946daaf-e128-4e19-8690-dbccb568986e"), true, false, new DateTime(2022, 12, 25, 12, 23, 57, 420, DateTimeKind.Local).AddTicks(758), "Babak" },
                    { new Guid("6fb6da98-62c5-421f-9a21-e71c0c7dc821"), new Guid("5306cb47-6c5c-46e5-96ef-704bba535e11"), true, false, new DateTime(2022, 12, 25, 12, 23, 57, 420, DateTimeKind.Local).AddTicks(770), "Reza" },
                    { new Guid("7c4b3b2e-90db-41d9-a08b-046632463035"), new Guid("86fe9d3b-7d95-402b-8dd4-b87d101bf408"), true, false, new DateTime(2022, 12, 25, 12, 23, 57, 420, DateTimeKind.Local).AddTicks(772), "Maryam" },
                    { new Guid("83a7b79f-3250-4b55-8fa2-267f13e7bfaa"), new Guid("fab59f16-5d35-4bd3-b294-2996de7e291d"), true, false, new DateTime(2022, 12, 25, 12, 23, 57, 420, DateTimeKind.Local).AddTicks(774), "Saeid" },
                    { new Guid("92b49dc0-ecb6-4888-b996-baaded0c9627"), new Guid("4610790d-c36b-468f-9894-e80d27d611e8"), true, false, new DateTime(2022, 12, 25, 12, 23, 57, 420, DateTimeKind.Local).AddTicks(756), "Mehran" },
                    { new Guid("bad1e3e6-60d5-4610-b017-2b63ab6341e6"), new Guid("e413ab3e-c937-40cb-98d2-f70e0bc5b947"), true, false, new DateTime(2022, 12, 25, 12, 23, 57, 420, DateTimeKind.Local).AddTicks(765), "Sara" },
                    { new Guid("de2b83db-0d80-4c7d-b360-a171c4c6bcac"), new Guid("ab2f4cae-bf89-45a2-a38e-63e06bd5c0af"), true, false, new DateTime(2022, 12, 25, 12, 23, 57, 420, DateTimeKind.Local).AddTicks(777), "Saman" },
                    { new Guid("ec88ef4e-77ea-44da-947f-1dc76f9fd4bd"), new Guid("b93a51d7-a661-4898-ac70-76c0f2aa1275"), true, false, new DateTime(2022, 12, 25, 12, 23, 57, 420, DateTimeKind.Local).AddTicks(768), "Ahad" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserMessages");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
