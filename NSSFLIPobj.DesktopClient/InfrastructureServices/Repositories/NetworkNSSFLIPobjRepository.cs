using NSSFLIPobj.ApplicationServices.Ports.Cache;
using NSSFLIPobj.DomainObjects;
using NSSFLIPobj.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NSSFLIPobj.InfrastructureServices.Repositories
{
    public class NetworkNSSFLIPobjRepository : NetworkRepositoryBase, IReadOnlyNSSFLIPobjRepository
    {
        private readonly IDomainObjectsCache<nssflipobj> _nssflipobjCache;

        public NetworkNSSFLIPobjRepository(string host, ushort port, bool useTls, IDomainObjectsCache<nssflipobj> nssflipobjCache)
            : base(host, port, useTls)
            => _nssflipobjCache = nssflipobjCache;

        public async Task<nssflipobj> GetNSSFLIPobj(long id)
            => CacheAndReturn(await ExecuteHttpRequest<nssflipobj>($"nssflipobjs/{id}"));

        public async Task<IEnumerable<nssflipobj>> GetAllNSSFLIPobjs()
            => CacheAndReturn(await ExecuteHttpRequest<IEnumerable<nssflipobj>>($"nssflipobjs"), allObjects: true);

        public async Task<IEnumerable<nssflipobj>> QueryNSSFLIPobjs(ICriteria<nssflipobj> criteria)
            => CacheAndReturn(await ExecuteHttpRequest<IEnumerable<nssflipobj>>($"nssflipobjs"), allObjects: true)
               .Where(criteria.Filter.Compile());


        private IEnumerable<nssflipobj> CacheAndReturn(IEnumerable<nssflipobj> nssflipobjs, bool allObjects = false)
        {
            if (allObjects)
            {
                _nssflipobjCache.ClearCache();
            }
            _nssflipobjCache.UpdateObjects(nssflipobjs, DateTime.Now.AddDays(1), allObjects);
            return nssflipobjs;
        }

        private nssflipobj CacheAndReturn(nssflipobj nssflipobj)
        {
            _nssflipobjCache.UpdateObject(nssflipobj, DateTime.Now.AddDays(1));
            return nssflipobj;
        }
    }
}
