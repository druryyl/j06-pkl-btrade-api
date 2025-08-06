using btrade.application.UseCase;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nuna.Lib.ActionResultHelper;

namespace btrade.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WilayahController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WilayahController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ListData()
        {
            var query = new WilayahListQuery();
            var response = await _mediator.Send(query);
            return Ok(new JSendOk(response));
        }

        [HttpPost("SyncData")]
        public async Task<IActionResult> SyncData(WilayahSyncCommand cmd)
        {
            var response = await _mediator.Send(cmd);
            return Ok(new JSendOk(response));
        }
    }
}
