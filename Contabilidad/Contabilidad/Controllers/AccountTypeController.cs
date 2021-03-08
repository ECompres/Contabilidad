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
    [Route("api/accountType")]
    [ApiController]
    public class AccountTypeController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public AccountTypeController(ApplicationDbContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountType>>> GetAll()
        {
            return await context.AccountType.Include(x => x.AccountingAccounts).ToListAsync();
        }

        [HttpGet("{id}", Name = "GetAccountType")]
        public async Task<ActionResult<AccountType>> Get(int id)
        {
            var accountType = await context.AccountType.FirstOrDefaultAsync(x => x.ID == id);

            if (accountType == null)
            {
                return NotFound("Account Type doesn't exist");
            }
            return Ok(accountType);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AccountType accountType)
        {
            if (ModelState.IsValid)
            {
                await context.AddAsync(accountType);
                await context.SaveChangesAsync();
                return new CreatedAtRouteResult("GetAccountType", new { id = accountType.ID }, accountType);
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] AccountType accountType)
        {
            if (id == accountType.ID)
            {
                context.Entry(accountType).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return Ok(accountType);
            }
            return NotFound("Id doesn't match");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var accountType = await context.AccountType.FirstOrDefaultAsync(x => x.ID == id);
            if (accountType == null)
            {
                return NotFound("Account Type doesn't exists");
            }
            context.AccountType.Remove(accountType);
            await context.SaveChangesAsync();
            return Ok(accountType);
        }
    }
}
