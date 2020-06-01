using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSSFLIPobj.DomainObjects;
using NSSFLIPobj.ApplicationServices.GetNSSFLIPobjListUseCase;
using NSSFLIPobj.InfrastructureServices.Presenters;

namespace NSSFLIPobj.InfrastructureServices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NSSFLIPobjController : ControllerBase
    {
        private readonly ILogger<NSSFLIPobjController> _logger;
        private readonly IGetNSSFLIPobjListUseCase _getNSSFLIPobjListUseCase;

        public NSSFLIPobjController(ILogger<NSSFLIPobjController> logger,
                                IGetNSSFLIPobjListUseCase getNSSFLIPobjListUseCase)
        {
            _logger = logger;
            _getNSSFLIPobjListUseCase = getNSSFLIPobjListUseCase;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllNSSFLIPobj()
        {
            var presenter = new NSSFLIPobjListPresenter();
            await _getNSSFLIPobjListUseCase.Handle(GetNSSFLIPobjListUseCaseRequest.CreateAllNSSFLIPobjRequest(), presenter);
            return presenter.ContentResult;
        }

        [HttpGet("{nssflipObjId}")]
        public async Task<ActionResult> GetNSSFLIPobj(long nssflipObjId)
        {
            var presenter = new NSSFLIPobjListPresenter();
            await _getNSSFLIPobjListUseCase.Handle(GetNSSFLIPobjListUseCaseRequest.CreateNSSFLIPobjRequest(nssflipObjId), presenter);
            return presenter.ContentResult;
        }

        [HttpGet("Districts/{district}")]
        public async Task<ActionResult> GetDistrictFilter(string district)
        {
            var presenter = new NSSFLIPobjListPresenter();
            await _getNSSFLIPobjListUseCase.Handle(GetNSSFLIPobjListUseCaseRequest.CreateDistrictNSSFLIPobjRequest(district), presenter);
            return presenter.ContentResult;
        }
    }
}
