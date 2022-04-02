using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace JWTNET_5.Infrastructure.Migrations
{
    public partial class SeedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                            table: "AspNetRoles",
                            columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
                            values: new object[] { Guid.NewGuid().ToString(), "Buyer", "Buyer".ToUpper(), Guid.NewGuid().ToString() }
                        );

                    migrationBuilder.InsertData(
                        table: "AspNetRoles",
                        columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
                        values: new object[] { Guid.NewGuid().ToString(), "Seller", "Seller".ToUpper(), Guid.NewGuid().ToString() }
                    );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [AspNetRoles]");

        }
    }
}
