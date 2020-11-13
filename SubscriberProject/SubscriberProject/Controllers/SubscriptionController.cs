using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SubscriberProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubscriptionController : ControllerBase
    {
        private readonly HttpClient _client;
        
        public SubscriptionController(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("Broker");
        }

        public async Task<IActionResult> Post(SubscribeRequest subscribeRequest)
        {
            if (string.IsNullOrEmpty(subscribeRequest.Device) || string.IsNullOrEmpty(subscribeRequest.Email))
                return BadRequest();

            var response = await _client.PostAsync("https://localhost:44329/broker/subscribe",
                new StringContent(JsonSerializer.Serialize(subscribeRequest), Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
                return Ok();
            else
                return StatusCode(500);
        }
    }
}
