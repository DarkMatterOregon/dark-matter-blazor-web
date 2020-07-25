using DarkMatterWasm.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DarkMatterWasm.Shared.Models;
using DarkMatterWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;


namespace DarkMatterWasm.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CrewController : ControllerBase
    {
        
        private readonly ILogger<ContactController> logger;
        private readonly AirTableService airtableService;

        public CrewController(ILogger<ContactController> logger, AirTableService airtableService)
        {
            this.logger = logger;
            this.airtableService = airtableService;
        }

        [HttpGet]
        public async Task<IEnumerable<CrewMember>> Get()
        {
            return await airtableService.GetCrewMembersAsync();
        }

    }
}
