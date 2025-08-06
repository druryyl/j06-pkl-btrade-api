﻿using btrade.application.UseCase;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nuna.Lib.ActionResultHelper;

namespace btrade.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KategoriController : ControllerBase
    {
        private readonly IMediator _mediator;

        public KategoriController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ListData()
        {
            var query = new KategoriListQuery();
            var response = await _mediator.Send(query);
            return Ok(new JSendOk(response));
        }
        [HttpPost]
        public async Task<IActionResult> SyncData(KategoriSyncCommand cmd)
        {
            var response = await _mediator.Send(cmd);
            return Ok(new JSendOk(response));
        }
    }
}
