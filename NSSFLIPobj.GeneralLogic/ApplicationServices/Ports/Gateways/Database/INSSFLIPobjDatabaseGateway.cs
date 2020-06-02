using NSSFLIPobj.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NSSFLIPobj.ApplicationServices.Ports.Gateways.Database
{
    public interface INSSFLIPobjDatabaseGateway
    {
        Task AddNSSFLIPobj(nssflipobj nssflipobj);

        Task RemoveNSSFLIPobj(nssflipobj nssflipobj);

        Task UpdateNSSFLIPobj(nssflipobj nssflipobj);

        Task<nssflipobj> GetNSSFLIPobj(long id);

        Task<IEnumerable<nssflipobj>> GetAllNSSFLIPobjs();

        Task<IEnumerable<nssflipobj>> QueryNSSFLIPobjs(Expression<Func<nssflipobj, bool>> filter);

    }
}
