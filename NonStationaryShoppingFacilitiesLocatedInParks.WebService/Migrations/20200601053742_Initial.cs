using Microsoft.EntityFrameworkCore.Migrations;

namespace NonStationaryShoppingFacilitiesLocatedInParks.WebService.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NSSFLIPobjs",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Number = table.Column<string>(nullable: true),
                    NameObj = table.Column<string>(nullable: true),
                    AdminArea = table.Column<string>(nullable: true),
                    District = table.Column<string>(nullable: true),
                    Adress = table.Column<string>(nullable: true),
                    CodAdrIP = table.Column<string>(nullable: true),
                    AreaObj = table.Column<string>(nullable: true),
                    KindObj = table.Column<string>(nullable: true),
                    Specialization = table.Column<string>(nullable: true),
                    PlacementPeriod = table.Column<string>(nullable: true),
                    TypeOfContract = table.Column<string>(nullable: true),
                    ContractStatus = table.Column<string>(nullable: true),
                    NumberOfContract = table.Column<string>(nullable: true),
                    NameOfBusinessEntity = table.Column<string>(nullable: true),
                    ContractStartDate = table.Column<string>(nullable: true),
                    ContractFinishDate = table.Column<string>(nullable: true),
                    GroundsForConcluding = table.Column<string>(nullable: true),
                    TradingStartDate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NSSFLIPobjs", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "NSSFLIPobjs",
                columns: new[] { "Id", "AdminArea", "Adress", "AreaObj", "CodAdrIP", "ContractFinishDate", "ContractStartDate", "ContractStatus", "District", "GroundsForConcluding", "KindObj", "NameObj", "NameOfBusinessEntity", "Number", "NumberOfContract", "PlacementPeriod", "Specialization", "TradingStartDate", "TypeOfContract" },
                values: new object[] { 1L, "Восточный административный округ", "город Москва, улица Сокольнический Вал, дом 1, строение 1", "285", "2109201", "30.06.2020", "30.06.2015", "действует", "Район Сокольники", "Результат аукциона (победитель)", "павильон", "№1, Нижний майский пруд между Майским просеком и Богородским шоссе", "Ветров Михаил Владимирович", "1", "592/15-A", "с 1 января по 31 декабря", "кафе", "30.06.2015", "договор на осущевствление торговой деятельности" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NSSFLIPobjs");
        }
    }
}
