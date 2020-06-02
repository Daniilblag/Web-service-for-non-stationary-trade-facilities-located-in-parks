using NSSFLIPobj.DomainObjects;
using NSSFLIPobj.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace NSSFLIPobj.ApplicationServices.GetDistrictListUseCase
{
    public class DistrictCriteria : ICriteria<nssflipobj>
    {
        public string District { get; }

        public DistrictCriteria (string district)
            => District = district;

        public Expression<Func<nssflipobj, bool>> Filter
            => (b => b.District == District);
    }
}
