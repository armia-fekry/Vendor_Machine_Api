using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace JWT_NET_5.Migrations
{
    public partial class SeedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles"
                , columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" }
                , values: new object[] { Guid.NewGuid().ToString(), "User", "USER", Guid.NewGuid().ToString() });

            migrationBuilder.InsertData(
                    table: "AspNetRoles"
                    , columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" }
                    , values: new object[] { Guid.NewGuid().ToString(), "Admin", "ADMIN", Guid.NewGuid().ToString() });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from AspNetRoles");
        }
    }
}
