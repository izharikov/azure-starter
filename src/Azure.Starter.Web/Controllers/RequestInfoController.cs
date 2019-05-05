using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Azure.Starter.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestInfoController : Controller
    {
        private readonly IConfiguration _configuration;

        public RequestInfoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<RequestInfoModel> Get()
        {
            return new RequestInfoModel(Request, _configuration["Variable"]);
        }
    }

    public class RequestInfoModel
    {
        private readonly HttpRequest _request;
        private readonly string _config;

        public RequestInfoModel(HttpRequest request, string config)
        {
            _request = request;
            _config = config;
        }

        public string HostName => _request.Host.Value;
        public string Config => _config;
        
    }
}