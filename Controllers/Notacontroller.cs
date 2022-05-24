using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetAPI.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetAPI.Controllers
{
    [ApiController]
    [Route("api/autores")]
    public class Notacontroller: ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public Notacontroller(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<List<Nota>>> Get()
        {
            return await context.Notas.ToListAsync();
        }


        [HttpPost]
        public async Task<ActionResult> Post(Nota nota)
        {
            context.Add(nota);
            await context.SaveChangesAsync();
            return Ok();
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Nota nota, int id)
        {
            if (nota.Id != id)
            {
                return BadRequest("El id no coincide con el que deseas actualizar");
            }
            var existe = await context.Notas.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound();

            }

            context.Update(nota);
            await context.SaveChangesAsync();
            return Ok();
        }



        [HttpGet("busqueda")]
        public async Task<ActionResult<List<Nota>>> BusquedaGeneral(string termino)
        {
            return await context.Notas.Where(notes=> notes.Titulo.Contains(termino) || notes.Cuerpo.Contains(termino)).ToListAsync();
        }
    }
}
