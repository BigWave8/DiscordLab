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
    public class ChatController : Controller, IChatController
    {
        private readonly IChatService _chatService;
        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return BadRequest();
            }
            var result = await _chatService.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] ChatDto chat)
        {
            if (chat == null)
            {
                return BadRequest();
            }
            var result = await _chatService.Insert(chat);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> Edit([FromBody] ChatDto chat)
        {
            if (chat == null)
            {
                return BadRequest();
            }
            await _chatService.Update(chat);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return BadRequest();
            }
            await _chatService.Delete(id);
            return Ok();
        }
    }
}
