using NSSFLIPobj.ApplicationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NSSFLIPobj.ApplicationServices.GetDistrictListUseCase
{
    public class GetNSSFLIPobjListUseCaseRequest : IUseCaseRequest<GetNSSFLIPobjListUseCaseResponse>
    {
        public string District { get; private set; }
        public long? NSSFLIPobjId { get; private set; }

        private GetNSSFLIPobjListUseCaseRequest()
        { }

        public static GetNSSFLIPobjListUseCaseRequest CreateAllNSSFLIPobjsRequest()
        {
            return new GetNSSFLIPobjListUseCaseRequest();
        }

        public static GetNSSFLIPobjListUseCaseRequest CreateNSSFLIPobjRequest(long nssflipobjId)
        {
            return new GetNSSFLIPobjListUseCaseRequest() { NSSFLIPobjId = nssflipobjId };
        }
        public static GetNSSFLIPobjListUseCaseRequest CreateNSSFLIPobjsRequest(string district)
        {
            return new GetNSSFLIPobjListUseCaseRequest() { District = district };
        }
    }
}
