using System;
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
                    PersonalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    Age = table.Column<int>(type: "int", nullable: true),
                    DateBorn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Education = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Exp = table.Column<int>(type: "int", nullable: true),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PassportSerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TIN_passport = table.Column<string>(type: "nvarchar(max)", nullable: true),
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

            migrationBuilder.CreateTable(
                name: "recordModels",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecordDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DoctorUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recordModels", x => x.ID);
                    table.ForeignKey(
                        name: "FK_recordModels_doctorUsers_DoctorUserId",
                        column: x => x.DoctorUserId,
                        principalTable: "doctorUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "analysisModels",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnalysisDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Result = table.Column<bool>(type: "bit", nullable: false),
                    ResultInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecordModelID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_analysisModels", x => x.ID);
                    table.ForeignKey(
                        name: "FK_analysisModels_recordModels_RecordModelID",
                        column: x => x.RecordModelID,
                        principalTable: "recordModels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pacientMedCarts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Age = table.Column<int>(type: "int", nullable: true),
                    DateBorn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Info = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecordModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pacientMedCarts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_pacientMedCarts_recordModels_RecordModelId",
                        column: x => x.RecordModelId,
                        principalTable: "recordModels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "roleModels",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Admin" });

            migrationBuilder.InsertData(
                table: "roleModels",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Doctor" });

            migrationBuilder.CreateIndex(
                name: "IX_analysisModels_RecordModelID",
                table: "analysisModels",
                column: "RecordModelID");

            migrationBuilder.CreateIndex(
                name: "IX_doctorFullInfos_DoctorUserId",
                table: "doctorFullInfos",
                column: "DoctorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_doctorUsers_RoleModelId",
                table: "doctorUsers",
                column: "RoleModelId");

            migrationBuilder.CreateIndex(
                name: "IX_pacientMedCarts_RecordModelId",
                table: "pacientMedCarts",
                column: "RecordModelId");

            migrationBuilder.CreateIndex(
                name: "IX_recordModels_DoctorUserId",
                table: "recordModels",
                column: "DoctorUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "analysisModels");

            migrationBuilder.DropTable(
                name: "doctorFullInfos");

            migrationBuilder.DropTable(
                name: "pacientMedCarts");

            migrationBuilder.DropTable(
                name: "recordModels");

            migrationBuilder.DropTable(
                name: "doctorUsers");

            migrationBuilder.DropTable(
                name: "roleModels");
        }
    }
}
