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
    public class EgresoController : ControllerBase
    {

        // api/v1/Egreso
        [HttpGet]
        [Route("api/v1/[controller]")]
        public IEnumerable<Egreso> Get()
        {
            using (var context = new MyWasteDBContext())
            {
                return context.Egresos.ToList();
            }
        }

        // api/v1/Egreso/id
        [HttpGet]
        [Route("api/v1/[controller]/byId/{id}")]
        public IEnumerable<Egreso> GetOneById(int id)
        {
            using (var context = new MyWasteDBContext())
            {
                return context.Egresos.Where(e => e.IdEgreso == id).ToList();
            }
        }

        // api/v1/Egreso/email
        [HttpGet]
        [Route("api/v1/[controller]/byEmail/{email}")]
        public IEnumerable<Egreso> GetOneByEmail(string email)
        {
            using (var context = new MyWasteDBContext())
            {
                return context.Egresos.Where(e => e.Email == email).ToList();
            }
        }

        // api/v1/Egreso/email & date
        [HttpGet]
        [Route("api/v1/[controller]/byEmail/date/{email}&{mes}&{year}")]
        public IEnumerable<Egreso> GetOneByEmailandDate(string email,string mes,string year)
        {
            using (var context = new MyWasteDBContext())
            {
                return context.Egresos.Where(e => 
                    e.Email == email 
                    && e.Mes.Equals(mes)
                    && e.Year.Equals(year)).ToList();
            }
        }

        // api/v1/Egreso/
        [HttpPost]
        [Route("api/v1/[controller]")]
        public async Task<ActionResult<Egreso>> PostEgreso(Egreso egreso)
        {
            using (var context = new MyWasteDBContext())
            {
                context.Egresos.Add(egreso);
                await context.SaveChangesAsync();

                //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
                return CreatedAtAction(nameof(GetOneById), new { id = egreso.IdEgreso }, egreso);
            }                
        }   

        // api/v1/Egreso/
        [HttpPost]
        [Route("api/v1/[controller]/edit/")]
        public ActionResult<Egreso> PutEgreso(Egreso egreso)
        {
            using (var context = new MyWasteDBContext())
            {
                var original = context.Egresos.Find(egreso.IdEgreso);

                if (original != null)
                {
                    context.Entry(original).CurrentValues.SetValues(egreso);
                    context.SaveChanges();
                    return egreso;
                }
                else
                {
                    return NotFound();
                }                
            }
        }

    }
}
