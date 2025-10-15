using btrade.application.UseCase;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nuna.Lib.ActionResultHelper;

namespace btrade.webapi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly IMediator _mediator;

    public CustomerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> ListData()
    {
        var query = new CustomerListDataQuery();
        var response = await _mediator.Send(query);
        return Ok(new JSendOk(response));
    }

    [HttpPost]
    public async Task<IActionResult> SyncData(CustomerSyncCommand cmd)
    {
        var response = await _mediator.Send(cmd);
        return Ok(new JSendOk(response));
    }

    [HttpPatch]
    public async Task<IActionResult> UpdateLocation(CustomerLocationUpdateCommand cmd)
    {
        await _mediator.Send(cmd);
        return Ok();
    }
}
