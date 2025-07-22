using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FilmApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMovieSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("0cfe2edd-1efb-4c35-8e95-90d1472c2fed"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("62d02d6c-722d-4785-88cc-98a0e10eea8f"));

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Director", "Genre", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("1d3a4cc6-2c4c-4bc5-953c-a3227308a111"), "Dağılımı laboriosam de. Ötekinden neque consectetur laboriosam sıfat minima öyle. Nostrum nemo koştum ut neque.", "Çiğdem Erberk", 8, new DateTime(2017, 7, 2, 1, 6, 20, 403, DateTimeKind.Local).AddTicks(7459), "Biber molestiae voluptatem." },
                    { new Guid("1ea451e8-e763-446c-adc5-0a84f58f1d64"), "Tv domates explicabo amet değerli tempora çorba dolore ışık. Mi çakıl odio koyun vitae sıradanlıktan beatae. Et ab için dolore voluptatem duyulmamış.", "Erinç Menemencioğlu", 4, new DateTime(2021, 1, 31, 7, 16, 18, 824, DateTimeKind.Local).AddTicks(4893), "Tempora explicabo magni." },
                    { new Guid("47fc5eb6-c7e0-4aac-8e9b-f4db504a49e7"), "Masanın aut koyun aliquid karşıdakine quam. Nisi ducimus non dolorem magni. Suscipit sit sıfat eius alias okuma suscipit. Eve gidecekmiş alias consectetur eius. Doğru olduğu kapının.", "Aydın Akgül", 10, new DateTime(2018, 10, 28, 21, 24, 25, 30, DateTimeKind.Local).AddTicks(1811), "İpsa ullam dolorem." },
                    { new Guid("c4f85cd2-7400-4e0f-9fc4-3560d1162bdb"), "Non layıkıyla duyulmamış enim sıradanlıktan rem ad beatae vel dışarı. Lambadaki adipisci consectetur duyulmamış. Gidecekmiş quaerat biber consequatur patlıcan voluptatem quae adipisci aut. İpsam nostrum ea un layıkıyla doğru iure doğru.", "Altıntay Körmükçü", 8, new DateTime(2024, 3, 18, 6, 0, 37, 812, DateTimeKind.Local).AddTicks(3472), "Biber quia masanın." },
                    { new Guid("fc773e40-681a-41af-b592-224e31016116"), "Tv kapının balıkhaneye. Sarmal sıfat ve sıla quia ratione kapının consequatur magnam kutusu. Nihil mutlu filmini ducimus ea adresini gidecekmiş ona ipsam.", "Beçkem Akgül", 7, new DateTime(2023, 3, 28, 6, 51, 6, 751, DateTimeKind.Local).AddTicks(2280), "Odio çarpan eos." }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("1d3a4cc6-2c4c-4bc5-953c-a3227308a111"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("1ea451e8-e763-446c-adc5-0a84f58f1d64"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("47fc5eb6-c7e0-4aac-8e9b-f4db504a49e7"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("c4f85cd2-7400-4e0f-9fc4-3560d1162bdb"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("fc773e40-681a-41af-b592-224e31016116"));

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Director", "Genre", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("0cfe2edd-1efb-4c35-8e95-90d1472c2fed"), "Açıklama2", "AHMET YUSUF BIRDIR2222", 0, new DateTime(2025, 7, 19, 17, 16, 28, 56, DateTimeKind.Local).AddTicks(7873), "TEST2" },
                    { new Guid("62d02d6c-722d-4785-88cc-98a0e10eea8f"), "Açıklama", "AHMET YUSUF BIRDIR", 12, new DateTime(2025, 7, 18, 17, 16, 28, 56, DateTimeKind.Local).AddTicks(7862), "TEST" }
                });
        }
    }
}
