using Microsoft.EntityFrameworkCore;
using NSSFLIPobj.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace NSSFLIPobj.InfrastructureServices.Gateways.Database
{
    public class NSSFLIPobjContext : DbContext
    {
        public DbSet<DomainObjects.NSSFLIPobj> NSSFLIPobjs { get; set; }


        public NSSFLIPobjContext(DbContextOptions options)
            : base(options)
        { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DomainObjects.NSSFLIPobj>().HasData(
              new DomainObjects.NSSFLIPobj()
              {
                  Id = 1L,
                  Number = "1",
                  NameObj = "№1, Нижний майский пруд между Майским просеком и Богородским шоссе",
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
                  TradingStartDate = "30.06.2015"
              }
           );
        }      
    }
}
