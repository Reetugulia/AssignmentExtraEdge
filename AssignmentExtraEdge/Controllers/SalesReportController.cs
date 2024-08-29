using AssignmentExtraEdge.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentExtraEdge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SalesReportController : ControllerBase
    {
        private readonly ISalesReportService _salesReportService;

        public SalesReportController(ISalesReportService _salesReportService)
        {
            this._salesReportService = _salesReportService;
        }
        [HttpGet]
        [Route("salesreport")]
        public IActionResult GetSalesReport([FromQuery] DateTime previous, [FromQuery] DateTime current)
        {
                var sales = _salesReportService.GetSalesReport(previous, current);
                return Ok(sales);
           
        }

        
        [HttpGet]
        [Route("getbrandsales")]
        public IActionResult GetBrandSalesReport([FromQuery] DateTime previous, [FromQuery] DateTime current)
        {
            

                var salesByBrand = _salesReportService.GetBrandSalesReport(previous, current);
                return Ok(salesByBrand);
            
        }

        [HttpGet("profit-loss-report")]
        public IActionResult GetProfitLossReport([FromQuery] DateTime previous, [FromQuery] DateTime current)
        {
          

                var profitLoss = _salesReportService.GetProfitLossReport(previous, current);
                return Ok(new { ProfitLoss = profitLoss });
            
           
        }
    }
}
