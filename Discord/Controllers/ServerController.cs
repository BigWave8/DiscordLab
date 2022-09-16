using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Dto;
using Discord.Interfaces.Controllers;
using Discord.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Discord.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServerController : Controller, IServerController
    {
        private readonly IServerService _serverService;
        public ServerController(IServerService serverService)
        {
            _serverService = serverService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return BadRequest();
            }
            var result = await _serverService.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] ServerDto server)
        {
            if (server == null)
            {
                return BadRequest();
            }
            var result = await _serverService.Insert(server);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> Edit([FromBody] ServerDto server)
        {
            if (server == null)
            {
                return BadRequest();
            }
            await _serverService.Update(server);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return BadRequest();
            }
            await _serverService.Delete(id);
            return Ok();
        }
    }
}
