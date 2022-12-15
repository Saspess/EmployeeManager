using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DepartmentsAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HouseNumber = table.Column<int>(type: "int", nullable: false),
                    HouseCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentsAddresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Educations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstitutionName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StartYear = table.Column<int>(type: "int", nullable: false),
                    EndYear = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeesAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HouseNumber = table.Column<int>(type: "int", nullable: false),
                    FlatNumber = table.Column<int>(type: "int", nullable: true),
                    HouseCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeesAddresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationsAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HouseNumber = table.Column<int>(type: "int", nullable: false),
                    HouseCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationsAddresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationsContacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationsContacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Salary = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentsDatasets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentAddressId = table.Column<int>(type: "int", nullable: false),
                    DirectorName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentsDatasets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepartmentsDatasets_DepartmentsAddresses_DepartmentAddressId",
                        column: x => x.DepartmentAddressId,
                        principalTable: "DepartmentsAddresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeesDatasets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeAddressId = table.Column<int>(type: "int", nullable: false),
                    EducationId = table.Column<int>(type: "int", nullable: false),
                    Birthday = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeesDatasets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeesDatasets_Educations_EducationId",
                        column: x => x.EducationId,
                        principalTable: "Educations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeesDatasets_EmployeesAddresses_EmployeeAddressId",
                        column: x => x.EmployeeAddressId,
                        principalTable: "EmployeesAddresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationsDatasets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationAddressId = table.Column<int>(type: "int", nullable: false),
                    OrganizationContactId = table.Column<int>(type: "int", nullable: false),
                    DirectorName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationsDatasets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationsDatasets_OrganizationsAddresses_OrganizationAddressId",
                        column: x => x.OrganizationAddressId,
                        principalTable: "OrganizationsAddresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganizationsDatasets_OrganizationsContacts_OrganizationContactId",
                        column: x => x.OrganizationContactId,
                        principalTable: "OrganizationsContacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationDatasetId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organizations_OrganizationsDatasets_OrganizationDatasetId",
                        column: x => x.OrganizationDatasetId,
                        principalTable: "OrganizationsDatasets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationId = table.Column<int>(type: "int", nullable: false),
                    DepartmentDatasetId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_DepartmentsDatasets_DepartmentDatasetId",
                        column: x => x.DepartmentDatasetId,
                        principalTable: "DepartmentsDatasets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Departments_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: false),
                    EmployeeDatasetId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_EmployeesDatasets_EmployeeDatasetId",
                        column: x => x.EmployeeDatasetId,
                        principalTable: "EmployeesDatasets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_DepartmentDatasetId",
                table: "Departments",
                column: "DepartmentDatasetId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_Name",
                table: "Departments",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_OrganizationId",
                table: "Departments",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentsDatasets_DepartmentAddressId",
                table: "DepartmentsDatasets",
                column: "DepartmentAddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentsDatasets_DirectorName",
                table: "DepartmentsDatasets",
                column: "DirectorName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentsDatasets_PhoneNumber",
                table: "DepartmentsDatasets",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Educations_InstitutionName",
                table: "Educations",
                column: "InstitutionName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeDatasetId",
                table: "Employees",
                column: "EmployeeDatasetId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PositionId",
                table: "Employees",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeesDatasets_EducationId",
                table: "EmployeesDatasets",
                column: "EducationId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeesDatasets_EmployeeAddressId",
                table: "EmployeesDatasets",
                column: "EmployeeAddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeesDatasets_PhoneNumber",
                table: "EmployeesDatasets",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_Name",
                table: "Organizations",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_OrganizationDatasetId",
                table: "Organizations",
                column: "OrganizationDatasetId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationsContacts_Email",
                table: "OrganizationsContacts",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationsContacts_PhoneNumber",
                table: "OrganizationsContacts",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationsDatasets_DirectorName",
                table: "OrganizationsDatasets",
                column: "DirectorName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationsDatasets_OrganizationAddressId",
                table: "OrganizationsDatasets",
                column: "OrganizationAddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationsDatasets_OrganizationContactId",
                table: "OrganizationsDatasets",
                column: "OrganizationContactId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Positions_Name",
                table: "Positions",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "EmployeesDatasets");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "DepartmentsDatasets");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "Educations");

            migrationBuilder.DropTable(
                name: "EmployeesAddresses");

            migrationBuilder.DropTable(
                name: "DepartmentsAddresses");

            migrationBuilder.DropTable(
                name: "OrganizationsDatasets");

            migrationBuilder.DropTable(
                name: "OrganizationsAddresses");

            migrationBuilder.DropTable(
                name: "OrganizationsContacts");
        }
    }
}
