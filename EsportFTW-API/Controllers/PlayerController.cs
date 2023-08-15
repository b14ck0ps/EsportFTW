using EsportFTW_DAL.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EsportFTW_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _palPlayerService;

        public PlayerController(IPlayerService playerService)
        {
            _palPlayerService = playerService;
        }

        [HttpGet]
        public ActionResult<Player> Get()
        {
            var players = _palPlayerService.Get();
            return Ok(players);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Player> Get(int id)
        {
            var player = _palPlayerService.Get(id);
            return Ok(player);
        }

        [HttpPost]
        public ActionResult<PlayerBaseInfo> Post([FromBody] PlayerBaseInfo player)
        {
            //if (!ModelState.IsValid) return BadRequest(ModelState);

            if (_palPlayerService.Add(player))
            {
                return Created("api/player", player);
            }
            return BadRequest();
        }
    }
}
