using Microsoft.AspNetCore.Mvc;

namespace EsportFTW_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        public ActionResult<Admin> Get()
        {
            var admins = _adminService.Get();
            return Ok(admins);
        }

        [HttpPost]
        public ActionResult<Admin> Post([FromBody] Admin admin)
        {
            /* if (!ModelState.IsValid)
             {
                 return BadRequest(ModelState);
             }*/
            _adminService.Add(admin);
            return Created("api/admin", admin);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Admin> Get(int id)
        {
            var admin = _adminService.Get(id);
            return Ok(admin);
        }

        [HttpPut]
        public ActionResult<Admin> Put([FromBody] Admin admin)
        {
            /*if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }*/
            _adminService.Update(admin);
            return Ok(admin);
        }

        [HttpDelete]
        public ActionResult<Admin> Delete(int id)
        {
            _adminService.Get(id);
            _adminService.Delete(id);
            return Ok();
        }
    }
}
