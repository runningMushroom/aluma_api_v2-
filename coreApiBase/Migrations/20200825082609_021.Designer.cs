﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using alumaApi.Data;

namespace alumaApi.Migrations
{
    [DbContext(typeof(DefaultDbContext))]
    [Migration("20200825082609_021")]
    partial class _021
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("alumaApi.Models.AdvisorAdviseModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ApplicationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Introduction")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaterialInformation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("StepId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("advisor_advise");
                });

            modelBuilder.Entity("alumaApi.Models.AdvisorAdvisedProductsModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AdvisorAdviseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<double>("LumpSum")
                        .HasColumnType("float");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<int>("Product")
                        .HasColumnType("int");

                    b.Property<double>("RecurringAmount")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("AdvisorAdviseId");

                    b.ToTable("advisor_advised_products");
                });

            modelBuilder.Entity("alumaApi.Models.ApplicationDocumentsModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ApplicationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("B64Prefix")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("DocuemtnData")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("DocumentType")
                        .HasColumnType("int");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId");

                    b.ToTable("application_documents");
                });

            modelBuilder.Entity("alumaApi.Models.ApplicationStepModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("ActiveStep")
                        .HasColumnType("bit");

                    b.Property<Guid>("ApplicationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Complete")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DataId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("FactoryId")
                        .HasColumnType("int");

                    b.Property<string>("FactoryStep")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<string>("ScheduleType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StepType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId");

                    b.ToTable("application_steps");
                });

            modelBuilder.Entity("alumaApi.Models.ApplicationsModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BdaNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Signed")
                        .HasColumnType("bit");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("application");
                });

            modelBuilder.Entity("alumaApi.Models.BankVerificationsModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AccOpen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AcceptCredits")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AcceptDebits")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AccountId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AccountNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AccountType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ApplicationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BankName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BranchCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("FoundAtBank")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdNumberMatch")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Initials")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NamesMatch")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OlderThan3Months")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Reference")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SearchData")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("StepId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeCorrect")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VerificationType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("bank_verification");
                });

            modelBuilder.Entity("alumaApi.Models.OtpModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ClientEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Otp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OtpType")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("otp");
                });

            modelBuilder.Entity("alumaApi.Models.RiskProfileModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Advisor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Aggressive")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("AgreeWithOutcome")
                        .HasColumnType("bit");

                    b.Property<Guid>("ApplicationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Client")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Conservative")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedOn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DerivedProfile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Goal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentityNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InvestmentTerm")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Moderate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModeratelyAggressive")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModeratelyConservative")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Reason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RequiredRisk")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RiskCapacity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RiskTolerance")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("StepId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("advisorNotes")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("risk_profile");
                });

            modelBuilder.Entity("alumaApi.Models.Schedules.PrimaryIndividual.BankDetailsModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AccountHolder")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AccountNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AccountType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Bank")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Branc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BrancNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ScheduleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ScheduleId")
                        .IsUnique();

                    b.ToTable("primary_schedule_individual_bank_details");
                });

            modelBuilder.Entity("alumaApi.Models.Schedules.PrimaryIndividual.ClientDetailsModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CityOfBirth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryOfBirth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("DateOfBirth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Employer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmpoymentStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstNames")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Industry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Initials")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nationality")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Occupation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ScheduleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ScheduleId")
                        .IsUnique();

                    b.ToTable("primary_schedule_individual_client_details");
                });

            modelBuilder.Entity("alumaApi.Models.Schedules.PrimaryIndividual.ContactDetailsModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Complex")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobileNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PA_City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PA_Complex")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PA_Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PA_PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PA_StreetName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PA_StreetNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PA_Suburb")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PA_UnitNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalInCareName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ScheduleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("StreetName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Suburb")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UnitNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ScheduleId")
                        .IsUnique();

                    b.ToTable("primary_schedule_individual_contact_details");
                });

            modelBuilder.Entity("alumaApi.Models.Schedules.PrimaryIndividual.DeclerationsModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("DateSigned")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("NameSurname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ScheduleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SignerCapacity")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ScheduleId")
                        .IsUnique();

                    b.ToTable("primary_schedule_individual_decleration");
                });

            modelBuilder.Entity("alumaApi.Models.Schedules.PrimaryIndividual.IdentityDetailsModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClientDetailsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CountryOfIssure")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("ExpiryDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentificationNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentificationType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ClientDetailsId");

                    b.ToTable("primary_schedule_individual_identity_details");
                });

            modelBuilder.Entity("alumaApi.Models.Schedules.PrimaryIndividual.PurposeAndFundingModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("DepositsValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("NumberOfDeposits")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumberOfWithdrrawals")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ScheduleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SourceOfFunds")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SourceOfWealth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WithdrawalsValue")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ScheduleId")
                        .IsUnique();

                    b.ToTable("primary_schedule_individual_purpose_and_funding");
                });

            modelBuilder.Entity("alumaApi.Models.Schedules.PrimaryIndividual.PurposeOptionModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Activity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("InvestingIn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Objective")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PurposeAndFundingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TimeFrame")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PurposeAndFundingId");

                    b.ToTable("primary_schedule_individual_purpose_and_funding_option");
                });

            modelBuilder.Entity("alumaApi.Models.Schedules.PrimaryIndividual.TaxResidencyItemsModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TasResidencyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TaxResidencyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TinNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TinUnavailableReason")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TaxResidencyId");

                    b.ToTable("primary_schedule_individual_tax_residency_items");
                });

            modelBuilder.Entity("alumaApi.Models.Schedules.PrimaryIndividual.TaxResidencyModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ScheduleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TaxNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TaxObligations")
                        .HasColumnType("bit");

                    b.Property<bool>("UsCitizen")
                        .HasColumnType("bit");

                    b.Property<bool>("UsOther")
                        .HasColumnType("bit");

                    b.Property<bool>("UsRelinquished")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ScheduleId")
                        .IsUnique();

                    b.ToTable("primary_schedule_individual_tax_residency");
                });

            modelBuilder.Entity("alumaApi.Models.Schedules.PrimaryIndividualModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ApplicationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("StepId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("primary_schedule_individual");
                });

            modelBuilder.Entity("alumaApi.Models.UserModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("IdNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(13)")
                        .HasMaxLength(13);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("MobileNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("MobileVerified")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("IdNumber")
                        .IsUnique();

                    b.HasIndex("MobileNumber")
                        .IsUnique()
                        .HasFilter("[MobileNumber] IS NOT NULL");

                    b.ToTable("users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("59c2dac2-89e8-49f0-ac59-f408d4d3eea6"),
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "root@aluma.co.za",
                            FirstName = "rootUser",
                            IdNumber = "9000000000000",
                            LastName = "root",
                            MobileNumber = "0810000000",
                            MobileVerified = true,
                            Modified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Password = "9627.w4KQ+piAmzYuM6oA075+Hw==.Kd46aDRUC2lJcRbW/IeIToxAk53bs+WX4QtSrDbbDyc=",
                            Role = "Admin"
                        });
                });

            modelBuilder.Entity("alumaApi.Models.AdvisorAdvisedProductsModel", b =>
                {
                    b.HasOne("alumaApi.Models.AdvisorAdviseModel", "AdvisorAdvise")
                        .WithMany("AdvisedProducts")
                        .HasForeignKey("AdvisorAdviseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("alumaApi.Models.ApplicationDocumentsModel", b =>
                {
                    b.HasOne("alumaApi.Models.ApplicationsModel", "Application")
                        .WithMany("Documents")
                        .HasForeignKey("ApplicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("alumaApi.Models.ApplicationStepModel", b =>
                {
                    b.HasOne("alumaApi.Models.ApplicationsModel", "Application")
                        .WithMany("Steps")
                        .HasForeignKey("ApplicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("alumaApi.Models.ApplicationsModel", b =>
                {
                    b.HasOne("alumaApi.Models.UserModel", "User")
                        .WithMany("Applications")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("alumaApi.Models.Schedules.PrimaryIndividual.BankDetailsModel", b =>
                {
                    b.HasOne("alumaApi.Models.Schedules.PrimaryIndividualModel", "Schedule")
                        .WithOne("BankDetails")
                        .HasForeignKey("alumaApi.Models.Schedules.PrimaryIndividual.BankDetailsModel", "ScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("alumaApi.Models.Schedules.PrimaryIndividual.ClientDetailsModel", b =>
                {
                    b.HasOne("alumaApi.Models.Schedules.PrimaryIndividualModel", "Schedule")
                        .WithOne("ClientDetails")
                        .HasForeignKey("alumaApi.Models.Schedules.PrimaryIndividual.ClientDetailsModel", "ScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("alumaApi.Models.Schedules.PrimaryIndividual.ContactDetailsModel", b =>
                {
                    b.HasOne("alumaApi.Models.Schedules.PrimaryIndividualModel", "Schedule")
                        .WithOne("ContactDetails")
                        .HasForeignKey("alumaApi.Models.Schedules.PrimaryIndividual.ContactDetailsModel", "ScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("alumaApi.Models.Schedules.PrimaryIndividual.DeclerationsModel", b =>
                {
                    b.HasOne("alumaApi.Models.Schedules.PrimaryIndividualModel", "Schedule")
                        .WithOne("Declerations")
                        .HasForeignKey("alumaApi.Models.Schedules.PrimaryIndividual.DeclerationsModel", "ScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("alumaApi.Models.Schedules.PrimaryIndividual.IdentityDetailsModel", b =>
                {
                    b.HasOne("alumaApi.Models.Schedules.PrimaryIndividual.ClientDetailsModel", "ClientDetails")
                        .WithMany("IdentityDetails")
                        .HasForeignKey("ClientDetailsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("alumaApi.Models.Schedules.PrimaryIndividual.PurposeAndFundingModel", b =>
                {
                    b.HasOne("alumaApi.Models.Schedules.PrimaryIndividualModel", "Schedule")
                        .WithOne("PurposeAndFunding")
                        .HasForeignKey("alumaApi.Models.Schedules.PrimaryIndividual.PurposeAndFundingModel", "ScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("alumaApi.Models.Schedules.PrimaryIndividual.PurposeOptionModel", b =>
                {
                    b.HasOne("alumaApi.Models.Schedules.PrimaryIndividual.PurposeAndFundingModel", "PurposeAndFunding")
                        .WithMany("PurposeOptions")
                        .HasForeignKey("PurposeAndFundingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("alumaApi.Models.Schedules.PrimaryIndividual.TaxResidencyItemsModel", b =>
                {
                    b.HasOne("alumaApi.Models.Schedules.PrimaryIndividual.TaxResidencyModel", "TaxResidency")
                        .WithMany("TaxResidencyItems")
                        .HasForeignKey("TaxResidencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("alumaApi.Models.Schedules.PrimaryIndividual.TaxResidencyModel", b =>
                {
                    b.HasOne("alumaApi.Models.Schedules.PrimaryIndividualModel", "Schedule")
                        .WithOne("TaxResidency")
                        .HasForeignKey("alumaApi.Models.Schedules.PrimaryIndividual.TaxResidencyModel", "ScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
