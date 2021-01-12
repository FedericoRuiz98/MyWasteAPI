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
    public class FormaDePagoController : ControllerBase
    {

        // api/v1/FormaDePago
        [HttpGet]
        [Route("api/v1/[controller]")]
        public IEnumerable<FormasDePago> Get()
        {
            using (var context = new MyWasteDBContext())
            {
                return context.FormasDePagos.ToList();
            }
        }

        // api/v1/FormaDePago/id
        [HttpGet]
        [Route("api/v1/[controller]/{id}")]
        public IEnumerable<FormasDePago> GetOneById(int id)
        {
            using (var context = new MyWasteDBContext())
            {
                return context.FormasDePagos.Where(f => f.IdFormaDePago == id).ToList();
            }
        }

        // api/v1/FormaDePago/
        [HttpPost]
        [Route("api/v1/[controller]")]
        public async Task<ActionResult<FormasDePago>> PostCategoria(FormasDePago formaDePago)
        {
            using (var context = new MyWasteDBContext())
            {
                context.FormasDePagos.Add(formaDePago);
                await context.SaveChangesAsync();

                //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
                return CreatedAtAction(nameof(GetOneById), new { id = formaDePago.IdFormaDePago }, formaDePago);
            }                
        }

    }
}
