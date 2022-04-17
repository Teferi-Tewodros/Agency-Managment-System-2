using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgencyManagmentSystem.Data.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryNameEnglish = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Maid",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SurName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GIVEN_NAMES = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Marital_status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Religion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Job = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Qualifications = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Experience = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Experience_Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Passport_NO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Passport_issue_place = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Passport_issue_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Passport_expire = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsSelected = table.Column<bool>(type: "bit", nullable: false),
                    IsRejected = table.Column<bool>(type: "bit", nullable: false),
                    TimeStamp = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maid", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Agents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Agency_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Owner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Agentemail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agents_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApprovalRequest",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Discription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApprovalRequest_Maid_MaidId",
                        column: x => x.MaidId,
                        principalTable: "Maid",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Approved",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Discription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Approved", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Approved_Maid_MaidId",
                        column: x => x.MaidId,
                        principalTable: "Maid",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BioData",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Discription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BioData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BioData_Maid_MaidId",
                        column: x => x.MaidId,
                        principalTable: "Maid",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CocAuthonticity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Discription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CocAuthonticity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CocAuthonticity_Maid_MaidId",
                        column: x => x.MaidId,
                        principalTable: "Maid",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaidAdress",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Wereda = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kebele = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    House_No = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaidAdress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaidAdress_Maid_MaidId",
                        column: x => x.MaidId,
                        principalTable: "Maid",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaidKin",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Relative_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Relative_kinship = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Relative_phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Relative_address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Relative_Id = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaidKin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaidKin_Maid_MaidId",
                        column: x => x.MaidId,
                        principalTable: "Maid",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MolsaApprovalLattere",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Discription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MolsaApprovalLattere", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MolsaApprovalLattere_Maid_MaidId",
                        column: x => x.MaidId,
                        principalTable: "Maid",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScannedCoc",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataFiles = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScannedCoc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScannedCoc_Maid_MaidId",
                        column: x => x.MaidId,
                        principalTable: "Maid",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScannedContactPersonID",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataFiles = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScannedContactPersonID", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScannedContactPersonID_Maid_MaidId",
                        column: x => x.MaidId,
                        principalTable: "Maid",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScannedMedical",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataFiles = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScannedMedical", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScannedMedical_Maid_MaidId",
                        column: x => x.MaidId,
                        principalTable: "Maid",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScannedMiniPhoto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataFiles = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScannedMiniPhoto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScannedMiniPhoto_Maid_MaidId",
                        column: x => x.MaidId,
                        principalTable: "Maid",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScannedNational_Id",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataFiles = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScannedNational_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScannedNational_Id_Maid_MaidId",
                        column: x => x.MaidId,
                        principalTable: "Maid",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScannedPassport",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataFiles = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScannedPassport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScannedPassport_Maid_MaidId",
                        column: x => x.MaidId,
                        principalTable: "Maid",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScannedPoliceClearance",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataFiles = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScannedPoliceClearance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScannedPoliceClearance_Maid_MaidId",
                        column: x => x.MaidId,
                        principalTable: "Maid",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScannedSigniture",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataFiles = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScannedSigniture", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScannedSigniture_Maid_MaidId",
                        column: x => x.MaidId,
                        principalTable: "Maid",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScannedwholePhoto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataFiles = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScannedwholePhoto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScannedwholePhoto_Maid_MaidId",
                        column: x => x.MaidId,
                        principalTable: "Maid",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VizaAuthonticity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Discription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VizaAuthonticity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VizaAuthonticity_Maid_MaidId",
                        column: x => x.MaidId,
                        principalTable: "Maid",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contrat",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AgentsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Employer_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Employer_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    National_Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Employer_Telephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Employer_email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contrat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contrat_Agents_AgentsId",
                        column: x => x.AgentsId,
                        principalTable: "Agents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contrat_Maid_MaidId",
                        column: x => x.MaidId,
                        principalTable: "Maid",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agents_CountryId",
                table: "Agents",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRequest_MaidId",
                table: "ApprovalRequest",
                column: "MaidId");

            migrationBuilder.CreateIndex(
                name: "IX_Approved_MaidId",
                table: "Approved",
                column: "MaidId");

            migrationBuilder.CreateIndex(
                name: "IX_BioData_MaidId",
                table: "BioData",
                column: "MaidId");

            migrationBuilder.CreateIndex(
                name: "IX_CocAuthonticity_MaidId",
                table: "CocAuthonticity",
                column: "MaidId");

            migrationBuilder.CreateIndex(
                name: "IX_Contrat_AgentsId",
                table: "Contrat",
                column: "AgentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Contrat_MaidId",
                table: "Contrat",
                column: "MaidId");

            migrationBuilder.CreateIndex(
                name: "IX_MaidAdress_MaidId",
                table: "MaidAdress",
                column: "MaidId");

            migrationBuilder.CreateIndex(
                name: "IX_MaidKin_MaidId",
                table: "MaidKin",
                column: "MaidId");

            migrationBuilder.CreateIndex(
                name: "IX_MolsaApprovalLattere_MaidId",
                table: "MolsaApprovalLattere",
                column: "MaidId");

            migrationBuilder.CreateIndex(
                name: "IX_ScannedCoc_MaidId",
                table: "ScannedCoc",
                column: "MaidId");

            migrationBuilder.CreateIndex(
                name: "IX_ScannedContactPersonID_MaidId",
                table: "ScannedContactPersonID",
                column: "MaidId");

            migrationBuilder.CreateIndex(
                name: "IX_ScannedMedical_MaidId",
                table: "ScannedMedical",
                column: "MaidId");

            migrationBuilder.CreateIndex(
                name: "IX_ScannedMiniPhoto_MaidId",
                table: "ScannedMiniPhoto",
                column: "MaidId");

            migrationBuilder.CreateIndex(
                name: "IX_ScannedNational_Id_MaidId",
                table: "ScannedNational_Id",
                column: "MaidId");

            migrationBuilder.CreateIndex(
                name: "IX_ScannedPassport_MaidId",
                table: "ScannedPassport",
                column: "MaidId");

            migrationBuilder.CreateIndex(
                name: "IX_ScannedPoliceClearance_MaidId",
                table: "ScannedPoliceClearance",
                column: "MaidId");

            migrationBuilder.CreateIndex(
                name: "IX_ScannedSigniture_MaidId",
                table: "ScannedSigniture",
                column: "MaidId");

            migrationBuilder.CreateIndex(
                name: "IX_ScannedwholePhoto_MaidId",
                table: "ScannedwholePhoto",
                column: "MaidId");

            migrationBuilder.CreateIndex(
                name: "IX_VizaAuthonticity_MaidId",
                table: "VizaAuthonticity",
                column: "MaidId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApprovalRequest");

            migrationBuilder.DropTable(
                name: "Approved");

            migrationBuilder.DropTable(
                name: "BioData");

            migrationBuilder.DropTable(
                name: "CocAuthonticity");

            migrationBuilder.DropTable(
                name: "Contrat");

            migrationBuilder.DropTable(
                name: "MaidAdress");

            migrationBuilder.DropTable(
                name: "MaidKin");

            migrationBuilder.DropTable(
                name: "MolsaApprovalLattere");

            migrationBuilder.DropTable(
                name: "ScannedCoc");

            migrationBuilder.DropTable(
                name: "ScannedContactPersonID");

            migrationBuilder.DropTable(
                name: "ScannedMedical");

            migrationBuilder.DropTable(
                name: "ScannedMiniPhoto");

            migrationBuilder.DropTable(
                name: "ScannedNational_Id");

            migrationBuilder.DropTable(
                name: "ScannedPassport");

            migrationBuilder.DropTable(
                name: "ScannedPoliceClearance");

            migrationBuilder.DropTable(
                name: "ScannedSigniture");

            migrationBuilder.DropTable(
                name: "ScannedwholePhoto");

            migrationBuilder.DropTable(
                name: "VizaAuthonticity");

            migrationBuilder.DropTable(
                name: "Agents");

            migrationBuilder.DropTable(
                name: "Maid");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
