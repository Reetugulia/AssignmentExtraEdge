using AssignmentExtraEdge.Model;
using AssignmentExtraEdge.Repository;
using AssignmentExtraEdge.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentExtraEdge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService service;
        public BrandController(IBrandService service) {
          this.service = service;
        }
        [HttpGet]
        [Route("Getbrands")]
        public IActionResult GetBrand()
        {
            var mobiles = service.GetBrand();
            return Ok(mobiles);
        }

        // GET: api/Mobiles/5
        [HttpGet]
        [Route("GetbrandbyId/{Id}")]
        public IActionResult GetBrandbyId(int id)
        {
            var mobile = service.GetBrandById(id);

            if (mobile == null)
            {
                return NotFound();
            }

            return Ok(mobile);
        }

        // POST: api/Mobiles
        [HttpPost]
        [Route("addbrand")]
        public IActionResult AddBrand(Brand brand)
        {
            var result = service.AddBrand(brand);

            if (result > 0)
            {
                return CreatedAtAction("GetBrand", new { id = brand.Id }, brand);
            }

            return BadRequest("Failed to add Brand.");
        }

        // PUT: api/Mobiles/5
        [HttpPut]
        [Route("updatebrand/{id}")]
        public IActionResult UpdateBrand(int id, Brand brand)
        {
            if (id != brand.Id)
            {
                return BadRequest("Mobile ID mismatch.");
            }

            var result = service.UpdateBrand(brand);

            if (result > 0)
            {
                return NoContent();
            }

            return BadRequest("Failed to update mobile.");
        }

        // DELETE: api/Mobiles/5
        [HttpDelete]
        [Route("deletebrand/{id}")]
        public IActionResult DeleteBrand(int id)
        {
            var result = service.DeleteBrand(id);

            if (result > 0)
            {
                return NoContent();
            }

            return NotFound("Mobile not found.");
        }
        [HttpPost]
        [Route("insertbulkbrand")]
        public IActionResult BulkInsertBrands([FromBody] List<Brand> brands)
        {
            service.BulkInsertBrands(brands);
            return Ok();
        }

        // PUT api/brands/bulk
        [HttpPut]
        [Route("updatebulkbrand")]
        public IActionResult BulkUpdateBrands([FromBody] List<Brand> brands)
        {
            service.BulkUpdateBrands(brands);
            return Ok();
        }

        // DELETE api/brands/bulk
        [HttpDelete]
        [Route("deletebulkbrand")]
        public IActionResult BulkDeleteBrands([FromBody] List<int> brandIds)
        {
           service.BulkDeleteBrands(brandIds);
            return Ok();
        }
    }
}
