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
    public class MessageController : Controller, IMessageController
    {
        private readonly IMessageService _messageService;
        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return BadRequest();
            }
            var result = await _messageService.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] MessageDto message)
        {
            if (message == null)
            {
                return BadRequest();
            }
            var result = await _messageService.Insert(message);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> Edit([FromBody] MessageDto message)
        {
            if (message == null)
            {
                return BadRequest();
            }
            await _messageService.Update(message);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return BadRequest();
            }
            await _messageService.Delete(id);
            return Ok();
        }
    }
}
