using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymMangment.DAL.Migrations
{
    /// <inheritdoc />
    public partial class dataall : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "phoneNumberCheck",
                table: "Members");

            migrationBuilder.AddCheckConstraint(
                name: "phoneNumberCheck",
                table: "Members",
                sql: "phonenumber LIKE '010%' OR phonenumber LIKE '011%' OR phonenumber LIKE '012%' OR phonenumber LIKE '015%'");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "phoneNumberCheck",
                table: "Members");

            migrationBuilder.AddCheckConstraint(
                name: "phoneNumberCheck",
                table: "Members",
                sql: "phonenumber LIKE '010% OR 011% OR 012% OR 015%'");
        }
    }
}
