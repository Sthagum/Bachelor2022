using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuadBook.Data.Migrations
{
    public partial class manglerbarecompanylocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ResourceID",
                table: "Booking",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Booking",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    LocationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuildingName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.LocationID);
                });

            migrationBuilder.CreateTable(
                name: "ResourceType",
                columns: table => new
                {
                    resourceTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    resourceTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceType", x => x.resourceTypeId);
                });

            migrationBuilder.CreateTable(
                name: "TypeProperties",
                columns: table => new
                {
                    typePropertiesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeProperties", x => x.typePropertiesId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_User_Company_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Company",
                        principalColumn: "CompanyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResourceProperties",
                columns: table => new
                {
                    resourcePropertiesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    typePropertiesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceProperties", x => x.resourcePropertiesId);
                    table.ForeignKey(
                        name: "FK_ResourceProperties_TypeProperties_typePropertiesId",
                        column: x => x.typePropertiesId,
                        principalTable: "TypeProperties",
                        principalColumn: "typePropertiesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Resource",
                columns: table => new
                {
                    resourceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    resourceType = table.Column<int>(type: "int", nullable: false),
                    resourceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    locationId = table.Column<int>(type: "int", nullable: false),
                    resourcePropertiesID = table.Column<int>(type: "int", nullable: false),
                    ResourceTypeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resource", x => x.resourceId);
                    table.ForeignKey(
                        name: "FK_Resource_Location_locationId",
                        column: x => x.locationId,
                        principalTable: "Location",
                        principalColumn: "LocationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Resource_ResourceProperties_resourcePropertiesID",
                        column: x => x.resourcePropertiesID,
                        principalTable: "ResourceProperties",
                        principalColumn: "resourcePropertiesId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Resource_ResourceType_ResourceTypeID",
                        column: x => x.ResourceTypeID,
                        principalTable: "ResourceType",
                        principalColumn: "resourceTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_ResourceID",
                table: "Booking",
                column: "ResourceID");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_UserID",
                table: "Booking",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Resource_locationId",
                table: "Resource",
                column: "locationId");

            migrationBuilder.CreateIndex(
                name: "IX_Resource_resourcePropertiesID",
                table: "Resource",
                column: "resourcePropertiesID");

            migrationBuilder.CreateIndex(
                name: "IX_Resource_ResourceTypeID",
                table: "Resource",
                column: "ResourceTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceProperties_typePropertiesId",
                table: "ResourceProperties",
                column: "typePropertiesId");

            migrationBuilder.CreateIndex(
                name: "IX_User_CompanyID",
                table: "User",
                column: "CompanyID");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Resource_ResourceID",
                table: "Booking",
                column: "ResourceID",
                principalTable: "Resource",
                principalColumn: "resourceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_User_UserID",
                table: "Booking",
                column: "UserID",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Resource_ResourceID",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_User_UserID",
                table: "Booking");

            migrationBuilder.DropTable(
                name: "Resource");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "ResourceProperties");

            migrationBuilder.DropTable(
                name: "ResourceType");

            migrationBuilder.DropTable(
                name: "TypeProperties");

            migrationBuilder.DropIndex(
                name: "IX_Booking_ResourceID",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_UserID",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "ResourceID",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Booking");
        }
    }
}
