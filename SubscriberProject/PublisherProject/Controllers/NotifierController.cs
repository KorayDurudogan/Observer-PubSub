using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace PublisherProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotifierController : ControllerBase
    {
        private readonly HttpClient _client;

        public NotifierController(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("Broker");
        }

        [Route("{device}")]
        public async Task<IActionResult> Get(string device)
        {
            var response = await _client.GetAsync($"https://localhost:44329/broker/notify/{device}");
            if (response.IsSuccessStatusCode)
                return Ok();
            else
                return StatusCode(500);
        }
    }
}
