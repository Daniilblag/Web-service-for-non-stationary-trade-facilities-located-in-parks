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
        private readonly NSSFLIPobjContext _nssflipobjContext;

        public NSSFLIPobjEFSqliteGateway(NSSFLIPobjContext NSSFLIPobjContext)
            => _nssflipobjContext = NSSFLIPobjContext;

        public async Task<nssflipobj> GetNSSFLIPobj(long id)
           => await _nssflipobjContext.NSSFLIPobjs.Where(b => b.Id == id).FirstOrDefaultAsync();

        public async Task<IEnumerable<nssflipobj>> GetAllNSSFLIPobjs()
            => await _nssflipobjContext.NSSFLIPobjs.ToListAsync();
          
        public async Task<IEnumerable<nssflipobj>> QueryNSSFLIPobjs(Expression<Func<nssflipobj, bool>> filter)
            => await _nssflipobjContext.NSSFLIPobjs.Where(filter).ToListAsync();

        public async Task AddNSSFLIPobj(nssflipobj nssflipobj)
        {
            _nssflipobjContext.NSSFLIPobjs.Add(nssflipobj);
            await _nssflipobjContext.SaveChangesAsync();
        }

        public async Task UpdateNSSFLIPobj(nssflipobj nssflipobj)
        {
            _nssflipobjContext.Entry(nssflipobj).State = EntityState.Modified;
            await _nssflipobjContext.SaveChangesAsync();
        }

        public async Task RemoveNSSFLIPobj(nssflipobj nssflipobj)
        {
            _nssflipobjContext.NSSFLIPobjs.Remove(nssflipobj);
            await _nssflipobjContext.SaveChangesAsync();
        }

    }
}
