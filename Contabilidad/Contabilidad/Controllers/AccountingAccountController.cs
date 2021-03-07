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
    [Route("api/accountingAccount")]
    [ApiController]
    public class AccountingAccountController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public AccountingAccountController(ApplicationDbContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountingAccount>>> GetAll()
        {
            return await context.AccountingAccount.Include(x=>x.AccountType).ToListAsync();
        }
        
        [HttpGet("{id}", Name ="GetAccountingAccount")]
        public async Task<ActionResult<AccountingAccount>> Get(int id)
        {
            var accountingAccount = await context.AccountingAccount.FirstOrDefaultAsync(x => x.ID == id);
            if(accountingAccount == null)
            {
                return NotFound("The Account doesn't exists");
            }
            return Ok(accountingAccount);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AccountingAccount accountingAccount)
        {
            if (ModelState.IsValid)
            {
                await context.AddAsync(accountingAccount);
                await context.SaveChangesAsync();
                return new CreatedAtRouteResult("GetAccountingAccount", new { id = accountingAccount.ID }, accountingAccount);
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] AccountingAccount accountingAccount)
        {
            if (id == accountingAccount.ID)
            {
                context.Entry(accountingAccount).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return Ok("Accounting Account modified");
            }
            return BadRequest("ID doesn't match");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var accountingAccount = await context.AccountingAccount.FirstOrDefaultAsync(x => x.ID == id);
            if(accountingAccount == null)
            {
                return NotFound("Accounting Account doesn't exist");
            }
            context.AccountingAccount.Remove(accountingAccount);
            await context.SaveChangesAsync();
            return Ok(accountingAccount);    
        }
    }
}
