using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerWebApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    customer_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customer_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mobile_no = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer", x => x.customer_id);
                });

            migrationBuilder.InsertData(
                table: "customer",
                columns: new[] { "customer_id", "customer_name", "email", "mobile_no" },
                values: new object[] { 1, "Nelson Silva", "demo1@email.com", "9346723425" });

            migrationBuilder.InsertData(
                table: "customer",
                columns: new[] { "customer_id", "customer_name", "email", "mobile_no" },
                values: new object[] { 2, "André Silva", "demo2@email.com", "99999999" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customer");
        }
    }
}
