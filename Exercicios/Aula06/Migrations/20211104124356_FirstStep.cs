using Microsoft.EntityFrameworkCore.Migrations;

namespace Aula6.Migrations
{
    public partial class FirstStep : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "course",
            //    columns: table => new
            //    {
            //        id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_course", x => x.id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "student",
            //    columns: table => new
            //    {
            //        number = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
            //        courseId = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_student", x => x.number);
            //        table.ForeignKey(
            //            name: "FK_student_course_courseId",
            //            column: x => x.courseId,
            //            principalTable: "course",
            //            principalColumn: "id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_student_courseId",
            //    table: "student",
            //    column: "courseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "student");

            //migrationBuilder.DropTable(
            //    name: "course");
        }
    }
}
