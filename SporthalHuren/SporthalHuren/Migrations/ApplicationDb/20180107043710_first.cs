using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SporthalHuren.Migrations.ApplicationDb
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    RequiredCapacity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Facilities",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facilities", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Proprietors",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    City = table.Column<string>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    HouseNumber = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    StreetName = table.Column<string>(nullable: false),
                    Zip = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proprietors", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    City = table.Column<string>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    HouseNumber = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    StreetName = table.Column<string>(nullable: false),
                    Zip = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Halls",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    City = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    HouseNumber = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    ProprietorID = table.Column<int>(nullable: false),
                    StreetName = table.Column<string>(nullable: false),
                    Zip = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Halls", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Halls_Proprietors_ProprietorID",
                        column: x => x.ProprietorID,
                        principalTable: "Proprietors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SportsHallsActivity",
                columns: table => new
                {
                    ActivityID = table.Column<int>(nullable: false),
                    SportsHallID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportsHallsActivity", x => new { x.ActivityID, x.SportsHallID });
                    table.ForeignKey(
                        name: "FK_SportsHallsActivity_Activities_ActivityID",
                        column: x => x.ActivityID,
                        principalTable: "Activities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SportsHallsActivity_Halls_SportsHallID",
                        column: x => x.SportsHallID,
                        principalTable: "Halls",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SportsHallsFacility",
                columns: table => new
                {
                    FacilityID = table.Column<int>(nullable: false),
                    SportsHallID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportsHallsFacility", x => new { x.FacilityID, x.SportsHallID });
                    table.ForeignKey(
                        name: "FK_SportsHallsFacility_Facilities_FacilityID",
                        column: x => x.FacilityID,
                        principalTable: "Facilities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SportsHallsFacility_Halls_SportsHallID",
                        column: x => x.SportsHallID,
                        principalTable: "Halls",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Times",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Day = table.Column<string>(nullable: false),
                    HallID = table.Column<int>(nullable: false),
                    TimeClose = table.Column<string>(nullable: false),
                    TimeOpen = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Times", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Times_Halls_HallID",
                        column: x => x.HallID,
                        principalTable: "Halls",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Capacity = table.Column<int>(nullable: false),
                    HallID = table.Column<int>(nullable: false),
                    RoomNumber = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Rooms_Halls_HallID",
                        column: x => x.HallID,
                        principalTable: "Halls",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActivityID = table.Column<int>(nullable: true),
                    Approved = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    HallID = table.Column<int>(nullable: false),
                    RemainingCapacity = table.Column<int>(nullable: false),
                    RoomID = table.Column<int>(nullable: true),
                    StartTime = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Bookings_Activities_ActivityID",
                        column: x => x.ActivityID,
                        principalTable: "Activities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bookings_Halls_HallID",
                        column: x => x.HallID,
                        principalTable: "Halls",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Rooms_RoomID",
                        column: x => x.RoomID,
                        principalTable: "Rooms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ActivityID",
                table: "Bookings",
                column: "ActivityID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_HallID",
                table: "Bookings",
                column: "HallID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_RoomID",
                table: "Bookings",
                column: "RoomID");

            migrationBuilder.CreateIndex(
                name: "IX_SportsHallsActivity_SportsHallID",
                table: "SportsHallsActivity",
                column: "SportsHallID");

            migrationBuilder.CreateIndex(
                name: "IX_SportsHallsFacility_SportsHallID",
                table: "SportsHallsFacility",
                column: "SportsHallID");

            migrationBuilder.CreateIndex(
                name: "IX_Times_HallID",
                table: "Times",
                column: "HallID");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_HallID",
                table: "Rooms",
                column: "HallID");

            migrationBuilder.CreateIndex(
                name: "IX_Halls_ProprietorID",
                table: "Halls",
                column: "ProprietorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "SportsHallsActivity");

            migrationBuilder.DropTable(
                name: "SportsHallsFacility");

            migrationBuilder.DropTable(
                name: "Times");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Facilities");

            migrationBuilder.DropTable(
                name: "Halls");

            migrationBuilder.DropTable(
                name: "Proprietors");
        }
    }
}
