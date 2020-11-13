using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BrokerProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BrokerController : ControllerBase
    {
        public BrokerController()
        {
        }

        [HttpPost]
        [Route("subscribe")]
        public IActionResult Subscribe(SubscribeRequest subscribeRequest)
        {
            if (string.IsNullOrEmpty(subscribeRequest.Device) || string.IsNullOrEmpty(subscribeRequest.Email))
                return BadRequest();

            try
            {
                AbsSubscribeService service = Factory.Create(subscribeRequest.Device);
                service.Subscribe(subscribeRequest.Email);
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("notify/{device}")]
        public async Task<IActionResult> Notify(string device)
        {
            try
            {
                AbsSubscribeService service = Factory.Create(device);
                service.Notify();
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
