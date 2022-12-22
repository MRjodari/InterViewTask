using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hermes.Persistence.Migrations
{
    public partial class ConfigureUserMessages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserMessages",
                columns: new[] { "Id", "UserId" },
                values: new object[,]
                {
                    { new Guid("37af754e-a853-4100-a40a-430659614e74"), new Guid("f7eacefa-39aa-4a3e-9cb6-76bec7fa4dff") },
                    { new Guid("b0d608dd-cc8a-4849-b546-92c400d9a8e1"), new Guid("1fc1571d-3890-43ed-9392-fe14a721c8f0") },
                    { new Guid("e44327fc-3b8e-4be3-b437-846685f4e056"), new Guid("cc2d6986-5d65-47ff-ac28-b03e5ecddd49") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DeviceIdentifier", "IsActive", "IsDeleted", "RegisterDate", "UserName" },
                values: new object[,]
                {
                    { new Guid("0cde848b-ca31-4710-b30e-886a94957a87"), new Guid("1d9e9ea6-1e63-4553-95ac-efea8fba263c"), true, false, new DateTime(2022, 12, 22, 15, 18, 0, 64, DateTimeKind.Local).AddTicks(2399), "Ahad" },
                    { new Guid("35227a66-40f5-4c85-b11e-934b55e23117"), new Guid("f7eacefa-39aa-4a3e-9cb6-76bec7fa4dff"), true, false, new DateTime(2022, 12, 22, 15, 18, 0, 64, DateTimeKind.Local).AddTicks(2386), "Mehran" },
                    { new Guid("66621e0a-63b5-488d-8bab-d1940b3e5e4a"), new Guid("f53e964d-5aa2-47b6-a67c-6900b49ea78c"), true, false, new DateTime(2022, 12, 22, 15, 18, 0, 64, DateTimeKind.Local).AddTicks(2409), "Aidin" },
                    { new Guid("6bae5770-fdd9-4c66-85f2-c0dadd4ab6aa"), new Guid("829e3cdc-78a3-4a3d-b1b5-c86a7f901fa4"), true, false, new DateTime(2022, 12, 22, 15, 18, 0, 64, DateTimeKind.Local).AddTicks(2389), "Babak" },
                    { new Guid("a2b8fc54-1e16-4bff-bf68-7f9aef177796"), new Guid("1fc1571d-3890-43ed-9392-fe14a721c8f0"), true, false, new DateTime(2022, 12, 22, 15, 18, 0, 64, DateTimeKind.Local).AddTicks(2366), "Mora" },
                    { new Guid("ae7e5565-74a7-46af-931c-3919b31a26d7"), new Guid("e8f8c794-415d-426f-a264-90623f5a61f8"), true, false, new DateTime(2022, 12, 22, 15, 18, 0, 64, DateTimeKind.Local).AddTicks(2401), "Reza" },
                    { new Guid("af09f8e0-328a-4663-a250-1584831f3e82"), new Guid("00a3cad7-fb9f-4d11-a40d-2ea84b856a70"), true, false, new DateTime(2022, 12, 22, 15, 18, 0, 64, DateTimeKind.Local).AddTicks(2405), "Saeid" },
                    { new Guid("b9f8fb7a-8c45-4f20-8eb6-92a7920eb043"), new Guid("9eda87ba-a33d-4354-a362-7da220780f7e"), true, false, new DateTime(2022, 12, 22, 15, 18, 0, 64, DateTimeKind.Local).AddTicks(2407), "Saman" },
                    { new Guid("c3b4483e-96b8-412d-b892-f2a0b22aee67"), new Guid("cc2d6986-5d65-47ff-ac28-b03e5ecddd49"), true, false, new DateTime(2022, 12, 22, 15, 18, 0, 64, DateTimeKind.Local).AddTicks(2384), "Ali" },
                    { new Guid("e7943c96-8efb-4913-b50b-bf22b6f80f6c"), new Guid("e9dc547c-7ea8-4113-a0b2-560c7de8d564"), true, false, new DateTime(2022, 12, 22, 15, 18, 0, 64, DateTimeKind.Local).AddTicks(2391), "Sara" },
                    { new Guid("ea75c306-b19b-4b54-88e2-d25d500bc2a2"), new Guid("fdbbcb91-2761-44db-ac06-e95c49ec0ba5"), true, false, new DateTime(2022, 12, 22, 15, 18, 0, 64, DateTimeKind.Local).AddTicks(2403), "Maryam" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserMessages",
                keyColumn: "Id",
                keyValue: new Guid("37af754e-a853-4100-a40a-430659614e74"));

            migrationBuilder.DeleteData(
                table: "UserMessages",
                keyColumn: "Id",
                keyValue: new Guid("b0d608dd-cc8a-4849-b546-92c400d9a8e1"));

            migrationBuilder.DeleteData(
                table: "UserMessages",
                keyColumn: "Id",
                keyValue: new Guid("e44327fc-3b8e-4be3-b437-846685f4e056"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0cde848b-ca31-4710-b30e-886a94957a87"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("35227a66-40f5-4c85-b11e-934b55e23117"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("66621e0a-63b5-488d-8bab-d1940b3e5e4a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6bae5770-fdd9-4c66-85f2-c0dadd4ab6aa"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a2b8fc54-1e16-4bff-bf68-7f9aef177796"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ae7e5565-74a7-46af-931c-3919b31a26d7"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("af09f8e0-328a-4663-a250-1584831f3e82"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b9f8fb7a-8c45-4f20-8eb6-92a7920eb043"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c3b4483e-96b8-412d-b892-f2a0b22aee67"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e7943c96-8efb-4913-b50b-bf22b6f80f6c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ea75c306-b19b-4b54-88e2-d25d500bc2a2"));
        }
    }
}
