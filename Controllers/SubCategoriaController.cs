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
    public class SubCategoriaController : ControllerBase
    {

        // api/v1/SubCategoria
        [HttpGet]
        [Route("api/v1/[controller]")]
        public IEnumerable<SubCategoria> Get()
        {
            using (var context = new MyWasteDBContext())
            {
                return context.SubCategorias.ToList();
            }
        }

        // api/v1/SubCategoria/id
        [HttpGet]
        [Route("api/v1/[controller]/{id}")]
        public IEnumerable<SubCategoria> GetOneById(int id)
        {
            using (var context = new MyWasteDBContext())
            {
                return context.SubCategorias.Where(scat => scat.IdSubCategoria == id).ToList();
            }
        }

        // api/v1/SubCategoria/
        [HttpPost]
        [Route("api/v1/[controller]")]
        public async Task<ActionResult<SubCategoria>> PostSubCategoria(SubCategoria subCategoria)
        {
            using (var context = new MyWasteDBContext())
            {
                context.SubCategorias.Add(subCategoria);
                await context.SaveChangesAsync();

                //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
                return CreatedAtAction(nameof(GetOneById), new { id = subCategoria.IdSubCategoria }, subCategoria);
            }                
        }

    }
}
