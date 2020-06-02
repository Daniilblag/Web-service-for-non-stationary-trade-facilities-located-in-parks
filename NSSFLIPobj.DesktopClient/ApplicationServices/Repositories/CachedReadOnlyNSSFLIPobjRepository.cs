using NSSFLIPobj.ApplicationServices.Ports.Cache;
using NSSFLIPobj.DomainObjects;
using NSSFLIPobj.DomainObjects.Ports;
using NSSFLIPobj.DomainObjects.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NSSFLIPobj.ApplicationServices.Repositories
{
    public class CachedReadOnlyNSSFLIPobjRepository : ReadOnlyNSSFLIPobjRepositoryDecorator
    {
        private readonly IDomainObjectsCache<nssflipobj> _nssflipobjsCache;

        public CachedReadOnlyNSSFLIPobjRepository(IReadOnlyNSSFLIPobjRepository nssflipobjRepository, 
                                             IDomainObjectsCache<nssflipobj> nssflipobjsCache)
            : base(nssflipobjRepository)
            => _nssflipobjsCache = nssflipobjsCache;

        public async override Task<nssflipobj> GetNSSFLIPobj(long id)
            => _nssflipobjsCache.GetObject(id) ?? await base.GetNSSFLIPobj(id);

        public async override Task<IEnumerable<nssflipobj>> GetAllNSSFLIPobjs()
            => _nssflipobjsCache.GetObjects() ?? await base.GetAllNSSFLIPobjs();

        public async override Task<IEnumerable<nssflipobj>> QueryNSSFLIPobjs(ICriteria<nssflipobj> criteria)
            => _nssflipobjsCache.GetObjects()?.Where(criteria.Filter.Compile()) ?? await base.QueryNSSFLIPobjs(criteria);

    }
}
