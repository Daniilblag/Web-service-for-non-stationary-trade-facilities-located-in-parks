using NSSFLIPobj.DomainObjects;
using NSSFLIPobj.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NSSFLIPobj.ApplicationServices.Repositories
{
    public class InMemoryNSSFLIPobjRepository : IReadOnlyNSSFLIPobjRepository,
                                           INSSFLIPobjRepository 
    {
        private readonly List<nssflipobj> _nssflipobjs = new List<nssflipobj>();

        public InMemoryNSSFLIPobjRepository(IEnumerable<nssflipobj> nssflipobjs = null)
        {
            if (nssflipobjs != null)
            {
                _nssflipobjs.AddRange(nssflipobjs);
            }
        }

        public Task AddNSSFLIPobj(nssflipobj nssflipobj)
        {
            _nssflipobjs.Add(nssflipobj);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<nssflipobj>> GetAllNSSFLIPobjs()
        {
            return Task.FromResult(_nssflipobjs.AsEnumerable());
        }

        public Task<nssflipobj> GetNSSFLIPobj(long id)
        {
            return Task.FromResult(_nssflipobjs.Where(pn => pn.Id == id).FirstOrDefault());
        }

        public Task<IEnumerable<nssflipobj>> QueryNSSFLIPobjs(ICriteria<nssflipobj> criteria)
        {
            return Task.FromResult(_nssflipobjs.Where(criteria.Filter.Compile()).AsEnumerable());
        }

        public Task RemoveNSSFLIPobj(nssflipobj nssflipobj)
        {
            _nssflipobjs.Remove(nssflipobj);
            return Task.CompletedTask;
        }

        public Task UpdateNSSFLIPobj(nssflipobj nssflipobj)
        {
            var foundNSSFLIPobj = GetNSSFLIPobj(nssflipobj.Id).Result;
            if (foundNSSFLIPobj == null)
            {
                AddNSSFLIPobj(nssflipobj);
            }
            else
            {
                if (foundNSSFLIPobj != nssflipobj)
                {
                    _nssflipobjs.Remove(foundNSSFLIPobj);
                    _nssflipobjs.Add(nssflipobj);
                }
            }
            return Task.CompletedTask;
        }
    }
}
