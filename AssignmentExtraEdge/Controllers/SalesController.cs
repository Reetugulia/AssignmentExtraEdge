using AssignmentExtraEdge.Model;
using AssignmentExtraEdge.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentExtraEdge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SalesController : ControllerBase
    {
        private readonly ISalesServices _salesService;

        public SalesController(ISalesServices salesService)
        {
            _salesService = salesService;
        }

        // GET: api/Sales
        [HttpGet]
        [Route("getsales")]
        public IActionResult GetSales()
        {
            var sales = _salesService.GetSales();
            return Ok(sales);
        }

        // GET: api/Sales/5
        [HttpGet]
        [Route("getsales/{id}")]
        public ActionResult<Sales> GetSale(int id)
        {
            var sale = _salesService.GetSaleById(id);

            if (sale == null)
            {
                return NotFound();
            }

            return Ok(sale);
        }

        // POST: api/Sales
        [HttpPost]
        [Route("addsales")]
        public IActionResult AddSale(Sales sale)
        {
            var result = _salesService.AddSale(sale);

            if (result > 0)
            {
                return CreatedAtAction("GetSale", new { id = sale.Id }, sale);
            }

            return BadRequest("Failed to add sale.");
        }

        // PUT: api/Sales/5
        [HttpPut]
        [Route("updatesales/{id}")]
        public IActionResult UpdateSale(int id, Sales sale)
        {
            if (id != sale.Id)
            {
                return BadRequest("Sale ID mismatch.");
            }

            var result = _salesService.UpdateSale(sale);

            if (result > 0)
            {
                return NoContent();
            }

            return BadRequest("Failed to update sale.");
        }

        
        [HttpDelete]
        [Route("deletesales/{id}")]
        public IActionResult DeleteSale(int id)
        {
            var result = _salesService.DeleteSale(id);

            if (result > 0)
            {
                return NoContent();
            }

            return NotFound("Sale not found.");
        }
        [HttpPost]
        [Route("insertbulksales")]
        public IActionResult BulkInsertSales([FromBody] List<Sales> sales)
        {
            var result = _salesService.BulkInsertSales(sales);
            return Ok(new { AffectedRows = result });
        }

      
        [HttpPut]
        [Route("updatebulksales")]
        public IActionResult BulkUpdateSales([FromBody] List<Sales> sales)
        {
            var result = _salesService.BulkUpdateSales(sales);
            return Ok(new { AffectedRows = result });
        }

     
        [HttpDelete]
        [Route("deletebulksales")]
        public IActionResult BulkDeleteSales([FromBody] List<int> saleIds)
        {
            var result = _salesService.BulkDeleteSales(saleIds);
            return Ok(new { AffectedRows = result });
        }

    }
}
