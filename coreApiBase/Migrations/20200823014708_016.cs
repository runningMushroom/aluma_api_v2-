using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace alumaApi.Migrations
{
    public partial class _016 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("863b9dd8-6e98-4a5c-a16e-198cc1949c46"));

            migrationBuilder.CreateTable(
                name: "bank_details",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    ApplicationId = table.Column<Guid>(nullable: false),
                    StepId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    SearchData = table.Column<string>(nullable: true),
                    Reference = table.Column<string>(nullable: true),
                    BranchCode = table.Column<string>(nullable: true),
                    AccountNumber = table.Column<string>(nullable: true),
                    AccountId = table.Column<string>(nullable: true),
                    IdNumber = table.Column<string>(nullable: true),
                    Initials = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    FoundAtBank = table.Column<string>(nullable: true),
                    AccOpen = table.Column<string>(nullable: true),
                    OlderThan3Months = table.Column<string>(nullable: true),
                    TypeCorrect = table.Column<string>(nullable: true),
                    IdNumberMatch = table.Column<string>(nullable: true),
                    NamesMatch = table.Column<string>(nullable: true),
                    AcceptDebits = table.Column<string>(nullable: true),
                    AcceptCredits = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bank_details", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "primary_schedule_individual",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    StepId = table.Column<Guid>(nullable: false),
                    ApplicationId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_primary_schedule_individual", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "primary_schedule_individual_bank_details",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    ScheduleId = table.Column<Guid>(nullable: false),
                    AccountHolder = table.Column<string>(nullable: true),
                    Bank = table.Column<string>(nullable: true),
                    Branc = table.Column<string>(nullable: true),
                    BrancNumber = table.Column<string>(nullable: true),
                    AccountNumber = table.Column<string>(nullable: true),
                    AccountType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_primary_schedule_individual_bank_details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_primary_schedule_individual_bank_details_primary_schedule_individual_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "primary_schedule_individual",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "primary_schedule_individual_client_details",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    ScheduleId = table.Column<Guid>(nullable: false),
                    ClientType = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Initials = table.Column<string>(nullable: true),
                    FirstNames = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<string>(nullable: true),
                    CountryOfBirth = table.Column<string>(nullable: true),
                    CityOfBirth = table.Column<string>(nullable: true),
                    Nationality = table.Column<string>(nullable: true),
                    EmpoymentStatus = table.Column<string>(nullable: true),
                    Employer = table.Column<string>(nullable: true),
                    Industry = table.Column<string>(nullable: true),
                    Occupation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_primary_schedule_individual_client_details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_primary_schedule_individual_client_details_primary_schedule_individual_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "primary_schedule_individual",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "primary_schedule_individual_contact_details",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ScheduleId = table.Column<Guid>(nullable: false),
                    UnitNumber = table.Column<string>(nullable: true),
                    Complex = table.Column<string>(nullable: true),
                    StreetNumber = table.Column<string>(nullable: true),
                    StreetName = table.Column<string>(nullable: true),
                    Suburb = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    PostalSameAsResidentual = table.Column<bool>(nullable: false),
                    PostalInCare = table.Column<bool>(nullable: false),
                    PostalInCareName = table.Column<string>(nullable: true),
                    PA_AddressLine_1 = table.Column<string>(nullable: true),
                    PA_AddressLine_2 = table.Column<string>(nullable: true),
                    PA_AddressLine_3 = table.Column<string>(nullable: true),
                    PA_AddressLine_4 = table.Column<string>(nullable: true),
                    PA_PostalCode = table.Column<string>(nullable: true),
                    PA_Country = table.Column<string>(nullable: true),
                    HomeNumber = table.Column<string>(nullable: true),
                    FaxNumber = table.Column<string>(nullable: true),
                    WorkNumber = table.Column<string>(nullable: true),
                    MobileNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_primary_schedule_individual_contact_details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_primary_schedule_individual_contact_details_primary_schedule_individual_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "primary_schedule_individual",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "primary_schedule_individual_decleration",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    ScheduleId = table.Column<Guid>(nullable: false),
                    NameSurname = table.Column<string>(nullable: true),
                    SignerCapacity = table.Column<string>(nullable: true),
                    DateSigned = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_primary_schedule_individual_decleration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_primary_schedule_individual_decleration_primary_schedule_individual_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "primary_schedule_individual",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "primary_schedule_individual_purpose_and_funding",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    ScheduleId = table.Column<Guid>(nullable: false),
                    NumberOfDeposits = table.Column<string>(nullable: true),
                    NumberOfWithdrrawals = table.Column<string>(nullable: true),
                    DepositsValue = table.Column<string>(nullable: true),
                    WithdrawalsValue = table.Column<string>(nullable: true),
                    SourceOfFunds = table.Column<string>(nullable: true),
                    SourceOfWealth = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_primary_schedule_individual_purpose_and_funding", x => x.Id);
                    table.ForeignKey(
                        name: "FK_primary_schedule_individual_purpose_and_funding_primary_schedule_individual_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "primary_schedule_individual",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "primary_schedule_individual_tax_residency",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    ScheduleId = table.Column<Guid>(nullable: false),
                    TaxNumber = table.Column<string>(nullable: true),
                    TaxObligations = table.Column<bool>(nullable: false),
                    UsCitizen = table.Column<bool>(nullable: false),
                    UsRelinquished = table.Column<bool>(nullable: false),
                    UsOther = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_primary_schedule_individual_tax_residency", x => x.Id);
                    table.ForeignKey(
                        name: "FK_primary_schedule_individual_tax_residency_primary_schedule_individual_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "primary_schedule_individual",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "primary_schedule_individual_identity_details",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    ClientDetailsId = table.Column<Guid>(nullable: false),
                    IdentificationType = table.Column<string>(nullable: true),
                    CountryOfIssure = table.Column<string>(nullable: true),
                    IdentificationNumber = table.Column<string>(nullable: true),
                    ExpiryDate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_primary_schedule_individual_identity_details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_primary_schedule_individual_identity_details_primary_schedule_individual_client_details_ClientDetailsId",
                        column: x => x.ClientDetailsId,
                        principalTable: "primary_schedule_individual_client_details",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "primary_schedule_individual_purpose_and_funding_option",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    PurposeAndFundingId = table.Column<Guid>(nullable: false),
                    InvestingIn = table.Column<string>(nullable: true),
                    Objective = table.Column<string>(nullable: true),
                    TimeFrame = table.Column<string>(nullable: true),
                    Activity = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_primary_schedule_individual_purpose_and_funding_option", x => x.Id);
                    table.ForeignKey(
                        name: "FK_primary_schedule_individual_purpose_and_funding_option_primary_schedule_individual_purpose_and_funding_PurposeAndFundingId",
                        column: x => x.PurposeAndFundingId,
                        principalTable: "primary_schedule_individual_purpose_and_funding",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "primary_schedule_individual_tax_residency_items",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TasResidencyId = table.Column<Guid>(nullable: false),
                    TaxResidencyId = table.Column<Guid>(nullable: false),
                    Country = table.Column<string>(nullable: true),
                    TinNumber = table.Column<string>(nullable: true),
                    TinUnavailableReason = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_primary_schedule_individual_tax_residency_items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_primary_schedule_individual_tax_residency_items_primary_schedule_individual_tax_residency_TaxResidencyId",
                        column: x => x.TaxResidencyId,
                        principalTable: "primary_schedule_individual_tax_residency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Created", "Email", "FirstName", "IdNumber", "LastName", "MobileNumber", "MobileVerified", "Modified", "Password", "Role" },
                values: new object[] { new Guid("912c3dff-5696-459c-b1d3-f302beebde56"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "root@aluma.co.za", "rootUser", "9000000000000", "root", "0810000000", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9891.XtQGurX/Nt8E6bE2daY7mw==.YoB8pd3M8QuRR/gof/ZVhVhXRA3Wcq6UAvvw6BFmy+w=", "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_primary_schedule_individual_bank_details_ScheduleId",
                table: "primary_schedule_individual_bank_details",
                column: "ScheduleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_primary_schedule_individual_client_details_ScheduleId",
                table: "primary_schedule_individual_client_details",
                column: "ScheduleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_primary_schedule_individual_contact_details_ScheduleId",
                table: "primary_schedule_individual_contact_details",
                column: "ScheduleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_primary_schedule_individual_decleration_ScheduleId",
                table: "primary_schedule_individual_decleration",
                column: "ScheduleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_primary_schedule_individual_identity_details_ClientDetailsId",
                table: "primary_schedule_individual_identity_details",
                column: "ClientDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_primary_schedule_individual_purpose_and_funding_ScheduleId",
                table: "primary_schedule_individual_purpose_and_funding",
                column: "ScheduleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_primary_schedule_individual_purpose_and_funding_option_PurposeAndFundingId",
                table: "primary_schedule_individual_purpose_and_funding_option",
                column: "PurposeAndFundingId");

            migrationBuilder.CreateIndex(
                name: "IX_primary_schedule_individual_tax_residency_ScheduleId",
                table: "primary_schedule_individual_tax_residency",
                column: "ScheduleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_primary_schedule_individual_tax_residency_items_TaxResidencyId",
                table: "primary_schedule_individual_tax_residency_items",
                column: "TaxResidencyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bank_details");

            migrationBuilder.DropTable(
                name: "primary_schedule_individual_bank_details");

            migrationBuilder.DropTable(
                name: "primary_schedule_individual_contact_details");

            migrationBuilder.DropTable(
                name: "primary_schedule_individual_decleration");

            migrationBuilder.DropTable(
                name: "primary_schedule_individual_identity_details");

            migrationBuilder.DropTable(
                name: "primary_schedule_individual_purpose_and_funding_option");

            migrationBuilder.DropTable(
                name: "primary_schedule_individual_tax_residency_items");

            migrationBuilder.DropTable(
                name: "primary_schedule_individual_client_details");

            migrationBuilder.DropTable(
                name: "primary_schedule_individual_purpose_and_funding");

            migrationBuilder.DropTable(
                name: "primary_schedule_individual_tax_residency");

            migrationBuilder.DropTable(
                name: "primary_schedule_individual");

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("912c3dff-5696-459c-b1d3-f302beebde56"));

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Created", "Email", "FirstName", "IdNumber", "LastName", "MobileNumber", "MobileVerified", "Modified", "Password", "Role" },
                values: new object[] { new Guid("863b9dd8-6e98-4a5c-a16e-198cc1949c46"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "root@aluma.co.za", "rootUser", "9000000000000", "root", "0810000000", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9257.6unCpoiH4RajOOnepvUemQ==.g/2g3cTi9vK1wRQvNqtIwGHDfVaTThtMCEgRFOZkwFU=", "Admin" });
        }
    }
}
