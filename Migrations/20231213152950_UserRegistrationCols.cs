using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpiritLink.Migrations
{
    /// <inheritdoc />
    public partial class UserRegistrationCols : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FirstTimers",
                columns: table => new
                {
                    FirstTimerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    GPSAddress = table.Column<string>(name: "GPS Address", type: "nvarchar(12)", maxLength: 12, nullable: true),
                    Status = table.Column<string>(type: "char(50)", unicode: false, fixedLength: true, maxLength: 50, nullable: true),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    WhoInvited = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AreaDescription = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK5", x => x.FirstTimerName)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "NewConverts",
                columns: table => new
                {
                    ConvertName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    GPSAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    WhoInvited = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AreaDescription = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK6", x => x.ConvertName)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "Pastor",
                columns: table => new
                {
                    PastorName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK3", x => x.PastorName)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BacentaLeader",
                columns: table => new
                {
                    LeaderName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LeaderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PastorName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK4", x => new { x.LeaderName, x.LeaderId, x.PastorName })
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "RefPastor7",
                        column: x => x.PastorName,
                        principalTable: "Pastor",
                        principalColumn: "PastorName");
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    MemberName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PastorName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ConvertName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FirstTimerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ActiveStatus = table.Column<bool>(type: "bit", nullable: true),
                    GPSAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Basonta = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Location = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    AreaDescription = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK7", x => new { x.MemberName, x.PastorName, x.ConvertName, x.FirstTimerName })
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "RefFirstTimers10",
                        column: x => x.FirstTimerName,
                        principalTable: "FirstTimers",
                        principalColumn: "FirstTimerName");
                    table.ForeignKey(
                        name: "RefNewConverts9",
                        column: x => x.ConvertName,
                        principalTable: "NewConverts",
                        principalColumn: "ConvertName");
                    table.ForeignKey(
                        name: "RefPastor8",
                        column: x => x.PastorName,
                        principalTable: "Pastor",
                        principalColumn: "PastorName");
                });

            migrationBuilder.CreateTable(
                name: "LaySchool",
                columns: table => new
                {
                    SchoolName = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: false),
                    SchoolId = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: false),
                    PastorName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MemberName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ConvertName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FirstTimerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LeaderId = table.Column<int>(type: "int", nullable: false),
                    LeaderName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MemberId = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: true),
                    Date = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK8", x => new { x.SchoolName, x.SchoolId, x.PastorName, x.MemberName, x.ConvertName, x.FirstTimerName, x.LeaderId, x.LeaderName })
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "RefBacentaLeader13",
                        columns: x => new { x.LeaderName, x.LeaderId, x.PastorName },
                        principalTable: "BacentaLeader",
                        principalColumns: new[] { "LeaderName", "LeaderId", "PastorName" });
                    table.ForeignKey(
                        name: "RefMembers11",
                        columns: x => new { x.MemberName, x.PastorName, x.ConvertName, x.FirstTimerName },
                        principalTable: "Members",
                        principalColumns: new[] { "MemberName", "PastorName", "ConvertName", "FirstTimerName" });
                    table.ForeignKey(
                        name: "RefPastor6",
                        column: x => x.PastorName,
                        principalTable: "Pastor",
                        principalColumn: "PastorName");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BacentaLeader_PastorName",
                table: "BacentaLeader",
                column: "PastorName");

            migrationBuilder.CreateIndex(
                name: "IX_LaySchool_LeaderName_LeaderId_PastorName",
                table: "LaySchool",
                columns: new[] { "LeaderName", "LeaderId", "PastorName" });

            migrationBuilder.CreateIndex(
                name: "IX_LaySchool_MemberName_PastorName_ConvertName_FirstTimerName",
                table: "LaySchool",
                columns: new[] { "MemberName", "PastorName", "ConvertName", "FirstTimerName" });

            migrationBuilder.CreateIndex(
                name: "IX_LaySchool_PastorName",
                table: "LaySchool",
                column: "PastorName");

            migrationBuilder.CreateIndex(
                name: "IX_Members_ConvertName",
                table: "Members",
                column: "ConvertName");

            migrationBuilder.CreateIndex(
                name: "IX_Members_FirstTimerName",
                table: "Members",
                column: "FirstTimerName");

            migrationBuilder.CreateIndex(
                name: "IX_Members_PastorName",
                table: "Members",
                column: "PastorName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "LaySchool");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "BacentaLeader");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "FirstTimers");

            migrationBuilder.DropTable(
                name: "NewConverts");

            migrationBuilder.DropTable(
                name: "Pastor");
        }
    }
}
