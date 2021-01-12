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
    public class CategoriaSubCategoriaController : ControllerBase
    {

        // api/v1/CategoriaSubCategorium
        [HttpGet]
        [Route("api/v1/[controller]")]
        public IEnumerable<CategoriaSubCategorium> Get()
        {
            using (var context = new MyWasteDBContext())
            {
                return context.CategoriaSubCategoria.ToList();
            }
        }

        // api/v1/CategoriaSubCategorium/id
        [HttpGet]
        [Route("api/v1/[controller]/{id}&&{idcat}")]
        public IEnumerable<CategoriaSubCategorium> GetOneById(int id, int idcat)
        {
            using (var context = new MyWasteDBContext())
            {
                return context.CategoriaSubCategoria.Where(scat => scat.IdSubCategoria == id && scat.IdCategoria == idcat).ToList();
            }
        }

        // api/v1/CategoriaSubCategorium/
        [HttpPost]
        [Route("api/v1/[controller]")]
        public async Task<ActionResult<SubCategoria>> PostCategoriaSubCategorium(int idcat, int idscat)
        {
            using (var context = new MyWasteDBContext())
            {
                CategoriaSubCategorium csc = new CategoriaSubCategorium();
                csc.IdCategoria = idcat;
                csc.IdSubCategoria = idscat;

                context.CategoriaSubCategoria.Add(csc);
                await context.SaveChangesAsync();

                //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
                return CreatedAtAction(nameof(GetOneById), csc);
            }                
        }

    }
}
