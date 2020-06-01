using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace NSSFLIPobj.DomainObjects.Ports
{
    public interface IReadOnlyNSSFLIPobjRepository
    {
        Task<NSSFLIPobj> GetNSSFLIPobj(long id);

        Task<IEnumerable<NSSFLIPobj>> GetAllNSSFLIPobjs();

        Task<IEnumerable<NSSFLIPobj>> QueryNSSFLIPobj(ICriteria<NSSFLIPobj> criteria);

    }

    public interface INSSFLIPobjRepository
    {
        Task AddNSSFLIPobj(NSSFLIPobj nssflipObj);

        Task RemoveNSSFLIPobj(NSSFLIPobj nssflipObj);

        Task UpdateNSSFLIPobj(NSSFLIPobj nssflipObj);
    }
}
