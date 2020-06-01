using NSSFLIPobj.DomainObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using NSSFLIPobj.ApplicationServices.Ports.Gateways.Database;

namespace NSSFLIPobj.InfrastructureServices.Gateways.Database
{
    public class NSSFLIPobjEFSqliteGateway : INSSFLIPobjDatabaseGateway
    {
        private readonly NSSFLIPobjContext _nssflipObjContext;

        public NSSFLIPobjEFSqliteGateway(NSSFLIPobjContext nssflipObjContext)
            => _nssflipObjContext = nssflipObjContext;

        public async Task<DomainObjects.NSSFLIPobj> GetNSSFLIPobj(long id)
           => await _nssflipObjContext.NSSFLIPobjs.FirstOrDefaultAsync();

        public async Task<IEnumerable<DomainObjects.NSSFLIPobj>> GetAllNSSFLIPobj()
            => await _nssflipObjContext.NSSFLIPobjs.ToListAsync();
          
        public async Task<IEnumerable<DomainObjects.NSSFLIPobj>> QueryNSSFLIPobj(Expression<Func<DomainObjects.NSSFLIPobj, bool>> filter)
            => await _nssflipObjContext.NSSFLIPobjs.Where(filter).ToListAsync();

        public async Task AddNSSFLIPobj(DomainObjects.NSSFLIPobj nssflipObj)
        {
            _nssflipObjContext.NSSFLIPobjs.Add(nssflipObj);
            await _nssflipObjContext.SaveChangesAsync();
        }

        public async Task UpdateNSSFLIPobj(DomainObjects.NSSFLIPobj nssflipobj)
        {
            _nssflipObjContext.Entry(nssflipobj).State = EntityState.Modified;
            await _nssflipObjContext.SaveChangesAsync();
        }

        public async Task RemoveNSSFLIPobj(DomainObjects.NSSFLIPobj nssflipobj)
        {
            _nssflipObjContext.NSSFLIPobjs.Remove(nssflipobj);
            await _nssflipObjContext.SaveChangesAsync();
        }


       
    }
}
