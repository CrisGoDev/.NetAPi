using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetAPI.Dtos;
using NetAPI.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetAPI.Controllers
{
    [EnableCors("MyCors")]
    [ApiController]
    [Route("api/nota")]
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

        [HttpGet("last")]
        public async Task<ActionResult<List<Nota>>> GetLast()
        {
            if (context.Notas.ToList().Count < 1)
            {
                return Ok();
            }
            return await context.Notas.OrderByDescending(nota=>nota.Id).Take(3).ToListAsync();
        }


        [HttpPost]
        public async Task<ActionResult> Post(NotaDto notadt)
        {
            var nota = mapper.Map<Nota>(notadt);

            nota.Fecha = DateTime.UtcNow;
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
