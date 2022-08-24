using BetterPOCAPI.Data;
using BetterPOCAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BetterPOCAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DrugstoreController : Controller
    {
        private readonly DrugstoreDBContext drugstoreDBContext;

        public DrugstoreController(DrugstoreDBContext drugstoreDBContext)
        {
            this.drugstoreDBContext = drugstoreDBContext;
        }

        //Get all products (drugstores)
        [HttpGet]
        public async Task<IActionResult> GetAllDrugstores()
        {
            var drugstores = await drugstoreDBContext.Drugstores.ToListAsync();
            return Ok(drugstores);
        }

        [HttpGet]
        [Route("{id:int}")]
        [ActionName("GetDrugstore")]
        public async Task<IActionResult> GetDrugstore([FromRoute] int id)
        {
            var drugstore = await drugstoreDBContext.Drugstores.FirstOrDefaultAsync(x => x.Id == id);
            if (drugstore != null)
            {
                return Ok(drugstore);
            }

            return NotFound("Drug not found");
        }


        [HttpPost]
        public async Task<IActionResult> AddDrugstores([FromBody] Drugstore drugstore)
        {
            drugstore.Id = new int();

            await drugstoreDBContext.Drugstores.AddAsync(drugstore);
            await drugstoreDBContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDrugstore),new { id = drugstore.Id }, drugstore);
        }


        [HttpPatch]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateDrugstores([FromRoute] int id, [FromBody] Drugstore drugstore)
        {
            var existingDrugstore = await drugstoreDBContext.Drugstores.FirstOrDefaultAsync(x => x.Id == id);
            if (existingDrugstore != null)
            {
                existingDrugstore.Name = drugstore.Name;
                existingDrugstore.Description = drugstore.Description;
                existingDrugstore.Price = drugstore.Price;
                existingDrugstore.StockQuantity = drugstore.StockQuantity;
                await drugstoreDBContext.SaveChangesAsync();
                return Ok(existingDrugstore);
            }
            return NotFound("Drug not found!");
        }

        [HttpDelete]
        [Route("{id:int}")]

        public async Task<IActionResult> DeleteDrugstores([FromRoute] int id)
        {
            var existingDrugstore = await drugstoreDBContext.Drugstores.FirstOrDefaultAsync(x => x.Id == id);
            if (existingDrugstore != null)
            {
                drugstoreDBContext.Remove(existingDrugstore);
                await drugstoreDBContext.SaveChangesAsync();
                return Ok(existingDrugstore);
            }
            return NotFound("Drug not found!");
        }

    }
}
