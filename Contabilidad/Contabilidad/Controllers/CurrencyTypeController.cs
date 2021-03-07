using Contabilidad.Contexts;
using Contabilidad.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contabilidad.Controllers
{
    [Route("api/currencyType")]
    [ApiController]
    public class CurrencyTypeController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public CurrencyTypeController(ApplicationDbContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CurrencyType>>> GetAll()
        {
            return await context.CurrencyType.ToListAsync();
        }

        [HttpGet("{id}", Name = "GetCurrencyType")]
        public async Task<ActionResult<CurrencyType>> Get(int id)
        {
            var currencyType = await context.CurrencyType.FirstOrDefaultAsync(x => x.ID == id);

            if (currencyType == null)
            {
                return NotFound("Currency Type doesn't exist");
            }
            return Ok(currencyType);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CurrencyType currencyType)
        {
            if (ModelState.IsValid)
            {
                await context.AddAsync(currencyType);
                await context.SaveChangesAsync();
                return new CreatedAtRouteResult("GetCurrencyType", new { id = currencyType.ID }, currencyType);
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] CurrencyType currencyType)
        {
            if (id == currencyType.ID)
            {
                context.Entry(currencyType).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return Ok("Currency Type modified");
            }
            return NotFound("Id doesn't match");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var currencyType = await context.CurrencyType.FirstOrDefaultAsync(x => x.ID == id);
            if (currencyType == null)
            {
                return NotFound("Currency Type doesn't exists");
            }
            context.CurrencyType.Remove(currencyType);
            await context.SaveChangesAsync();
            return Ok(currencyType);
        }
    }
}
