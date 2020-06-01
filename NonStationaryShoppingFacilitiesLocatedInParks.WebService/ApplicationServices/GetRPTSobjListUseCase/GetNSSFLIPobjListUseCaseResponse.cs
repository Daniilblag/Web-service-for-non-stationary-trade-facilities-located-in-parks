using NSSFLIPobj.DomainObjects;
using NSSFLIPobj.ApplicationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NSSFLIPobj.ApplicationServices.GetNSSFLIPobjListUseCase
{
    public class GetNSSFLIPobjListUseCaseResponse : UseCaseResponse
    {
        public IEnumerable<DomainObjects.NSSFLIPobj> NSSFLIPobj { get; }

        public GetNSSFLIPobjListUseCaseResponse(IEnumerable<DomainObjects.NSSFLIPobj> nssflipObj) => NSSFLIPobj = nssflipObj;
    }
}
