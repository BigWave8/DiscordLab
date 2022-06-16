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
    public class UserController : Controller, IUserController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return BadRequest();
            }
            var result = await _userService.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] UserDto user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            var result = await _userService.Insert(user);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> Edit([FromBody] UserDto user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            await _userService.Update(user);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return BadRequest();
            }
            await _userService.Delete(id);
            return Ok();
        }
    }
}
