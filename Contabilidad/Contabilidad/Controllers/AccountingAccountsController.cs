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
    [Route("api/[controller]")]
    [ApiController]
    public class AccountingAccountsController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public AccountingAccountsController(ApplicationDbContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountingAccounts>>> GetAll()
        {
            return await context.AccountingAccounts.ToListAsync();
        }
        
        [HttpGet("{id}", Name ="GetAccountingAccount")]
        public async Task<ActionResult<AccountingAccounts>> Get(int id)
        {
            var accountingAccount = await context.AccountingAccounts.FirstOrDefaultAsync(x => x.ID == id);
            if(accountingAccount == null)
            {
                return NotFound("The Account doesn't exists");
            }
            return Ok(accountingAccount);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AccountingAccounts accountingAccount)
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
        public async Task<ActionResult> Put(int id, [FromBody] AccountingAccounts accountingAccount)
        {
            if (id == accountingAccount.ID)
            {
                context.Entry(accountingAccount).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest("ID doesn't match");
        }
    }
}
