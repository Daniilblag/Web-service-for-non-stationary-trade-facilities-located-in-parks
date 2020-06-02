using NSSFLIPobj.DomainObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Xunit;
using NSSFLIPobj.ApplicationServices.GetDistrictListUseCase;
using System.Linq.Expressions;
using NSSFLIPobj.ApplicationServices.Ports;
using NSSFLIPobj.DomainObjects.Ports;
using NSSFLIPobj.ApplicationServices.Repositories;

namespace NSSFLIPobj.WebService.Core.Tests
{
    public class GetNSSFLIPobjListUseCaseTest
    {
        private InMemoryNSSFLIPobjRepository CreateNSSFLIPobjRepository()
        {
            var repo = new InMemoryNSSFLIPobjRepository(new List<nssflipobj> {
                new nssflipobj { Id = 1, District = "Район Сокольники", Name = "№1, Нижний майский пруд между Майским просеком и Богородским шоссе"},
                new nssflipobj { Id = 2, District = "Район Сокольники", Name = "№2, Митьковский проезд между павильоном №4 и №7а"},
                new nssflipobj { Id = 3, District = "Район Сокольники", Name = "№3, Фестивальная площадь"},
                new nssflipobj { Id = 4, District = "Район Сокольники", Name = "№6, Пересечение 3-го лучевого просека и Митьковского проезда"},
            });
            return repo;
        }
        [Fact]
        public void TestGetAllNSSFLIPobj()
        {
            var useCase = new GetNSSFLIPobjListUseCase(CreateNSSFLIPobjRepository());
            var outputPort = new OutputPort();
                        
            Assert.True(useCase.Handle(GetNSSFLIPobjListUseCaseRequest.CreateAllNSSFLIPobjsRequest(), outputPort).Result);
            Assert.Equal<int>(4, outputPort.NSSFLIPobjs.Count());
            Assert.Equal(new long[] { 1, 2, 3, 4 }, outputPort.NSSFLIPobjs.Select(mp => mp.Id));
        }

        [Fact]
        public void TestGetAllNSSFLIPobjsFromEmptyRepository()
        {
            var useCase = new GetNSSFLIPobjListUseCase(new InMemoryNSSFLIPobjRepository());
            var outputPort = new OutputPort();

            Assert.True(useCase.Handle(GetNSSFLIPobjListUseCaseRequest.CreateAllNSSFLIPobjsRequest(), outputPort).Result);
            Assert.Empty(outputPort.NSSFLIPobjs);
        }

        [Fact]
        public void TestGetNSSFLIPobj()
        {
            var useCase = new GetNSSFLIPobjListUseCase(CreateNSSFLIPobjRepository());
            var outputPort = new OutputPort();

            Assert.True(useCase.Handle(GetNSSFLIPobjListUseCaseRequest.CreateNSSFLIPobjRequest(2), outputPort).Result);
            Assert.Single(outputPort.NSSFLIPobjs, pn => 2 == pn.Id);
        }

        [Fact]
        public void TestTryGetNotExistingNSSFLIPobj()
        {
            var useCase = new GetNSSFLIPobjListUseCase(CreateNSSFLIPobjRepository());
            var outputPort = new OutputPort();

            Assert.True(useCase.Handle(GetNSSFLIPobjListUseCaseRequest.CreateNSSFLIPobjRequest(999), outputPort).Result);
            Assert.Empty(outputPort.NSSFLIPobjs);
        }
      
    }

    class OutputPort : IOutputPort<GetNSSFLIPobjListUseCaseResponse>
    {
        public IEnumerable<nssflipobj> NSSFLIPobjs { get; private set; }

        public void Handle(GetNSSFLIPobjListUseCaseResponse response)
        {
            NSSFLIPobjs = response.NSSFLIPobjs;
        }
    }
}
