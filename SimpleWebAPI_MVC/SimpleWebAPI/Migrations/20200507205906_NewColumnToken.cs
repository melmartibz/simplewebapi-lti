using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleWebAPI.Migrations
{
    public partial class NewColumnToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("3b0954a1-1c83-43e6-b979-bb647d84c856"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("50fdd9e6-6ce9-43af-96c8-5813bc32ddf8"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("6c8e2c04-b324-44bf-993f-4b62c434dce6"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("715ccf0c-5259-44e9-95ab-be0be18eeb7f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("96d31214-0c35-402b-ab35-4994ee27fea5"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: new Guid("b0793b6c-9ea5-46bb-bd14-8d51f1a94c70"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: new Guid("ae1c050f-ca33-49c4-8310-0255d3500397"));

            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "Users",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { new Guid("b8fe3b7a-d2ca-4f47-a2dc-5d4a06e84a00"), "Kitchewares" },
                    { new Guid("92946aeb-0e77-4dbf-992d-6d35551c03ed"), "Gadgets and Electronics" },
                    { new Guid("8a3689c4-5664-46a3-8140-d33acf19f46f"), "Gardening Tools" },
                    { new Guid("c7780694-87b7-4679-846c-055cef8dc5d7"), "Sports Equipment" },
                    { new Guid("a7200bc4-9dc2-4b28-b74f-3fde7f50f42f"), "Gaming" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "CategoryID", "Description", "Image", "Name" },
                values: new object[] { new Guid("0e814ef5-e26e-4c0d-b748-c53de784bfba"), new Guid("a7200bc4-9dc2-4b28-b74f-3fde7f50f42f"), "Final Fantasy 7 Remake", "https://gadgetpilipinas.net/wp-content/uploads/2019/09/ff7remake1st.jpg", "FF7 Remake" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Email", "Password", "Token", "Username" },
                values: new object[] { new Guid("7f6d871b-3da5-4c32-af87-2ce45ca500be"), "user@useremail.com", "123password", null, "Weeddnim" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("8a3689c4-5664-46a3-8140-d33acf19f46f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("92946aeb-0e77-4dbf-992d-6d35551c03ed"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("a7200bc4-9dc2-4b28-b74f-3fde7f50f42f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("b8fe3b7a-d2ca-4f47-a2dc-5d4a06e84a00"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("c7780694-87b7-4679-846c-055cef8dc5d7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: new Guid("0e814ef5-e26e-4c0d-b748-c53de784bfba"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: new Guid("7f6d871b-3da5-4c32-af87-2ce45ca500be"));

            migrationBuilder.DropColumn(
                name: "Token",
                table: "Users");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { new Guid("3b0954a1-1c83-43e6-b979-bb647d84c856"), "Kitchewares" },
                    { new Guid("715ccf0c-5259-44e9-95ab-be0be18eeb7f"), "Gadgets and Electronics" },
                    { new Guid("50fdd9e6-6ce9-43af-96c8-5813bc32ddf8"), "Gardening Tools" },
                    { new Guid("6c8e2c04-b324-44bf-993f-4b62c434dce6"), "Sports Equipment" },
                    { new Guid("96d31214-0c35-402b-ab35-4994ee27fea5"), "Gaming" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "CategoryID", "Description", "Image", "Name" },
                values: new object[] { new Guid("b0793b6c-9ea5-46bb-bd14-8d51f1a94c70"), new Guid("96d31214-0c35-402b-ab35-4994ee27fea5"), "Final Fantasy 7 Remake", "https://gadgetpilipinas.net/wp-content/uploads/2019/09/ff7remake1st.jpg", "FF7 Remake" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Email", "Password", "Username" },
                values: new object[] { new Guid("ae1c050f-ca33-49c4-8310-0255d3500397"), "user@useremail.com", "123password", "Weeddnim" });
        }
    }
}
