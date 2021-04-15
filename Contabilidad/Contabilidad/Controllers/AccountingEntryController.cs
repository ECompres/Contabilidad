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
    [Route("api/accountingEntry")]
    [ApiController]
    public class AccountingEntryController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public AccountingEntryController(ApplicationDbContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountingEntry>>> GetAll()
        {
            return await context.AccountingEntry.Include(a => a.AuxiliarSystem).ToListAsync();
        }

        [HttpGet("{id}", Name = "GetAccountingEntry")]
        public async Task<ActionResult<AccountingEntry>> Get(int id)
        {
            var accountingEntry = await context.AccountingEntry.FirstOrDefaultAsync(x => x.ID == id);
            if (accountingEntry == null)
            {
                return NotFound("Accounting Entry doesn't exist");
            }
            return Ok(accountingEntry);
        }

        [HttpGet("auxiliars/{id}")]
        public async Task<ActionResult<IEnumerable<AccountingEntry>>> GetByAuxiliars(int id)
        {
            return await context.AccountingEntry.Where(x => x.IdAuxiliarSystem == id).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AccountingEntry accountingEntry)
        {
            if (ModelState.IsValid)
            {
                context.AccountingEntry.Add(accountingEntry);
                await context.SaveChangesAsync();
                return new CreatedAtRouteResult("GetAccountingEntry", new { id = accountingEntry.ID }, accountingEntry);
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] AccountingEntry accountingEntry)
        {
            if (id == accountingEntry.ID)
            {
                context.Entry(accountingEntry).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return Ok(accountingEntry);
            }
            return NotFound("ID doesn't match");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var accountingEntry = await context.AccountingEntry.FirstOrDefaultAsync(x => x.ID == id);

            if (accountingEntry == null)
            {
                return NotFound("Accounting Entry doesn't exist");
            }
            context.AccountingEntry.Remove(accountingEntry);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
