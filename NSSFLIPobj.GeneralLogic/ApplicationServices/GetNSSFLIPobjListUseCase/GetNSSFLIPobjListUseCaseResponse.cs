using NSSFLIPobj.DomainObjects;
using NSSFLIPobj.ApplicationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NSSFLIPobj.ApplicationServices.GetDistrictListUseCase
{
    public class GetNSSFLIPobjListUseCaseResponse : UseCaseResponse
    {
        public IEnumerable<nssflipobj> NSSFLIPobjs { get; }

        public GetNSSFLIPobjListUseCaseResponse(IEnumerable<nssflipobj> nssflipobjs) => NSSFLIPobjs = nssflipobjs;
    }
}
