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
    public class ContactController : ControllerBase
    {
        
        private readonly ILogger<ContactController> logger;
        private readonly AirTableService airtableService;

        public ContactController(ILogger<ContactController> logger, AirTableService airtableService)
        {
            this.logger = logger;
            this.airtableService = airtableService;
        }

        [HttpGet]
        public IEnumerable<Contact> Get()
        {
           return new List<Contact>();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Contact contact)
        {
            var result = await airtableService.ContactUs(contact);
            if (result)
            {
                return Ok();
            }

            return NotFound();
        }
    }
}
