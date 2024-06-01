using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiFerremax.DTOs;
using WebApiFerremax.Entities;

namespace WebApiFerremax.Controllers
{
    [ApiController]
    [Route("api/herramienta/{herramientaId:int}")]
    public class HerramientasManualesController : ControllerBase
    {
        
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public HerramientasManualesController(ApplicationDbContext context , IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("{id:int}")]
        
        public async Task<ActionResult<HerramientaManualDTO>> Get(int id)
        {
            var herramientaManual =  await context.DbHerramientaManual.FirstOrDefaultAsync(x => x.Id == id);
            return mapper.Map<HerramientaManualDTO>(herramientaManual);
        }
        

        [HttpPost]
        public async Task<ActionResult> Post(HerramientaManualCreacionDTO herramientaManualDTO)
        {
            /*
            var existeHerramienta = await context.DbHerramienta.AnyAsync(x => x.Id == herramientaManual.HerramientaId);

            if (!existeHerramienta)
            {
                return BadRequest($"No existe el autor de Id:{herramientaManual.HerramientaId}");
            }
            */

            var herramientaManual = mapper.Map<HerramientaManual>(herramientaManualDTO);

            context.Add(herramientaManual);
            await context.SaveChangesAsync();
            return Ok();
        }
        
        
    }
}
