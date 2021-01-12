using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyWasteAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWasteAPI.Controllers
{
    [ApiController]
    public class PersonaController : ControllerBase
    {

        // api/v1/Persona
        [HttpGet]
        [Route("api/v1/[controller]")]
        public IEnumerable<Persona> Get()
        {
            using (var context = new MyWasteDBContext())
            {
                return context.Personas.ToList();
            }
        }

        // api/v1/Persona/id
        [HttpGet]
        [Route("api/v1/[controller]/{id}")]
        public IEnumerable<Persona> GetOneById(int id)
        {
            using (var context = new MyWasteDBContext())
            {
                return context.Personas.Where(p => p.IdPresona == id).ToList();
            }
        }

        // api/v1/Persona/
        [HttpPost]
        [Route("api/v1/[controller]")]
        public async Task<ActionResult<Usuario>> PostPersona(Persona persona)
        {
            using (var context = new MyWasteDBContext())
            {
                context.Personas.Add(persona);
                await context.SaveChangesAsync();

                //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
                return CreatedAtAction(nameof(GetOneById), new { id = persona.IdPresona }, persona);
            }                
        }

    }
}
