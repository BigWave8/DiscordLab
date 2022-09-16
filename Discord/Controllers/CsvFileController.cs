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
    public class CsvFileController : Controller, ICsvFileController
    {
        private readonly ICsvFileService _csvFileService;
        public CsvFileController(ICsvFileService csvFileService)
        {
            _csvFileService = csvFileService;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            await _csvFileService.ReadFile();
            return Ok();
        }
    }
}
