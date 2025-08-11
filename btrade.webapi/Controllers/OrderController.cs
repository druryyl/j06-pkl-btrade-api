using btrade.application.UseCase;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nuna.Lib.ActionResultHelper;

namespace btrade.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> UploadData(OrderUploadCommand cmd)
        {
            await _mediator.Send(cmd);
            return Ok(new JSendOk("Done"));
        }

        [HttpGet]
        [Route("incremental/{tgl1}/{tgl2})")]
        public async Task<IActionResult> IncrementalDownload(string tgl1, string tgl2)
        {
            var query = new OrderIncrementalDownloadQuery(tgl1, tgl2);
            var result = await _mediator.Send(query);
            return Ok(new JSendOk(result));
        }
    }
}
