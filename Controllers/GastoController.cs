using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyWasteAPI.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace MyWasteAPI.Controllers
{
    [ApiController]
    public class GastoController : ControllerBase
    {

        // api/v1/Gasto
        [HttpGet]
        [Route("api/v1/[controller]")]
        public IEnumerable<Gasto> Get()
        {
            using (var context = new MyWasteDBContext())
            {
                return context.Gastos.ToList();
            }
        }

        // api/v1/Gasto/id
        [HttpGet]
        [Route("api/v1/[controller]/byId/{id}")]
        public IEnumerable<Gasto> GetOneById(int id)
        {
            using (var context = new MyWasteDBContext())
            {
                return context.Gastos.Where(g => g.IdGasto == id).ToList();
            }
        }

        // api/v1/Gasto/bypasivo/idPasivo
        [HttpGet]
        [Route("api/v1/[controller]/bypasivo/{idPasivo}")]
        public IEnumerable<Gasto> GetOneByEmailandDate(int idPasivo)
        {
            using (var context = new MyWasteDBContext())
            {
                return context.Gastos.Where(g => g.IdPasivo == idPasivo).ToList();
            }
        }

        // api/v1/Gasto/
        [HttpPost]
        [Route("api/v1/[controller]")]
        public async Task<ActionResult<Gasto>> PostEgreso(Gasto gasto)
        {
            using (var context = new MyWasteDBContext())
            {
                context.Gastos.Add(gasto);
                await context.SaveChangesAsync();

                //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
                return CreatedAtAction(nameof(GetOneById), new { id = gasto.IdGasto }, gasto);
            }                
        }   

        // api/v1/Egreso/
        [HttpPost]
        [Route("api/v1/[controller]/edit/")]
        public ActionResult<Gasto> PutEgreso(Gasto gasto)
        {
            using (var context = new MyWasteDBContext())
            {
                var original = context.Gastos.Find(gasto.IdGasto);

                if (original != null)
                {
                    context.Entry(original).CurrentValues.SetValues(gasto);
                    context.SaveChanges();
                    return gasto;
                }
                else
                {
                    return NotFound();
                }                
            }
        }

    }
}
