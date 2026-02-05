using btrade.application.UseCase;
using btrade.application.WarehouseFreature;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nuna.Lib.ActionResultHelper;

namespace btrade.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WarehouseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> UploadData(WrhSavePackingOrderCmd cmd)
        {
            await _mediator.Send(cmd);
            return Ok(new JSendOk("Done"));
        }
        [HttpGet]
        public async Task<IActionResult> DownloadData(WrhDownloadPackingOrderCmd cmd)
        {
            var result = await _mediator.Send(cmd);
            return Ok(new JSendOk(result));
        }

    }
}
