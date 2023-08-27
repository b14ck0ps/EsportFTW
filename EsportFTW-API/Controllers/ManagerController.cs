using EsportFTW_DAL.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace EsportFTW_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly IManagerService _managerService;

        public ManagerController(IManagerService managerService)
        {
            _managerService = managerService;
        }


        [HttpGet]
        public ActionResult<ManagerBase> Get()
        {
            var managers = _managerService.Get();
            return Ok(managers);
        }

        [HttpPost]
        public ActionResult<ManagerBase> Post([FromBody] ManagerBase manager)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _managerService.Add(manager);
            return Created("api/manager", manager);
        }
    }
}
