using Microsoft.EntityFrameworkCore.Migrations;

namespace SignUpGenius.Migrations
{
    public partial class Start : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppointmentTime",
                columns: table => new
                {
                    TimeID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Day = table.Column<string>(type: "TEXT", nullable: true),
                    Time = table.Column<string>(type: "TEXT", nullable: true),
                    Scheduled = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentTime", x => x.TimeID);
                });

            migrationBuilder.CreateTable(
                name: "Form",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Time = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Size = table.Column<int>(type: "INTEGER", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Form", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppointmentTime");

            migrationBuilder.DropTable(
                name: "Form");
        }
    }
}
