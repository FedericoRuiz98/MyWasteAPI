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
    public class CategoriaController : ControllerBase
    {

        // api/v1/Categoria
        [HttpGet]
        [Route("api/v1/[controller]")]
        public IEnumerable<Categoria> Get()
        {
            using (var context = new MyWasteDBContext())
            {
                return context.Categorias.ToList();
            }
        }

        // api/v1/Categoria/id
        [HttpGet]
        [Route("api/v1/[controller]/{id}")]
        public IEnumerable<Categoria> GetOneById(int id)
        {
            using (var context = new MyWasteDBContext())
            {
                return context.Categorias.Where(cat => cat.IdCategoria == id).ToList();
            }
        }

        // api/v1/Categoria/
        [HttpPost]
        [Route("api/v1/[controller]")]
        public async Task<ActionResult<Categoria>> PostCategoria(Categoria categoria)
        {
            using (var context = new MyWasteDBContext())
            {
                context.Categorias.Add(categoria);
                await context.SaveChangesAsync();

                //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
                return CreatedAtAction(nameof(GetOneById), new { id = categoria.IdCategoria }, categoria);
            }                
        }

    }
}
