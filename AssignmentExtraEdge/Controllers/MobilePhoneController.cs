using AssignmentExtraEdge.Model;
using AssignmentExtraEdge.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace AssignmentExtraEdge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MobilePhoneController : ControllerBase
    {
        private readonly IMobilePhoneServices _mobileService;

        public MobilePhoneController(IMobilePhoneServices mobileService)
        {
            _mobileService = mobileService;
        }

        // GET: api/Mobiles
        [HttpGet]
        [Route("Getmobiles")]
        public IActionResult  GetMobiles()
        {
            var mobiles = _mobileService.GetMobiles();
            return Ok(mobiles);
        }

        // GET: api/Mobiles/5
        [HttpGet]
        [Route("GetMobilebyId/{Id}")]
        public IActionResult  GetMobilebyId(int id)
        {
            var mobile = _mobileService.GetMobileById(id);

            if (mobile == null)
            {
                return NotFound();
            }

            return Ok(mobile);
        }

        // POST: api/Mobiles
        [HttpPost]
        [Route("addmobile")]
        public IActionResult AddMobile(MobilePhones mobile)
        {
            var result = _mobileService.AddMobile(mobile);

              return new ObjectResult(result);
        }

        // PUT: api/Mobiles/5
        [HttpPut]
        [Route("updatemobile/{id}")]
        public IActionResult UpdateMobile(int id, MobilePhones  mobile)
        {
            if (id != mobile.Id)
            {
                return BadRequest("Mobile ID mismatch.");   
            }

            var result = _mobileService.UpdateMobile(mobile);

            if (result > 0)
            {
                return NoContent();
            }

            return BadRequest("Failed to update mobile.");
        }

        // DELETE: api/Mobiles/5
        [HttpDelete]
        [Route("deletemobile/{id}")]
        public IActionResult DeleteMobile(int id)
        {
            var result = _mobileService.DeleteMobile(id);

            if (result > 0)
            {
                return NoContent();
            }

            return NotFound("Mobile not found.");
        }
        [HttpPost]
        [Route("insertbulk")]
        public IActionResult BulkInsertMobiles([FromBody] List<MobilePhones> mobiles)
        {
            var result = _mobileService.BulkInsertMobiles(mobiles);
            return Ok(new { AffectedRows = result });
        }

        // PUT api/mobilephones/updatebulk
        [HttpPut]
        [Route("updatebulk")]
        public IActionResult BulkUpdateMobiles([FromBody] List<MobilePhones> mobiles)
        {
            var result = _mobileService.BulkUpdateMobiles(mobiles);
            return Ok(new { AffectedRows = result });
        }

        // DELETE api/mobilephones/deletebulk
        [HttpDelete]
        [Route("deletebulk")]
        public IActionResult BulkDeleteMobiles([FromBody] List<int> mobileIds)
        {
            var result = _mobileService.BulkDeleteMobiles(mobileIds);
            return Ok(new { AffectedRows = result });
        }
    }
}
