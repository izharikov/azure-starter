using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Starter.Core.Models;
using Azure.Starter.Database.Context;
using Microsoft.AspNetCore.Mvc;

namespace Azure.Starter.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        private readonly SampleAppContext _sampleAppContext;

        public SampleController(SampleAppContext sampleAppContext)
        {
            _sampleAppContext = sampleAppContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SampleModel>> Get()
        {
            return _sampleAppContext.Samples;
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<SampleModel>> Update(Guid id)
        {
            var sample = _sampleAppContext.Samples.Find(id);
            sample.Features = new List<string>(sample.Features){
                $"Feature {DateTime.Now}"
                
            };
             await _sampleAppContext.SaveChangesAsync();
            return sample;
        }
    }
}