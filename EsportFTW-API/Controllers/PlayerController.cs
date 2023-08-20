using EsportFTW_DAL.DTOs;
using EsportFTW_DAL.Interface;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EsportFTW_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet]
        public ActionResult<Player> Get()
        {
            var players = _playerService.Get();
            return Ok(players);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Player> Get(int id)
        {
            var player = _playerService.Get(id);
            return Ok(player);
        }

        [HttpPost]
        public ActionResult<PlayerRegistrationDto> Post([FromBody] PlayerRegistrationDto player)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (_playerService.IsEmailUnique(player.Email))
            {
                ModelState.AddModelError("Email", "Email is already in use");
                return BadRequest(ModelState);
            }

            if (_playerService.RegisterWithAddress(player))
            {
                return Created("api/player", player);
            }
            return BadRequest();
        }

        [HttpPut]
        public ActionResult<PlayerBaseInfo> Put([FromBody] PlayerBaseInfo player)
        {
            //if (!ModelState.IsValid) return BadRequest(ModelState);

            /*if (_playerService.Update(player))
                return Ok(player);
            return BadRequest();*/
            return Ok();
        }

        [HttpDelete]
        public ActionResult<Player> Delete(int id)
        {
            if (_playerService.Delete(id))
                return Ok();
            return BadRequest();
        }
    }
}
