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
    public class UsuarioController : ControllerBase
    {

        // api/v1/Usuario
        [HttpGet]
        [Route("api/v1/[controller]")]
        public IEnumerable<Usuario> Get()
        {
            using (var context = new MyWasteDBContext())
            {
                return context.Usuarios.ToList();
            }
        }

        // api/v1/Usuario/id
        [HttpGet]
        [Route("api/v1/[controller]/{email}")]
        public IEnumerable<Usuario> GetOneById(string email)
        {
            using (var context = new MyWasteDBContext())
            {
                return context.Usuarios.Where(user => user.Email == email).ToList();
            }
        }

        // api/v1/Usuario/id
        [HttpPost]
        [Route("api/v1/[controller]/login")]
        public IEnumerable<Usuario> login(string email)
        {
            using (var context = new MyWasteDBContext())
            {
                return context.Usuarios.Where(user => user.Email == email).ToList();
            }
        }

        // api/v1/Usuario/
        [HttpPost]
        [Route("api/v1/[controller]")]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            using (var context = new MyWasteDBContext())
            {
                context.Usuarios.Add(usuario);
                await context.SaveChangesAsync();

                //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
                return CreatedAtAction(nameof(GetOneById), new { email = usuario.Email }, usuario);
            }                
        }

    }
}
