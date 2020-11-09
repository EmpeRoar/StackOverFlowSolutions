using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace SO.Ardalisx.Endpoints.Test
{
    public class SayHello : BaseAsyncEndpoint<string>
    {
        public SayHello()
        {
        }

        [HttpGet]
        [Route("Say")]
        public override async Task<ActionResult<string>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return Ok("Nayshhh");
        }
    }
}