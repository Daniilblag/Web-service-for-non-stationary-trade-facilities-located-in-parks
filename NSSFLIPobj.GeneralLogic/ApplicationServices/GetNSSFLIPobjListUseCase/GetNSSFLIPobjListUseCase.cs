using System.Threading.Tasks;
using System.Collections.Generic;
using NSSFLIPobj.DomainObjects;
using NSSFLIPobj.DomainObjects.Ports;
using NSSFLIPobj.ApplicationServices.Ports;

namespace NSSFLIPobj.ApplicationServices.GetDistrictListUseCase
{
    public class GetNSSFLIPobjListUseCase : IGetNSSFLIPobjListUseCase
    {
        private readonly IReadOnlyNSSFLIPobjRepository _readOnlyNSSFLIPobjRepository;

        public GetNSSFLIPobjListUseCase(IReadOnlyNSSFLIPobjRepository readOnlyNSSFLIPobjRepository) 
            => _readOnlyNSSFLIPobjRepository = readOnlyNSSFLIPobjRepository;
        
        public async Task<bool> Handle(GetNSSFLIPobjListUseCaseRequest request, IOutputPort<GetNSSFLIPobjListUseCaseResponse> outputPort)
        {
            IEnumerable<nssflipobj> nssflipobjs = null;
            if (request.NSSFLIPobjId != null)
            {
                var nssflipobj = await _readOnlyNSSFLIPobjRepository.GetNSSFLIPobj(request.NSSFLIPobjId.Value);
                nssflipobjs = (nssflipobj != null) ? new List<nssflipobj>() { nssflipobj } : new List<nssflipobj>();
                
            }
            else if (request.District != null)
            {
                nssflipobjs = await _readOnlyNSSFLIPobjRepository.QueryNSSFLIPobjs(new DistrictCriteria(request.District));
            }
            else
            {
                nssflipobjs = await _readOnlyNSSFLIPobjRepository.GetAllNSSFLIPobjs();
            }
            outputPort.Handle(new GetNSSFLIPobjListUseCaseResponse(nssflipobjs));
            return true;
        }
    }
}
