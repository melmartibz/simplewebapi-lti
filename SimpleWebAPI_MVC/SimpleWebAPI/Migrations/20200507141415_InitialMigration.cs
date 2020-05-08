using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleWebAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CategoryID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
