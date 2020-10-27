using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BlazorAuthCoreHosted.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        private readonly ILogger<DemoController> _logger;

        public DemoController(ILogger<DemoController> logger)
        {
            _logger = logger;
        }
        
        [HttpGet]
        public string Get(int? id)
        {
            try
            {
                if (id.HasValue)
                {
                    throw new Exception($"Unexpected things happened.");
                }
                return "hello, Get() is done";
            }
            catch (Exception ex)
            {
                var message = $"Error caught with parameters: id ={id}";
                _logger.LogError(ex, message, new object[] { "key1 = v1", 8888 });
                //_logger.LogErrorToCloud(ex, new Dictionary<string, object> { { "key1", "value1" } });
                //_logger.LogErrorToCloud(ex);
                return $"id {id} doesn't exist.";
            }
        }
    }
}
