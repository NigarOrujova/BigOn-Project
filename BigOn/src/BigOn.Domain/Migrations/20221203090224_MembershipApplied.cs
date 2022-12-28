using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BigOn.Domain.Migrations
{
    public partial class MembershipApplied : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Membership");

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "Types",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedByUserId",
                table: "Types",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "Tags",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedByUserId",
                table: "Tags",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "Subscribers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedByUserId",
                table: "Subscribers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "Sizes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedByUserId",
                table: "Sizes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedByUserId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "ProductImages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedByUserId",
                table: "ProductImages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "Materials",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedByUserId",
                table: "Materials",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "Faqs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedByUserId",
                table: "Faqs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "ContactPosts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedByUserId",
                table: "ContactPosts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "Colors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedByUserId",
                table: "Colors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedByUserId",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "Brands",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedByUserId",
                table: "Brands",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "BlogPosts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedByUserId",
                table: "BlogPosts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "BlogPostComments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedByUserId",
                table: "BlogPostComments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "Membership",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "Membership",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfileImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoverImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                schema: "Membership",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Membership",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Basket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Basket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Basket_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "Membership",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Basket_Users_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "Membership",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductCatalog",
                columns: table => new
                {
                    ColorId = table.Column<int>(type: "int", nullable: false),
                    SizeId = table.Column<int>(type: "int", nullable: false),
                    MaterialId = table.Column<int>(type: "int", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCatalog", x => new { x.ProductId, x.ColorId, x.SizeId, x.MaterialId, x.TypeId });
                    table.ForeignKey(
                        name: "FK_ProductCatalog_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCatalog_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCatalog_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCatalog_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCatalog_Types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCatalog_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "Membership",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductCatalog_Users_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "Membership",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                schema: "Membership",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Membership",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                schema: "Membership",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Membership",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                schema: "Membership",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Membership",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Membership",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                schema: "Membership",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Membership",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Types_CreatedByUserId",
                table: "Types",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Types_DeletedByUserId",
                table: "Types",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_CreatedByUserId",
                table: "Tags",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_DeletedByUserId",
                table: "Tags",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscribers_CreatedByUserId",
                table: "Subscribers",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscribers_DeletedByUserId",
                table: "Subscribers",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Sizes_CreatedByUserId",
                table: "Sizes",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Sizes_DeletedByUserId",
                table: "Sizes",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CreatedByUserId",
                table: "Products",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_DeletedByUserId",
                table: "Products",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_CreatedByUserId",
                table: "ProductImages",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_DeletedByUserId",
                table: "ProductImages",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_CreatedByUserId",
                table: "Materials",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_DeletedByUserId",
                table: "Materials",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Faqs_CreatedByUserId",
                table: "Faqs",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Faqs_DeletedByUserId",
                table: "Faqs",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactPosts_CreatedByUserId",
                table: "ContactPosts",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactPosts_DeletedByUserId",
                table: "ContactPosts",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Colors_CreatedByUserId",
                table: "Colors",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Colors_DeletedByUserId",
                table: "Colors",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CreatedByUserId",
                table: "Categories",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_DeletedByUserId",
                table: "Categories",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Brands_CreatedByUserId",
                table: "Brands",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Brands_DeletedByUserId",
                table: "Brands",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_CreatedByUserId",
                table: "BlogPosts",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_DeletedByUserId",
                table: "BlogPosts",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPostComments_CreatedByUserId",
                table: "BlogPostComments",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPostComments_DeletedByUserId",
                table: "BlogPostComments",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Basket_CreatedByUserId",
                table: "Basket",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Basket_DeletedByUserId",
                table: "Basket",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCatalog_ColorId",
                table: "ProductCatalog",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCatalog_CreatedByUserId",
                table: "ProductCatalog",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCatalog_DeletedByUserId",
                table: "ProductCatalog",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCatalog_MaterialId",
                table: "ProductCatalog",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCatalog_SizeId",
                table: "ProductCatalog",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCatalog_TypeId",
                table: "ProductCatalog",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                schema: "Membership",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "Membership",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                schema: "Membership",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                schema: "Membership",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                schema: "Membership",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "Membership",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "Membership",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPostComments_Users_CreatedByUserId",
                table: "BlogPostComments",
                column: "CreatedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPostComments_Users_DeletedByUserId",
                table: "BlogPostComments",
                column: "DeletedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPosts_Users_CreatedByUserId",
                table: "BlogPosts",
                column: "CreatedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPosts_Users_DeletedByUserId",
                table: "BlogPosts",
                column: "DeletedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Brands_Users_CreatedByUserId",
                table: "Brands",
                column: "CreatedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Brands_Users_DeletedByUserId",
                table: "Brands",
                column: "DeletedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Users_CreatedByUserId",
                table: "Categories",
                column: "CreatedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Users_DeletedByUserId",
                table: "Categories",
                column: "DeletedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Colors_Users_CreatedByUserId",
                table: "Colors",
                column: "CreatedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Colors_Users_DeletedByUserId",
                table: "Colors",
                column: "DeletedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactPosts_Users_CreatedByUserId",
                table: "ContactPosts",
                column: "CreatedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactPosts_Users_DeletedByUserId",
                table: "ContactPosts",
                column: "DeletedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Faqs_Users_CreatedByUserId",
                table: "Faqs",
                column: "CreatedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Faqs_Users_DeletedByUserId",
                table: "Faqs",
                column: "DeletedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_Users_CreatedByUserId",
                table: "Materials",
                column: "CreatedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_Users_DeletedByUserId",
                table: "Materials",
                column: "DeletedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_Users_CreatedByUserId",
                table: "ProductImages",
                column: "CreatedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_Users_DeletedByUserId",
                table: "ProductImages",
                column: "DeletedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_CreatedByUserId",
                table: "Products",
                column: "CreatedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_DeletedByUserId",
                table: "Products",
                column: "DeletedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sizes_Users_CreatedByUserId",
                table: "Sizes",
                column: "CreatedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sizes_Users_DeletedByUserId",
                table: "Sizes",
                column: "DeletedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscribers_Users_CreatedByUserId",
                table: "Subscribers",
                column: "CreatedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscribers_Users_DeletedByUserId",
                table: "Subscribers",
                column: "DeletedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Users_CreatedByUserId",
                table: "Tags",
                column: "CreatedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Users_DeletedByUserId",
                table: "Tags",
                column: "DeletedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Types_Users_CreatedByUserId",
                table: "Types",
                column: "CreatedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Types_Users_DeletedByUserId",
                table: "Types",
                column: "DeletedByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPostComments_Users_CreatedByUserId",
                table: "BlogPostComments");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogPostComments_Users_DeletedByUserId",
                table: "BlogPostComments");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogPosts_Users_CreatedByUserId",
                table: "BlogPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogPosts_Users_DeletedByUserId",
                table: "BlogPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_Brands_Users_CreatedByUserId",
                table: "Brands");

            migrationBuilder.DropForeignKey(
                name: "FK_Brands_Users_DeletedByUserId",
                table: "Brands");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Users_CreatedByUserId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Users_DeletedByUserId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Colors_Users_CreatedByUserId",
                table: "Colors");

            migrationBuilder.DropForeignKey(
                name: "FK_Colors_Users_DeletedByUserId",
                table: "Colors");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactPosts_Users_CreatedByUserId",
                table: "ContactPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactPosts_Users_DeletedByUserId",
                table: "ContactPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_Faqs_Users_CreatedByUserId",
                table: "Faqs");

            migrationBuilder.DropForeignKey(
                name: "FK_Faqs_Users_DeletedByUserId",
                table: "Faqs");

            migrationBuilder.DropForeignKey(
                name: "FK_Materials_Users_CreatedByUserId",
                table: "Materials");

            migrationBuilder.DropForeignKey(
                name: "FK_Materials_Users_DeletedByUserId",
                table: "Materials");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_Users_CreatedByUserId",
                table: "ProductImages");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_Users_DeletedByUserId",
                table: "ProductImages");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_CreatedByUserId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_DeletedByUserId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Sizes_Users_CreatedByUserId",
                table: "Sizes");

            migrationBuilder.DropForeignKey(
                name: "FK_Sizes_Users_DeletedByUserId",
                table: "Sizes");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscribers_Users_CreatedByUserId",
                table: "Subscribers");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscribers_Users_DeletedByUserId",
                table: "Subscribers");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Users_CreatedByUserId",
                table: "Tags");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Users_DeletedByUserId",
                table: "Tags");

            migrationBuilder.DropForeignKey(
                name: "FK_Types_Users_CreatedByUserId",
                table: "Types");

            migrationBuilder.DropForeignKey(
                name: "FK_Types_Users_DeletedByUserId",
                table: "Types");

            migrationBuilder.DropTable(
                name: "Basket");

            migrationBuilder.DropTable(
                name: "ProductCatalog");

            migrationBuilder.DropTable(
                name: "RoleClaims",
                schema: "Membership");

            migrationBuilder.DropTable(
                name: "UserClaims",
                schema: "Membership");

            migrationBuilder.DropTable(
                name: "UserLogins",
                schema: "Membership");

            migrationBuilder.DropTable(
                name: "UserRoles",
                schema: "Membership");

            migrationBuilder.DropTable(
                name: "UserTokens",
                schema: "Membership");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "Membership");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "Membership");

            migrationBuilder.DropIndex(
                name: "IX_Types_CreatedByUserId",
                table: "Types");

            migrationBuilder.DropIndex(
                name: "IX_Types_DeletedByUserId",
                table: "Types");

            migrationBuilder.DropIndex(
                name: "IX_Tags_CreatedByUserId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_DeletedByUserId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Subscribers_CreatedByUserId",
                table: "Subscribers");

            migrationBuilder.DropIndex(
                name: "IX_Subscribers_DeletedByUserId",
                table: "Subscribers");

            migrationBuilder.DropIndex(
                name: "IX_Sizes_CreatedByUserId",
                table: "Sizes");

            migrationBuilder.DropIndex(
                name: "IX_Sizes_DeletedByUserId",
                table: "Sizes");

            migrationBuilder.DropIndex(
                name: "IX_Products_CreatedByUserId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_DeletedByUserId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_ProductImages_CreatedByUserId",
                table: "ProductImages");

            migrationBuilder.DropIndex(
                name: "IX_ProductImages_DeletedByUserId",
                table: "ProductImages");

            migrationBuilder.DropIndex(
                name: "IX_Materials_CreatedByUserId",
                table: "Materials");

            migrationBuilder.DropIndex(
                name: "IX_Materials_DeletedByUserId",
                table: "Materials");

            migrationBuilder.DropIndex(
                name: "IX_Faqs_CreatedByUserId",
                table: "Faqs");

            migrationBuilder.DropIndex(
                name: "IX_Faqs_DeletedByUserId",
                table: "Faqs");

            migrationBuilder.DropIndex(
                name: "IX_ContactPosts_CreatedByUserId",
                table: "ContactPosts");

            migrationBuilder.DropIndex(
                name: "IX_ContactPosts_DeletedByUserId",
                table: "ContactPosts");

            migrationBuilder.DropIndex(
                name: "IX_Colors_CreatedByUserId",
                table: "Colors");

            migrationBuilder.DropIndex(
                name: "IX_Colors_DeletedByUserId",
                table: "Colors");

            migrationBuilder.DropIndex(
                name: "IX_Categories_CreatedByUserId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_DeletedByUserId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Brands_CreatedByUserId",
                table: "Brands");

            migrationBuilder.DropIndex(
                name: "IX_Brands_DeletedByUserId",
                table: "Brands");

            migrationBuilder.DropIndex(
                name: "IX_BlogPosts_CreatedByUserId",
                table: "BlogPosts");

            migrationBuilder.DropIndex(
                name: "IX_BlogPosts_DeletedByUserId",
                table: "BlogPosts");

            migrationBuilder.DropIndex(
                name: "IX_BlogPostComments_CreatedByUserId",
                table: "BlogPostComments");

            migrationBuilder.DropIndex(
                name: "IX_BlogPostComments_DeletedByUserId",
                table: "BlogPostComments");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Types");

            migrationBuilder.DropColumn(
                name: "DeletedByUserId",
                table: "Types");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "DeletedByUserId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Subscribers");

            migrationBuilder.DropColumn(
                name: "DeletedByUserId",
                table: "Subscribers");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Sizes");

            migrationBuilder.DropColumn(
                name: "DeletedByUserId",
                table: "Sizes");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DeletedByUserId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "DeletedByUserId",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "DeletedByUserId",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Faqs");

            migrationBuilder.DropColumn(
                name: "DeletedByUserId",
                table: "Faqs");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "ContactPosts");

            migrationBuilder.DropColumn(
                name: "DeletedByUserId",
                table: "ContactPosts");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Colors");

            migrationBuilder.DropColumn(
                name: "DeletedByUserId",
                table: "Colors");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "DeletedByUserId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "DeletedByUserId",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "DeletedByUserId",
                table: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "BlogPostComments");

            migrationBuilder.DropColumn(
                name: "DeletedByUserId",
                table: "BlogPostComments");
        }
    }
}
