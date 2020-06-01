using NSSFLIPobj.ApplicationServices.GetNSSFLIPobjListUseCase;
using System.Net;
using Newtonsoft.Json;
using NSSFLIPobj.ApplicationServices.Ports;

namespace NSSFLIPobj.InfrastructureServices.Presenters
{
    public class NSSFLIPobjListPresenter : IOutputPort<GetNSSFLIPobjListUseCaseResponse>
    {
        public JsonContentResult ContentResult { get; }

        public NSSFLIPobjListPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(GetNSSFLIPobjListUseCaseResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.NotFound);
            ContentResult.Content = response.Success ? JsonConvert.SerializeObject(response.NSSFLIPobj) : JsonConvert.SerializeObject(response.Message);
        }
    }
}
