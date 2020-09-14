using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace alumaApi.Migrations
{
    public partial class _043 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Branc",
                table: "primary_schedule_individual_bank_details");

            migrationBuilder.DropColumn(
                name: "BrancNumber",
                table: "primary_schedule_individual_bank_details");

            migrationBuilder.AddColumn<string>(
                name: "Branch",
                table: "primary_schedule_individual_bank_details",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BranchNumber",
                table: "primary_schedule_individual_bank_details",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "primary_schedule_trust",
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
                    table.PrimaryKey("PK_primary_schedule_trust", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "primary_schedule_trust_bank_details",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    AccountHolder = table.Column<string>(nullable: true),
                    Bank = table.Column<string>(nullable: true),
                    Branch = table.Column<string>(nullable: true),
                    BranchNumber = table.Column<string>(nullable: true),
                    AccountNumber = table.Column<string>(nullable: true),
                    AccountType = table.Column<string>(nullable: true),
                    ScheduleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_primary_schedule_trust_bank_details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_primary_schedule_trust_bank_details_primary_schedule_trust_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "primary_schedule_trust",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "primary_schedule_trust_details",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    ScheduleId = table.Column<Guid>(nullable: false),
                    TrustType = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Industry = table.Column<string>(nullable: true),
                    Purpose = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    InCareAddress = table.Column<string>(nullable: true),
                    InCareName = table.Column<string>(nullable: true),
                    ContactPerson = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_primary_schedule_trust_details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_primary_schedule_trust_details_primary_schedule_trust_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "primary_schedule_trust",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "primary_schedule_trust_entity_classification",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    ScheduleId = table.Column<Guid>(nullable: false),
                    FatchaPartner = table.Column<string>(nullable: true),
                    Managed = table.Column<string>(nullable: true),
                    OtherInvestment = table.Column<string>(nullable: true),
                    Depository = table.Column<string>(nullable: true),
                    GlobalIntermediaryId = table.Column<string>(nullable: true),
                    DocumentedTrust = table.Column<string>(nullable: true),
                    ManaginInstitutionName = table.Column<string>(nullable: true),
                    ManaginInstitutionGiin = table.Column<string>(nullable: true),
                    ManaginInstitutionCountry = table.Column<string>(nullable: true),
                    ComplaintFi = table.Column<string>(nullable: true),
                    ExemptOwner = table.Column<string>(nullable: true),
                    OwnerDocumented = table.Column<string>(nullable: true),
                    NonReporting = table.Column<string>(nullable: true),
                    AwaitingGiin = table.Column<string>(nullable: true),
                    Limited = table.Column<string>(nullable: true),
                    NonParticipating = table.Column<string>(nullable: true),
                    Other = table.Column<string>(nullable: true),
                    RegularTradeRelationTrue = table.Column<string>(nullable: true),
                    EntityName = table.Column<string>(nullable: true),
                    StockExchangeName = table.Column<string>(nullable: true),
                    GovernmentEntityTrue = table.Column<string>(nullable: true),
                    NfeInternationalTrue = table.Column<string>(nullable: true),
                    NfeLiquidatingTrue = table.Column<string>(nullable: true),
                    NfeTreasuryTrue = table.Column<string>(nullable: true),
                    NfeDirectTrue = table.Column<string>(nullable: true),
                    NfeDirectName = table.Column<string>(nullable: true),
                    SponsorName = table.Column<string>(nullable: true),
                    SponsorGiin = table.Column<string>(nullable: true),
                    NonProfit = table.Column<string>(nullable: true),
                    NonProfitDetails = table.Column<string>(nullable: true),
                    HightPassive = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_primary_schedule_trust_entity_classification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_primary_schedule_trust_entity_classification_primary_schedule_trust_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "primary_schedule_trust",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "primary_schedule_trust_tax_residency",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    TaxNumber = table.Column<string>(nullable: true),
                    PersonUsTaxObligations = table.Column<string>(nullable: true),
                    UsRegistered = table.Column<string>(nullable: true),
                    UsJurisdiction = table.Column<string>(nullable: true),
                    AnyUsPersons = table.Column<string>(nullable: true),
                    TrustUsTaxObligations = table.Column<string>(nullable: true),
                    InternationalObligations = table.Column<string>(nullable: true),
                    UsOther = table.Column<string>(nullable: true),
                    ScheduleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_primary_schedule_trust_tax_residency", x => x.Id);
                    table.ForeignKey(
                        name: "FK_primary_schedule_trust_tax_residency_primary_schedule_trust_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "primary_schedule_trust",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "primary_schedule_trust_details_address_items",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    UnitNumber = table.Column<string>(nullable: true),
                    ComplexName = table.Column<string>(nullable: true),
                    StreetNumber = table.Column<string>(nullable: true),
                    StreetName = table.Column<string>(nullable: true),
                    Suburb = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    TrustDetailsId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_primary_schedule_trust_details_address_items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_primary_schedule_trust_details_address_items_primary_schedule_trust_details_TrustDetailsId",
                        column: x => x.TrustDetailsId,
                        principalTable: "primary_schedule_trust_details",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "primary_schedule_trust_tax_residency_item",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Country = table.Column<string>(nullable: true),
                    TinNumber = table.Column<string>(nullable: true),
                    TinUnavailableReason = table.Column<string>(nullable: true),
                    TrustTaxResidencyId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_primary_schedule_trust_tax_residency_item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_primary_schedule_trust_tax_residency_item_primary_schedule_trust_tax_residency_TrustTaxResidencyId",
                        column: x => x.TrustTaxResidencyId,
                        principalTable: "primary_schedule_trust_tax_residency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "broker_details",
                keyColumn: "Id",
                keyValue: new Guid("3f7cb4b6-3b03-4b28-b012-e602ec5a3aaf"),
                columns: new[] { "Created", "EmploymentDate", "Modified" },
                values: new object[] { new DateTime(2020, 9, 9, 8, 56, 50, 597, DateTimeKind.Local).AddTicks(8940), new DateTime(2019, 9, 9, 8, 56, 50, 598, DateTimeKind.Local).AddTicks(6850), new DateTime(2020, 9, 9, 8, 56, 50, 597, DateTimeKind.Local).AddTicks(9002) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("3f7cb4b6-3b03-4b28-b012-e602ec5c36af"),
                columns: new[] { "Created", "Modified", "Password" },
                values: new object[] { new DateTime(2020, 9, 9, 8, 56, 50, 575, DateTimeKind.Local).AddTicks(9624), new DateTime(2020, 9, 9, 8, 56, 50, 576, DateTimeKind.Local).AddTicks(533), "9068.i5erJMraArjUw/AP37T/eA==.z82bfjGgTlvZc82sa4wkRRYPHYAwK2oXp50a8O7Wr0s=" });

            migrationBuilder.CreateIndex(
                name: "IX_primary_schedule_trust_bank_details_ScheduleId",
                table: "primary_schedule_trust_bank_details",
                column: "ScheduleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_primary_schedule_trust_details_ScheduleId",
                table: "primary_schedule_trust_details",
                column: "ScheduleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_primary_schedule_trust_details_address_items_TrustDetailsId",
                table: "primary_schedule_trust_details_address_items",
                column: "TrustDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_primary_schedule_trust_entity_classification_ScheduleId",
                table: "primary_schedule_trust_entity_classification",
                column: "ScheduleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_primary_schedule_trust_tax_residency_ScheduleId",
                table: "primary_schedule_trust_tax_residency",
                column: "ScheduleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_primary_schedule_trust_tax_residency_item_TrustTaxResidencyId",
                table: "primary_schedule_trust_tax_residency_item",
                column: "TrustTaxResidencyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "primary_schedule_trust_bank_details");

            migrationBuilder.DropTable(
                name: "primary_schedule_trust_details_address_items");

            migrationBuilder.DropTable(
                name: "primary_schedule_trust_entity_classification");

            migrationBuilder.DropTable(
                name: "primary_schedule_trust_tax_residency_item");

            migrationBuilder.DropTable(
                name: "primary_schedule_trust_details");

            migrationBuilder.DropTable(
                name: "primary_schedule_trust_tax_residency");

            migrationBuilder.DropTable(
                name: "primary_schedule_trust");

            migrationBuilder.DropColumn(
                name: "Branch",
                table: "primary_schedule_individual_bank_details");

            migrationBuilder.DropColumn(
                name: "BranchNumber",
                table: "primary_schedule_individual_bank_details");

            migrationBuilder.AddColumn<string>(
                name: "Branc",
                table: "primary_schedule_individual_bank_details",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BrancNumber",
                table: "primary_schedule_individual_bank_details",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "broker_details",
                keyColumn: "Id",
                keyValue: new Guid("3f7cb4b6-3b03-4b28-b012-e602ec5a3aaf"),
                columns: new[] { "Created", "EmploymentDate", "Modified" },
                values: new object[] { new DateTime(2020, 9, 7, 15, 29, 30, 968, DateTimeKind.Local).AddTicks(7761), new DateTime(2019, 9, 7, 15, 29, 30, 969, DateTimeKind.Local).AddTicks(2852), new DateTime(2020, 9, 7, 15, 29, 30, 968, DateTimeKind.Local).AddTicks(7816) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("3f7cb4b6-3b03-4b28-b012-e602ec5c36af"),
                columns: new[] { "Created", "Modified", "Password" },
                values: new object[] { new DateTime(2020, 9, 7, 15, 29, 30, 955, DateTimeKind.Local).AddTicks(4037), new DateTime(2020, 9, 7, 15, 29, 30, 955, DateTimeKind.Local).AddTicks(4626), "9409.T0yzZrmhp2sR6DGevcr1GA==.r5RKE9Q8TbLi3Obc6VOxueBpxG02UnH+x4MgiInHBc8=" });
        }
    }
}
