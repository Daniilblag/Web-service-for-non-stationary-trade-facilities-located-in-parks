using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace NSSFLIPobj.DomainObjects.Ports
{
    public interface IReadOnlyNSSFLIPobjRepository
    {
        Task<nssflipobj> GetNSSFLIPobj(long id);

        Task<IEnumerable<nssflipobj>> GetAllNSSFLIPobjs();

        Task<IEnumerable<nssflipobj>> QueryNSSFLIPobjs(ICriteria<nssflipobj> criteria);

    }

    public interface INSSFLIPobjRepository
    {
        Task AddNSSFLIPobj(nssflipobj nssflipobj);

        Task RemoveNSSFLIPobj(nssflipobj nssflipobj);

        Task UpdateNSSFLIPobj(nssflipobj nssflipobj);
    }
}
