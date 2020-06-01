using NSSFLIPobj.ApplicationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NSSFLIPobj.ApplicationServices.GetNSSFLIPobjListUseCase
{
    public class GetNSSFLIPobjListUseCaseRequest : IUseCaseRequest<GetNSSFLIPobjListUseCaseResponse>
    {
        public string District { get; private set; }
        public long? NSSFLIPobjId { get; private set; }

        private GetNSSFLIPobjListUseCaseRequest()
        { }

        public static GetNSSFLIPobjListUseCaseRequest CreateAllNSSFLIPobjRequest()
        {
            return new GetNSSFLIPobjListUseCaseRequest();
        }

        public static GetNSSFLIPobjListUseCaseRequest CreateNSSFLIPobjRequest(long nssflipObjId)
        {
            return new GetNSSFLIPobjListUseCaseRequest() { NSSFLIPobjId = nssflipObjId };
        }
        public static GetNSSFLIPobjListUseCaseRequest CreateDistrictNSSFLIPobjRequest(string nssflipObjs)
        {
            return new GetNSSFLIPobjListUseCaseRequest() { District = nssflipObjs };
        }
    }
}
