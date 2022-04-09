using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartMedicineProject.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "roleModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roleModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "doctorUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Patronymic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doctorUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_doctorUsers_roleModels_RoleModelId",
                        column: x => x.RoleModelId,
                        principalTable: "roleModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "doctorFullInfos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Age = table.Column<int>(type: "int", nullable: false),
                    DoctorUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doctorFullInfos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_doctorFullInfos_doctorUsers_DoctorUserId",
                        column: x => x.DoctorUserId,
                        principalTable: "doctorUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "roleModels",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Admin" });

            migrationBuilder.InsertData(
                table: "roleModels",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "User" });

            migrationBuilder.CreateIndex(
                name: "IX_doctorFullInfos_DoctorUserId",
                table: "doctorFullInfos",
                column: "DoctorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_doctorUsers_RoleModelId",
                table: "doctorUsers",
                column: "RoleModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "doctorFullInfos");

            migrationBuilder.DropTable(
                name: "doctorUsers");

            migrationBuilder.DropTable(
                name: "roleModels");
        }
    }
}
