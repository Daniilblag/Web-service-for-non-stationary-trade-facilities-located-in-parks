using NSSFLIPobj.ApplicationServices.Ports.Gateways.Database;
using NSSFLIPobj.DomainObjects;
using NSSFLIPobj.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NSSFLIPobj.ApplicationServices.Repositories
{
    public class DbNSSFLIPobjRepository : IReadOnlyNSSFLIPobjRepository,
                                     INSSFLIPobjRepository
    {
        private readonly INSSFLIPobjDatabaseGateway _databaseGateway;

        public DbNSSFLIPobjRepository(INSSFLIPobjDatabaseGateway databaseGateway)
            => _databaseGateway = databaseGateway;

        public async Task<nssflipobj> GetNSSFLIPobj(long id)
            => await _databaseGateway.GetNSSFLIPobj(id);

        public async Task<IEnumerable<nssflipobj>> GetAllNSSFLIPobjs()
            => await _databaseGateway.GetAllNSSFLIPobjs();

        public async Task<IEnumerable<nssflipobj>> QueryNSSFLIPobjs(ICriteria<nssflipobj> criteria)
            => await _databaseGateway.QueryNSSFLIPobjs(criteria.Filter);

        public async Task AddNSSFLIPobj(nssflipobj nssflipobj)
            => await _databaseGateway.AddNSSFLIPobj(nssflipobj);

        public async Task RemoveNSSFLIPobj(nssflipobj nssflipobj)
            => await _databaseGateway.RemoveNSSFLIPobj(nssflipobj);

        public async Task UpdateNSSFLIPobj(nssflipobj nssflipobj)
            => await _databaseGateway.UpdateNSSFLIPobj(nssflipobj);
    }
}
