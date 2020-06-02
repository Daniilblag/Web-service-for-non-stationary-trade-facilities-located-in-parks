using Microsoft.EntityFrameworkCore;
using NSSFLIPobj.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace NSSFLIPobj.InfrastructureServices.Gateways.Database
{
    public class NSSFLIPobjContext : DbContext
    {
        public DbSet<nssflipobj> NSSFLIPobjs { get; set; }

        public NSSFLIPobjContext(DbContextOptions options)
            : base(options)
        { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            FillTestData(modelBuilder);
        }
        private void FillTestData(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<nssflipobj>().HasData(
                new
                {
                    Id = 1L,
                    Number = "1",
                    Name = "№1, Нижний майский пруд между Майским просеком и Богородским шоссе",
                    AdminArea = "Восточный административный округ",
                    District = "Район Сокольники",
                    Adress = "город Москва, улица Сокольнический Вал, дом 1, строение 1",
                    CodAdrIP = "2109201",
                    AreaObj = "285",
                    KindObj = "павильон",
                    Specialization = "кафе",
                    PlacementPeriod = "с 1 января по 31 декабря",
                    TypeOfContract = "договор на осущевствление торговой деятельности",
                    ContractStatus = "действует",
                    NumberOfContract = "592/15-A",
                    NameOfBusinessEntity = "Ветров Михаил Владимирович",
                    ContractStartDate = "30.06.2015",
                    ContractFinishDate = "30.06.2020",
                    GroundsForConcluding = "Результат аукциона (победитель)",
                    TradingStartDate = "30.06.2015",
                },
                new
                {
                    Id = 2L,
                    Number = "2",
                    Name = "№2, Митьковский проезд между павильоном №4 и №7а",
                    AdminArea = "Восточный административный округ",
                    District = "Район Сокольники",
                    Adress = "город Москва, улица Сокольнический Вал, дом 1, строение 1",
                    CodAdrIP = "2109201",
                    AreaObj = "10",
                    KindObj = "киоск",
                    Specialization = "кафе",
                    PlacementPeriod = "с 1 января по 31 декабря",
                    TypeOfContract = "договор на размещение",
                    ContractStatus = "действует",
                    NumberOfContract = "НТО-04-02-006177",
                    NameOfBusinessEntity = "Печатнов Александр Александрович",
                    ContractStartDate = "12.03.2019",
                    ContractFinishDate = "12.03.2024",
                    GroundsForConcluding = "Результат аукциона (победитель)",
                    TradingStartDate = "12.03.2019"

                },
                new
                {
                    Id = 3L,
                    Number = "3",
                    Name = "№3, Фестивальная площадь",
                    AdminArea = "Восточный административный округ",
                    District = "Район Сокольники",
                    Adress = "город Москва, улица Сокольнический Вал, дом 1, строение 1",
                    CodAdrIP = "2109201",
                    AreaObj = "672",
                    KindObj = "павильон",
                    Specialization = "кафе",
                    PlacementPeriod = "с 1 января по 31 декабря",
                    TypeOfContract = "договор на размещение",
                    ContractStatus = "действует",
                    NumberOfContract = "361/16-A",
                    NameOfBusinessEntity = "Меркато",
                    ContractStartDate = "23.05.2016",
                    ContractFinishDate = "22.05.2021",
                    GroundsForConcluding = "Результат аукциона (победитель)",
                    TradingStartDate = "23.05.2016"

                },
                new
                {
                    Id = 4L,
                    Number = "4",
                    Name = "№6, Пересечение 3-го лучевого просека и Митьковского проезда",
                    AdminArea = "Восточный административный округ",
                    District = "Район Сокольники",
                    Adress = "город Москва, улица Сокольнический Вал, дом 1, строение 1",
                    CodAdrIP = "2109201",
                    AreaObj = "210",
                    KindObj = "павильон",
                    Specialization = "кафе",
                    PlacementPeriod = "с 1 января по 31 декабря",
                    TypeOfContract = "договор на осущевствление торговой деятельности",
                    ContractStatus = "действует",
                    NumberOfContract = "362/16-A",
                    NameOfBusinessEntity = "Авагян Диана Степановна",
                    ContractStartDate = "30.05.2016",
                    ContractFinishDate = "30.05.2021",
                    GroundsForConcluding = "Результат аукциона (победитель)",
                    TradingStartDate = "30.05.2016"

                }
               
            );
        }
    }
}
