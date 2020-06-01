using NSSFLIPobj.DomainObjects;
using NSSFLIPobj.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace NSSFLIPobj.ApplicationServices.GetNSSFLIPobjListUseCase
{
    public class DistrictCriteria : ICriteria<DomainObjects.NSSFLIPobj>
    {
        public string District { get; }      /*save filtration criteria*/

        public DistrictCriteria(string district) /*get criteria and save as class member*/
            => District = district;

        public Expression<Func<DomainObjects.NSSFLIPobj, bool>> Filter
            => (rpts => rpts.District == District); /*Filter*/
    }
}
