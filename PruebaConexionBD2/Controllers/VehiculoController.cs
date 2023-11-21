using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaConexionBD2.Entityes;

namespace PruebaConexionBD2.Controllers
{
    [ApiController]
    [Route("Api/vehiculo")]
    public class VehiculoController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public VehiculoController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Vehiculo vehiculo)
        {
            _dbContext.Add(vehiculo);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vehiculo>>> get()
        {
            return await _dbContext.Vehiculos.ToListAsync();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Vehiculo vehiculo)
        {
            if (id != vehiculo.Id)
            {
                return BadRequest();
            }
            _dbContext.Entry(vehiculo).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return Ok(vehiculo);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _dbContext.Vehiculos.Where(d => d.Id == id).ExecuteDeleteAsync();

            if(result == 0)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
