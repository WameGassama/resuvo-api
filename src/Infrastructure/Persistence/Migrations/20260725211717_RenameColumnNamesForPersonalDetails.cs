using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RenameColumnNamesForPersonalDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "personal_details_postal_code",
                table: "resumes",
                newName: "postal_code");

            migrationBuilder.RenameColumn(
                name: "personal_details_photo",
                table: "resumes",
                newName: "photo");

            migrationBuilder.RenameColumn(
                name: "personal_details_phone",
                table: "resumes",
                newName: "phone");

            migrationBuilder.RenameColumn(
                name: "personal_details_last_name",
                table: "resumes",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "personal_details_first_name",
                table: "resumes",
                newName: "first_name");

            migrationBuilder.RenameColumn(
                name: "personal_details_email",
                table: "resumes",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "personal_details_country",
                table: "resumes",
                newName: "country");

            migrationBuilder.RenameColumn(
                name: "personal_details_city",
                table: "resumes",
                newName: "city");

            migrationBuilder.RenameColumn(
                name: "personal_details_address",
                table: "resumes",
                newName: "address");

            migrationBuilder.RenameColumn(
                name: "personal_details_job_titel",
                table: "resumes",
                newName: "job_title");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "postal_code",
                table: "resumes",
                newName: "personal_details_postal_code");

            migrationBuilder.RenameColumn(
                name: "photo",
                table: "resumes",
                newName: "personal_details_photo");

            migrationBuilder.RenameColumn(
                name: "phone",
                table: "resumes",
                newName: "personal_details_phone");

            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "resumes",
                newName: "personal_details_last_name");

            migrationBuilder.RenameColumn(
                name: "first_name",
                table: "resumes",
                newName: "personal_details_first_name");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "resumes",
                newName: "personal_details_email");

            migrationBuilder.RenameColumn(
                name: "country",
                table: "resumes",
                newName: "personal_details_country");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "resumes",
                newName: "personal_details_city");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "resumes",
                newName: "personal_details_address");

            migrationBuilder.RenameColumn(
                name: "job_title",
                table: "resumes",
                newName: "personal_details_job_titel");
        }
    }
}
