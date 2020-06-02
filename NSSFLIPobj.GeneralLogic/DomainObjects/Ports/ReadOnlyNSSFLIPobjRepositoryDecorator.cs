using NSSFLIPobj.DomainObjects;
using NSSFLIPobj.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NSSFLIPobj.DomainObjects.Repositories
{
    public abstract class ReadOnlyNSSFLIPobjRepositoryDecorator : IReadOnlyNSSFLIPobjRepository
    {
        private readonly IReadOnlyNSSFLIPobjRepository _nssflipobjRepository;

        public ReadOnlyNSSFLIPobjRepositoryDecorator(IReadOnlyNSSFLIPobjRepository nssflipobjRepository)
        {
            _nssflipobjRepository = nssflipobjRepository;
        }

        public virtual async Task<IEnumerable<nssflipobj>> GetAllNSSFLIPobjs()
        {
            return await _nssflipobjRepository?.GetAllNSSFLIPobjs();
        }

        public virtual async Task<nssflipobj> GetNSSFLIPobj(long id)
        {
            return await _nssflipobjRepository?.GetNSSFLIPobj(id);
        }

        public virtual async Task<IEnumerable<nssflipobj>> QueryNSSFLIPobjs(ICriteria<nssflipobj> criteria)
        {
            return await _nssflipobjRepository?.QueryNSSFLIPobjs(criteria);
        }
    }
}
