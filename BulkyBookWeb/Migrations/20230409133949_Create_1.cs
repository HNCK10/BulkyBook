using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BulkyBookWeb.Migrations
{
    /// <inheritdoc />
    public partial class Create_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SignIn",
                table: "SignIn");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Registration",
                table: "Registration");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PasswordReset",
                table: "PasswordReset");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PasswordChange",
                table: "PasswordChange");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Authentication",
                table: "Authentication");

            migrationBuilder.RenameTable(
                name: "SignIn",
                newName: "Login");

            migrationBuilder.RenameTable(
                name: "Registration",
                newName: "Register");

            migrationBuilder.RenameTable(
                name: "PasswordReset",
                newName: "ResetPassword");

            migrationBuilder.RenameTable(
                name: "PasswordChange",
                newName: "ChangePassword");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.RenameTable(
                name: "Authentication",
                newName: "Authenticate");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Login",
                table: "Login",
                column: "Email");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Register",
                table: "Register",
                column: "Email");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResetPassword",
                table: "ResetPassword",
                column: "Email");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChangePassword",
                table: "ChangePassword",
                column: "Email");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Authenticate",
                table: "Authenticate",
                column: "Email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ResetPassword",
                table: "ResetPassword");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Register",
                table: "Register");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Login",
                table: "Login");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChangePassword",
                table: "ChangePassword");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Authenticate",
                table: "Authenticate");

            migrationBuilder.RenameTable(
                name: "ResetPassword",
                newName: "PasswordReset");

            migrationBuilder.RenameTable(
                name: "Register",
                newName: "Registration");

            migrationBuilder.RenameTable(
                name: "Login",
                newName: "SignIn");

            migrationBuilder.RenameTable(
                name: "ChangePassword",
                newName: "PasswordChange");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.RenameTable(
                name: "Authenticate",
                newName: "Authentication");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PasswordReset",
                table: "PasswordReset",
                column: "Email");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Registration",
                table: "Registration",
                column: "Email");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SignIn",
                table: "SignIn",
                column: "Email");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PasswordChange",
                table: "PasswordChange",
                column: "Email");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Authentication",
                table: "Authentication",
                column: "Email");
        }
    }
}
