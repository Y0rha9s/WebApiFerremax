using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiFerremax.DTOs;
using WebApiFerremax.Entities;

namespace WebApiFerremax.Controllers
{
    [ApiController]
    [Route("api/herramientas")]
    public class HerramientasController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public HerramientasController(ApplicationDbContext context, IMapper mapper) 
        { 
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<HerramientaDTO>>> Get()
        {

            var herramienta = await context.DbHerramienta.ToListAsync();
            return mapper.Map<List<HerramientaDTO>>(herramienta);
        }

        [HttpPost]
        public async Task<ActionResult> Post(HerramientaCreacionDTO herramientaCreacionDTO)
        {
            var existeHerramientaMismoMarca = await context.DbHerramienta.AnyAsync(x => x.Nombre == herramientaCreacionDTO.Nombre);

            if(existeHerramientaMismoMarca) 
            {
                return BadRequest($"Ya existe una marca con el nombre {herramientaCreacionDTO.Nombre}");
            }

            var herramientaMap = mapper.Map<Herramienta>(herramientaCreacionDTO);

            context.Add(herramientaMap);
            await context.SaveChangesAsync();
            return Ok();

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult>Put(Herramienta herramienta, int id)
        {
            if (herramienta.Id != id)
            {
                return BadRequest("El id de la herramienta no coincide con el id la url");
            }

            var existe = await context.DbHerramienta.AnyAsync(herramientaDB => herramientaDB.Id == id);

            if (!existe)
            {
                return NotFound();
            }

            context.Update(herramienta);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.DbHerramienta.AnyAsync(x => x.Id == id);

            if (!existe) 
            { 
                return NotFound();
            }

            context.Remove(new Herramienta() { Id = id});
            await context.SaveChangesAsync();
            return Ok();

        }

    }
}
