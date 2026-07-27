using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedPersonalDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "personal_details_address",
                table: "resumes",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "personal_details_city",
                table: "resumes",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "personal_details_country",
                table: "resumes",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "personal_details_email",
                table: "resumes",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "personal_details_first_name",
                table: "resumes",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "personal_details_job_titel",
                table: "resumes",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "personal_details_last_name",
                table: "resumes",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "personal_details_phone",
                table: "resumes",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "personal_details_photo",
                table: "resumes",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "personal_details_postal_code",
                table: "resumes",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "personal_details_address",
                table: "resumes");

            migrationBuilder.DropColumn(
                name: "personal_details_city",
                table: "resumes");

            migrationBuilder.DropColumn(
                name: "personal_details_country",
                table: "resumes");

            migrationBuilder.DropColumn(
                name: "personal_details_email",
                table: "resumes");

            migrationBuilder.DropColumn(
                name: "personal_details_first_name",
                table: "resumes");

            migrationBuilder.DropColumn(
                name: "personal_details_job_titel",
                table: "resumes");

            migrationBuilder.DropColumn(
                name: "personal_details_last_name",
                table: "resumes");

            migrationBuilder.DropColumn(
                name: "personal_details_phone",
                table: "resumes");

            migrationBuilder.DropColumn(
                name: "personal_details_photo",
                table: "resumes");

            migrationBuilder.DropColumn(
                name: "personal_details_postal_code",
                table: "resumes");
        }
    }
}
