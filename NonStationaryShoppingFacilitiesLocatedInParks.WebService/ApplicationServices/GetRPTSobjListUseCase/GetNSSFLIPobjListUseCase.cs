using System.Threading.Tasks;
using System.Collections.Generic;
using NSSFLIPobj.DomainObjects;
using NSSFLIPobj.DomainObjects.Ports;
using NSSFLIPobj.ApplicationServices.Ports;

namespace NSSFLIPobj.ApplicationServices.GetNSSFLIPobjListUseCase
{
    public class GetNSSFLIPobjListUseCase : IGetNSSFLIPobjListUseCase
    {
        private readonly IReadOnlyNSSFLIPobjRepository _readOnlyNSSFLIPobjRepository;

        public GetNSSFLIPobjListUseCase(IReadOnlyNSSFLIPobjRepository readOnlyNSSFLIPobjRepository) 
            => _readOnlyNSSFLIPobjRepository = readOnlyNSSFLIPobjRepository;

        public async Task<bool> Handle(GetNSSFLIPobjListUseCaseRequest request, IOutputPort<GetNSSFLIPobjListUseCaseResponse> outputPort)
        {
            IEnumerable<DomainObjects.NSSFLIPobj> nssflipObjs = null;
            if (request.NSSFLIPobjId != null)
            {
                var nssflipObj = await _readOnlyNSSFLIPobjRepository.GetNSSFLIPobj(request.NSSFLIPobjId.Value);
                nssflipObjs = (nssflipObj != null) ? new List<DomainObjects.NSSFLIPobj>() { nssflipObj } : new List<DomainObjects.NSSFLIPobj>();
                
            }
            else if (request.District != null)
            {
                nssflipObjs = await _readOnlyNSSFLIPobjRepository.QueryNSSFLIPobj(new DistrictCriteria(request.District));
            }
            else
            {
                nssflipObjs = await _readOnlyNSSFLIPobjRepository.GetAllNSSFLIPobjs();
            }
            outputPort.Handle(new GetNSSFLIPobjListUseCaseResponse(nssflipObjs));
            return true;
        }
    }
}
