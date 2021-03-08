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
    [Route("api/auxiliarSystem")]
    [ApiController]
    public class AuxiliarSystemController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public AuxiliarSystemController(ApplicationDbContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuxiliarSystem>>> GetAll()
        {
            return await context.AuxiliarSystem.ToListAsync();
        }

        [HttpGet("{id}", Name = "GetAuxiliarSystem")]
        public async Task<ActionResult<AuxiliarSystem>> Get(int id)
        {
            var auxiliarSystem = await context.AuxiliarSystem.FirstOrDefaultAsync(x => x.ID == id);

            if (auxiliarSystem == null)
            {
                return NotFound("Auxiliar System doesn't exist");
            }
            return Ok(auxiliarSystem);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AuxiliarSystem auxiliarSystem)
        {
            if (ModelState.IsValid)
            {
                await context.AddAsync(auxiliarSystem);
                await context.SaveChangesAsync();
                return new CreatedAtRouteResult("GetAuxiliarSystem", new { id = auxiliarSystem.ID }, auxiliarSystem);
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] AuxiliarSystem auxiliarSystem)
        {
            if (id == auxiliarSystem.ID)
            {
                context.Entry(auxiliarSystem).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return Ok(auxiliarSystem);
            }
            return NotFound("Id doesn't match");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var auxiliarSystem = await context.AuxiliarSystem.FirstOrDefaultAsync(x => x.ID == id);
            if (auxiliarSystem == null)
            {
                return NotFound("Auxiliar System doesn't exists");
            }
            context.AuxiliarSystem.Remove(auxiliarSystem);
            await context.SaveChangesAsync();
            return Ok(auxiliarSystem);
        }
    }
}
