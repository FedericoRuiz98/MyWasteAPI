﻿using Microsoft.AspNetCore.Mvc;
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
    public class PasivoController : ControllerBase
    {

        // api/v1/Pasivo
        [HttpGet]
        [Route("api/v1/[controller]")]
        public IEnumerable<Pasivo> Get()
        {
            using (var context = new MyWasteDBContext())
            {
                return context.Pasivos.ToList();
            }
        }

        // api/v1/Pasivo/id
        [HttpGet]
        [Route("api/v1/[controller]/{id}")]
        public IEnumerable<Pasivo> GetOneById(int id)
        {
            using (var context = new MyWasteDBContext())
            {
                return context.Pasivos.Where(p => p.IdPasivo == id).ToList();
            }
        }

        // api/v1/Pasivo/byEgreso/id
        [HttpGet]
        [Route("api/v1/[controller]/byEgreso/{idEgreso}")]
        public IEnumerable<Pasivo> GetPasivosByEgreso(int idEgreso)
        {
            using (var context = new MyWasteDBContext())
            {
                return context.Pasivos.Where(p => p.IdEgreso == idEgreso).ToList();
            }

        }

        // api/v1/Pasivo/
        [HttpPost]
        [Route("api/v1/[controller]")]
        public async Task<ActionResult<Pasivo>> PostPasivo(Pasivo pasivo)
        {
            using (var context = new MyWasteDBContext())
            {
                context.Pasivos.Add(pasivo);
                await context.SaveChangesAsync();

                //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
                return CreatedAtAction(nameof(GetOneById), new { id = pasivo.IdPasivo }, pasivo);
            }                
        }

        // api/v1/Pasivo/edit
        [HttpPost]
        [Route("api/v1/[controller]/edit/")]
        public ActionResult<Pasivo> PutEgreso(Pasivo pasivo)
        {
            using (var context = new MyWasteDBContext())
            {
                var original = context.Pasivos.Find(pasivo.IdPasivo);

                if (original != null)
                {
                    context.Entry(original).CurrentValues.SetValues(pasivo);
                    context.SaveChanges();
                    return pasivo;
                }
                else
                {
                    return NotFound();
                }
            }
        }

    }
}
