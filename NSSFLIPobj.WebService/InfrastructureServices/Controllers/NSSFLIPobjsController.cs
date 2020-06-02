using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSSFLIPobj.DomainObjects;
using NSSFLIPobj.ApplicationServices.GetDistrictListUseCase;
using NSSFLIPobj.InfrastructureServices.Presenters;

namespace NSSFLIPobj.InfrastructureServices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NSSFLIPobjsController : ControllerBase
    {
        private readonly ILogger<NSSFLIPobjsController> _logger;
        private readonly IGetNSSFLIPobjListUseCase _getNSSFLIPobjListUseCase;

        public NSSFLIPobjsController(ILogger<NSSFLIPobjsController> logger,
                                IGetNSSFLIPobjListUseCase getNSSFLIPobjListUseCase)
        {
            _logger = logger;
            _getNSSFLIPobjListUseCase = getNSSFLIPobjListUseCase;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllNSSFLIPobjs()
        {
            var presenter = new NSSFLIPobjListPresenter();
            await _getNSSFLIPobjListUseCase.Handle(GetNSSFLIPobjListUseCaseRequest.CreateAllNSSFLIPobjsRequest(), presenter);
            return presenter.ContentResult;
        }

        [HttpGet("{nssflipobjId}")]
        public async Task<ActionResult> GetNSSFLIPobj(long nssflipobjId)
        {
            var presenter = new NSSFLIPobjListPresenter();
            await _getNSSFLIPobjListUseCase.Handle(GetNSSFLIPobjListUseCaseRequest.CreateNSSFLIPobjRequest(nssflipobjId), presenter);
            return presenter.ContentResult;
        }

        [HttpGet("metroline/{metroline}")]
        public async Task<ActionResult> GetDistrictNSSFLIPobjs(string metroline)
        {
            var presenter = new NSSFLIPobjListPresenter();
            await _getNSSFLIPobjListUseCase.Handle(GetNSSFLIPobjListUseCaseRequest.CreateNSSFLIPobjsRequest(metroline), presenter);
            return presenter.ContentResult;
        }
    }
}
