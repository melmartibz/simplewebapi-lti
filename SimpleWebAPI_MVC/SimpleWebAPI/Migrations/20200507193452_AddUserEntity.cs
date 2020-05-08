using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleWebAPI.Migrations
{
    public partial class AddUserEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("3c339f1d-8c94-426d-91bd-4be8119d85e6"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("58e36022-c982-461f-a4f3-d45255a54c86"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("8385e38d-5088-4a63-bf55-b4e21c88e1f7"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("a2203b89-438c-4eb1-9444-e041b1f26321"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: new Guid("ebef8c84-14f9-4902-870a-e0d0ef79f4f4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: new Guid("68d48c29-efc0-4b66-a7cc-938974893a57"));

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<Guid>(nullable: false),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

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

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { new Guid("a2203b89-438c-4eb1-9444-e041b1f26321"), "Kitchewares" },
                    { new Guid("3c339f1d-8c94-426d-91bd-4be8119d85e6"), "Gadgets and Electronics" },
                    { new Guid("58e36022-c982-461f-a4f3-d45255a54c86"), "Gardening Tools" },
                    { new Guid("ebef8c84-14f9-4902-870a-e0d0ef79f4f4"), "Sports Equipment" },
                    { new Guid("8385e38d-5088-4a63-bf55-b4e21c88e1f7"), "Gaming" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "CategoryID", "Description", "Image", "Name" },
                values: new object[] { new Guid("68d48c29-efc0-4b66-a7cc-938974893a57"), new Guid("8385e38d-5088-4a63-bf55-b4e21c88e1f7"), "Final Fantasy 7 Remake", "https://gadgetpilipinas.net/wp-content/uploads/2019/09/ff7remake1st.jpg", "FF7 Remake" });
        }
    }
}
